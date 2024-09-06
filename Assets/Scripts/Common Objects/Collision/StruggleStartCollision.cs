using UnityEngine;

public class StruggleStartCollision : GenerationsObject
{
    public StruggleEndCollision struggleEndCollision;
    public BezierPath bezierPath;
    public float velocity = 10;

    private void Awake()
    {
        OnPlayerTriggerEnter!.AddListener(StruggleStart);
    }

    #region State Struggle
    private void StateStruggleStart()
    {
        player.isStruggling = true;
    }

    private void StateStruggle()
    {
        BezierKnot bezierKnot = new BezierKnot();

        bezierPath.PutOnPath(player.transform, PutOnPathMode.BinormalAndNormal, out bezierKnot, out _, 1);

        player.transform.rotation = Quaternion.LookRotation(bezierKnot.tangent, bezierKnot.normal);

        player.rigidbody.velocity = player.transform.forward * velocity;
    }

    private void StateStruggleEnd()
    {
        player.isStruggling = false;
    }
    #endregion

    private void StruggleStart()
    {
        player.stateMachine.ChangeState(StateStruggle, gameObject);
    }
}
