using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines;

namespace Unity.Splines.Examples
{
    public class HighwayExample : MonoBehaviour
    {
        public SplineContainer container;

        [SerializeField]
        float speed = 0.1f;

        SplinePath[] paths = new SplinePath[4];
        float t = 0f;

        IEnumerator CarPathCoroutine()
        {
            for(int n = 0; ; ++n)
            {
                t = 0f;
                var path = paths[n % 4];

                while (t <= 1f)
                {
                    var pos = path.EvaluatePosition(t);
                    var direction = path.EvaluateTangent(t);
                    transform.position = pos;
                    transform.LookAt(pos + direction);
                    t += speed * Time.deltaTime;
                    yield return null;
                }
            }
        }

        void Start()
        {
            var localToWorldMatrix = container.transform.localToWorldMatrix;
            paths[0] = new SplinePath(new[]
            {
                new SplineSlice<Spline>(container.Splines[0], new SplineRange(0, 3), localToWorldMatrix),
                new SplineSlice<Spline>(container.Splines[3], new SplineRange(0, 3), localToWorldMatrix),
                new SplineSlice<Spline>(container.Splines[1], new SplineRange(1, 2), localToWorldMatrix),
                new SplineSlice<Spline>(container.Splines[2], new SplineRange(2, 3), localToWorldMatrix),
                new SplineSlice<Spline>(container.Splines[0], new SplineRange(3, 3), localToWorldMatrix)
            });

            paths[1] = new SplinePath(new[]
            {
                new SplineSlice<Spline>(container.Splines[0], new SplineRange(0, 2), localToWorldMatrix),
                new SplineSlice<Spline>(container.Splines[2], new SplineRange(0, 5), localToWorldMatrix),
                new SplineSlice<Spline>(container.Splines[0], new SplineRange(3, 3), localToWorldMatrix)
            });

            paths[2] = new SplinePath(new[]
            {
                new SplineSlice<Spline>(container.Splines[0], new SplineRange(0, 2), localToWorldMatrix),
                new SplineSlice<Spline>(container.Splines[2], new SplineRange(0, 3), localToWorldMatrix),
                new SplineSlice<Spline>(container.Splines[1], new SplineRange(2, -3), localToWorldMatrix),
            });

            paths[3] = new SplinePath(new[]
            {
                new SplineSlice<Spline>(container.Splines[0], new SplineRange(0, 3), localToWorldMatrix),
                new SplineSlice<Spline>(container.Splines[3], new SplineRange(0, 3), localToWorldMatrix),
                new SplineSlice<Spline>(container.Splines[1], new SplineRange(1, 2), localToWorldMatrix),
                new SplineSlice<Spline>(container.Splines[2], new SplineRange(2, -3), localToWorldMatrix),
                new SplineSlice<Spline>(container.Splines[0], new SplineRange(1, -2), localToWorldMatrix),
            });

            StartCoroutine(CarPathCoroutine());
        }
    }
}
