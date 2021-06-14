using UnityEngine;

public class EnemyBeetle : Enemy
{
    [Header("Enemy Properties")]
    public GameObject bullet;
    public GameObject gun;


    new private void Update()
    {
        base.Update();

        if (isTargetLook)
        {
            if (target)
            {
                Quaternion rotation = Quaternion.LookRotation((target.transform.position - transform.position).normalized, transform.up);
                transform.rotation = Quaternion.Lerp(transform.rotation, rotation, 10 * Time.deltaTime);
            }
        }
    }

    #region State
    void StateIdleStart()
    {

    }
    void StateIdle()
    {

    }
    void StateIdleEnd()
    {

    }
    #endregion
}
