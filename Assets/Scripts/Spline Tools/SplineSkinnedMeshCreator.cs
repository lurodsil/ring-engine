using System.Xml;
using UnityEngine;
using UnityEngine.Splines;
using UnityEngine.Splines.Extensions;

namespace RingEngine
{
    [ExecuteAlways]
    public class SplineSkinnedMeshCreator : MonoBehaviour
    {
        [SerializeField] private SplineContainer splineContainer;
        [SerializeField] private BezierMeshStructure gameObjects;

        [SerializeField] private bool capStart;
        [SerializeField] private bool capEnd;
        public float distance = 1;

        private bool needsUpdate;

        private void OnEnable()
        {
            Spline.Changed += OnSplineChanged;
        }

        private void OnDisable()
        {
            Spline.Changed -= OnSplineChanged;
        }

        private void OnValidate()
        {
            needsUpdate = true;
        }

        private void Update()
        {
            if (!Application.isPlaying && needsUpdate)
            {
                needsUpdate = false;
                UpdateMesh();
            }
        }

        private void OnSplineChanged(Spline spline, int index, SplineModification modification)
        {
            if (splineContainer == null) return;

            if (spline == splineContainer.Splines[0])
            {
                needsUpdate = true;
            }


        }

        [ContextMenu("Update Mesh")]
        private void UpdateMesh()
        {
            if (splineContainer == null || gameObjects == null) return;

            CreateMesh(gameObjects, 500,  distance);
        }

        public void CreateMesh(BezierMeshStructure bezierMeshStructure, int iterations = 500, float maxDistance = 1f)
        {
            splineContainer.Evaluate(0, out FrenetFrame splineKnot);

            splineKnot = FrenetFrameUtility.LocalToWorld(splineKnot,transform);

            Vector3 lastPosition = splineKnot.point;

            EraseMesh(bezierMeshStructure.name);

            GameObject temp = new GameObject(bezierMeshStructure.name);
            temp.transform.SetParent(transform);
            temp.transform.localPosition = Vector3.zero;
            temp.transform.localRotation = Quaternion.identity;

            if (capStart)
            {
                var cap = Instantiate(bezierMeshStructure.cap, splineKnot.point, splineKnot.rotation, temp.transform);
                cap.transform.localScale *= bezierMeshStructure.scale;
            }

            GameObject newPart = Instantiate(bezierMeshStructure.part, temp.transform);
            Transform start = newPart.transform.Find("Start");
            Transform end = start.transform.Find("End");

            start.localScale *= bezierMeshStructure.scale;
            start.position = splineKnot.point;
            start.rotation = splineKnot.rotation;

            float step = 1.0f / iterations;

            for (float t = 0; t <= 1.0f; t += step)
            {
                splineContainer.Evaluate(t, out splineKnot);
                splineKnot = FrenetFrameUtility.LocalToWorld(splineKnot, transform);

                if (Vector3.Distance(lastPosition, splineKnot.point) > maxDistance)
                {
                    if (start != null && end != null)
                    {
                        end.position = splineKnot.point;
                        end.rotation = splineKnot.rotation;
                    }

                    
                    // Escolher parte dependendo do ângulo
                    GameObject prefab = Mathf.Abs(Vector3.Dot(Vector3.up, splineKnot.tangent)) > 0.99f
                                        ? bezierMeshStructure.wall
                                        : bezierMeshStructure.part;



                    if (bezierMeshStructure.wall)
                    {
                        newPart = Instantiate(prefab, temp.transform);

                    }

                    start = newPart.transform.Find("Start");
                    end = start.transform.Find("End");

                    start.localScale *= bezierMeshStructure.scale;
                    start.position = splineKnot.point;
                    start.rotation = splineKnot.rotation;


                    lastPosition = splineKnot.point;
                }
            }
            splineContainer.Evaluate(1, out splineKnot);

            splineKnot = FrenetFrameUtility.LocalToWorld(splineKnot, transform);

            end.position = splineKnot.point;
            end.rotation = splineKnot.rotation;

            if (capEnd)
            {
                var cap = Instantiate(
                    bezierMeshStructure.cap,
                    end.position,
                    Quaternion.LookRotation(-splineKnot.tangent, splineKnot.normal),
                    temp.transform);

                cap.transform.localScale *= bezierMeshStructure.scale;
            }
        }

        public void EraseMesh(string meshName)
        {
            var existing = transform.Find(meshName);
            if (existing)
            {
                DestroyImmediate(existing.gameObject);
            }
        }
    }
}