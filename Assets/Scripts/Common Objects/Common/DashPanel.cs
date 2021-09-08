using UnityEngine;

public class DashPanel : RingEngineObject
{
    public bool IsChangeCameraWhenChangePath = false;
    public bool IsChangePath = false;
    public bool IsConstantStartVelocity = true;
    public bool IsInvisible = false;
    public bool IsTo3D = false;
    public bool IsUseDelayCamera = true;
    public float OutOfControl = 0.5f;
    public float Speed = 100f;
    public float SpeedMax = 60f;
    public float SpeedMin = 30f;
    public bool IsStartVelocityConstant = true;

    public AudioClip dashPanelSound;

    private AudioSource audioSource;

    private float duration;
    private float outOfControl;

    public Transform startPoint;

    public override void OnValidate()
    {

    }

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        objectState = StateDashPanel;
    }

    #region State Dash Panel
    void StateDashPanelStart()
    {
        player.transform.forward = transform.forward;
        player.transform.position = transform.position;
        outOfControl = player.stateMachine.lastStateTime + OutOfControl;
    }
    void StateDashPanel()
    {
        RaycastHit raycastHit = player.GetGroundInformation();

        if (player.IsGrounded())
        {
            player.rigidbody.velocity = player.transform.forward * Speed;
            player.transform.StickToGround(raycastHit);
        }
        else
        {
            player.stateMachine.ChangeState(player.StateFall, gameObject);
            return;
        }

        if (Time.time > outOfControl)
        {
            player.stateMachine.ChangeState(player.StateMove, gameObject);
        }
    }
    void StateDashPanelEnd()
    {

    }
    #endregion
}