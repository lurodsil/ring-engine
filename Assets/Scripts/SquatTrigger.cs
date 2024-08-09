using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquatTrigger : CommonObject
{
    private void Start()
    {
        OnPlayerTriggerEnter.AddListener(Enter);
        OnPlayerTriggerExit.AddListener(Exit);
    }
    public void Enter()
    {
        player.canStand = false;
    }

    public void Exit()
    {
        player.canStand = true;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        GizmosExtension.DrawBoxBoundaries(GetComponent<BoxCollider>());
    }
}
