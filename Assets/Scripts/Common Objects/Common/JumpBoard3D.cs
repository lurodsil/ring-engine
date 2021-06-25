using UnityEngine;

public class JumpBoard3D : GenerationsObject
{
    public float ImpulseSpeedOnBoost = 50f;
    public float ImpulseSpeedOnNormal = 60f;
    public bool IsTo3D = false;
    public bool LookBack = false;
    public float OutOfControl = 2.01f;
    public bool RigidBody = true;
    public float SizeType = 0f;

    private AudioSource audioSource;

    public AudioClip sound;
    public Transform startPoint;

    private float duration;
    private float outOfControl;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    #region State Jump Board
    private void StateJumpBoardStart()
    {
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
    private void StateJumpBoard()
    {
        player.transform.rotation = Quaternion.LookRotation(player.rigidbody.velocity.normalized, Vector3.up);

        if (Time.time > outOfControl)
        {
            player.stateMachine.ChangeState(player.StateTransition, gameObject);
        }
    }
    private void StateJumpBoardEnd()
    {
    }

    #endregion State Jump Board

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        GizmosExtension.DrawTrajectory(startPoint.position, startPoint.forward, ImpulseSpeedOnNormal, 2, 0);
        Gizmos.color = Color.red;
        GizmosExtension.DrawTrajectory(startPoint.position, startPoint.forward, ImpulseSpeedOnNormal, OutOfControl, 0);

        Gizmos.color = Color.blue;
        GizmosExtension.DrawTrajectory(startPoint.position, startPoint.forward, ImpulseSpeedOnBoost, 2, 0);
        Gizmos.color = Color.red;
        GizmosExtension.DrawTrajectory(startPoint.position, startPoint.forward, ImpulseSpeedOnBoost, OutOfControl, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(GameTags.playerTag))
        {
            audioSource.PlayOneShot(sound);
            player = other.GetComponent<Player>();
            player.stateMachine.ChangeState(StateJumpBoard, gameObject);
        }
    }
}