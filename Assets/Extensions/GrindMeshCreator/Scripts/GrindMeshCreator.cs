using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrindMeshCreator : MonoBehaviour {

    public GameObject grindPart;
    public GameObject grindCap;
    public bool dynamicOccluded = false;
    private BezierSpline bezierSpline;
    private DualBezierSpline dualBezierSpline;

    public void CreateMesh ()
    {
        grindCap.GetComponent<MeshRenderer>().allowOcclusionWhenDynamic = dynamicOccluded;
        grindPart.GetComponentInChildren<SkinnedMeshRenderer>().allowOcclusionWhenDynamic = dynamicOccluded;

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

        EraseMesh();

        GameObject grindMesh = new GameObject("GrindMesh");
        grindMesh.transform.parent = transform;

        Instantiate(grindCap, knot.point, rotation, grindMesh.transform);

        GameObject newPart = Instantiate(grindPart, grindMesh.transform);
        Transform start = newPart.transform.Find("Start");
        Transform end = start.transform.Find("End");

        start.position = knot.point;
        start.rotation = rotation;

        for (float f = 0; f < 1; f += 0.001f)
        {
            if (bezierSpline)
            {
                knot = bezierSpline.GetKnot(f);
            }
            else
            {
                knot = dualBezierSpline.GetKnot(f, 0.5f);
            }

            if (Vector3.Distance(lastPosition, knot.point) > 2.5f)
            {
                rotation = Quaternion.LookRotation(knot.tangent, knot.normal);
                end.position = knot.point;
                end.rotation = rotation;
                newPart = Instantiate(grindPart, grindMesh.transform);
                start = newPart.transform.Find("Start");
                end = start.transform.Find("End");
                start.position = knot.point;
                start.rotation = rotation;
                lastPosition = knot.point;
            }
        }

        Instantiate(grindCap, end.position, Quaternion.LookRotation(-end.forward, end.up), grindMesh.transform);
    }


    public void EraseMesh()
    {
        if (transform.Find("GrindMesh"))
        {
            DestroyImmediate(transform.Find("GrindMesh").gameObject);
        }
    }
}
