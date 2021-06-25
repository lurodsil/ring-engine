using UnityEngine;

public class ConvertToDualBezierSpline : MonoBehaviour
{
    BezierSpline bezierSpline;
    public float size = 0.3f;

    public void Convert()
    {
        bezierSpline = GetComponent<BezierSpline>();

        GameObject dualBezierSpline = new GameObject(gameObject.name);
        dualBezierSpline.transform.CopyTransform(transform);

        GameObject leftSplineObject = new GameObject("left");
        leftSplineObject.transform.parent = dualBezierSpline.transform;
        leftSplineObject.transform.Reset();
        GameObject rightSplineObject = new GameObject("right");
        rightSplineObject.transform.parent = dualBezierSpline.transform;
        rightSplineObject.transform.Reset();

        BezierSpline leftSpline = leftSplineObject.AddComponent<BezierSpline>();
        BezierSpline rightSpline = rightSplineObject.AddComponent<BezierSpline>();

        for (int i = 0; i < bezierSpline.bezierControlPoints.Count; i++)
        {
            Vector3 tangent = (bezierSpline.bezierControlPoints[i].outvec - bezierSpline.bezierControlPoints[i].point).normalized;

            Vector3 binormal = Vector3.Cross(Vector3.up, tangent) * (size * 0.5f);

            BezierControlPoint bezierControlPointLeft = new BezierControlPoint(bezierSpline.bezierControlPoints[i].point - binormal, bezierSpline.bezierControlPoints[i].invec - binormal, bezierSpline.bezierControlPoints[i].outvec - binormal, bezierSpline.bezierControlPoints[i].bezierControlPointMode);
            BezierControlPoint bezierControlPointRight = new BezierControlPoint(bezierSpline.bezierControlPoints[i].point + binormal, bezierSpline.bezierControlPoints[i].invec + binormal, bezierSpline.bezierControlPoints[i].outvec + binormal, bezierSpline.bezierControlPoints[i].bezierControlPointMode);

            leftSpline.bezierControlPoints.Add(bezierControlPointLeft);
            rightSpline.bezierControlPoints.Add(bezierControlPointRight);
        }

        dualBezierSpline.AddComponent<DualBezierSpline>();
    }
}
