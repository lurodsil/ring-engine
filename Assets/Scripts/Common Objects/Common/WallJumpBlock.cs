using UnityEngine;

public class WallJumpBlock : CommonStatefulObject
{
    public float SizeX = 2f;
    public float SizeY = 5f;
    public float SizeZ = 0.1f;


    public float jumpForce = 30;

    private void Start()
    {
        objectState = StateWallJump;
    }

    #region State Wall Jump
    private void StateWallJumpStart()
    {
        player.StoreRigidbodyState();
        player.rigidbody.drag = 20;
        player.transform.rotation = Quaternion.LookRotation(-transform.forward + transform.right * 0.1f);
    }
    private void StateWallJump()
    {
        Vector3 jumpDirection = transform.forward + Vector3.up;

        Debug.DrawRay(player.transform.position, jumpDirection, Color.red);

        if (player.IsGrounded())
        {
            player.stateMachine.ChangeState(player.StateIdle, gameObject);
        }

        if (Input.GetButtonDown(XboxButton.A))
        {
            player.rigidbody.velocity = Vector3.zero;

            player.rigidbody.drag = 0;

            player.rigidbody.AddForce(jumpDirection.normalized * jumpForce, ForceMode.Impulse);

            player.stateMachine.ChangeState(player.StateFall, gameObject);
        }

        if (!Physics.Raycast(player.transform.position, -transform.forward, .6f))
        {
            player.stateMachine.ChangeState(player.StateFall, gameObject);
        }
    }
    private void StateWallJumpEnd()
    {
        player.tangentMultiplier = Vector3.Dot(player.sideViewKnot.tangent, transform.forward);
        player.ResetRigidbodyState();
        player.transform.forward = transform.forward;
        player.outOfControl = 2;
    }

    #endregion State
}