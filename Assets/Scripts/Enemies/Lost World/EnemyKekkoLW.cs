using UnityEngine;

public class EnemyKekkoLW : Enemy {

    public float blowForce = 100;
    public new ParticleSystem particleSystem;

    Animator animator;

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

    }
    private void StateIdle()
    {
        if (target)
        {
            stateMachine.ChangeState(StateAttack);
        }
    }
    private void StateIdleEnd()
    {

    }
    #endregion


    #region State Attack
    private void StateAttackStart()
    {
        animator.SetTrigger("Attack");
    }
    private void StateAttack()
    {
        if (!target)
        {
            stateMachine.ChangeState(StateIdle);
            return;
        }

        if (Time.time > stateMachine.lastStateTime + 4)
        {
            stateMachine.ChangeState(StateIdle);
        }
    }
    private void StateAttackEnd()
    {
    }
    #endregion

    public void Blow()
    {
        particleSystem.Play();

        if (target)
        {
            Rigidbody rb = target.GetComponent<Rigidbody>();

            float distance = Vector3.Distance(transform.position, target.transform.position);

            Vector3 direction = transform.DirectionTo(target.transform.position);

            rb.AddForce(direction * (blowForce - distance), ForceMode.Impulse);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag(GameTags.playerTag))
        {
            IDamageable damageable = collision.collider.GetComponent<IDamageable>();
            damageable.TakeDamage(gameObject);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        
    }
}
