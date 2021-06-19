using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BezierSpline))]
[RequireComponent(typeof(MeshCollider))]
[RequireComponent(typeof(Rigidbody))]
[AddComponentMenu("Bezier Splines/Bezier Spline Collider")]
public class BezierSplineCollider : MonoBehaviour
{
    public int iterations = 10;
    public float scale = 1;
    private Mesh mesh;
    private BezierSpline bezierSpline;
    private MeshCollider meshCollider;

    public void CreateMesh(int iterations)
    {      
        bezierSpline = GetComponent<BezierSpline>();
        meshCollider = GetComponent<MeshCollider>();

        Vector3[] vertices = new Vector3[(iterations + 1) * 2];
        int[] triangles = new int[vertices.Length * 3];

        float step = 1f / iterations;

        //Create Vertices
        for (int i = 0; i < vertices.Length; i += 2)
        {
            float t = (i / 2) * step;

            Vector3 point = bezierSpline.GetPoint(t);
            Vector3 binormal = bezierSpline.GetBinormal(t) * scale;

            vertices[i] = transform.InverseTransformPoint(point - binormal);
            vertices[i + 1] = transform.InverseTransformPoint(point + binormal);           
        }

        //Create Triangles
        for (int i = 0; i < vertices.Length - 2; i++)
        {
            triangles[i * 3] = i;
            triangles[i * 3 + 1] = i + 1;
            triangles[i * 3 + 2] = i + 2;
        }

        mesh = new Mesh();
        mesh.name = "spline collider";
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
        rigidbody.hideFlags = HideFlags.HideInInspector;
        EraseMesh();
        gameObject.layer = LayerMask.NameToLayer("Spline Collision");
    }
}
