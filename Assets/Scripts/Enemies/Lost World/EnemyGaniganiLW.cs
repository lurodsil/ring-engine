using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGaniganiLW : Enemy
{
    public Transform shotPositionL, shotPositionR;
    public Shot shot;
    public float shotForce = 10;
    public bool sideShot;

    Animator animator;
    float dotRightVelocity;

    public override void Start()
    {
        base.Start();

        animator = GetComponent<Animator>();

        stateMachine.Initialize(this, StateIdle);
    }

    public override void Update()
    {
        base.Update();

        dotRightVelocity = Vector3.Dot(transform.right, rigidbody.velocity);

        animator.SetFloat("DotRightVelocity", dotRightVelocity);

        stateMachine.OnUpdate();
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
        animator.SetTrigger("Attack");
    }
    private void StateAttack()
    {
        if (!target)
        {
            stateMachine.ChangeState(StateIdle);
            return;
        }

        if (Time.time > stateMachine.lastStateTime + 1.8f)
        {
            stateMachine.ChangeState(StateIdle);
        }
    }
    private void StateAttackEnd()
    {
        if (target)
        {
            animator.SetTrigger("Shot");
            Shot();
        }
    }
    #endregion

    public void Shot()
    {
        Quaternion leftRotation = shotPositionL.rotation;
        Quaternion rightRotation = shotPositionR.rotation;

        if (sideShot)
        {
            Vector3 directionLeft = Vector3.Lerp(-transform.right, transform.up, 0.5f);
            Vector3 directionRight = Vector3.Lerp(transform.right, transform.up, 0.5f);

            leftRotation = Quaternion.LookRotation(directionLeft);
            rightRotation = Quaternion.LookRotation(directionRight);
        }     

        Shot shotInstanceL = Instantiate(shot, shotPositionL.position, leftRotation);
        Shot shotInstanceR = Instantiate(shot, shotPositionR.position, rightRotation);

        shotInstanceL.initialForce = shotForce;
        shotInstanceR.initialForce = shotForce;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag(GameTags.playerTag))
        {
            IDamageable damageable = collision.collider.GetComponent<IDamageable>();
            damageable.TakeDamage(gameObject);
        }
    }
}
