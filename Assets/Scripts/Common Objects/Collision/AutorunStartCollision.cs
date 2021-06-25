using UnityEngine;

public class AutorunStartCollision : GenerationsObject
{
    public float Collision_Height = 30f;
    public float Collision_Width = 10f;
    public float EaseTime = 2f;
    public bool IsForceToGround = false;
    public float KeepTime = 5f;
    public float Speed = 40f;
    public float ToPathEaseTime = 0.5f;
    public float Type = 0f;

    public BezierPath bezierPath;
    public AutorunFinishCollision autorunFinishCollision;

    public override void OnValidate()
    {
        if (!gameObject.GetComponent<BoxCollider>())
        {
            BoxCollider collider = gameObject.AddComponent<BoxCollider>();

            collider.isTrigger = true;
        }
        else
        {
            BoxCollider collider = gameObject.GetComponent<BoxCollider>();

            collider.isTrigger = true;
        }

        transform.localScale = new Vector3(Collision_Width, Collision_Height, 1);
    }

    public void StateAutorunStart()
    {

    }

    public void StateAutorun()
    {
        //player.groundInfo.SearchGroundHighSpeed();
        //player.AlignPlayer();
        player.PutOnGround();

        BezierKnot bezierKnot = new BezierKnot();
        bezierPath.PutOnPath(player.transform, PutOnPathMode.BinormalOnly, out bezierKnot);
        Vector3 tangent = Vector3.Dot(player.transform.forward, bezierKnot.tangent) > 0 ? bezierKnot.tangent : -bezierKnot.tangent;
        //tangent.y = player.GetGroundInformation().normal.y;
        player.transform.rotation = Quaternion.FromToRotation(player.transform.forward, tangent) * player.transform.rotation;
        Speed = Mathf.MoveTowards(Speed, 44, 12 * Time.deltaTime);
        player.rigidbody.velocity = player.transform.forward * Speed;
    }

    public void StateAutorunEnd()
    {

    }

    private void OnPlayerTriggerEnter()
    {
        if (player.stateMachine.currentStateName != "StateAutorun")
        {
            player.stateMachine.ChangeState(StateAutorun, gameObject);
            autorunFinishCollision.gameObject.SetActive(true);
        }
    }
}