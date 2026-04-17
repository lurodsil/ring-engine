using Unity.Mathematics;
using UnityEngine;

namespace UnityEngine.Splines.Extensions
{
    public static class SplineExtensions
    {
        public static void Evaluate<T>(this T spline, float t, out SplineKnot knot) where T : ISpline
        {
            spline.Evaluate(t, out float3 position, out float3 tangent, out float3 normal);

            knot = new SplineKnot(position, tangent, normal);
        }

        public static void Evaluate<T>(this T spline, float t, out SplineKnot knot, Transform reference) where T : ISpline
        {
            spline.Evaluate(t, out float3 position, out float3 tangent, out float3 normal);

            float3 worldPos = reference.TransformPoint(position);
            float3 worldTangent = math.normalize(reference.TransformDirection(tangent));
            float3 worldNormal = math.normalize(reference.TransformDirection(normal));

            knot = new SplineKnot(worldPos, worldTangent, worldNormal);
        }

        public static Spline AddPoint(this Spline spline, float3 position, TangentMode tangentMode, quaternion rotation = new quaternion(), float3 direction = new float3())
        {
            spline.Add(new BezierKnot(position, -direction, direction, rotation));
            spline.SetTangentMode(spline.Count - 1, tangentMode);
            return spline;
        }
    }
}