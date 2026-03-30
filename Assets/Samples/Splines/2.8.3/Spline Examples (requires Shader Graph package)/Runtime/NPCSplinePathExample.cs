using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines;

namespace Unity.Splines.Examples
{
    public class NPCSplinePathExample : MonoBehaviour
    {

        public GameObject npc;
        public SplineContainer container1;
        public SplineContainer container2;
        public Vector3 offsetFromPath;

        SplinePath path;
        float t = 0f;

        void Start()
        {
            var container1Transform = container1.transform.localToWorldMatrix;
            var container2Transform = container2.transform.localToWorldMatrix;
            // Create a SplinePath from a subset of Splines
            path = new SplinePath(new[]
            {
                new SplineSlice<Spline>(container1.Splines[1], new SplineRange(0, 4), container1Transform),
                new SplineSlice<Spline>(container1.Splines[2], new SplineRange(0, 4), container1Transform),
                new SplineSlice<Spline>(container1.Splines[0], new SplineRange(4, -5), container1Transform),
                new SplineSlice<Spline>(container1.Splines[1], new SplineRange(0, 2), container1Transform),
                new SplineSlice<Spline>(container1.Splines[3], new SplineRange(0, 2), container1Transform),
                new SplineSlice<Spline>(container2.Splines[0], new SplineRange(3, -4), container2Transform)
            });
        }

        void Update()
        {
            Vector3 pos = path.EvaluatePosition(t);
            npc.transform.position = pos + offsetFromPath;

            t += 0.05f * Time.deltaTime;
            if (t > 1f) t = 0f;
        }
    }
}
