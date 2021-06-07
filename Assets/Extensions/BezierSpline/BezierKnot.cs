using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BezierKnot
{
    public Vector3 point { get; set; }
    public Vector3 tangent { get; set; }
    public Vector3 binormal { get; set; }
    public Vector3 normal { get; set; }

    public BezierKnot()
    {

    }

    public BezierKnot(Vector3 point, Vector3 tangent, Vector3 binormal, Vector3 normal)
    {
        this.point = point;
        this.tangent = tangent;
        this.binormal = binormal;
        this.normal = normal;
    }
}
