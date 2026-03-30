using System;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Splines;

namespace Unity.Splines.Examples
{
    // Visualize the nearest point on a spline to a roving sphere.
    [RequireComponent(typeof(LineRenderer))]
    public class ShowNearestPoint : MonoBehaviour
    {
        // Boundary setup for the wandering sphere
        Vector3 m_Center = Vector3.zero;
        float m_Size = 50f;

        // Store a collection of Splines to test for nearest to our position.
        SplineContainer[] m_SplineContainer;

        LineRenderer m_LineRenderer;

        // This GameObject will be used to visualize the nearest point on the nearest spline to this transform.
        [SerializeField]
        Transform m_NearestPoint;

        void Start()
        {
            if (!TryGetComponent(out m_LineRenderer))
                Debug.LogError("ShowNearestPoint requires a LineRenderer.");
            m_LineRenderer.positionCount = 2;
#if UNITY_2023_1_OR_NEWER
            m_SplineContainer = FindObjectsByType<SplineContainer>(FindObjectsSortMode.None);
#else
            m_SplineContainer = FindObjectsOfType<SplineContainer>();
#endif
            if (m_NearestPoint == null)
                Debug.LogError("Nearest Point GameObject is null");
        }

        void Update()
        {
            var position = CalculatePosition();
            var nearest = new float4(0, 0, 0, float.PositiveInfinity);

            foreach (var container in m_SplineContainer)
            {
                using var native = new NativeSpline(container.Spline, container.transform.localToWorldMatrix);
                float d = SplineUtility.GetNearestPoint(native, transform.position, out float3 p, out float t);
                if (d < nearest.w)
                    nearest = new float4(p, d);
            }

            m_LineRenderer.SetPosition(0, position);
            m_LineRenderer.SetPosition(1, nearest.xyz);
            m_NearestPoint.position = nearest.xyz;
            transform.position = position;
        }

        Vector3 CalculatePosition()
        {
            float time = Time.time * .2f, time1 = time + 1;
            float half = m_Size * .5f;

            return m_Center + new Vector3(
                Mathf.PerlinNoise(time, time) * m_Size - half,
                0,
                Mathf.PerlinNoise(time1, time1) * m_Size - half
            );
        }

        void OnDrawGizmosSelected()
        {
            Gizmos.DrawWireCube(m_Center, new Vector3(m_Size, .1f, m_Size));
        }
    }
}