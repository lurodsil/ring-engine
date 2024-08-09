using System.Collections.Generic;
using UnityEngine;

public class BezierMesh
{
    public Mesh CreateSplineMesh(Transform meshHolder, BezierSpline bezierSpline, int splineIterations = 50, float maxDistance = 1, float scale = 1)
    {
        List<Vector3> vertices = new List<Vector3>();

        float step = 1f / splineIterations;

        Vector3 lastPoint = bezierSpline.GetPoint(0);
        Vector3 binormal = bezierSpline.GetBinormal(0).normalized * scale;

        //Adds the two first vertices
        vertices.Add(meshHolder.InverseTransformPoint(lastPoint - binormal));
        vertices.Add(meshHolder.InverseTransformPoint(lastPoint + binormal));

        //Create Vertices
        for (float f = 0; f < 1; f += step)
        {
            Vector3 point = bezierSpline.GetPoint(f);

            if (Vector3.Distance(lastPoint, point) > maxDistance)
            {
                binormal = bezierSpline.GetBinormal(f).normalized * scale;
                vertices.Add(meshHolder.InverseTransformPoint(point - binormal));
                vertices.Add(meshHolder.InverseTransformPoint(point + binormal));

                lastPoint = point;
            }

            
        }

        //Adds the two last vertices
        vertices.Add(meshHolder.InverseTransformPoint(lastPoint - binormal));
        vertices.Add(meshHolder.InverseTransformPoint(lastPoint + binormal));

        int[] triangles = new int[vertices.Count * 3];

        //Create Triangles
        for (int i = 0; i < (vertices.Count / 2f) - 1; i++)
        {
            triangles[i * 6] = i * 2;
            triangles[i * 6 + 1] = i * 2 + 2;
            triangles[i * 6 + 2] = i * 2 + 1;

            triangles[i * 6 + 3] = i * 2 + 1;
            triangles[i * 6 + 4] = i * 2 + 2;
            triangles[i * 6 + 5] = i * 2 + 3;
        }

        Mesh returnMesh = new Mesh();
        returnMesh.name = "spline mesh";
        returnMesh.vertices = vertices.ToArray();
        returnMesh.triangles = triangles;

        return returnMesh;
    }

    public Mesh CreateSplineMesh(DualBezierSpline dualBezierSpline, int splineIterations = 50, float maxDistance = 1)
    {
        List<Vector3> vertices = new List<Vector3>();

        float step = 1f / splineIterations;

        Vector3 lastPointLeft = dualBezierSpline.GetPoint(0, 0);
        Vector3 lastPointRight = dualBezierSpline.GetPoint(0, 1);
        Vector3 lastMiddlePoint = Vector3.Lerp(lastPointLeft, lastPointRight, 0.5f);

        //Adds the two first vertices
        vertices.Add(dualBezierSpline.transform.InverseTransformPoint(lastPointLeft));
        vertices.Add(dualBezierSpline.transform.InverseTransformPoint(lastPointRight));

        //Create Vertices
        for (float f = 0; f < 1; f += step)
        {
            Vector3 pointLeft = dualBezierSpline.GetPoint(f, 0);
            Vector3 pointRight = dualBezierSpline.GetPoint(f, 1);
            Vector3 middlePoint = Vector3.Lerp(pointLeft, pointLeft, 0.5f);

            if (Vector3.Distance(lastMiddlePoint, middlePoint) > maxDistance)
            {
                vertices.Add(dualBezierSpline.transform.InverseTransformPoint(pointLeft));
                vertices.Add(dualBezierSpline.transform.InverseTransformPoint(pointRight));
            }

            lastPointLeft = pointLeft;
            lastPointRight = pointRight;
            lastMiddlePoint = middlePoint;
        }

        //Adds the two last vertices
        vertices.Add(dualBezierSpline.transform.InverseTransformPoint(lastPointLeft));
        vertices.Add(dualBezierSpline.transform.InverseTransformPoint(lastPointRight));

        int[] triangles = new int[vertices.Count * 3];

        //Create Triangles
        for (int i = 0; i < (vertices.Count / 2f) - 1; i++)
        {
            triangles[i * 6] = i * 2;
            triangles[i * 6 + 1] = i * 2 + 2;
            triangles[i * 6 + 2] = i * 2 + 1;

            triangles[i * 6 + 3] = i * 2 + 1;
            triangles[i * 6 + 4] = i * 2 + 2;
            triangles[i * 6 + 5] = i * 2 + 3;
        }

        Mesh returnMesh = new Mesh();
        returnMesh.name = "spline mesh";
        returnMesh.vertices = vertices.ToArray();
        returnMesh.triangles = triangles;

        return returnMesh;
    }
}
