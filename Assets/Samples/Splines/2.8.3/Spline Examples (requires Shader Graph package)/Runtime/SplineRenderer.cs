using System;
using System.Linq;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Splines;

namespace Unity.Splines.Examples
{
    [Serializable]
    public struct SplineLineRendererSettings
    {
        public float width;
        public Material material;
        [Range(16, 512)]
        public int subdivisions;
        public Color startColor, endColor;
    }

    [RequireComponent(typeof(SplineContainer))]
    public class SplineRenderer : MonoBehaviour
    {
        SplineContainer m_SplineContainer;
        Spline[] m_Splines;
        bool m_Dirty;
        Vector3[] m_Points;

        [SerializeField]
        SplineLineRendererSettings m_LineRendererSettings = new SplineLineRendererSettings() {
            width = .5f,
            subdivisions = 64
        };

        LineRenderer[] m_Lines;

        void Awake()
        {
            m_SplineContainer = GetComponent<SplineContainer>();
            m_Splines = m_SplineContainer.Splines.ToArray();
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
            for (int i = 0, c = m_Splines.Length; !m_Dirty && i < c; ++i)
                if (m_Splines[i] == spline)
                    m_Dirty = true;
        }

        void Update()
        {
            if (m_Lines?.Length != m_Splines.Length)
            {
                if (m_Lines != null)
                    foreach (var line in m_Lines) DestroyImmediate(line.gameObject);

                m_Lines = new LineRenderer[m_Splines.Length];

                for (int i = 0, c = m_Splines.Length; i < c; ++i)
                {
                    m_Lines[i] = new GameObject().AddComponent<LineRenderer>();
                    m_Lines[i].gameObject.name = $"SplineRenderer {i}";
                    m_Lines[i].transform.SetParent(transform, true);
                }

                m_Dirty = true;
            }

            // It's nice to be able to see resolution changes at runtime
            if (m_Points?.Length != m_LineRendererSettings.subdivisions)
            {
                m_Dirty = true;
                m_Points = new Vector3[m_LineRendererSettings.subdivisions];
                foreach (var line in m_Lines)
                    line.positionCount = m_LineRendererSettings.subdivisions;
            }

            if (!m_Dirty)
                return;

            m_Dirty = false;
            var trs = m_SplineContainer.transform.localToWorldMatrix;

            for (int s = 0, c = m_Splines.Length; s < c; ++s)
            {
                if (m_Splines[s].Count < 1)
                    continue;

                for (int i = 0; i < m_LineRendererSettings.subdivisions; i++)
                    m_Points[i] = math.transform(trs, m_Splines[s].EvaluatePosition(i / (m_LineRendererSettings.subdivisions - 1f)));

                m_Lines[s].widthCurve = new AnimationCurve(new Keyframe(0f, m_LineRendererSettings.width));
                m_Lines[s].startColor = m_LineRendererSettings.startColor;
                m_Lines[s].endColor = m_LineRendererSettings.endColor;
                m_Lines[s].material = m_LineRendererSettings.material;
                m_Lines[s].useWorldSpace = true;
                m_Lines[s].SetPositions(m_Points);
            }
        }
    }
}
