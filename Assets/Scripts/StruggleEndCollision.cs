using UnityEngine;

public class StruggleEndCollision : CommonObject
{
    public bool active;

    private void Awake()
    {
        OnPlayerTriggerEnter!.AddListener(StruggleEnd);
    }

    private void StruggleEnd()
    {
        if (active)
        {
            player.isStruggling = false;

            player.stateMachine.ChangeState(player.StateFall, gameObject);            
        }
    }
}
