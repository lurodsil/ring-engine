using UnityEngine;

public class Balloon : RingEngineObject
{
    public float BalloonColor = 0;
    public float Dimension = 0;
    public float GroundOffset = 0;

    public bool IsDefaultPositionRecover = true;
    public bool IsGroup = false;

    public float ReviveTime = 3;
    public float SpeedMax = 20;
    public float SpeedMin = 10;
    public float upVelocity = 10;
    public float keepVelocityRate = 0.8f;

    #region State Balloon
    private void StateBalloonStart()
    {
        Vector3 playerKeepVelocity = player.rigidbody.velocity.normalized * Random.Range(SpeedMin,SpeedMax);
        playerKeepVelocity.y = upVelocity;
        player.rigidbody.velocity = playerKeepVelocity;
    }

    private void StateBalloon()
    {
        player.stateMachine.ChangeState(player.StateTransition, gameObject);
    }

    private void StateBalloonEnd()
    {
    }
    #endregion 

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(GameTags.playerTag))
        {
            player = GetComponent<Player>();
            player.stateMachine.ChangeState(StateBalloon, gameObject);
        }
    }
}
