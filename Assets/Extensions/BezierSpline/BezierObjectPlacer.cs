using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BezierObjectPlacer : MonoBehaviour
{
    public GameObject prefab;
    [Range(0,1)]
    public float time;

    public Vector3 offset;

    public BezierSpline bezierSpline;
    public DualBezierSpline dualBezierSpline;

    private void OnEnable()
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
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;

        BezierKnot knot = new BezierKnot();

        if (bezierSpline)
        {
            knot = bezierSpline.GetKnot(time);
        }
        else
        {
            knot = dualBezierSpline.GetKnot(time, 0.5f);
        }

        Gizmos.DrawSphere(knot.point +
                (knot.binormal * offset.x) +
                (knot.normal * offset.y) +
                (knot.tangent * offset.z), 0.3f);
    }
}
