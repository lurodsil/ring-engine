using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BezierControlPoint
{
    public BezierControlPointMode bezierControlPointMode;
    public Vector3 point;
    public Vector3 invec;
    public Vector3 outvec;

    public BezierControlPoint()
    {

    }

    public BezierControlPoint(Vector3 point, Vector3 invec, Vector3 outvec, BezierControlPointMode bezierControlPointMode)
    {
        this.bezierControlPointMode = bezierControlPointMode;
        this.invec = invec;
        this.outvec = outvec;
        this.point = point;
    }
}
