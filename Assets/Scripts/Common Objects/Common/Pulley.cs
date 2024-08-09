using UnityEngine;

public class Pulley : CommonActivableStatefulObject
{
    public bool isJumpCancel = true;
    public bool isHommingAttackEnable = true;
    public float speed = 30;

    public Transform pulleyHandle;
    public Rigidbody _rigidbody;
    public BezierPath bezierPath;

    public GameObject target;

    private SphereCollider sphereCollider;

    private float appliedSpeed;
    private Vector3 colliderOffset = new Vector3(0, -2, 0);
    private Vector3 playerOffset = new Vector3(0, -2.25f, 0);

    private BezierKnot knot = new BezierKnot();
    private FixedJoint fixedJoint;

    public void Start()
    {
        sphereCollider = GetComponent<SphereCollider>();
        objectState = StatePulley;
        _rigidbody = pulleyHandle.GetComponent<Rigidbody>();
        _rigidbody.useGravity = false;        
    }

    private void FixedUpdate()
    {
        if (active)
        {
            if (Vector3.Distance(pulleyHandle.position, bezierPath.bezierSpline.GetPoint(1)) < 1f)
            {
                Deactivate();
            }
            else
            {
                appliedSpeed = speed;                
            }
        }
        else
        {
            if (Vector3.Distance(pulleyHandle.position, bezierPath.bezierSpline.GetPoint(0)) < 1f)
            {
                appliedSpeed = 0;
                sphereCollider.enabled = true;
            }
            else
            {
                appliedSpeed = -speed;
            }
        }

        _rigidbody.velocity = knot.tangent * appliedSpeed;

        bezierPath.PutOnPath(pulleyHandle, PutOnPathMode.BinormalAndNormal, out knot, out _, 10);
        pulleyHandle.rotation = Quaternion.LookRotation(knot.tangent, knot.normal);
        sphereCollider.center = pulleyHandle.localPosition + colliderOffset;
    }

    #region State Pulley
    void StatePulleyStart()
    {
        OnStateStart?.Invoke();

        Activate();

        player.UpdateTargets();

        player.DisablePhysics();

        player.GetComponent<Sonic>().EnableDoubleJump();

        player.transform.parent = pulleyHandle.transform;
        player.transform.forward = pulleyHandle.forward;  
        sphereCollider.enabled = false;
    }
    public void StatePulley()
    {
        player.transform.localPosition = playerOffset;

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
        target.SetActive(false);
        player.EnablePhysics();
        player.canHomming = isHommingAttackEnable;
        player.transform.parent = null;
        player.rigidbody.velocity = Vector3.Lerp(player.transform.forward, player.transform.up, 0.2f) * speed;
    }
    #endregion
}