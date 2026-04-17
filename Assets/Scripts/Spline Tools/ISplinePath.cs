using UnityEngine;
using UnityEngine.Splines;

public interface ISplinePath
{
    void PutOnPathRigidbody(Rigidbody rb, PutOnPathMode putOnPathMode, out BezierKnot bezierKnot, out float closestTimeOnSpline, float attractForce = 10f, float binormalOffset = 0.5f)
    {
        bezierKnot = default;
        closestTimeOnSpline = 0f;
    }

    void PutOnPath(Rigidbody rb, PutOnPathMode putOnPathMode, out BezierKnot bezierKnot, out float closestTimeOnSpline, float attractForce = 10f, float binormalOffset = 0.5f)
    {
        bezierKnot = default;
        closestTimeOnSpline = 0f;
    }
}

