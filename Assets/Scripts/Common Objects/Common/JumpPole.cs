using UnityEngine;

public class JumpPole : CommonStatefulObject
{
    public float addMinVelocity = 10f;
    public float addMaxVelocity = 30f;
    public float acceleration = 5f;

    private void Start()
    {
        objectState = StateJumpPole;
    }

    #region State Jump Pole
    private void StateJumpPoleStart()
    {
        OnStateStart?.Invoke();

        player.transform.forward = transform.forward;

        float absoluteYVelocity = Mathf.Abs(player.rigidbody.linearVelocity.y);
        float clampedVelocity = Mathf.Clamp(absoluteYVelocity + acceleration, addMinVelocity, addMaxVelocity);

        player.rigidbody.linearVelocity = Vector3.up * clampedVelocity;        
    }
    private void StateJumpPole()
    {
        if (player.rigidbody.linearVelocity.y < 10)
        {
            player.stateMachine.ChangeState(player.StateFall, gameObject);
        }
    }
    private void StateJumpPoleEnd()
    {
        OnStateEnd?.Invoke();
    }
    #endregion
}