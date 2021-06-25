using UnityEngine;

public class JumpBoard : GenerationsObject
{
    public float AngleType = 0f;
    public float ImpulseSpeedOnBoost = 50f;
    public float ImpulseSpeedOnNormal = 35f;

    public bool IsTo3D = false;
    public bool LookBack = false;
    public float OutOfControl = 1.5f;
    public bool RigidBody = true;
    private AudioSource audioSource;
    public AudioClip sound;


    float duration;
    float outOfControl;

    public Transform startPoint;

    public override void OnValidate()
    {

    }

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    #region State Jump Board
    void StateJumpBoardStart()
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

    void StateJumpBoard()
    {
        //player.groundInfo.SearchGroundHighSpeed();

        player.transform.rotation = Quaternion.LookRotation(player.rigidbody.velocity.normalized, Vector3.up);

        //if (player.IsGrounded())
        //{
        //     player.stateMachine.ChangeState(interactingGameObjects, player.);
        //}

        if (Time.time > outOfControl)
        {
            player.stateMachine.ChangeState(player.StateTransition, gameObject);
        }
    }
    void StateJumpBoardEnd()
    {

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

            player.stateMachine.ChangeState(StateJumpBoard, gameObject);
        }
    }
}