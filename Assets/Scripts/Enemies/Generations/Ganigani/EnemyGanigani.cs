using UnityEngine;

public class EnemyGanigani : Enemy
{
    public float dotRight { get; set; }
    [Header("Enemy Properties")]
    public bool isWaitOnEnd = false;
    public float waitSeconds = 3;
    public Transform missilePointR;
    public Transform missilePointL;
    public GameObject missile;
    private GameObject missileR;
    private GameObject missileL;

    public float velocity { get; set; }

    new void Start()
    {
        base.Start();

        stateMachine.Initialize(this, StateIdle);
    }

    new void Update()
    {
        base.Update();

        if (waypointIndex > waypoints.Length - 1)
        {
            waypointIndex = 0;
        }

        stateMachine.OnUpdate();
    }

    #region State
    void StateIdleStart()
    {

    }
    void StateIdle()
    {
        if (target)
        {
            stateMachine.ChangeState(StateExcite);
        }
        else if (movementType == EnemyMovementType.Waypoint)
        {
            stateMachine.ChangeState(StateMove);
        }

    }
    void StateIdleEnd()
    {

    }
    #endregion

    #region State
    void StateMoveStart()
    {
        velocity = 2f;
    }
    void StateMove()
    {
        dotRight = Vector3.Dot(transform.right, (waypoints[waypointIndex] - transform.position).normalized);

        if (dotRight > 0)
        {
            rigidbody.velocity = transform.right * velocity;
        }
        else
        {
            rigidbody.velocity = -transform.right * velocity;
        }

        if (Vector3.Distance(transform.position, waypoints[waypointIndex]) < 0.1f)
        {
            if (isWaitOnEnd)
            {
                stateMachine.ChangeState(StateWait);
                waypointIndex++;
            }
            else
            {
                waypointIndex++;
            }
        }

        if (target)
        {
            stateMachine.ChangeState(StateExcite);
        }

    }
    void StateMoveEnd()
    {

    }
    #endregion

    #region State Wait
    void StateWaitStart()
    {
        velocity = 0;
    }
    void StateWait()
    {
        if (target)
        {
            stateMachine.ChangeState(StateExcite);
        }

        stateMachine.ChangeState(StateMove, waitSeconds);
    }
    void StateWaitEnd()
    {

    }
    #endregion

    #region State
    void StateExciteStart()
    {
        velocity = 0;
    }
    void StateExcite()
    {
        stateMachine.ChangeState(StateAlert);
    }
    void StateExciteEnd()
    {

    }
    #endregion

    #region State Alert
    void StateAlertStart()
    {

    }
    void StateAlert()
    {
        if (target)
        {
            if (Vector3.Distance(transform.position, target.transform.position) < 3)
            {
                stateMachine.ChangeState(StateAttack);
            }

            if (enemyType == EnemyType.Active)
            {

            }
        }
        else
        {
            stateMachine.ChangeState(StateSeek);
        }
    }
    void StateAlertEnd()
    {

    }
    #endregion

    #region State Seek
    void StateSeekStart()
    {

    }
    void StateSeek()
    {
        stateMachine.ChangeState(StateIdle);
    }
    void StateSeekEnd()
    {

    }
    #endregion

    #region State Attack
    void StateAttackStart()
    {

    }
    void StateAttack()
    {
        stateMachine.ChangeState(StateIdle);
    }
    void StateAttackEnd()
    {

    }
    #endregion

    #region State AttackSuccess
    void StateAttackSuccessStart()
    {

    }
    void StateAttackSuccess()
    {
        stateMachine.ChangeState(StateIdle);
    }
    void StateAttackSuccessEnd()
    {

    }
    #endregion

    void HitPlayer()
    {
        stateMachine.ChangeState(StateAttackSuccess);
    }

    void StateDamageStart()
    {
        rigidbody.freezeRotation = false;
    }

    void SpawnMissile()
    {
        missileL = Instantiate(missile, missilePointL.position, missilePointL.rotation, missilePointL);
        missileR = Instantiate(missile, missilePointR.position, missilePointR.rotation, missilePointR);
    }

    void Shot()
    {
        missileL.SendMessage("Shot", true, SendMessageOptions.DontRequireReceiver);
        missileR.SendMessage("Shot", true, SendMessageOptions.DontRequireReceiver);
    }
}
