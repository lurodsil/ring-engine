using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ProBuilder;

public class BezierMeshCreator : MonoBehaviour
{
    public bool capStart = true;
    public bool capEnd = true;

    public BezierMeshStructure[] structures;
    public GameObject[] decorations;
    public float distanceMin = 1;
    public float distanceMax = 2;
    public float betweenDecorationDistanceMin = 2;
    public float betweenDecorationDistanceMax = 3;
    public float percentageOfDecoration = 50;

    public float scaleMultiplier = 1;

    private BezierSpline bezierSpline;
    private DualBezierSpline dualBezierSpline;

    public void CreateDecorations()
    {
        if (GetComponent<BezierSpline>())
        {
            bezierSpline = GetComponent<BezierSpline>();
        }
        else if (GetComponent<DualBezierSpline>())
        {
            dualBezierSpline = GetComponent<DualBezierSpline>();
        }
        else
        {
            return;
        }

        EraseMesh("Decorations");

        float step = 1.0f / 100;

        Vector3 lastPoint = bezierSpline.GetPoint(0);

        float distance = distanceMin;
        float distaceBetween = betweenDecorationDistanceMin;

        GameObject decorationsObject = new GameObject("Decorations");
        decorationsObject.transform.parent = transform;
        decorationsObject.transform.Reset();

        for (float f = 0; f < 1; f += step)
        {
            BezierKnot knot = bezierSpline.GetKnot(f);

            Quaternion rotation = Quaternion.LookRotation(knot.binormal);

            if (Vector3.Distance(knot.point, lastPoint) > distaceBetween)
            {
                if(Random.Range(0, 100) < percentageOfDecoration)
                {
                    var deco = Instantiate(decorations[Random.Range(0, decorations.Length)], knot.point + (knot.binormal * Random.Range(distanceMin, distanceMax) * Mathf.Sign(Random.Range(-1,1))), rotation, decorationsObject.transform);
                    deco.transform.localScale *= scaleMultiplier;
                }

                lastPoint = knot.point;

                distaceBetween = Random.Range(betweenDecorationDistanceMin, betweenDecorationDistanceMax);
            }
        }
    }

    public void CreatAllMeshes()
    {
        for (int i = 0; i < structures.Length; i++)
        {
            if (structures[i].part && structures[i].cap)
            {
                CreateMesh(structures[i], 100, distanceMax);
            }
            else
            {
                Debug.Log("Bezier mesh structure is not setup");
            }
        }
    }

    public void CreateMesh(BezierMeshStructure bezierMeshStructure, int iterations = 100, float maxDistance = 2.5f)
    {

        if (GetComponent<BezierSpline>())
        {
            bezierSpline = GetComponent<BezierSpline>();
        }
        else if (GetComponent<DualBezierSpline>())
        {
            dualBezierSpline = GetComponent<DualBezierSpline>();
        }
        else
        {
            return;
        }

        BezierKnot knot = new BezierKnot();

        if (bezierSpline)
        {
            knot = bezierSpline.GetKnot(0);
        }
        else
        {
            knot = dualBezierSpline.GetKnot(0, 0.5f);
        }

        Vector3 lastPosition = knot.point;
        Quaternion rotation = Quaternion.LookRotation(knot.tangent, knot.normal);

        EraseMesh(bezierMeshStructure.name);

        GameObject temp = new GameObject("temp");
        temp.transform.parent = transform;
        temp.transform.Reset();

        if (capStart)
        {
            var cap = Instantiate(bezierMeshStructure.cap, knot.point, rotation, temp.transform);
            cap.transform.localScale *= bezierMeshStructure.scale;
        }


        GameObject newPart = Instantiate(bezierMeshStructure.part, temp.transform);
        Transform start = newPart.transform.Find("Start");
        Transform end = start.transform.Find("End");
        start.transform.localScale *= bezierMeshStructure.scale;
        start.position = knot.point;
        start.rotation = rotation;

        float step = 1.0f / iterations;

        for (float f = 0; f < 1.0f; f += step)
        {
            if (bezierSpline)
            {
                knot = bezierSpline.GetKnot(f);
            }
            else
            {
                knot = dualBezierSpline.GetKnot(f, 0.5f);
            }

            if (Vector3.Distance(lastPosition, knot.point) > maxDistance)
            {
                rotation = Quaternion.LookRotation(knot.tangent, knot.normal);
                end.position = knot.point;
                end.rotation = rotation;
                newPart = Instantiate(bezierMeshStructure.part, temp.transform);
                start = newPart.transform.Find("Start");
                end = start.transform.Find("End");
                start.transform.localScale *= bezierMeshStructure.scale;
                start.position = knot.point;
                start.rotation = rotation;
                lastPosition = knot.point;
            }
        }
        if (bezierSpline)
        {
            knot = bezierSpline.GetKnot(1);
        }
        else
        {
            knot = dualBezierSpline.GetKnot(1, 0.5f);
        }
        rotation = Quaternion.LookRotation(knot.tangent, knot.normal);
        end.position = knot.point;
        end.rotation = rotation;

        if (capEnd)
        {
            var cap = Instantiate(bezierMeshStructure.cap, end.transform.position, Quaternion.LookRotation(-end.transform.forward, end.transform.up), temp.transform);
            cap.transform.localScale *= bezierMeshStructure.scale;
        }

        SkinnedMeshRenderer[] skinedMeshRenderers = temp.GetComponentsInChildren<SkinnedMeshRenderer>();
        MeshFilter[] meshFilters = temp.GetComponentsInChildren<MeshFilter>();

        CombineInstance[] combineInstances = new CombineInstance[skinedMeshRenderers.Length + meshFilters.Length];

        for (int i = 0; i < meshFilters.Length; i++)
        {
            combineInstances[i].mesh = meshFilters[i].sharedMesh;
            combineInstances[i].transform = meshFilters[i].transform.localToWorldMatrix;
        }

        for (int i = 0; i < skinedMeshRenderers.Length; i++)
        {
            Mesh mesh = new Mesh();
            mesh.name = skinedMeshRenderers[i].name;

            skinedMeshRenderers[i].BakeMesh(mesh);
            combineInstances[i + meshFilters.Length].mesh = mesh;

            combineInstances[i + meshFilters.Length].transform = skinedMeshRenderers[i].transform.localToWorldMatrix;
        }

        Mesh finalMesh = new Mesh();
        finalMesh.name = "mesh_instance";

        finalMesh.CombineMeshes(combineInstances);

        GameObject meshObject = new GameObject(bezierMeshStructure.name);
        meshObject.transform.parent = transform;

        MeshFilter meshFilter = meshObject.AddComponent<MeshFilter>();
        MeshRenderer meshRenderer = meshObject.AddComponent<MeshRenderer>();

        meshFilter.sharedMesh = finalMesh;

        meshRenderer.sharedMaterials = skinedMeshRenderers[0].sharedMaterials;

        if (bezierMeshStructure.colliderType != ColliderType.None)
        {
            MeshCollider meshCollider = meshObject.AddComponent<MeshCollider>();

            if (bezierMeshStructure.colliderType == ColliderType.SplineCollider)
            {
                BezierMesh bezierMesh = new BezierMesh();

                if (bezierSpline)
                {
                    meshCollider.sharedMesh = bezierMesh.CreateSplineMesh(meshObject.transform, bezierSpline, 200, 1, bezierMeshStructure.colliderScale);
                }
                else
                {
                    meshCollider.sharedMesh = bezierMesh.CreateSplineMesh(dualBezierSpline, iterations, maxDistance);
                }
            }
        }

        DestroyImmediate(transform.Find("temp").gameObject);
    }

    public void EraseMesh(string meshName)
    {
        if (transform.Find(meshName))
        {
            DestroyImmediate(transform.Find(meshName).gameObject);
        }
    }
}
