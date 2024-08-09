using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.ProBuilder;

[RequireComponent(typeof(BezierSpline))]
[RequireComponent(typeof(MeshCollider))]
[AddComponentMenu("Bezier Splines/Bezier Spline Collider")]
public class BezierSplineCollider : MonoBehaviour
{
    public int iterations = 10;
    public float maxDistance = 1;
    public float scale = 1;
    public void CreateMesh()
    {
        BezierMesh bezierMesh = new BezierMesh();

        MeshCollider meshCollider = GetComponent<MeshCollider>();

        BezierSpline bezierSpline = GetComponent<BezierSpline>();

        if (bezierSpline != null)
        {
            meshCollider.sharedMesh = bezierMesh.CreateSplineMesh( transform, bezierSpline, iterations, maxDistance, scale);
        }
    }

    public void EraseMesh()
    {
        GetComponent<MeshCollider>().sharedMesh = null;
    }
}
