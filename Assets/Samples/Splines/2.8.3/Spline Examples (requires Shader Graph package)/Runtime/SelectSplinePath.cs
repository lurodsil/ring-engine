using System;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Splines;

[DisallowMultipleComponent]
public class SelectSplinePath : MonoBehaviour
{
    SplineContainer m_Container;
    SplinePath<Spline> m_Amalgamate;

    const int k_PreviewCurveResolution = 42;
    LineRenderer m_LineRenderer;
    Vector3[] m_CurvePoints;

    void Start()
    {
        m_Container = GetComponent<SplineContainer>();
        m_Amalgamate = new SplinePath<Spline>(m_Container.Splines);
        m_LineRenderer = GetComponent<LineRenderer>();
        m_LineRenderer.positionCount = k_PreviewCurveResolution;
        m_CurvePoints = new Vector3[k_PreviewCurveResolution];
    }

    void Update()
    {
        using var native = new NativeSpline(m_Amalgamate, m_Container.transform.localToWorldMatrix);
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        float distance = float.PositiveInfinity;
        var nearest = new BezierCurve();

        for (int i = 0; i < native.Count; ++i)
        {
            if(native.GetCurveLength(i) < float.Epsilon)
                continue;

            var curve = native.GetCurve(i);
            var dist = CurveUtility.GetNearestPoint(curve, ray, out var p, out _);
            if (dist < distance)
            {
                nearest = curve;
                distance = dist;
            }
        }

        for (int i = 0, c = m_CurvePoints.Length; i < c; ++i)
            m_CurvePoints[i] = CurveUtility.EvaluatePosition(nearest, i / (c - 1f)) + new float3(0f, .1f, 0f);

        m_LineRenderer.SetPositions(m_CurvePoints);
    }
}
