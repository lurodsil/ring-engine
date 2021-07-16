using UnityEngine;

public class JumpCollision : GenerationsObject
{
    public float Collision_Height = 2f;
    public float Collision_Width = 5f;
    public float ImpulseSpeedOnBoost = 50f;
    public float ImpulseSpeedOnNormal = 50f;
    public bool IsStartVelocityConstant = true;
    public float OutOfControl = 0.49f;
    public float Pitch = 5;
    public float SpeedMin = 20f;
    public float TerrainIgnoreTime = 0.25f;
    public float m_ClassicSpinThreshold = 30f;
    public bool m_IsGroundOnly = false;
    public float trajectoryLength = 1;

    private float duration;
    private float outOfControl;

    public override void OnValidate()
    {
        if (!gameObject.GetComponent<BoxCollider>())
        {
            BoxCollider boxCollider = gameObject.AddComponent<BoxCollider>();
            boxCollider.isTrigger = true;
        }
        transform.localScale = new Vector3(Collision_Width, Collision_Height, 1);
    }

    #region State Jump Collision
    private void StateJumpCollisionStart()
    {
        if (player.isBoosting)
        {
            player.rigidbody.velocity = transform.forward * ImpulseSpeedOnBoost;
        }
        else
        {
            player.rigidbody.velocity = transform.forward * ImpulseSpeedOnNormal;
        }

        duration = player.stateMachine.lastStateTime + TerrainIgnoreTime;
        outOfControl = player.stateMachine.lastStateTime + OutOfControl;
    }

    private void StateJumpCollision()
    {

        //player.groundInfo.SearchGroundHighSpeed();
        Vector3 horizontalVelocity = player.rigidbody.velocity.normalized;
        horizontalVelocity.y = 0;
        if (horizontalVelocity.magnitude > 0.1)
            player.transform.rotation = Quaternion.LookRotation(horizontalVelocity, Vector3.up);

        //if (Time.time > duration)
        //{
        //    if (player.IsGrounded())
        //    {
        //        if (player.isBoosting)
        //        {
        //            player.rigidbody.velocity = player.transform.forward * ImpulseSpeedOnBoost;
        //        }
        //        else
        //        {
        //            player.rigidbody.velocity = player.transform.forward * ImpulseSpeedOnNormal;
        //        }

        //        player.PutOnGround();
        //    }
        //}

        if (Time.time > player.stateMachine.lastStateTime + OutOfControl)
        {
            player.stateMachine.ChangeState(player.StateTransition, gameObject);
            return;
        }
    }

    private void StateJumpCollisionEnd()
    {

    }

    #endregion State Jump Collision

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(GameTags.playerTag))
        {
            player = other.GetComponent<Player>();
            player.stateMachine.ChangeState(StateJumpCollision, gameObject);
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