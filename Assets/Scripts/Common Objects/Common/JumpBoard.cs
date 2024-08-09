using UnityEngine;

public class JumpBoard : CommonStatefulObject
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


    private void Start()
    {
        audioSource = GetComponent<AudioSource>();

        objectState = StateJumpBoard;
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
        audioSource.PlayOneShot(sound);
    }

    void StateJumpBoard()
    {
        player.transform.rotation = Quaternion.LookRotation(player.rigidbody.velocity.normalized, Vector3.up);

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
}