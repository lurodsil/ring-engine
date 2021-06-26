using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGaniganiLW : Enemy
{
    public override void Start()
    {
        base.Start();

        stateMachine.Initialize(this, StateIdle);
    }

    #region State Idle
    private void StateIdleStart()
    {

    }
    private void StateIdle()
    {

    }
    private void StateIdleEnd()
    {

    }
    #endregion
}
