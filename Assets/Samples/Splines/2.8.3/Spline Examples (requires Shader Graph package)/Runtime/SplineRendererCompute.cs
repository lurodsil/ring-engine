using System;
using UnityEngine;
using UnityEngine.Splines;

namespace Unity.Splines.Examples
{
    /// <summary>
    /// A simple example showing how to pass Spline data to the GPU using SplineComputeBufferScope.
    /// </summary>
    [RequireComponent(typeof(LineRenderer), typeof(SplineContainer))]
    public class SplineRendererCompute : MonoBehaviour
    {
        // Use with Shader/InterpolateSpline.compute
        [SerializeField]
        ComputeShader m_ComputeShader;

        [SerializeField, Range(16, 512)]
        int m_Segments = 128;

        Spline m_Spline;
        LineRenderer m_Line;
        bool m_Dirty;

        SplineComputeBufferScope<Spline> m_SplineBuffers;
        Vector3[] m_Positions;
        ComputeBuffer m_PositionsBuffer;
        int m_GetPositionsKernel;

        void Awake()
        {
            m_Spline = GetComponent<SplineContainer>().Spline;

            // Set up the LineRenderer
            m_Line = GetComponent<LineRenderer>();
            m_Line.positionCount = m_Segments;

            m_GetPositionsKernel = m_ComputeShader.FindKernel("GetPositions");

            // Set up the spline evaluation compute shader. We'll use SplineComputeBufferScope to simplify the process.
            // Note that SplineComputeBufferScope is optional, you can manage the Curve, Lengths, and Info properties
            // yourself if preferred.
            m_SplineBuffers = new SplineComputeBufferScope<Spline>(m_Spline);
            m_SplineBuffers.Bind(m_ComputeShader, m_GetPositionsKernel, "info", "curves", "curveLengths");

            // Set the compute shader properties necessary for accessing spline information. Most Spline functions in
            // Spline.cginc require the info, curves, and curve length properties. This is equivalent to:
            //     m_ComputeShader.SetVector("info", m_SplineBuffers.Info);
            //     m_ComputeShader.SetBuffer(m_GetPositionsKernel, "curves", m_SplineBuffers.Curves);
            //     m_ComputeShader.SetBuffer(m_GetPositionsKernel, "curveLengths", m_SplineBuffers.CurveLengths);
            m_SplineBuffers.Upload();

            // m_Positions will be used to read back evaluated positions from the GPU
            m_Positions = new Vector3[m_Segments];

            // Set up our input and readback buffers. In this example we'll evaluate a set of positions along the spline
            m_PositionsBuffer = new ComputeBuffer(m_Segments, sizeof(float) * 3);
            m_PositionsBuffer.SetData(m_Positions);
            m_ComputeShader.SetBuffer(m_GetPositionsKernel, "positions", m_PositionsBuffer);
            m_ComputeShader.SetFloat("positionsCount", m_Segments);

            m_Dirty = true;
        }

        void OnEnable()
        {
            Spline.Changed += OnSplineChanged;
        }

        void OnDisable()
        {
            Spline.Changed -= OnSplineChanged;
        }

        void OnSplineChanged(Spline spline, int knotIndex, SplineModification modificationType)
        {
            if (m_Spline == spline)
                m_Dirty = true;
        }

        void OnDestroy()
        {
            m_PositionsBuffer?.Dispose();
            m_SplineBuffers.Dispose();
        }

        void Update()
        {
            if (!m_Dirty)
                return;

            // Once initialized, call SplineComputeBufferScope.Upload() to update the GPU copies of spline data. This
            // is only necessary here because we're constantly updating the Spline in this example. If the Spline is
            // static, there is no need to call Upload every frame.
            m_SplineBuffers.Upload();

            m_ComputeShader.GetKernelThreadGroupSizes(m_GetPositionsKernel, out var threadSize, out _, out _);
            m_ComputeShader.Dispatch(m_GetPositionsKernel, (int)threadSize, 1, 1);
            m_PositionsBuffer.GetData(m_Positions);

            m_Line.loop = m_Spline.Closed;
            m_Line.SetPositions(m_Positions);
        }
    }
}
