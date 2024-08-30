using UnityEngine;
using static UnityEngine.Rendering.VirtualTexturing.Debugging;

public class IronPole2D : CommonStatefulObject
{
    public float launchVelocity = 30;
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
            player.stateMachine.ChangeState(player.StateFall, gameObject);
        }
    }

    public void StateIronPoleEnd()
    {
        OnStateEnd!.Invoke();
        player.rigidbody.useGravity = true;
        player.transform.parent = null;
        player.rigidbody.AddForce(-FindHips(player.transform).forward * launchVelocity, ForceMode.Impulse);
        player.canHomming = true;
    }

    private Transform FindHips(Transform player)
    {
        foreach (Transform t in player.GetComponentsInChildren<Transform>())
        {
            if(t.name == "Hips")
            {
                return t;
            }
        }

        return null;
    }
}