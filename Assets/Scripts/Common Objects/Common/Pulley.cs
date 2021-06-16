using UnityEngine;

public class Pulley : GenerationsObject
{
    public float EndPosition = 3f;
    public bool IsJumpCancel = true;
    public bool IsPoleAttackInvSide = false;
    public float Length = 1f;
    public float MinInitVel = 0f;
    public float PathID = 1f;
    public float StartPosition = 0f;
    public float speed;

    public AudioClip pulleySound;
    public Transform pulleyHandle;
    public BezierPath bezierPath;

    private SphereCollider sphereCollider;
    private AudioSource audioSource;

    private float appliedSpeed;
    private Vector3 colliderOffset = new Vector3(0, -2, 0);
    private Vector3 playerOffset = new Vector3(0, -2.25f, 0);

    private BezierKnot knot = new BezierKnot();

    public override void OnValidate()
    {

    }

    private void Start()
    {
        sphereCollider = GetComponent<SphereCollider>();
        audioSource = pulleyHandle.GetComponent<AudioSource>();
        audioSource.clip = pulleySound;
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
                audioSource.Stop();
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
    }
    public void StatePulley()
    {
        if (!active)
        {
            player.stateMachine.ChangeState(player.StateTransition, gameObject);
        }
    }
    void StatePulleyEnd()
    {
        player.canHomming = true;
        player.transform.parent = null;
        player.rigidbody.useGravity = true;
        player.rigidbody.velocity = Vector3.Lerp(player.transform.forward, player.transform.up, 0.2f) * speed;
    }
    #endregion


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(GameTags.playerTag))
        {
            player = other.GetComponent<Player>();
            Activate();
            player.stateMachine.ChangeState(StatePulley, gameObject);
        }
    }

    private void OnBecomeActive()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }
}