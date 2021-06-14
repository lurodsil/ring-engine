using RingEngine;
using UnityEngine;

public class AdlibTrickJump : GenerationsObject
{


    public float ImpulseSpeedOnBoost = 41f;
    public float ImpulseSpeedOnNormal = 41f;

    public bool IsTo3D = true;
    public float OutOfControl = 3.5f;

    public float SizeType = 1f;

    private AudioSource audioSource;
    public Transform startPoint;


    float duration;
    float outOfControl;

    public override void OnValidate()
    {

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
            player.stateMachine.ChangeState(player.StateTransition);
        }
    }
    void StateAdlibTrickJumpEnd()
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

            if (!audioSource.isPlaying)
            {
                //audioSource.PlayOneShot(springSound);
            }

            player = other.GetComponent<Player>();

            player.stateMachine.ChangeState(StateAdlibTrickJump);
        }
    }
}