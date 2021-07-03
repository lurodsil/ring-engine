using UnityEngine;

public enum CannonState
{
    EnteringUp,
    EnteringDown,
    AimCanon,
    Wait,
    Shot
}

public class Cannon : GenerationsObject
{
    public bool AutoShot = false;
    public float BaseVel = 20.4f;
    public float CameraEaseTime_Enter = 0.6f;
    public float CameraEaseTime_Keep = 0.6f;
    public float CameraEaseTime_Leave = 0.1f;
    public int CameraID;
    public Vector3 DstPos;

    public float ModeChange = 1f;
    public bool MoveBarrel = true;
    public float StaticPercent = 0f;
    public float Type = 0f;
    public bool UseFloorModel = true;
    public float VelRatio = 3f;
    public float DebugShotTimeLength = 1;
    public float OutOfControl = 1;

    private AudioSource audioSource;
    public AudioClip shot;
    public AudioClip start;
    public AudioClip loop;
    public AudioClip stop;

    public Transform target;
    public Transform cannon;
    public Transform barrel;
    public Transform enterPosition;
    public Transform shotPosition;

    public CannonState cannonState;

    private float duration;
    private float outOfControl;
    private float lastStateTime;

    private bool aimCannon;

    public override void OnValidate()
    {
    }

    private void Start()
    {
        DstPos = target.position;
        audioSource = GetComponent<AudioSource>();
        audioSource.loop = true;
        audioSource.clip = loop;

        objectState = StateCanon;
    }

    private void Update()
    {
        if (aimCannon)
        {
            target.position = Vector3.MoveTowards(target.position, DstPos, 60 * Time.deltaTime);
        }
        else
        {
            target.position = Vector3.MoveTowards(target.position, new Vector3(barrel.position.x, DstPos.y, barrel.position.z), 60 * Time.deltaTime);
        }

        cannon.LookAt(new Vector3(target.position.x, cannon.position.y, target.position.z));
        barrel.LookAt(target);

        if (cannonState != CannonState.Shot)
        {
            float distance = Vector3.Distance(shotPosition.position, target.position);
            duration = Time.time + PhysicsExtension.Time(distance, BaseVel);
            outOfControl = Time.time + OutOfControl;
            
        }
    }

    #region State

    private void StateCanonStart()
    {
        player.rigidbody.isKinematic = true;
        player.rigidbody.useGravity = false;
        player.rigidbody.velocity = Vector3.zero;
        cannonState = CannonState.EnteringUp;
        player.bezierPath = null;
    }

    private void StateCanon()
    {
        switch (cannonState)
        {
            case CannonState.EnteringUp:
                player.transform.position = Vector3.MoveTowards(player.transform.position, enterPosition.position, 10 * Time.deltaTime);

                if (Vector3.Distance(player.transform.position, enterPosition.position) < 0.5f)
                {
                    cannonState = CannonState.EnteringDown;
                }
                break;

            case CannonState.EnteringDown:
                player.transform.position = Vector3.MoveTowards(player.transform.position, shotPosition.position, 10 * Time.deltaTime);

                if (Vector3.Distance(player.transform.position, shotPosition.position) < 0.5f)
                {
                    player.transform.parent = shotPosition;
                    player.transform.rotation = Quaternion.identity;
                    cannonState = CannonState.AimCanon;
                    audioSource.PlayOneShot(start);
                    audioSource.PlayDelayed(start.length);
                }

                break;

            case CannonState.AimCanon:
                aimCannon = true;

                if (Vector3.Distance(target.position, DstPos) < 0.5f)
                {
                    cannonState = CannonState.Wait;
                    audioSource.Stop();
                    audioSource.PlayOneShot(stop);
                }
                break;

            case CannonState.Wait:
                if (AutoShot || Input.GetButtonDown(XboxButton.A))
                {
                    player.rigidbody.isKinematic = false;
                    player.rigidbody.useGravity = true;
                    player.transform.parent = null;
                    cannonState = CannonState.Shot;

                    audioSource.PlayOneShot(shot);
                }
                break;

            case CannonState.Shot:

                if (Time.time < duration)
                {
                    player.rigidbody.velocity = shotPosition.forward * BaseVel;
                }
                
                if (player.IsGrounded())
                {
                    player.stateMachine.ChangeState(player.StateMove3D, gameObject);
                }

                player.transform.forward = player.rigidbody.velocity.normalized;

                break;
        }
    }

    private void StateCanonEnd()
    {
        aimCannon = false;
        cannonState = CannonState.Wait;
    }

    #endregion State

    private void OnDrawGizmos()
    {
        float distance = Vector3.Distance(barrel.position, target.position);
        Gizmos.color = Color.green;
        Gizmos.DrawLine(shotPosition.position, shotPosition.position + ((target.position - shotPosition.position).normalized * distance));
        GizmosExtension.DrawTrajectory(shotPosition.position + ((target.position - shotPosition.position).normalized * distance), (target.position - shotPosition.position).normalized, BaseVel, DebugShotTimeLength);
    }
}