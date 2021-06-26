using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleEnemy : Enemy
{
    private Animator animator;

    public override void Start()
    {
        base.Start();
        animator = GetComponent<Animator>();
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
        rigidbody.velocity = Vector3.zero;
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
        animator.SetBool("IsAttacking", true);
    }
    private void StateAttack()
    {
        if (!target)
        {
            stateMachine.ChangeState(StateIdle);
            return;
        }
        else
        {
            transform.LookAt(new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z));
            rigidbody.velocity = transform.forward * attackMovementVelocity;
        }
    }
    private void StateAttackEnd()
    {
        animator.SetBool("IsAttacking", false);
    }
    #endregion

    #region State Success
    private void StateAttackSuccessStart()
    {
        rigidbody.velocity = Vector3.zero;
    }
    private void StateAttackSuccess()
    {
        transform.rotation = Quaternion.FromToRotation(transform.up, Vector3.up) * transform.rotation;
        stateMachine.ChangeState(StateIdle, 5);
    }
    private void StateAttackSuccessEnd()
    {

    }
    #endregion

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag(GameTags.playerTag))
        {
            IDamageable damageable = collision.collider.GetComponent<IDamageable>();
            damageable.TakeDamage(gameObject);
            stateMachine.ChangeState(StateAttackSuccess);
        }
    }

    public void PlayDamageAnimation()
    {
        animator.SetTrigger("Damage");
    }
}
