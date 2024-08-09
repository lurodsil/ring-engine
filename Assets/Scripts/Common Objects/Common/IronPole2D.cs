using UnityEngine;
using static UnityEngine.Rendering.VirtualTexturing.Debugging;

public class IronPole2D : CommonStatefulObject
{
    public float CameraEaseTimeEnter = 0.6f;
    public float CameraEaseTimeKeep = 0f;
    public float CameraEaseTimeLeave = 1.2f;
    public int CameraID;

    public float GuideSide = 0f;

    public float Length = 4f;

    public Transform targetPosition;
    public Vector3 playerOffset;

    public void Start()
    {

        objectState = StateIronPole;
    }

    public void StateIronPoleStart()
    {
        OnStateStart!.Invoke();
        player.rigidbody.useGravity = false;
        player.rigidbody.velocity = Vector3.zero;
        player.transform.parent = targetPosition;
        player.transform.forward = Vector3.Dot(targetPosition.forward, player.transform.forward) > 0 ? targetPosition.forward : -targetPosition.forward;
        player.transform.localPosition = playerOffset;
        
    }
    public void StateIronPole()
    {
        if (Input.GetButtonDown(XboxButton.A))
        {
            player.stateMachine.ChangeState( player.StateFall, gameObject);          
                
        }
    }
    public void StateIronPolePhysics()
    {
        
    }

    public void StateIronPoleEnd()
    {
        OnStateEnd!.Invoke();
        player.rigidbody.useGravity = true;
        player.transform.parent = null;
        player.rigidbody.AddForce(-player.hips.forward * 30, ForceMode.Impulse);
        player.canHomming = true;
    }
}