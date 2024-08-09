using UnityEngine;
using UnityEngine.UIElements.Experimental;

public class SelectCanon : CommonStatefulObject
{
    public float InputTmie = 2.5f;
    public float OutOfControl = 0.13f;
    public float OutOfControl_Fail = 0.2f;
    public float ShotForce = 20f;
    public float ShotForce_Fail = 20f;
    public float SuccessDir = 1f;

    public AudioClip start;
    public AudioClip select;
    public AudioClip loop;
    public AudioClip end;
    public AudioClip fail;

    private Animator animator;
    private AudioSource audioSource;

    private float waitShot;
    private float waitShotTarget;
    private bool audioPlayed;
    private int selectCanonID;
    [SerializeField] private SkinnedMeshRenderer scannon;
    private Vector2 offset;


    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = loop;

        objectState = StateSelectCanon;
        offset.x = 0.6f;
    }

    private void Update()
    {
        waitShot = Mathf.Lerp(waitShot, waitShotTarget, 10 * Time.deltaTime);

        animator.SetFloat("WaitShot", waitShot);

        scannon.materials[0].SetTextureOffset("_EmissiveColorMap", offset);
    }

    #region State Select Canon
    void StateSelectCanonStart()
    {
        player.rigidbody.useGravity = false;
        player.rigidbody.velocity = Vector3.zero;
        player.transform.rotation = transform.rotation;
        animator.SetTrigger("Select Canon Start");
        audioSource.PlayOneShot(start);
        audioSource.Play();
        offset.x = 0.6f;
        OnStateStart!.Invoke();
    }
    void StateSelectCanon()
    {
        Vector2 input = new Vector2(Input.GetAxisRaw(XboxAxis.LeftStickX) * -Mathf.Sign(Vector3.Dot(transform.right, Camera.main.transform.forward)), Input.GetAxisRaw(XboxAxis.LeftStickY)) ;

        float step = 0.3f / InputTmie;

        offset.x += step * Time.deltaTime;

        if (input.x == -1)
        {
            waitShotTarget = 1;
            selectCanonID = 3;
            animator.transform.localRotation = Quaternion.Euler(90, 0, 0);
            player.transform.forward = -animator.transform.up;

            if (!audioPlayed)
            {
                audioPlayed = true;
                audioSource.PlayOneShot(select);
            }
        }
        else if (input.x == 1)
        {
            waitShotTarget = 1;
            selectCanonID = 3;
            animator.transform.localRotation = Quaternion.Euler(270, 0, 0);
            player.transform.forward = -animator.transform.up;

            if (!audioPlayed)
            {
                audioPlayed = true;
                audioSource.PlayOneShot(select);
            }
        }
        else if (input.y == 1)
        {
            waitShotTarget = 1;
            selectCanonID = 1;
            animator.transform.localRotation = Quaternion.Euler(180, 0, 0);
            player.transform.rotation = transform.rotation;

            if (!audioPlayed)
            {
                audioPlayed = true;
                audioSource.PlayOneShot(select);
            }
        }
        else if (input.y == -1)
        {
            waitShotTarget = 1;
            selectCanonID = 5;
            animator.transform.localRotation = Quaternion.Euler(0, 0, 0);
            player.transform.rotation = transform.rotation;

            if (!audioPlayed)
            {
                audioPlayed = true;
                audioSource.PlayOneShot(select);
            }
        }
        else
        {
            player.transform.rotation = transform.rotation;
            waitShotTarget = 0;
            selectCanonID = 0;
            audioPlayed = false;
        }

        player.transform.position = transform.position - Vector3.up * 0.5f;


        if (Input.GetButtonDown(XboxButton.A) && input != Vector2.zero)
        {
            animator.SetTrigger("Select Canon End");

            player.stateMachine.ChangeState(StateSelectCanonSuccess, gameObject);
            return;
        }

        if (Time.time > player.stateMachine.lastStateTime + InputTmie)
        {
            selectCanonID = 0;
            player.stateMachine.ChangeState(StateSelectCanonFail, gameObject);
        }      
    }
    void StateSelectCanonEnd()
    {
        player.rigidbody.useGravity = true;
        player.SendMessage("StateSelectCanonEndID", selectCanonID);
        animator.SetTrigger("Select Canon End");


    }
    #endregion

    #region State Select Canon Success
    void StateSelectCanonSuccessStart()
    {
        audioSource.Stop();

        audioSource.PlayOneShot(end);

        if (selectCanonID == 5)
        {
            player.rigidbody.velocity = -animator.transform.up * ShotForce;
        }
    }
    void StateSelectCanonSuccess()
    {
        if (selectCanonID != 5)
        {
            player.rigidbody.velocity = -animator.transform.up * ShotForce;

            player.stateMachine.ChangeState(player.StateTransition, gameObject, OutOfControl);
        }
        else if (player.IsGrounded())
        {
            player.stateMachine.ChangeState(player.StateIdle, gameObject);
        }

    }
    void StateSelectCanonSuccessEnd()
    {

    }
    #endregion 

    #region State Select Canon Fail
    void StateSelectCanonFailStart()
    {
        animator.transform.localRotation = Quaternion.Euler(0, 0, 0);

        audioSource.Stop();

        audioSource.PlayOneShot(fail);

        player.rigidbody.velocity = Vector3.down * ShotForce_Fail;
    }
    void StateSelectCanonFail()
    {
        if (player.IsGrounded())
        {
            player.stateMachine.ChangeState(player.StateIdle, gameObject, 2.5f);
        }
    }
    void StateSelectCanonFailEnd()
    {

    }
    #endregion

    public float EaseIn()
    {
        float ease = (Time.time - player.stateMachine.lastStateTime) * (1 / (InputTmie * 10));

        if (ease > 0.99f)
        {
            return 1;
        }
        else
        {
            return ease;
        }
    }
}