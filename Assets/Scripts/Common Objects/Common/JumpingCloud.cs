using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpingCloud : CommonObject
{
    public float jumpForceLow = 15;
    public float jumpForceHigh = 30;

    private void Awake()
    {
        OnPlayerTriggerEnter!.AddListener(CloudJumpStart);
    }

    #region State Cloud Jump
    private void StateCloudJumpStart()
    {
        if (Input.GetButton(XboxButton.A))
        {
            player.rigidbody.velocity = transform.up * jumpForceHigh;
        }
        else
        {
            player.rigidbody.velocity = transform.up * jumpForceLow;
        }       
    }

    private void StateCloudJump()
    {
        player.stateMachine.ChangeState(player.StateFall, gameObject);        
    }

    private void StateCloudJumpEnd()
    {

    }

    #endregion State Jump Collision

    private void CloudJumpStart()
    {
        if (!player.IsGrounded() && player.rigidbody.velocity.y < 0)
        {
            player.stateMachine.ChangeState(StateCloudJump, gameObject);
        }
    }
}
