using UnityEngine;

public class Fan :  CommonActivableStatefulObject
{



    public float Base = 0f;

    public float IgnoreTime = 0.5f;
    public bool IsBDE = false;

    public bool IsOneShot = false;
    public float JumpVel = 10f;
    public float KeepHeight = 4.7f;
    public float Place = 0f;
    public float Time_Off = 0f;
    public float Time_On = 2f;
    public float Time_Wait = 0f;
    public float TrgHeight = 7.69999f;
    public float Type = 0f;
    public bool UseLoopSE = true;
    public bool UseModel = true;
    public bool WakeStart = true;
    public float keepTime = 0.02f;
    public float upSpeed = 2;

    Vector3 velocity;

    private Animator animator;
    private AudioSource audioSource;
    public AudioClip sound;

    private BoxCollider boxCollider;
    float lastStateTime;

    public void Start()
    {

        animator = GetComponent<Animator>();
        animator.SetTrigger("Fan On");
        animator.speed = 0;


        audioSource = GetComponent<AudioSource>();

        audioSource.clip = sound;

        if (active)
        {
            TurnOn();
        }
        

        objectState = StateFloat;

        OnPlayerTriggerExit.AddListener(ExitFan);
        OnBecomeActive.AddListener(TurnOn);
        OnBecomeInactive.AddListener(TurnOff);
    }

    private void ExitFan()
    {
        if (active)
        {
            player.stateMachine.ChangeState(player.StateFall, gameObject);            
        }
    }

    public void TurnOn()
    {
        audioSource.Play();
        animator.speed = 1;
        
    }

    public void TurnOff()
    {
        audioSource.Stop();
        animator.speed = 0;
    }

    #region State
    void StateFloatStart()
    {
        
    }
    void StateFloat()
    {
        Vector3 vel = MainCamera.Transform.TransformDirection(new Vector3(Input.GetAxis(XboxAxis.LeftStickX) * 2, 0, Input.GetAxis(XboxAxis.LeftStickY) * 2));

        velocity.x = vel.x;
        velocity.z = vel.z;

        float targetVel = 0;

        if (player.transform.position.y < transform.position.y + KeepHeight - 2)
        {
            targetVel = upSpeed;
        }
        else if (player.transform.position.y < transform.position.y + KeepHeight - 1)
        {
            targetVel = -upSpeed;
        }

        velocity.y = Mathf.Lerp(velocity.y, targetVel, 2 * Time.deltaTime);

        player.rigidbody.velocity = velocity;

        player.transform.up = Vector3.up;
    }
    void StateFloatEnd()
    {

    }
    #endregion 
}