using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("Bezier Splines/Dual Bezier Spline")]
public class DualBezierSpline : MonoBehaviour
{
    private float currentDistance;
    private float lastDistance = float.MaxValue;
    private float closestFloat = 0;
    private float f = 0;
    private float lastT;

    public bool drawDirections;

    [Range(0.1f, 0.001f)]
    public float drawPrecision = 0.01f;

    public BezierSpline left, right;

    public Vector3 GetPoint(float t, float l)
    {
        return Vector3.Lerp(left.GetPoint(t), right.GetPoint(t), l);
    }

    public Vector3 GetTangent(float t)
    {
        return Vector3.Lerp(left.GetTangent(t), right.GetTangent(t), 0.5f).normalized;
    }

    public Vector3 GetBinormal(float t)
    {
        return (GetPoint(t, 1) - GetPoint(t, 0)).normalized;
    }

    public Vector3 GetNormal(float t)
    {
        return Vector3.Cross(GetTangent(t), GetBinormal(t)).normalized;
    }

    public BezierKnot GetKnot(float t, float b)
    {
        return new BezierKnot(GetPoint(t, b), GetTangent(t), GetBinormal(t), GetNormal(t));
    }

    public float ClosestPoint(Vector3 point, float precision)
    {
        lastDistance = float.MaxValue;
        closestFloat = 0;
        f = 0;

        while (f <= 1)
        {
            Vector3 diff = GetPoint(f, 0.5f) - point;

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
        float multiplier = 0.2f;
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
            Vector3 diff = GetPoint(f, 0.5f) - point;

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

    public float GetLength()
    {
        return (left.GetLength(0.0001f) + right.GetLength(0.0001f)) / 2;
    }

    private void OnDrawGizmos()
    {
        if (drawDirections)
        {
            Gizmos.color = Color.blue;
            for (float f = 0; f < 1f - drawPrecision; f += drawPrecision)
            {
                Vector3 bezierPoint = GetPoint(f, 0.5f);
                Gizmos.color = Color.blue;
                Gizmos.DrawLine(bezierPoint, bezierPoint + GetTangent(f));
                Gizmos.color = Color.red;
                Gizmos.DrawLine(bezierPoint, bezierPoint + GetBinormal(f));
                Gizmos.color = Color.green;
                Gizmos.DrawLine(bezierPoint, bezierPoint + GetNormal(f));
            }
        }
    }

    private void Reset()
    {
        try
        {
            left = transform.Find("left").GetComponent<BezierSpline>();
        }
        catch
        {
            print("Can't find left bezier spline.");
        }

        try
        {
            right = transform.Find("right").GetComponent<BezierSpline>();
        }
        catch
        {
            print("Can't find right bezier spline.");
        }
    }
}
