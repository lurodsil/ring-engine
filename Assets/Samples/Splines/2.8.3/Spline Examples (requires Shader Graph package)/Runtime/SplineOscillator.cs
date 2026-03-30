using System.Linq;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Splines;

namespace Unity.Splines.Examples.Editor
{
    [RequireComponent(typeof(SplineContainer))]
    class SplineOscillator : MonoBehaviour
    {
        Spline m_Spline;
        BezierKnot[] m_Origins;

        [SerializeField, Range(.1f, 10f)]
        float m_Speed = 3f;

        [SerializeField, Range(1f, 10f)]
        float m_Frequency = 3.14f;

        void Start()
        {
            m_Spline = GetComponent<SplineContainer>().Spline;
            m_Origins = m_Spline.Knots.ToArray();
        }

        void Update()
        {
            for (int i = 0, c = m_Spline.Count; i < c; ++i)
            {
                var offset = i / (c - 1f) * m_Frequency;
                m_Spline[i] = m_Origins[i] + math.cos((Time.time + offset) * m_Speed) * new float3(0, 1, 0);
            }
        }
    }
}
