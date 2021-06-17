using System.Collections;
using UnityEngine;

public class Balloon : RingEngineObject
{
    public float ReviveTime = 3;
    public float speedMax = 20;
    public float speedMin = 10;
    public float upVelocity = 10;
    public float keepVelocityRate = 0.8f;
    public GameObject ballonHolder;

    private void Start()
    {
        objectState = StateBalloon;
    }

    private void Update()
    {
        if (active)
        {
            ballonHolder.transform.localScale = Vector3.Lerp(ballonHolder.transform.localScale, Vector3.one, 5 * Time.deltaTime);
        }
        else
        {
            ballonHolder.transform.localScale = Vector3.zero;
        }
        
    }

    #region State Balloon
    private void StateBalloonStart()
    {
        OnStateStart?.Invoke();
        Vector3 playerKeepVelocity = player.rigidbody.velocity.normalized * Random.Range(speedMin,speedMax);
        playerKeepVelocity.y = upVelocity;
        player.rigidbody.velocity = playerKeepVelocity;
    }

    private void StateBalloon()
    {
        player.stateMachine.ChangeState(player.StateTransition, gameObject);
    }

    private void StateBalloonEnd()
    {
        OnStateEnd?.Invoke();
        player.canHomming = true;

        StartCoroutine(Revive(ReviveTime));
    }
    #endregion 

    private IEnumerator Revive(float time)
    {
        yield return new WaitForSeconds(time);
        Activate();
    }
}
