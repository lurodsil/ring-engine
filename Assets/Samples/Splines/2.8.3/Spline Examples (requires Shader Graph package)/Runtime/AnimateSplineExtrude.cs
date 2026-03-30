using System;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Splines;

namespace samples.Runtime
{
    /// <summary>
    /// Animate extruding a section of a spline.
    /// </summary>
    [RequireComponent(typeof(SplineExtrude))]
    class AnimateSplineExtrude : MonoBehaviour
    {
        SplineExtrude m_Extrude;

        [SerializeField, Range(.0001f, 2f)]
        float m_Speed = .25f;

        float m_Span;

        [SerializeField]
        bool m_RebuildExtrudeOnUpdate = true;

        void Start()
        {
            m_Extrude = GetComponent<SplineExtrude>();
            m_Span = (m_Extrude.Range.y - m_Extrude.Range.x) * .5f;
        }

        void Update()
        {
            bool allClosed = true;
            foreach (var spline in m_Extrude.Splines)
                if (!spline.Closed)
                {
                    allClosed = false;
                    break;
                }

            float t = allClosed
                ? Time.time * m_Speed
                : Mathf.Lerp(-m_Span, 1 + m_Span, math.frac(Time.time * m_Speed));
            m_Extrude.Range = new float2(t - m_Span, t + m_Span);

            if (m_RebuildExtrudeOnUpdate)
                m_Extrude.Rebuild();
        }
    }
}
