using RingEngine;
using UnityEngine;

public class Spring : GenerationsObject
{
    public float AimDirection = 0f;
    public float BaseRotation = 0f;
    public float DebugShotTimeLength = 2f;
    public float FirstSpeed = 30f;
    public bool IsBreak = false;
    public bool IsChangeCameraWhenPathChange = true;
    public bool IsHomingAttackEnable = false;
    public bool IsLongBase = false;
    public bool IsPathChange = false;
    public bool IsSideSet = false;
    public bool IsStartVelocityConstant = true;
    public bool IsWallWalk = false;
    public bool IsWithBase = false;
    public bool IsYawUpdate = false;
    public float KeepVelocityDistance = 5f;
    public float MotionType = 0f;
    public float OutOfControl = 0.4f;
    public bool m_IsConstantFrame = false;
    public bool m_IsConstantPosition = true;
    public bool m_IsMonkeyHunting = false;
    public bool m_IsStopBoost = false;
    public bool m_IsTo3D = false;
    public Vector3 m_MonkeyTarget;
    public bool IsInvisible = false;
    public bool HasBase = false;
    public bool m_IsMonkeyHuntingLowAngle = true;

    public AudioClip springSound;

    private Animator animator;
    private AudioSource audioSource;

    public Transform startPoint;
    public ParticleSystem particle;

    private float duration;
    private float outOfControl;
    private float dotTransformUpVector3Up;

    public override void OnValidate()
    {

    }

    public void Start()
    {
        animator = GetComponentInChildren<Animator>();
        audioSource = GetComponent<AudioSource>();
        dotTransformUpVector3Up = Vector3.Dot(transform.up, Vector3.up);
    }

    #region State Spring
    void StateSpringStart()
    {
        player.transform.position = startPoint.position;
        duration = player.stateMachine.lastStateTime + MathfExtension.Time(KeepVelocityDistance, FirstSpeed);
        outOfControl = player.stateMachine.lastStateTime + OutOfControl;
        player.rigidbody.velocity = Vector3.zero;
        if (m_IsStopBoost)
        {
            player.isBoosting = false;
        }
    }
    void StateSpring()
    {
        player.SearchGround(); ;

        if (Time.time < duration)
        {
            player.rigidbody.velocity = transform.up * FirstSpeed;
        }

        if (Mathf.Abs(player.rigidbody.velocity.y) > 0)
        {
            startPoint.forward = player.rigidbody.velocity.normalized;
        }

        if (Time.time < outOfControl)
        {
            if (dotTransformUpVector3Up > 0.99f)
            {
                player.transform.rotation = Quaternion.FromToRotation(player.transform.up, Vector3.up) * player.transform.rotation;
            }
            else
            {
                player.transform.rotation = Quaternion.LookRotation(-startPoint.up, startPoint.forward);
            }
        }
        else
        {
            player.stateMachine.ChangeState(player.StateFall, gameObject);
        }
    }
    void StateSpringEnd()
    {
        player.canHomming = IsHomingAttackEnable;
    }
    #endregion

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(GameTags.playerTag))
        {
            animator.SetTrigger("Spring");
            audioSource.PlayOneShot(springSound);
            if (particle)
                particle.Play();
            player = other.GetComponent<Player>();
            player.stateMachine.ChangeState(StateSpring, gameObject);
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        GizmosExtension.DrawTrajectory(transform.position, transform.up, FirstSpeed, DebugShotTimeLength, KeepVelocityDistance);
        Gizmos.color = Color.red;
        GizmosExtension.DrawTrajectory(transform.position, transform.up, FirstSpeed, OutOfControl, KeepVelocityDistance);
    }
}

public interface ISpring
{
    public void StateSpringStart();
    public void StateSpring();
    public void StateSpringEnd();

}