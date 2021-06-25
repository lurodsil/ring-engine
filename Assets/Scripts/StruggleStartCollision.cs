using UnityEngine;

public class StruggleStartCollision : GenerationsObject
{
    public StruggleEndCollision struggleEndCollision;
    public BezierPath bezierPath;
    public float velocity = 10;

    #region State Struggle
    private void StateStruggleStart()
    {

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
    }
    #endregion

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(GameTags.playerTag))
        {
            player = other.GetComponent<Player>();

            player.stateMachine.ChangeState(StateStruggle, gameObject);

            struggleEndCollision.Deactivate();
        }
    }
}
