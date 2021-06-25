using UnityEngine;

public class SelectCanon : RingEngineObject
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

    public override void OnValidate()
    {

    }

    private void Start()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = loop;

        objectState = StateSelectCanon;
    }

    private void Update()
    {
        waitShot = Mathf.Lerp(waitShot, waitShotTarget, 10 * Time.deltaTime);

        animator.SetFloat("WaitShot", waitShot);
    }

    #region State Select Canon
    void StateSelectCanonStart()
    {
        player.rigidbody.isKinematic = true;
        player.rigidbody.velocity = Vector3.zero;
        player.transform.rotation = transform.rotation;

        audioSource.PlayOneShot(start);
        audioSource.Play();
    }
    void StateSelectCanon()
    {
        Vector2 input = new Vector2(Input.GetAxisRaw(XboxAxis.LeftStickX), Input.GetAxisRaw(XboxAxis.LeftStickY));

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

        player.stateMachine.ChangeState(StateSelectCanonFail, gameObject, InputTmie);

    }
    void StateSelectCanonEnd()
    {
        player.rigidbody.isKinematic = false;
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

        player.rigidbody.velocity = -animator.transform.up * ShotForce_Fail;
    }
    void StateSelectCanonFail()
    {
        if (player.IsGrounded())
        {
            player.stateMachine.ChangeState(player.StateIdle, gameObject, 2.8f);
        }
    }
    void StateSelectCanonFailEnd()
    {

    }
    #endregion
}