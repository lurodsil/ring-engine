using Unity.Mathematics;
using UnityEngine;

namespace UnityEngine.Splines.Extensions
{
    public static class SplineContainerExtensions
    {
        public static void Evaluate<T>(this T splineContainer, float t, out FrenetFrame splineFrame, float binormalTime = 0.5f) where T : ISplineContainer
        {
            int count = 0;
            if (splineContainer != null)
                count = splineContainer.Splines.Count;

            if (count == 0)
                throw new System.Exception("SplineContainer must have at least 1 spline.");

            if (count == 1)
            {
                splineContainer.Splines[0].Evaluate(t, out float3 position, out float3 tangent, out float3 normal);

                splineFrame =  new FrenetFrame(position, tangent, normal, t);    
                return;
            }

            if (count == 2)
            {
                splineContainer.Splines[0].Evaluate(t, out float3 posL, out float3 tanL, out float3 norL);
                splineContainer.Splines[1].Evaluate(t, out float3 posR, out float3 tanR, out float3 norR);

                float3 position = math.lerp(posL, posR, binormalTime);
                float3 tangent = math.normalize(math.lerp(tanL, tanR, binormalTime));
                float3 binormal = math.normalize(posR - posL);

                // Ortogonaliza e normaliza corretamente
                tangent = math.normalize(tangent);
                binormal = math.normalize(binormal - math.dot(binormal, tangent) * tangent); // projeta fora da tangente
                float3 normal = math.cross(tangent, binormal); // garante que seja perpendicular aos outros

                splineFrame = new FrenetFrame(position, tangent, normal, t);


                return;
            }

            throw new System.Exception("Only 1 or 2 splines are supported.");
        }
    }
}