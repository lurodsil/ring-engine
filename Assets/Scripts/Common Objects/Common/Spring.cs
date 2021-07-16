using UnityEngine;

public class Spring : RingEngineObject
{
    public bool IsHomingAttackEnable = false;
    public bool isStartPositionConstant = true;
    public bool isBoostCancel = false;
    public bool isTo3D = false;
    public float firstSpeed = 30f;
    public float keepVelocityDistance = 5f;
    public float OutOfControl = 0.4f;
    public Transform startPoint;
    public float DebugShotTimeLength = 2f;
    private float duration;
    private float outOfControl;
    private float dotTransformUpVector3Up;


    private void Awake()
    {
        objectState = StateSpring;
    }

    public void Start()
    {
        dotTransformUpVector3Up = Vector3.Dot(transform.up, Vector3.up);
    }

    #region State Spring
    private void StateSpringStart()
    {
        if (isTo3D)
        {
            player.sideViewPath = null;
        }

        OnStateStart?.Invoke();
        if (isStartPositionConstant)
        {
            player.transform.position = startPoint.position;
        }
        duration = player.stateMachine.lastStateTime + PhysicsExtension.Time(keepVelocityDistance, firstSpeed);
        outOfControl = player.stateMachine.lastStateTime + OutOfControl;
        player.rigidbody.velocity = Vector3.zero;
        if (isBoostCancel)
        {
            player.isBoosting = false;
        }

        player.afectMeshRotation = true;
    }
    private void StateSpring()
    {     

        if (Time.time < duration)
        {
            player.rigidbody.velocity = transform.up * firstSpeed;
        }

        if (Mathf.Abs(player.rigidbody.velocity.y) > 0)
        {
            startPoint.forward = player.rigidbody.velocity.normalized;
        }

        if (Time.time < outOfControl)
        {

            Vector3 horizontalVelocity = player.rigidbody.velocity.normalized;
            horizontalVelocity.y = 0;
            if (horizontalVelocity.magnitude > 0.1)
                player.transform.rotation = Quaternion.LookRotation(horizontalVelocity, Vector3.up);

            if (dotTransformUpVector3Up > 0.99f)
            {
                player.targetMeshRotation = Quaternion.FromToRotation(player.transform.up, Vector3.up) * player.transform.rotation;
            }
            else
            {
                player.targetMeshRotation = Quaternion.LookRotation(-startPoint.up, startPoint.forward);
            }
        }
        else
        {
            player.stateMachine.ChangeState(player.StateFall, gameObject);
        }

        if (player.IsGrounded())
        {
            player.stateMachine.ChangeState(player.StateMove3D, gameObject);
        }

    }
    private void StateSpringEnd()
    {
        OnStateEnd?.Invoke();
        player.canHomming = IsHomingAttackEnable;
        player.targetMeshRotation = Quaternion.Euler(Vector3.zero);
    }
    #endregion

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        GizmosExtension.DrawTrajectory(transform.position, transform.up, firstSpeed, DebugShotTimeLength, keepVelocityDistance);
        Gizmos.color = Color.red;
        GizmosExtension.DrawTrajectory(transform.position, transform.up, firstSpeed, OutOfControl, keepVelocityDistance);
    }
}