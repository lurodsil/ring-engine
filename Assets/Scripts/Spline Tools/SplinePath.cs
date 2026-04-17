using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Splines;
using UnityEngine.Splines.Extensions;

public class SplinePath : MonoBehaviour, ISplinePath
{
    [Range(0.01f, 0.001f)]
    public float pathFindPrecision = 0.01f;
    public bool fastMode = true;
    [HideInInspector]
    public SplineContainer splineContainer;
    private Vector3 pathPosition;

    private void Awake()
    {
        try
        {
            splineContainer = GetComponent<SplineContainer>();
        }
        catch
        {

        }
    }



    //public void PutOnPath(Transform target, PutOnPathMode putOnPathMode)
    //{
    //    PutOnPath(target, putOnPathMode, out _, out _);
    //}

    //public void PutOnPath(Transform target, PutOnPathMode putOnPathMode, out BezierKnot bezierKnot)
    //{
    //    PutOnPath(target, putOnPathMode, out bezierKnot, out _);
    //}

    //public void PutOnPath(Transform target, PutOnPathMode putOnPathMode, out BezierKnot bezierKnot, out float closestTimeOnSpline, float atractForce = 0, float binormalOffset = 0.5f)
    //{
    //    if (bezierSpline)
    //    {
    //        closestTimeOnSpline = fastMode == true ? bezierSpline.ClosestPointFast(target.position) : bezierSpline.ClosestPoint(target.position, pathFindPrecision);
    //        bezierKnot = bezierSpline.GetKnot(closestTimeOnSpline);
    //    }
    //    else if (dualBezierSpline)
    //    {
    //        closestTimeOnSpline = fastMode == true ? dualBezierSpline.ClosestPointFast(target.position) : dualBezierSpline.ClosestPoint(target.position, pathFindPrecision);
    //        bezierKnot = dualBezierSpline.GetKnot(closestTimeOnSpline, binormalOffset);
    //    }
    //    else
    //    {
    //        closestTimeOnSpline = 0;
    //        bezierKnot = null;
    //        return;
    //    }

    //    Quaternion rotation = Quaternion.LookRotation(bezierKnot.tangent, bezierKnot.normal);

    //    Vector3 position = target.position;

    //    Matrix4x4 matrix = Matrix4x4.TRS(bezierKnot.point, rotation, Vector3.one);

    //    switch (putOnPathMode)
    //    {
    //        case PutOnPathMode.BinormalOnly:
    //            pathPosition = bezierKnot.binormal * matrix.inverse.MultiplyPoint(position).x;
    //            break;
    //        case PutOnPathMode.NormalOnly:
    //            pathPosition = bezierKnot.normal * matrix.inverse.MultiplyPoint(position).y;
    //            break;
    //        case PutOnPathMode.BinormalAndNormal:
    //            pathPosition = bezierKnot.binormal * matrix.inverse.MultiplyPoint(position).x + bezierKnot.normal * matrix.inverse.MultiplyPoint(position).y;
    //            break;
    //    }

    //    if (atractForce <= 0)
    //    {
    //        target.position -= pathPosition;
    //    }
    //    else
    //    {
    //        target.position -= pathPosition * (atractForce * Time.fixedDeltaTime);
    //    }
    //}

  //  public void PutOnPath(
  //Rigidbody target,
  //PutOnPathMode putOnPathMode,
  //out BezierKnot bezierKnot,
  //out float closestTimeOnSpline,
  //float attractForce = 0f,
  //float binormalOffset = 0.5f)
  //  {
  //      bezierKnot = default;
  //      closestTimeOnSpline = 0;

  //      //if (bezierSpline)
  //      //{
  //      //    closestTimeOnSpline = fastMode
  //      //        ? bezierSpline.ClosestPointFast(target.position)
  //      //        : bezierSpline.ClosestPoint(target.position, pathFindPrecision);

  //      //    bezierKnot = bezierSpline.GetKnot(closestTimeOnSpline);
  //      //}
  //      //else if (dualBezierSpline)
  //      //{
  //      //    closestTimeOnSpline = fastMode
  //      //        ? dualBezierSpline.ClosestPointFast(target.position)
  //      //        : dualBezierSpline.ClosestPoint(target.position, pathFindPrecision);

  //      //    bezierKnot = dualBezierSpline.GetKnot(closestTimeOnSpline, binormalOffset);
  //      //}
  //      //else
  //      //{
  //      //    closestTimeOnSpline = 0f;
  //      //    bezierKnot = null;
  //      //    return;
  //      //}

  //      //// Rotação do frame do spline
  //      //Quaternion rotation = Quaternion.LookRotation(
  //      //    bezierKnot.tangent.normalized,
  //      //    bezierKnot.normal.normalized
  //      //);

  //      //Matrix4x4 matrix = Matrix4x4.TRS(
  //      //    bezierKnot.point,
  //      //    rotation,
  //      //    Vector3.one
  //      //);

  //      //// Posição do target no espaço local do spline
  //      //Vector3 localPos = matrix.inverse.MultiplyPoint(target.position);

  //      //Vector3 pathOffset = Vector3.zero;

  //      //switch (putOnPathMode)
  //      //{
  //      //    case PutOnPathMode.BinormalOnly:
  //      //        pathOffset = bezierKnot.binormal * localPos.x;
  //      //        break;

  //      //    case PutOnPathMode.NormalOnly:
  //      //        pathOffset = bezierKnot.normal * localPos.y;
  //      //        break;

  //      //    case PutOnPathMode.BinormalAndNormal:
  //      //        pathOffset =
  //      //            bezierKnot.binormal * localPos.x +
  //      //            bezierKnot.normal * localPos.y;
  //      //        break;
  //      //}

  //      //if (attractForce <= 0f)
  //      //{
  //      //    // Correção instantânea
  //      //    target.position -= pathOffset;
  //      //}
  //      //else
  //      //{
  //      //    // Correção suave (não física)
  //      //    float dt = Time.fixedDeltaTime; // use deltaTime se não for FixedUpdate
  //      //    target.position -= pathOffset * attractForce * dt;
  //      //}
  //  }

    //public void PutOnPathRigidbody(
    //  Rigidbody rb,
    //  PutOnPathMode putOnPathMode,
    //  out BezierKnot bezierKnot,
    //  out float closestTimeOnSpline,
    //  float attractForce = 10f,
    //  float binormalOffset = 0.5f)
    //{
    ////    Vector3 position = rb.position;

    ////    // Pega ponto mais próximo na spline
    ////    //closestTimeOnSpline = ClosestPoint(rb.position, 0.001f);
    ////    SplineUtility.GetNearestPoint(splineContainer.Spline, rb.position, out float3 nearest, out closestTimeOnSpline);

    ////    splineContainer.Evaluate(closestTimeOnSpline, out SplineKnot splineKnot);
    ////    var worldKnot = splineKnot.LocalToWorld(transform);
    ////    bezierKnot = new BezierKnot(worldKnot.point, worldKnot.tangent, worldKnot.binormal, worldKnot.normal);

    ////    // Frame do spline
    ////    Quaternion rotation = Quaternion.LookRotation(bezierKnot.tangent.normalized, bezierKnot.normal.normalized);
    ////    Matrix4x4 matrix = Matrix4x4.TRS(bezierKnot.point, rotation, Vector3.one);

    ////    // Posição local em relação ao spline
    ////    Vector3 localPos = matrix.inverse.MultiplyPoint(position);

    ////    // Calcula offset
    ////    Vector3 pathOffset = Vector3.zero;
    ////    switch (putOnPathMode)
    ////    {
    ////        case PutOnPathMode.BinormalOnly:
    ////            pathOffset = bezierKnot.binormal * localPos.x;
    ////            break;
    ////        case PutOnPathMode.NormalOnly:
    ////            pathOffset = bezierKnot.normal * localPos.y;
    ////            break;
    ////        case PutOnPathMode.BinormalAndNormal:
    ////            pathOffset = bezierKnot.binormal * localPos.x + bezierKnot.normal * localPos.y;
    ////            break;
    ////    }

    ////    float dt = Time.fixedDeltaTime;

    ////    // =========================
    ////    // POSIÇÃO
    ////    // =========================
    ////    // Tangente da spline
    ////    Vector3 tangent = bezierKnot.tangent.normalized;

    ////    // Correção para manter no path
    ////    Vector3 correction = pathOffset * Mathf.Clamp01(attractForce * Time.fixedDeltaTime);

    ////    // Aplica apenas perpendicular à tangente
    ////    Vector3 perpendicularCorrection = correction - Vector3.Project(correction, tangent);

    ////    // Move a posição do Rigidbody
    ////    rb.MovePosition(rb.position - perpendicularCorrection);

    ////    // Corrige velocidade apenas perpendicular à spline
    ////    Vector3 velocity = rb.linearVelocity;
    ////    Vector3 tangentialVelocity = Vector3.Project(velocity, tangent); // velocidade ao longo do path
    ////    Vector3 perpendicularVelocity = velocity - tangentialVelocity;    // velocidade fora do path

    ////    // Remove apenas a componente perpendicular
    ////    perpendicularVelocity -= Vector3.Project(perpendicularVelocity, correction.normalized);

    ////    rb.linearVelocity = tangentialVelocity + perpendicularVelocity;
    ////}

    ////[Range(0f, 1f)]
    ////[SerializeField] private float binormalTime = 0.5f;

    ////private void OnDrawGizmos()
    ////{
    ////    if (enabled)
    ////    {
    ////        if(!splineContainer)
    ////            splineContainer = GetComponent<SplineContainer>();
    ////        for (float t = 0; t < 1; t += 0.01f)
    ////        {
    ////            splineContainer.Evaluate(t, out SplineKnot knot, binormalTime);
    ////            splineContainer.Evaluate(t, out SplineKnot knotL, 0);
    ////            splineContainer.Evaluate(t, out SplineKnot knotR, 1);

    ////            var worldKnot = knot.LocalToWorld(transform);

    ////            Gizmos.color = Color.blue;
    ////            Gizmos.DrawRay(worldKnot.point, worldKnot.tangent);
    ////            Gizmos.color = Color.red;
    ////            Gizmos.DrawRay(worldKnot.point, worldKnot.binormal);
    ////            Gizmos.color = Color.green;
    ////            Gizmos.DrawRay(worldKnot.point, worldKnot.normal);

    ////            //Gizmos.color = Color.yellow;
    ////            //Gizmos.DrawLine(knotL.LocalToWorld(transform).point, knotR.LocalToWorld(transform).point);
    ////        }
    ////    }
    //}

    public void PutOnPath(
    Rigidbody target,
    PutOnPathMode putOnPathMode,
    out BezierKnot bezierKnot,
    out float closestTimeOnSpline,
    float attractForce = 0f,
    float binormalOffset = 0.5f)
    {
        bezierKnot = null;
        closestTimeOnSpline = 0f;


       // // Pega ponto mais próximo na spline
       //// closestTimeOnSpline = ClosestPoint(target.position, 0.001f);
       // SplineUtility.GetNearestPoint(splineContainer.Spline, target.position, out float3 nearest, out closestTimeOnSpline, 4, 4);

       // splineContainer.Evaluate(closestTimeOnSpline, out SplineKnot splineKnot);
       // var worldKnot = splineKnot.LocalToWorld(transform);
       // bezierKnot = new BezierKnot(worldKnot.point, worldKnot.tangent, worldKnot.binormal, worldKnot.normal);

       // if (bezierKnot == null)
       //     return;

       // // =========================
       // // 2. Base ortonormal (mais segura)
       // // =========================
       // Vector3 tangent = bezierKnot.tangent.normalized;
       // Vector3 normal = bezierKnot.normal.normalized;

       // // Recalcula binormal pra garantir ortogonalidade perfeita
       // Vector3 binormal = Vector3.Cross(tangent, normal).normalized;

       // // Re-ortogonaliza normal (evita drift acumulado)
       // normal = Vector3.Cross(binormal, tangent).normalized;

       // // =========================
       // // 3. Offset no espaço da spline
       // // =========================
       // Vector3 toTarget = target.position - bezierKnot.point;

       // float offsetX = Vector3.Dot(toTarget, binormal);
       // float offsetY = Vector3.Dot(toTarget, normal);

       // Vector3 pathOffset = Vector3.zero;

       // switch (putOnPathMode)
       // {
       //     case PutOnPathMode.BinormalOnly:
       //         pathOffset = binormal * offsetX;
       //         break;

       //     case PutOnPathMode.NormalOnly:
       //         pathOffset = normal * offsetY;
       //         break;

       //     case PutOnPathMode.BinormalAndNormal:
       //         pathOffset = binormal * offsetX + normal * offsetY;
       //         break;
       // }

       // // =========================
       // // 4. Correção de posição
       // // =========================
       // if (attractForce <= 0f)
       // {
       //     target.position -= pathOffset;
       // }
       // else
       // {
       //     float dt = Time.fixedDeltaTime;
       //     target.position -= pathOffset * attractForce * dt;
       // }
       // Vector3 velocity = target.linearVelocity;

       // // salva energia antes de qualquer alteração
       // float tangentialSpeed = Vector3.Dot(velocity, tangent);

       // // remove apenas componente lateral REAL (normal + binormal)
       // if (pathOffset.sqrMagnitude > 0.0001f)
       // {
       //     Vector3 lateralDir = pathOffset.normalized;
       //     Vector3 unwantedVelocity = Vector3.Project(velocity, lateralDir);
       //     velocity -= unwantedVelocity;
       // }

       // // reconstrói velocidade mantendo energia
       // velocity = tangent * tangentialSpeed + Vector3.ProjectOnPlane(velocity, tangent);

       // target.linearVelocity = velocity;
    }

    //public void PutOnPath(
    //Transform target,
    //PutOnPathMode putOnPathMode,
    //out BezierKnot bezierKnot,
    //out float closestTimeOnSpline,
    //float attractForce = 0f,
    //float binormalOffset = 0.5f)
    //{
    //    if (bezierSpline)
    //    {
    //        closestTimeOnSpline = fastMode
    //            ? bezierSpline.ClosestPointFast(target.position)
    //            : bezierSpline.ClosestPoint(target.position, pathFindPrecision);

    //        bezierKnot = bezierSpline.GetKnot(closestTimeOnSpline);
    //    }
    //    else if (dualBezierSpline)
    //    {
    //        closestTimeOnSpline = fastMode
    //            ? dualBezierSpline.ClosestPointFast(target.position)
    //            : dualBezierSpline.ClosestPoint(target.position, pathFindPrecision);

    //        bezierKnot = dualBezierSpline.GetKnot(closestTimeOnSpline, binormalOffset);
    //    }
    //    else
    //    {
    //        closestTimeOnSpline = 0f;
    //        bezierKnot = null;
    //        return;
    //    }

    //    // Rotação do frame do spline
    //    Quaternion rotation = Quaternion.LookRotation(
    //        bezierKnot.tangent.normalized,
    //        bezierKnot.normal.normalized
    //    );

    //    Matrix4x4 matrix = Matrix4x4.TRS(
    //        bezierKnot.point,
    //        rotation,
    //        Vector3.one
    //    );

    //    // Posição do target no espaço local do spline
    //    Vector3 localPos = matrix.inverse.MultiplyPoint(target.position);

    //    Vector3 pathOffset = Vector3.zero;

    //    switch (putOnPathMode)
    //    {
    //        case PutOnPathMode.BinormalOnly:
    //            pathOffset = bezierKnot.binormal * localPos.x;
    //            break;

    //        case PutOnPathMode.NormalOnly:
    //            pathOffset = bezierKnot.normal * localPos.y;
    //            break;

    //        case PutOnPathMode.BinormalAndNormal:
    //            pathOffset =
    //                bezierKnot.binormal * localPos.x +
    //                bezierKnot.normal * localPos.y;
    //            break;
    //    }

    //    if (attractForce <= 0f)
    //    {
    //        // Correção instantânea
    //        target.position -= pathOffset;
    //    }
    //    else
    //    {
    //        // Correção suave (não física)
    //        float dt = Time.fixedDeltaTime; // use deltaTime se não for FixedUpdate
    //        target.position -= pathOffset * attractForce * dt;
    //    }
    //}

    private float currentDistance;
    private float lastDistance = float.MaxValue;
    private float closestFloat = 0;
    private float f = 0;

    public float ClosestPoint(Vector3 point, float precision)
    {
        lastDistance = float.MaxValue;
        closestFloat = 0;
        f = 0;

        while (f <= 1)
        {
            Vector3 pos = splineContainer.EvaluatePosition(f);

            Vector3 diff = pos - point;

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



    //public void GetClosestKnot(Vector3 position, out BezierKnot bezierKnot, float binormalOffset = 0.5f)
    //{
    //    if (bezierSpline)
    //    {
    //        float closestTimeOnSpline = fastMode == true ? bezierSpline.ClosestPointFast(position) : bezierSpline.ClosestPoint(position, pathFindPrecision);
    //        bezierKnot = bezierSpline.GetKnot(closestTimeOnSpline);
    //    }
    //    else if (dualBezierSpline)
    //    {
    //        float closestTimeOnSpline = fastMode == true ? dualBezierSpline.ClosestPointFast(position) : dualBezierSpline.ClosestPoint(position, pathFindPrecision);
    //        bezierKnot = dualBezierSpline.GetKnot(closestTimeOnSpline, binormalOffset);
    //    }
    //    else
    //    {
    //        bezierKnot = null;
    //    }
    //}
}

