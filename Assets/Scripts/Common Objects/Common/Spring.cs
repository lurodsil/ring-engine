using UnityEngine;

public class Spring : RingEngineObject
{
    public bool IsHomingAttackEnable = false;
    public bool isStartPositionConstant = true;
    public bool isBoostCancel = false;
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
            if (dotTransformUpVector3Up > 0.99f)
            {
                player.transform.rotation = Quaternion.FromToRotation(player.transform.up, Vector3.up) * player.transform.rotation;
            }
            else
            {
                player.transform.rotation = Quaternion.LookRotation(-startPoint.up, startPoint.forward);
            }
        }
        else
        {
            player.stateMachine.ChangeState(player.StateFall, gameObject);
        }
    }
    private void StateSpringEnd()
    {
        OnStateEnd?.Invoke();
        player.canHomming = IsHomingAttackEnable;
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