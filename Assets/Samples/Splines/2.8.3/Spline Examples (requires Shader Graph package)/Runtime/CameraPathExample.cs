using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines;
using Unity.Mathematics;

namespace Unity.Splines.Examples
{
    public class CameraPathExample : MonoBehaviour
    {
        public SplineContainer container;

        [SerializeField]
        float speed = 0.01f;

        SplinePath cameraTrack;

        void Start()
        {
            cameraTrack = new SplinePath(new[]
            {
                new SplineSlice<Spline>(container.Splines[0], new SplineRange(0, 6),
                    container.transform.localToWorldMatrix),
                new SplineSlice<Spline>(container.Splines[1], new SplineRange(0, 6),
                    container.transform.localToWorldMatrix)
            });
        }

        void Update()
        {
            cameraTrack.Evaluate(math.frac(speed * Time.time), out var pos, out var right, out var up);
            Vector3 forward = Vector3.Cross(right, up);
            transform.position = pos;
            transform.LookAt((Vector3) pos + forward);
        }

    }
}
