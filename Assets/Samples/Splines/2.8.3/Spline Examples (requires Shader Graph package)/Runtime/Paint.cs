using System.Collections.Generic;
using System.Linq;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Splines;
using UnityEngine.UIElements;

namespace Unity.Splines.Examples
{
    /// <summary>
    /// This sample demonstrates how to create a spline from a collection of points drawn by the cursor.
    /// </summary>
    public class Paint : MonoBehaviour
    {
        // The minimum amount of cursor movement to be considered a new sample.
        const float StrokeDeltaThreshold = .1f;
        const int LeftMouseButton = 0;

        [SerializeField]
        Mesh m_SampleDot;

        [SerializeField]
        Material m_SampleMat, m_ControlPointMat;

        // Point reduction epsilon determines how aggressive the point reduction algorithm is when removing redundant
        // points. Lower values result in more accurate spline representations of the original line, at the cost of
        // greater number knots.
        [Range(0f, 1f), SerializeField]
        float m_PointReductionEpsilon = .15f;

        // Tension affects how "curvy" splines are at knots. 0 is a sharp corner, 1 is maximum curvitude.
        [Range(0f, 1f), SerializeField]
        float m_SplineTension = 1 / 4f;

        Label m_Stats;
        Camera m_Camera;
        List<float3> m_Stroke = new List<float3>(1024);
        List<float3> m_Reduced = new List<float3>(512);
        bool m_Painting;
        Vector3 m_LastMousePosition;

        void Start()
        {
            m_Camera = Camera.main;

            m_Stats = PaintUI.root.Q<Label>("Stats");
            m_Stats.text = "";

            var epsilonSlider = PaintUI.root.Q<Slider>("PointReductionEpsilonSlider");
            epsilonSlider.RegisterValueChangedCallback(PointReductionEpsilonChanged);
            epsilonSlider.value = m_PointReductionEpsilon;

            var tensionSlider = PaintUI.root.Q<Slider>("SplineTensionSlider");
            tensionSlider.RegisterValueChangedCallback(SplineTensionChanged);
            tensionSlider.value = m_SplineTension;
        }

        void SplineTensionChanged(ChangeEvent<float> evt)
        {
            m_SplineTension = evt.newValue;
            RebuildSpline();
        }

        void PointReductionEpsilonChanged(ChangeEvent<float> evt)
        {
            m_PointReductionEpsilon = evt.newValue;
            RebuildSpline();
        }

        void RebuildSpline()
        {
            // Before setting spline knots, reduce the number of sample points.
            SplineUtility.ReducePoints(m_Stroke, m_Reduced, m_PointReductionEpsilon);

            var spline = GetComponent<SplineContainer>().Spline;

            // Assign the reduced sample positions to the Spline knots collection. Here we are constructing new
            // BezierKnots from a single position, disregarding tangent and rotation. The tangent and rotation will be
            // calculated automatically in the next step wherein the tangent mode is set to "Auto Smooth."
            spline.Knots = m_Reduced.Select(x => new BezierKnot(x));

            var all = new SplineRange(0, spline.Count);

            // Sets the tangent mode for all knots in the spline to "Auto Smooth."
            spline.SetTangentMode(all, TangentMode.AutoSmooth);

            // Sets the tension parameter for all knots. Note that the "Tension" parameter is only applicable to
            // "Auto Smooth" mode knots.
            spline.SetAutoSmoothTension(all, m_SplineTension);

            m_Stats.text = $"Input Sample Count: {m_Stroke.Count}\nSpline Knot Count: {m_Reduced.Count}";
        }

        void AddSample(Vector2 p)
        {
            Vector3 wp = m_LastMousePosition = p;
            wp.z = 10f;
            m_Stroke.Add(m_Camera.ScreenToWorldPoint(wp));
        }

        void Update()
        {
            if (!PaintUI.PointerOverUI && Input.GetMouseButtonDown(LeftMouseButton))
            {
                m_Painting = true;
                m_Stroke.Clear();
                AddSample(Input.mousePosition);
            }

            if (Input.GetMouseButtonUp(LeftMouseButton))
            {
                m_Painting = false;
                RebuildSpline();
            }

            if (m_Painting && Vector2.Distance(Input.mousePosition, m_LastMousePosition) > StrokeDeltaThreshold)
                AddSample(Input.mousePosition);

            foreach (var sample in m_Stroke)
                Graphics.DrawMesh(m_SampleDot, Matrix4x4.TRS(sample, Quaternion.identity, new Vector3(.2f, .2f, .2f)),
                    m_SampleMat, 0);

            foreach (var point in m_Reduced)
                Graphics.DrawMesh(m_SampleDot,
                    Matrix4x4.TRS((Vector3)point + new Vector3(0f, 0f, -1f), Quaternion.identity,
                        new Vector3(.3f, .3f, .3f)), m_ControlPointMat, 0);
        }
    }
}
