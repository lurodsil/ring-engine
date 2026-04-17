using Unity.Mathematics;
using UnityEngine;

namespace UnityEngine.Splines.Extensions
{
    public struct SplineKnot
    {
        public float3 point { get; private set; }
        public float3 tangent { get; private set; }
        public float3 binormal { get; private set; }
        public float3 normal { get; private set; }

        public float width { get; private set; }

        public Quaternion rotation
        {
            get
            {
                if (math.lengthsq(tangent) < 0.0001f)
                    return Quaternion.identity;

                return Quaternion.LookRotation(tangent, normal);
            }
        }

        public SplineKnot(float3 point, float3 tangent, float3 normal, float width = 1f)
        {
            this.point = point;
            this.width = width;

            this.tangent = math.normalize(tangent);

            // Garante ortonormalidade
            this.binormal = math.normalize(math.cross(this.tangent, normal));
            this.normal = -math.normalize(math.cross(this.binormal, this.tangent));
        }

        public SplineKnot(float3 point, float3 tangent, float3 normal, float3 binormal, float width = 1f)
        {
            this.point = point;
            this.width = width;

            this.tangent = math.normalize(tangent);

            // Garante ortonormalidade
            this.binormal = math.normalize(binormal);
            this.normal = math.normalize(math.cross(this.binormal, this.tangent));
        }

        // 🔥 Agora usa o próprio this
        public SplineKnot LocalToWorld(Transform transform)
        {
            return new SplineKnot(
                transform.TransformPoint(point),
                math.normalize(transform.TransformDirection(tangent)),
                math.normalize(transform.TransformDirection(normal)),
                width
            );
        }

        public SplineKnot WorldToLocal(Transform transform)
        {
            return new SplineKnot(
                transform.InverseTransformPoint(point),
                math.normalize(transform.InverseTransformDirection(tangent)),
                math.normalize(transform.InverseTransformDirection(normal)),
                width
            );
        }

        public SplineKnot Reverse()
        {
            return new SplineKnot(
                point,
                -tangent,
                normal,
                width
            );
        }
    }
}