using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : RingEngineObject
{
    public BezierPath bezierPath;


    private void Start()
    {
        objectState = StateRocket;
    }

    #region State Rocket
    private void StateRocketStart()
    {
        OnStateStart?.Invoke();
        player.transform.position = transform.position;
    }

    public void StateRocket()
    {
        transform.position = player.transform.position;
        player.rigidbody.useGravity = false;
    }
    public void StateRocketPhysics()
    {
        BezierKnot bezierKnot = new BezierKnot();

        float closest = 0;

        bezierPath.PutOnPath(player.transform, PutOnPathMode.BinormalAndNormal, out bezierKnot, out closest, 15);

        if(player.rigidbody.velocity.magnitude < 40)
        {
            player.rigidbody.AddForce(bezierKnot.tangent * 40, ForceMode.Acceleration);
        }


        player.transform.rotation = Quaternion.LookRotation(bezierKnot.tangent, bezierKnot.normal);

        transform.rotation = Quaternion.LookRotation(bezierKnot.tangent, bezierKnot.normal);

        if(closest > 0.99f)
        {
            player.stateMachine.ChangeState(player.StateFall, gameObject);
        }
    }

    private void StateRocketEnd()
    {
        OnStateEnd?.Invoke();
        player.rigidbody.useGravity = true;
    }
    #endregion

    public override void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(GameTags.playerTag))
        {
            player = other.GetComponent<Player>();
            player.stateMachine.ChangeState(objectState, StateRocketPhysics, gameObject);
        }
    }
}
