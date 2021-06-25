using UnityEngine;

public class StumbleCollision : RingEngineObject
{
    public float outOfControl = 0.45f;
    public float stumbleUpVelocity = 13f;
    public float keepVelocityRate = 0.3f;

    #region State Stumble
    private void StateStumbleStart()
    {
        OnStateStart?.Invoke();
        Vector3 playerKeepVelocity = player.rigidbody.velocity * keepVelocityRate;
        playerKeepVelocity.y = stumbleUpVelocity;
        player.rigidbody.velocity = playerKeepVelocity;

        player.isBoosting = false;
        player.canHomming = false;
    }
    private void StateStumble()
    {
        player.stateMachine.ChangeState(player.StateMove3D, gameObject, outOfControl);
    }
    private void StateStumbleEnd()
    {
        OnStateEnd?.Invoke();
    }
    #endregion State

    public override void OnTriggerEnter(Collider other)
    {
        if (active && other.CompareTag(GameTags.playerTag))
        {
            player = other.GetComponent<Player>();

            if (player.stateMachine.currentStateName == "StateMove3D")
            {
                player.stateMachine.ChangeState(StateStumble, gameObject);
            }
        }
    }
}