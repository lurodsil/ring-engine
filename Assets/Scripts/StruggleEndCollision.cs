using UnityEngine;

public class StruggleEndCollision : GenerationsObject
{
    private void OnTriggerEnter(Collider other)
    {
        if (active && other.CompareTag(GameTags.playerTag))
        {
            player = other.GetComponent<Player>();

            player.stateMachine.ChangeState(player.StateFall, gameObject);

            Deactivate();
        }
    }
}
