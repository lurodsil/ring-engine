using UnityEngine;

public class DashRing : GenerationsObject
{
    public float FirstSpeed = 25f;
    public bool IsChangeCameraWhenChangePath = false;
    public bool IsChangePath = false;
    public bool IsHeadToVelocity = false;
    public bool IsTo3D = false;
    public float KeepVelocityDistance = 5f;
    public float OutOfControl = 0.5f;

    public AudioClip dashRingSound;
    public Transform startPoint;
    public ParticleSystem particle;

    private AudioSource audioSource;

    private float duration;
    private float outOfControl;

    public override void OnValidate()
    {
    }

    public void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    #region State Dash Ring
    private void StateDashRingStart()
    {
        player.transform.position = startPoint.position;
        duration = player.stateMachine.lastStateTime + PhysicsExtension.Time(KeepVelocityDistance, FirstSpeed);
        outOfControl = player.stateMachine.lastStateTime + OutOfControl;
        player.rigidbody.velocity = Vector3.zero;
        player.isBoosting = false;
    }
    private void StateDashRing()
    {
        if (Time.time < duration)
        {
            player.rigidbody.velocity = -transform.forward * FirstSpeed;
        }

        if (Mathf.Abs(player.rigidbody.velocity.y) > 0)
        {
            startPoint.forward = player.rigidbody.velocity.normalized;
        }

        if (Time.time < outOfControl)
        {
            player.transform.rotation = Quaternion.LookRotation(-startPoint.up, startPoint.forward);
        }
        else
        {
            player.stateMachine.ChangeState(player.StateFall, gameObject);
        }
    }
    private void StateDashRingEnd()
    {
        player.canHomming = true;
    }
    #endregion State Dash Ring

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(GameTags.playerTag))
        {
            audioSource.PlayOneShot(dashRingSound);
            particle.Play();
            player = other.GetComponent<Player>();
            player.stateMachine.ChangeState(StateDashRing, gameObject);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        GizmosExtension.DrawTrajectory(startPoint.position, startPoint.forward, FirstSpeed, 2, KeepVelocityDistance);
        Gizmos.color = Color.red;
        GizmosExtension.DrawTrajectory(startPoint.position, startPoint.forward, FirstSpeed, OutOfControl, KeepVelocityDistance);
    }
}