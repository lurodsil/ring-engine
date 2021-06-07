using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("Bezier Splines/Bezier Spline")]
public class BezierSpline : MonoBehaviour
{
    private float currentDistance;
    private float lastDistance = float.MaxValue;
    private float closestFloat = 0;
    private float f = 0;

    public bool alwaysDrawSpline = false;
    public bool drawDirections;

    [Range(0.1f, 0.001f)]
    public float drawPrecision = 0.01f;

    public List<BezierControlPoint> bezierControlPoints = new List<BezierControlPoint>();

    public Vector3 GetPoint(float t)
    {
        int i;
        if (t >= 1f)
        {
            t = 1f;
            i = bezierControlPoints.Count - 2;
        }
        else
        {
            t = Mathf.Clamp01(t) * (bezierControlPoints.Count - 1);
            i = (int)t;
            t -= i;
        }

        return transform.TransformPoint(Bezier.GetPoint(bezierControlPoints[i].point, bezierControlPoints[i].outvec, bezierControlPoints[i + 1].invec, bezierControlPoints[i + 1].point, t));
    }

    public Vector3 GetVelocity(float t)
    {
        int i;
        if (t >= 1f)
        {
            t = 1f;
            i = bezierControlPoints.Count - 2;
        }
        else
        {
            t = Mathf.Clamp01(t) * (bezierControlPoints.Count - 1);
            i = (int)t;
            t -= i;
        }
        return transform.TransformPoint(Bezier.GetFirstDerivative(bezierControlPoints[i].point, bezierControlPoints[i].outvec, bezierControlPoints[i + 1].invec, bezierControlPoints[i + 1].point, t)) - transform.position;
    }

    public Vector3 GetTangent(float t)
    {
        return GetVelocity(t).normalized;
    }

    public Vector3 GetBinormal(float t)
    {
        return Vector3.Cross(Vector3.up, GetTangent(t));
    }

    public Vector3 GetNormal(float t)
    {
        return Vector3.Cross(GetTangent(t), GetBinormal(t)).normalized;
    }

    public BezierKnot GetKnot(float t)
    {
        return new BezierKnot(GetPoint(t), GetTangent(t), GetBinormal(t), GetNormal(t));
    }

    public float ClosestPoint(Vector3 point, float precision)
    {
        lastDistance = float.MaxValue;
        closestFloat = 0;
        f = 0;

        while (f <= 1)
        {
            Vector3 diff = GetPoint(f) - point;

            currentDistance = diff.sqrMagnitude;

            if (currentDistance < lastDistance)
            {
                closestFloat = f;

                lastDistance = currentDistance;
            }
            f += precision;
        }
        return closestFloat;
    }

    public float ClosestPointFast(Vector3 point)
    {
        float multiplier = 0.1f;
        float lastMultiplier = 0;

        float pt = ClosestPoint(point, multiplier);

        for (int i = 0; i < 20; i++)
        {
            lastMultiplier = multiplier;
            multiplier *= 0.5f;
            pt = CalculateClosest(point, pt, lastMultiplier, multiplier);
        }

        return pt;
    }

    private float CalculateClosest(Vector3 point, float current, float lastPrecision, float precision)
    {
        lastDistance = float.MaxValue;
        closestFloat = 0;
        f = current - lastPrecision;

        while (f < current + lastPrecision)
        {
            Vector3 diff = GetPoint(f) - point;

            currentDistance = diff.sqrMagnitude;

            if (currentDistance < lastDistance)
            {
                closestFloat = f;

                lastDistance = currentDistance;
            }

            f += precision;
        }

        return closestFloat;
    }

    public float GetLength(float precision)
    {
        float length = 0;

        for (float f = 0; f < 1f - precision; f += precision)
        {
            length += (GetPoint(f) - GetPoint(f + precision)).sqrMagnitude;
        }

        return length * length;
    }

    public void OnDrawGizmosSelected()
    {
        if (!alwaysDrawSpline)
        {
            DrawSpline();
        }
    }

    public void OnDrawGizmos()
    {
        if (alwaysDrawSpline)
        {
            DrawSpline();
        }
    }

    public void DrawSpline()
    {
#if UNITY_EDITOR
        if (bezierControlPoints.Count > 1)
        {
            for (int i = 0; i < bezierControlPoints.Count - 1; i++)
            {
                UnityEditor.Handles.DrawBezier(transform.TransformPoint(bezierControlPoints[i].point), transform.TransformPoint(bezierControlPoints[i + 1].point), transform.TransformPoint(bezierControlPoints[i].outvec), transform.TransformPoint(bezierControlPoints[i + 1].invec), Color.white, null, 3);
            }

            if (drawDirections)
            {
                Gizmos.color = Color.blue;
                for (float f = 0; f < 1f - drawPrecision; f += drawPrecision)
                {
                    Vector3 bezierPoint = GetPoint(f);
                    Gizmos.color = Color.blue;
                    Gizmos.DrawLine(bezierPoint, bezierPoint + GetTangent(f));
                    Gizmos.color = Color.red;
                    Gizmos.DrawLine(bezierPoint, bezierPoint + GetBinormal(f));
                    Gizmos.color = Color.green;
                    Gizmos.DrawLine(bezierPoint, bezierPoint + GetNormal(f));
                }
            }
        }
#endif
    }

    private void Reset()
    {
        bezierControlPoints = new List<BezierControlPoint>
        {
            new BezierControlPoint(new Vector3(0, 0, 1), new Vector3(0, 0, 0.5f), new Vector3(0, 0, 1.5f), BezierControlPointMode.Mirrored),

            new BezierControlPoint(new Vector3(0, 0, 5), new Vector3(0, 0, 4.5f), new Vector3(0, 0, 5.5f), BezierControlPointMode.Mirrored)
        };
    }
}
