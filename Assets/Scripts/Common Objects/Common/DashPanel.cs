using UnityEngine;

public class DashPanel : CommonStatefulObject
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
        player.rigidbody.velocity = Vector3.zero;
        player.rigidbody.AddForce(transform.forward * Speed, ForceMode.Impulse);
    }
    void StateDashPanel()
    {
        RaycastHit raycastHit = player.GetGroundInformation();

        if (player.IsGrounded())
        {
            player.transform.StickToGround(raycastHit,10);
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
        player.tangentMultiplier = Vector3.Dot(player.sideViewKnot.tangent, transform.forward);
    }
    #endregion
}