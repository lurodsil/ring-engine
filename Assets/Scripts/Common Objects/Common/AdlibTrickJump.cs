using RingEngine;
using UnityEngine;

public class AdlibTrickJump : RingEngineObject
{
    public float ImpulseSpeedOnBoost = 41f;
    public float ImpulseSpeedOnNormal = 41f;
    public bool IsTo3D = true;
    public float OutOfControl = 3.5f;
    private AudioSource audioSource;
    public Transform startPoint;
    public AudioClip sound;
    float duration;
    float outOfControl;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    #region State Jump Board
    void StateAdlibTrickJumpStart()
    {
        Time.timeScale = 0.7f;

        player.transform.position = startPoint.position;

        player.transform.forward = startPoint.forward;

        if (player.isBoosting)
        {
            player.rigidbody.velocity = startPoint.forward * ImpulseSpeedOnBoost;
        }
        else
        {
            player.rigidbody.velocity = startPoint.forward * ImpulseSpeedOnNormal;
        }

        outOfControl = player.stateMachine.lastStateTime + OutOfControl;
    }
    void StateAdlibTrickJump()
    {
        if (Time.time > outOfControl)
        {
            player.stateMachine.ChangeState(player.StateTransition, gameObject);
        }
    }
    void StateAdlibTrickJumpEnd()
    {
        Time.timeScale = 1f;
    }
    #endregion

    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        GizmosExtension.DrawTrajectory(startPoint.position, startPoint.forward, ImpulseSpeedOnNormal, 2);
        Gizmos.color = Color.blue;
        GizmosExtension.DrawTrajectory(startPoint.position, startPoint.forward, ImpulseSpeedOnBoost, 2);

        Gizmos.color = Color.red;
        GizmosExtension.DrawTrajectory(startPoint.position, startPoint.forward, ImpulseSpeedOnNormal, OutOfControl);
        GizmosExtension.DrawTrajectory(startPoint.position, startPoint.forward, ImpulseSpeedOnBoost, OutOfControl);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(GameTags.playerTag))
        {
            audioSource.PlayOneShot(sound);

            player = other.GetComponent<Player>();

            player.stateMachine.ChangeState(StateAdlibTrickJump, gameObject);
        }
    }
}