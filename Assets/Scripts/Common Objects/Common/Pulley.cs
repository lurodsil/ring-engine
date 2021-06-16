using UnityEngine;

public class Pulley : RingEngineObject
{
    public bool isJumpCancel = true;
    public bool isHommingAttackEnable = true;
    public float speed;

    public Transform pulleyHandle;
    public BezierPath bezierPath;

    private SphereCollider sphereCollider;

    private float appliedSpeed;
    private Vector3 colliderOffset = new Vector3(0, -2, 0);
    private Vector3 playerOffset = new Vector3(0, -2.25f, 0);

    private BezierKnot knot = new BezierKnot();

    private void Start()
    {
        sphereCollider = GetComponent<SphereCollider>();

        objectState = StatePulley;
    }

    private void Update()
    {
        if (active)
        {
            if (Vector3.Distance(pulleyHandle.position, bezierPath.bezierSpline.GetPoint(1)) > 0.5f)
            {
                appliedSpeed = -speed;
            }
            else
            {
                Deactivate();
            }
        }
        else
        {
            if (Vector3.Distance(pulleyHandle.position, bezierPath.bezierSpline.GetPoint(0)) > 0.5f)
            {
                appliedSpeed = speed;
            }
            else
            {
                appliedSpeed = 0;
            }
        }

        pulleyHandle.Translate(knot.tangent * -appliedSpeed * Time.deltaTime);
        bezierPath.PutOnPath(pulleyHandle, PutOnPathMode.BinormalAndNormal, out knot);
        pulleyHandle.rotation = Quaternion.LookRotation(knot.tangent, knot.normal);
        sphereCollider.center = pulleyHandle.localPosition + colliderOffset;
    }

    #region State Pulley
    void StatePulleyStart()
    {
        player.rigidbody.useGravity = false;
        player.rigidbody.velocity = Vector3.zero;
        player.transform.parent = pulleyHandle;
        player.transform.forward = pulleyHandle.forward;
        player.transform.localPosition = playerOffset;

        OnStateStart?.Invoke();
    }
    public void StatePulley()
    {
        if (!active)
        {
            player.stateMachine.ChangeState(player.StateTransition, gameObject);
        }

        if (!isJumpCancel && Input.GetButtonDown(XboxButton.A))
        {
            player.canHomming = false;
            player.stateMachine.ChangeState(player.StateJump, gameObject);
        }
    }
    void StatePulleyEnd()
    {
        OnStateEnd?.Invoke();
        player.canHomming = isHommingAttackEnable;
        player.transform.parent = null;
        player.rigidbody.useGravity = true;
        player.rigidbody.velocity = Vector3.Lerp(player.transform.forward, player.transform.up, 0.2f) * speed;
    }
    #endregion
}