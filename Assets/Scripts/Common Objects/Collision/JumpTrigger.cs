using UnityEngine;

public class JumpTrigger : CommonObject
{
    public float ImpulseSpeedOnBoost = 50f;
    public float ImpulseSpeedOnNormal = 50f;
    public float OutOfControl = 0.49f;
    public float SpeedMin = 20f;

    private float duration;
    private float outOfControl;

    private void Awake()
    {
        OnPlayerTriggerEnter!.AddListener(JumpTriggerStart);
    }

    #region State Jump Trigger
    private void StateJumpTriggerStart()
    {
        outOfControl = player.stateMachine.lastStateTime + OutOfControl;

        if (player.rigidbody.linearVelocity.magnitude > player.currentPhysicsMotion.maxSpeed)
        {
            player.rigidbody.linearVelocity = transform.forward * ImpulseSpeedOnBoost;

            player.SendMessage("StateBoostEnd");
        }
        else
        {
            player.rigidbody.linearVelocity = transform.forward * ImpulseSpeedOnNormal;
        }
    }

    private void StateJumpTrigger()
    {
        Vector3 horizontalVelocity = player.rigidbody.linearVelocity.normalized;
        horizontalVelocity.y = 0;
        if (horizontalVelocity.magnitude > 0.1)
            player.transform.rotation = Quaternion.LookRotation(horizontalVelocity, Vector3.up);


        if (Time.time > outOfControl)
        {
            if (player.isSnowboarding)
            {
                player.stateMachine.ChangeState(player.StateSnowBoardFall, gameObject);
            }
            else
            {
                player.stateMachine.ChangeState(player.StateFall, gameObject);
            }
            
            return;
        }  
    }

    private void StateJumpTriggerEnd()
    {

    }

    #endregion

    private void JumpTriggerStart()
    {
        if (player.rigidbody.linearVelocity.magnitude > SpeedMin)
        {
            if (Vector3.Dot(player.transform.forward, transform.forward) > 0.2f)
            {
                player.stateMachine.ChangeState(StateJumpTrigger, gameObject);
            }
        }
        
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        GizmosExtension.DrawTrajectory(transform.position, transform.forward, ImpulseSpeedOnNormal, 2);
        Gizmos.color = Color.blue;
        GizmosExtension.DrawTrajectory(transform.position, transform.forward, ImpulseSpeedOnBoost, 2);
        Gizmos.color = Color.red;
        GizmosExtension.DrawTrajectory(transform.position, transform.forward, ImpulseSpeedOnNormal, OutOfControl);
        GizmosExtension.DrawTrajectory(transform.position, transform.forward, ImpulseSpeedOnBoost, OutOfControl);
    }
}