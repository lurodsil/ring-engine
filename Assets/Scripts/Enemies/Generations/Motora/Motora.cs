using UnityEngine;

[RequireComponent(typeof(MotoraAnimation))]
[RequireComponent(typeof(MotoraAudio))]
[RequireComponent(typeof(MotoraEffect))]
public class Motora : Enemy
{
    public override void Start()
    {
        base.Start();

        stateMachine.Initialize(this, StateIdle);
    }

    public override void Update()
    {
        base.Update();

        stateMachine.OnUpdate();
    }

    #region State Idle
    private void StateIdleStart()
    {

    }
    private void StateIdle()
    {
        if (movementType == EnemyMovementType.Waypoint)
        {
            stateMachine.ChangeState(StateMove);
        }
    }
    private void StateIdleEnd()
    {

    }
    #endregion

    #region State Move
    private void StateMovetart()
    {

    }
    private void StateMove()
    {
        SimpleWaypointMovement();
    }
    private void StateMoveEnd()
    {

    }
    #endregion
}
