using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(DualBezierSpline))]
[RequireComponent(typeof(MeshCollider))]
[RequireComponent(typeof(Rigidbody))]
[AddComponentMenu("Bezier Splines/Dual Bezier Spline Collider")]
public class DualBezierSplineCollider : MonoBehaviour
{
    public int iterations = 10;
    private Mesh mesh;
    private DualBezierSpline dualBezierSpline;
    private MeshCollider meshCollider;

    public void CreateMesh(int iterations)
    {
        dualBezierSpline = GetComponent<DualBezierSpline>();
        meshCollider = GetComponent<MeshCollider>();

        Vector3[] vertices = new Vector3[(iterations + 1) * 2];
        int[] triangles = new int[vertices.Length * 3];

        float step = 1f / iterations;

        //Create Vertices
        for (int i = 0; i < vertices.Length; i += 2)
        {
            float t = (i / 2) * step;

            Vector3 pointLeft = dualBezierSpline.GetPoint(t, 0);
            Vector3 pointRight = dualBezierSpline.GetPoint(t, 1);

            vertices[i] = transform.InverseTransformPoint(pointLeft);
            vertices[i + 1] = transform.InverseTransformPoint(pointRight);
        }

        //Create Triangles
        for (int i = 0; i < vertices.Length - 2; i++)
        {
            triangles[i * 3] = i;
            triangles[i * 3 + 1] = i + 1;
            triangles[i * 3 + 2] = i + 2;
        }

        mesh = new Mesh();
        mesh.name = " dual spline collider";
        mesh.vertices = vertices;
        mesh.triangles = triangles;

        meshCollider.sharedMesh = mesh;
    }

    public void EraseMesh()
    {
        mesh = null;
        GetComponent<MeshCollider>().sharedMesh = null;
    }

    private void Reset()
    {
        GetComponent<MeshCollider>().hideFlags = HideFlags.HideInInspector;
        Rigidbody rigidbody = GetComponent<Rigidbody>();
        rigidbody.useGravity = false;
        rigidbody.isKinematic = true;
        rigidbody.collisionDetectionMode = CollisionDetectionMode.ContinuousSpeculative;
        rigidbody.hideFlags = HideFlags.HideInInspector;
        EraseMesh();
        gameObject.layer = LayerMask.NameToLayer("Spline Collision");             
    }
}
