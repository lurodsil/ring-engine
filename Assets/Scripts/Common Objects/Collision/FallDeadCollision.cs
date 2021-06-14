using UnityEngine;

public class FallDeadCollision : GenerationsObject
{
    public float Collision_Height = 48f;
    public float Collision_Width = 56f;
    public bool drown = false;

    public override void OnValidate()
    {
        gameObject.GetComponent<BoxCollider>().isTrigger = true;
        transform.localScale = new Vector3(Collision_Width, Collision_Height, 0.1f);
    }

    #region State Fall Dead
    void StateFallDeadStart()
    {
        //MainCamera.instance.playerIsAlive = false;
        player.drown = drown;
    }
    void StateFallDead()
    {
        if (drown)
        {
            player.rigidbody.velocity *= 0.9f;
        }

        if (Time.time > player.stateMachine.lastStateTime + 2)
        {
            GameManager.instance.LoadSceneWithLoading("Test Stage");
        }
    }
    void StateFallDeadEnd()
    {

    }
    #endregion

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(GameTags.playerTag))
        {
            player = other.GetComponent<Player>();

            player.stateMachine.ChangeState(StateFallDead, gameObject);
        }
    }
}