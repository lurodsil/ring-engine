using UnityEngine;

public class EnemyEFighterAnimation : MonoBehaviour
{
    private Animator animator;
    private EnemyEFighter enemyEFighter;

    void Start()
    {
        animator = GetComponent<Animator>();
        enemyEFighter = GetComponent<EnemyEFighter>();
        animator.SetBool("IsAlive", true);
    }

    private void Update()
    {
        animator.SetFloat("Velocity", enemyEFighter.velocity);
    }

    void StateSeekStart()
    {
        animator.SetTrigger("Seek");
    }

    void StateLookStart()
    {
        animator.SetInteger("LookID", Random.Range(0, 2));
        animator.SetTrigger("Look");
    }

    void StateWalkTurnStart()
    {
        animator.SetTrigger("Turn");
    }

    void StateThreatStart()
    {
        animator.SetBool("Threat", true);
    }

    void StateThreatEnd()
    {
        animator.SetBool("Threat", false);
    }

    void StateAttackStart()
    {
        animator.SetTrigger("Attack");
    }

    void StateAttackSuccessStart()
    {
        animator.SetTrigger("AttackSuccess");
    }

    public void TakeDamage()
    {
        animator.SetBool("IsAlive", false);
        animator.SetTrigger("Destroy");
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag(GameTags.playerTag))
        {
            animator.SetInteger("DirectionID", (int)VectorExtension.InverseDirection(transform, collision.collider.transform.position));
        }
    }
}
