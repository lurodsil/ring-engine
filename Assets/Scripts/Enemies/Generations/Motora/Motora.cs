using UnityEngine;

[RequireComponent(typeof(MotoraAnimation))]
[RequireComponent(typeof(MotoraAudio))]
[RequireComponent(typeof(MotoraEffect))]
public class Motora : Enemy
{
    public override void Start()
    {
        base.Start();
    }

    public override void Update()
    {
        base.Update();

        if (stateMachine.initiated)
        {
            stateMachine.Update();
        }
        else
        {
            stateMachine.Initialize(gameObject, StateIdle);
        }
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
