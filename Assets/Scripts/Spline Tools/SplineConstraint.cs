using UnityEngine;
using UnityEngine.Splines;
using UnityEngine.Splines.Extensions;

[RequireComponent(typeof(Rigidbody))]
public class SplineConstraint : MonoBehaviour
{
    [SerializeField] private bool visualizeFrame = false;
    [SerializeField] private SplineContainer splineContainer;
    [SerializeField] private SplineConstraintMode mode;
    private new Rigidbody rigidbody;
    public FrenetFrame currentFrenetFrame { get; private set; }


    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (splineContainer == null || rigidbody == null)
            return;

        switch (mode)
        {
            case SplineConstraintMode.BinormalOnly:
                ApplyConstraint(rigidbody, SplineConstraintMode.BinormalOnly);
                break;
        }
    }

    private void ApplyConstraint(Rigidbody target, SplineConstraintMode mode, float attractForce = 0f)
    {
        float t = GetClosestTimeOnSpline(splineContainer.Spline, target.position);

        currentFrenetFrame = BuildFrenetFrameFromSpline(splineContainer.Spline, t);

        Vector3 pathOffset = CalculateOffset(target.position, currentFrenetFrame, mode);

        ApplyPosition(target, pathOffset, attractForce);

        ApplyVelocityCorrection(target, currentFrenetFrame, pathOffset);
    }

    private FrenetFrame BuildFrenetFrameFromSpline(Spline spline, float t)
    {
        splineContainer.Evaluate(t, out FrenetFrame splineFrame);
        return splineFrame;
    }

    private float GetClosestTimeOnSpline(Spline spline, Vector3 position)
    {
        SplineUtility.GetNearestPoint(spline, position, out _, out float t);
        return t;
    }

    private Vector3 CalculateOffset(Vector3 targetPosition, FrenetFrame frame, SplineConstraintMode mode)
    {
        Vector3 toTarget = targetPosition - frame.point;

        float offsetX = Vector3.Dot(toTarget, frame.binormal);
        float offsetY = Vector3.Dot(toTarget, frame.normal);

        return CalculateTargetOffset(offsetX, offsetY, frame, mode);
    }

    private Vector3 CalculateTargetOffset(float offsetX, float offsetY, FrenetFrame frame, SplineConstraintMode mode)
    {
        switch (mode)
        {
            case SplineConstraintMode.NormalOnly:
                return frame.normal * offsetY;

            case SplineConstraintMode.BinormalOnly:
                return frame.binormal * offsetX;

            case SplineConstraintMode.BinormalAndNormal:
                return frame.binormal * offsetX + frame.normal * offsetY;

            default:
                return Vector3.zero;
        }
    }

    private void ApplyPosition(Rigidbody target, Vector3 offset, float attractForce)
    {
        // Ignore very small offsets to avoid unnecessary calculations
        if (offset.sqrMagnitude < 0.000001f)
            return;

        // Instant snap to path
        if (attractForce <= 0f)
        {
            target.position -= offset;
        }
        else
        {
            // Smooth attraction towards the path
            target.position -= offset * attractForce * Time.fixedDeltaTime;
        }
    }

    private void ApplyVelocityCorrection(Rigidbody target, FrenetFrame frame, Vector3 offset)
    {
        Vector3 velocity = target.linearVelocity;

        // Preserve speed along the spline tangent
        float tangentialSpeed = Vector3.Dot(velocity, frame.tangent);

        // Remove lateral velocity component (normal + binormal)
        if (offset.sqrMagnitude > 0.0001f)
        {
            Vector3 lateralDir = offset.normalized;
            Vector3 unwantedVelocity = Vector3.Project(velocity, lateralDir);
            velocity -= unwantedVelocity;
        }

        // Reconstruct velocity while keeping tangential energy
        velocity = frame.tangent * tangentialSpeed +
                   Vector3.ProjectOnPlane(velocity, frame.tangent);

        target.linearVelocity = velocity;
    }

    public void SetSplineContainer(SplineContainer splineContainer)
    {
        this.splineContainer = splineContainer;
    }

    public void SetMode(SplineConstraintMode mode)
    {
        this.mode = mode;
    }

    private void OnDrawGizmos()
    {

#if UNITY_EDITOR
        if (visualizeFrame)
        {
            FrenetFrameUtility.DrawFrame(currentFrenetFrame);
        }
#endif
    }
}