using UnityEngine;

public class EnemyEFighter : Enemy
{
    private bool startRotation;
    public float velocity { get; set; }

    [Header("Egg Fighter Parameters")]
    public float walkTurnDelay = 1.5f;

    new void Start()
    {
        base.Start();

        stateMachine.Initialize(this, StateIdle);
    }

    new void Update()
    {
        base.Update();

        if (isGrounded)
        {
            transform.rotation = Quaternion.FromToRotation(transform.up, groundInfo.normal) * transform.rotation;
        }
        else
        {
            transform.rotation = Quaternion.FromToRotation(transform.up, Vector3.up) * transform.rotation;
        }

        if (waypointIndex > waypoints.Length - 1)
        {
            waypointIndex = 0;
        }

        stateMachine.OnUpdate();
    }

    #region State
    void StateStart()
    {

    }
    void State()
    {

    }
    void StateEnd()
    {

    }
    #endregion

    #region State Idle
    void StateIdleStart()
    {
        velocity = 0;
    }
    void StateIdle()
    {
        if (movementType == EnemyMovementType.Waypoint)
        {
            stateMachine.ChangeState(StateWalk);
        }

        if (target)
        {
            stateMachine.ChangeState(StateLook);
        }
    }
    void StateIdleEnd()
    {

    }
    #endregion

    #region State Walk
    void StateWalkStart()
    {

    }
    void StateWalk()
    {
        velocity = Mathf.MoveTowards(velocity, 2, 2 * Time.deltaTime);

        Quaternion rotation = Quaternion.LookRotation(transform.DirectionTo(waypoints[waypointIndex]), transform.up);

        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, 5 * Time.deltaTime);

        if (isGrounded)
        {
            rigidbody.velocity = transform.forward * velocity;
        }

        if (Vector3.Distance(transform.position, waypoints[waypointIndex]) < 1)
        {
            stateMachine.ChangeState(StateWalkTurn);
            waypointIndex++;
        }

        if (target)
        {
            stateMachine.ChangeState(StateIdle);
        }
    }
    void StateWalkEnd()
    {

    }
    #endregion

    #region State Walk Turn
    void StateWalkTurnStart()
    {

    }
    void StateWalkTurn()
    {
        stateMachine.ChangeState(StateWalk, walkTurnDelay);

        if (startRotation)
        {
            Quaternion rotation = Quaternion.LookRotation(transform.DirectionTo(waypoints[waypointIndex]), transform.up);

            transform.rotation = Quaternion.Lerp(transform.rotation, rotation, 5 * Time.deltaTime);
        }
    }
    void StateWalkTurnEnd()
    {
        startRotation = false;
    }
    #endregion

    #region State Threat
    void StateThreatStart()
    {

    }
    void StateThreat()
    {
        if (!target)
        {
            stateMachine.ChangeState(StateSeek);
        }
        else
        {
            if (Vector3.Distance(transform.position, target.transform.position) < 3)
            {
                stateMachine.ChangeState(StateAttack);
            }
        }
    }
    void StateThreatEnd()
    {

    }
    #endregion

    #region State Attack
    void StateAttackStart()
    {

    }
    void StateAttack()
    {
        if (target)
        {
            stateMachine.ChangeState(StateLook, 1);
        }
        else
        {
            stateMachine.ChangeState(StateSeek);
        }
    }
    void StateAttackEnd()
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

    #region State Run
    void StateChaseStart()
    {
        velocity = 5;
    }
    void StateChase()
    {
        Quaternion rotation = Quaternion.LookRotation(transform.DirectionTo(lastTargetPosition), transform.up);

        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, 10 * Time.deltaTime);

        if (target)
        {
            if (Vector3.Distance(transform.position, lastTargetPosition) < 2f)
            {
                velocity = 0;
                stateMachine.ChangeState(StateAttack);
            }
        }
        else
        {
            if (Vector3.Distance(transform.position, lastTargetPosition) < 1f)
            {
                velocity = 0;
                stateMachine.ChangeState(StateSeek);
            }
        }

        if (isGrounded)
        {
            rigidbody.velocity = transform.forward * velocity;
        }

    }
    void StateChaseEnd()
    {

    }
    #endregion

    #region State Look
    void StateLookStart()
    {

    }
    void StateLook()
    {
        if (isPlayerChase)
        {
            stateMachine.ChangeState(StateChase, 2f);
        }
        else
        {
            stateMachine.ChangeState(StateThreat);
        }
    }
    void StateLookEnd()
    {

    }
    #endregion

    #region State AttackSuccess
    void StateAttackSuccessStart()
    {

    }
    void StateAttackSuccess()
    {
        stateMachine.ChangeState(StateIdle, 1);
    }
    void StateAttackSuccessEnd()
    {

    }
    #endregion   

    //Animation event
    void WalkTurn()
    {
        rigidbody.velocity = transform.up * 10;
        startRotation = true;
    }

    //EFighter hand receiver
    public void HitPlayer()
    {
        stateMachine.ChangeState(StateAttackSuccess);
    }

    //Animation event
    void Footstep()
    {
        if (stateMachine.currentStateName == "StateWalk")
        {
            velocity = 0.4f;
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (!isAlive && collision.collider.CompareTag(GameTags.enemyTag))
        {
            collision.gameObject.GetComponent<IDamageable>().TakeDamage(gameObject);

            TakeDamage(collision.gameObject);
        }
    }
}

