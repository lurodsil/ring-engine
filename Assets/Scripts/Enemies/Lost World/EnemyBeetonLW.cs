using UnityEngine;

public class EnemyBeetonLW : Enemy
{
    public Transform shotPosition;
    public Shot shot;
    public float shotVelocity = 10;

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

    public void Shot()
    {
        Shot shotInstance = Instantiate(shot, shotPosition.position, Quaternion.identity);
        shotInstance.transform.LookAt(target.transform.position + (target.transform.up * 0.5f));
    }

    #region State Idle
    private void StateIdleStart()
    {

    }
    private void StateIdle()
    {
        if (movementType != EnemyMovementType.None)
        {
            stateMachine.ChangeState(StateMove);
        }

        if (target)
        {
            stateMachine.ChangeState(StateAttack);
        }
    }
    private void StateIdleEnd()
    {

    }
    #endregion

    #region State Move
    private void StateMoveStart()
    {

    }
    private void StateMove()
    {
        switch (movementType)
        {
            case EnemyMovementType.None: break;
            case EnemyMovementType.Waypoint: SimpleWaypointMovement(); break;
            case EnemyMovementType.Bezier: break;
        }

        if (target)
        {
            stateMachine.ChangeState(StateAttack);
        }
    }
    private void StateMoveEnd()
    {

    }
    #endregion

    #region State Attack
    private void StateAttackStart()
    {
        rigidbody.velocity = Vector3.zero;
    }
    private void StateAttack()
    {
        if (!target)
        {
            stateMachine.ChangeState(StateIdle);
            return;
        }

        if (Time.time > stateMachine.lastStateTime + 2)
        {
            stateMachine.ChangeState(StateIdle);
        }
        else
        {
            transform.LookAt(new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z));
        }
    }
    private void StateAttackEnd()
    {
        if (target)
        {
            GetComponent<Animator>().SetTrigger("Attack");
        }
    }
    #endregion
}
