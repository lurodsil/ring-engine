using UnityEngine;

public class StumbleCollision : RingEngineObject
{
    public float outOfControl = 0.45f;
    public float stumbleUpVelocity = 13f;
    public float keepVelocityRate = 0.3f;

    #region State Stumble
    private void StateStumbleStart()
    {
        Vector3 rigidbodyKeepVelocity = player.rigidbody.velocity * keepVelocityRate;
        rigidbodyKeepVelocity.y = stumbleUpVelocity;
        player.rigidbody.velocity = rigidbodyKeepVelocity;
    }
    private void StateStumble()
    {
        player.SearchGround();

        player.stateMachine.ChangeState(player.StateMove3D, gameObject, outOfControl);
    }
    private void StateStumbleEnd()
    {
    }
    #endregion State

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(GameTags.playerTag))
        {
            player = other.GetComponent<Player>();

            if (player.stateMachine.currentStateName == "StateMove3D")
            {
                player.stateMachine.ChangeState(StateStumble, gameObject);
            }
        }
    }
}