using UnityEngine;

public class EnemyGaniganiAnimation : MonoBehaviour
{
    private Animator animator;
    private EnemyGanigani enemyGanigani;

    void Start()
    {
        animator = GetComponent<Animator>();
        enemyGanigani = GetComponent<EnemyGanigani>();
    }

    void Update()
    {
        animator.SetFloat("Velocity", enemyGanigani.velocity * enemyGanigani.dotRight);
    }

    void StateExciteStart()
    {
        animator.SetTrigger("Excite");
    }

    void StateSeekStart()
    {
        animator.SetTrigger("Seek");
    }

    void StateAttackStart()
    {
        animator.SetTrigger("Attack");
    }

    void StateAttackSuccessStart()
    {
        animator.SetTrigger("Perform");
    }
}
