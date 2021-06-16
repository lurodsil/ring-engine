using RingEngine;
using UnityEngine;

public class Spring : RingEngineObject
{
    public float DebugShotTimeLength = 2f;
    public float FirstSpeed = 30f;
    public bool IsHomingAttackEnable = false;
    public float KeepVelocityDistance = 5f;
    public float OutOfControl = 0.4f;
    public bool isBoostCancel = false;
    public Transform startPoint;
    private float duration;
    private float outOfControl;
    private float dotTransformUpVector3Up;
    public bool isStartPositionConstant = true;

    public void Start()
    {
        dotTransformUpVector3Up = Vector3.Dot(transform.up, Vector3.up);
    }

    #region State Spring
    void StateSpringStart()
    {
        OnStateStart?.Invoke();
        if (isStartPositionConstant)
        {
            player.transform.position = startPoint.position;
        }
        duration = player.stateMachine.lastStateTime + MathfExtension.Time(KeepVelocityDistance, FirstSpeed);
        outOfControl = player.stateMachine.lastStateTime + OutOfControl;
        player.rigidbody.velocity = Vector3.zero;
        if (isBoostCancel)
        {
            player.isBoosting = false;
        }
    }
    void StateSpring()
    {
        player.SearchGround(); ;

        if (Time.time < duration)
        {
            player.rigidbody.velocity = transform.up * FirstSpeed;
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
    void StateSpringEnd()
    {
        OnStateEnd?.Invoke();
        player.canHomming = IsHomingAttackEnable;
    }
    #endregion

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(GameTags.playerTag))
        {
            player = other.GetComponent<Player>();
            player.stateMachine.ChangeState(StateSpring, gameObject);
        }
    }

    void OnDrawGizmos()
    {

        Gizmos.color = Color.green;
        GizmosExtension.DrawTrajectory(transform.position, transform.up, FirstSpeed, DebugShotTimeLength, KeepVelocityDistance);
        Gizmos.color = Color.red;
        GizmosExtension.DrawTrajectory(transform.position, transform.up, FirstSpeed, OutOfControl, KeepVelocityDistance);
    }
}