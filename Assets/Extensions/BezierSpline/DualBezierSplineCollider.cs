using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(DualBezierSpline))]
[RequireComponent(typeof(MeshCollider))]
[AddComponentMenu("Bezier Splines/Dual Bezier Spline Collider")]
public class DualBezierSplineCollider : MonoBehaviour
{
    public int iterations = 10;
    public float maxDistance = 1;
    public void CreateMesh()
    {
        BezierMesh bezierMesh = new BezierMesh();
        MeshCollider meshCollider = GetComponent<MeshCollider>();

        DualBezierSpline dualBezierSpline = GetComponent<DualBezierSpline>();

        if (dualBezierSpline != null)
        {
            meshCollider.sharedMesh = bezierMesh.CreateSplineMesh(dualBezierSpline, iterations, maxDistance);
        }
    }

    public void EraseMesh()
    {
        GetComponent<MeshCollider>().sharedMesh = null;
    }
}
