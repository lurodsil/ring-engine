using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BezierPath : MonoBehaviour
{
    [Range(0.01f, 0.0001f)]
    public float pathFindPrecision = 0.01f;
    public bool fastMode = true;
    [HideInInspector]
    public BezierSpline bezierSpline;
    [HideInInspector]
    public DualBezierSpline dualBezierSpline;
    private Vector3 pathPosition;

    private void Awake()
    {
        try
        {
            bezierSpline = GetComponent<BezierSpline>();
        }
        catch
        {
            
        }

        try
        {
            dualBezierSpline = GetComponent<DualBezierSpline>();
        }
        catch
        {

        }
    }

    public void PutOnPath(Transform target, PutOnPathMode putOnPathMode)
    {
        PutOnPath(target, putOnPathMode, out _, out _);
    }

    public void PutOnPath(Transform target, PutOnPathMode putOnPathMode, out BezierKnot bezierKnot)
    {
        PutOnPath(target, putOnPathMode, out bezierKnot, out _);
    }

    public void PutOnPath(Transform target, PutOnPathMode putOnPathMode, out BezierKnot bezierKnot, out float closestTimeOnSpline, float atractForce = 0, float binormalOffset = 0.5f)
    {
        if (bezierSpline)
        {
            closestTimeOnSpline = fastMode == true ? bezierSpline.ClosestPointFast(target.position) : bezierSpline.ClosestPoint(target.position, pathFindPrecision);
            bezierKnot = bezierSpline.GetKnot(closestTimeOnSpline);
        }
        else if (dualBezierSpline)
        {
            closestTimeOnSpline = fastMode == true ? dualBezierSpline.ClosestPointFast(target.position) : dualBezierSpline.ClosestPoint(target.position, pathFindPrecision);
            bezierKnot = dualBezierSpline.GetKnot(closestTimeOnSpline, binormalOffset);
        }
        else
        {
            closestTimeOnSpline = 0;
            bezierKnot = null;
            return;
        }

        Quaternion rotation = Quaternion.LookRotation(bezierKnot.tangent, bezierKnot.normal);

        Vector3 position = target.position;

        Matrix4x4 matrix = Matrix4x4.TRS(bezierKnot.point, rotation, Vector3.one);

        switch (putOnPathMode)
        {
            case PutOnPathMode.BinormalOnly:
                pathPosition = bezierKnot.binormal * matrix.inverse.MultiplyPoint(position).x;
                break;
            case PutOnPathMode.NormalOnly:
                pathPosition = bezierKnot.normal * matrix.inverse.MultiplyPoint(position).y;
                break;
            case PutOnPathMode.BinormalAndNormal:
                pathPosition = bezierKnot.binormal * matrix.inverse.MultiplyPoint(position).x + bezierKnot.normal * matrix.inverse.MultiplyPoint(position).y;
                break;
        }

        if (atractForce <= 0)
        {
            target.position -= pathPosition;
        }
        else
        {
            target.position -= pathPosition * (atractForce * Time.deltaTime);
        }
    }
}
