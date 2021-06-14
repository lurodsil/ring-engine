using UnityEngine;

public class StumbleCollision : GenerationsObject
{
    public float Collision_Height = 1.7f;
    public float Collision_Length = 4.5f;
    public float Collision_Width = 3f;
    public float DefaultStatus = 0f;
    public float LaunchVelocity = 13f;
    public float NoControlTime = 0.45f;
    public float Shape_Type = 0f;
    public float keepVelocityRate = 0.3f;

    public override void OnValidate()
    {
        transform.localScale = new Vector3(Collision_Width, Collision_Height, Collision_Length);
    }

    #region State Stumble
    private void StateStumbleStart()
    {
        Vector3 rigidbodyKeepVelocity = player.rigidbody.velocity * keepVelocityRate;
        rigidbodyKeepVelocity.y = LaunchVelocity;
        player.rigidbody.velocity = rigidbodyKeepVelocity;
    }
    private void StateStumble()
    {
        player.SearchGround();

        player.stateMachine.ChangeState(player.StateMove3D, gameObject, NoControlTime);
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