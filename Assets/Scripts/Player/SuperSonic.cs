using UnityEngine;

public class SuperSonic : Player
{
    public Sonic sonic;

    public float cameraTargetUpOffset = 1.7f;
    public float cameraTargetUpOffsetInAir = 1.0f;

    private bool canStomp;
    private bool canAirboost;
    [Header("Airboost")]
    public float airboostVelocity = 70;
    public float airboostTime = 0.25f;
    public float airboostKeepVelocity = 0.8f;

    public bool flying;
    private GameObject eggman;

    private Vector3 flyVelocity;
    public AudioClip change;

    public void OnEnable()
    {
        GetComponent<AudioSource>().PlayOneShot(change);
    }

    public override void Update()
    {
        base.Update();

        if (IsGrounded())
        {
            canStomp = true;
            canAirboost = true;
        }

        if (GameManager.instance.gameState == GameState.Playing)
        {
            if (stateMachine.initiated)
            {
                stateMachine.OnUpdate();
            }
            else
            {
                stateMachine.Initialize(this, StateIdle);
            }
        }

        if (Input.GetButtonDown(XboxButton.LeftStick))
        {
            flying = true;
        }

        if (stateMachine.currentStateName != "StateFly")
        {
            if (flying)
            {
                stateMachine.ChangeState(StateFly);
            }
        }
    }

    #region State Fly
    void StateFlyStart()
    {
        rigidbody.useGravity = false;

        eggman = GameObject.FindGameObjectWithTag("Eggman");
    }
    void StateFly()
    {
        if (Input.GetButtonDown(XboxButton.X))
        {
            if (isBoosting == false)
            {
                SendMessage("StateBoostStart");
                if (leftStickDirection.magnitude > 0.1f)
                {
                    transform.forward = leftStickDirection.normalized;
                }

            }
        }

        if (Input.GetButtonUp(XboxButton.X))
        {
            if (isBoosting == true)
            {
                SendMessage("StateBoostEnd");
            }
        }

        Vector2 leftStick = new Vector2(Input.GetAxis(XboxAxis.LeftStickX), Input.GetAxis(XboxAxis.LeftStickY));

        if (isBoosting)
        {
            //MainCamera.instance.manualCam = false;

            transform.Rotate(leftStick.y * 50 * Time.deltaTime, leftStick.x * 50 * Time.deltaTime, 0);

            transform.rotation = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y, 0);

            if (Mathf.Abs(leftStick.y) > 0.1f)
            {

            }
            //else
            //{
            //    transform.Rotate(0, leftStick.x * 90 * Time.deltaTime, 0);

            //    transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.FromToRotation(transform.up, Vector3.up) * transform.rotation, 5 * Time.deltaTime);
            //}

            rigidbody.velocity = transform.forward * 150;
        }
        else
        {
            //AlignPlayer();

            //MainCamera.instance.manualCam = true;

            Vector3 forsd = Camera.main.transform.forward;



            transform.forward = forsd;

            flyVelocity = (transform.forward * Input.GetAxis(XboxAxis.LeftStickY) + transform.right * Input.GetAxis(XboxAxis.LeftStickX)) * 60;

            if (Input.GetButton(XboxButton.A))
            {
                flyVelocity.y = 40;
            }
            else if (Input.GetButton(XboxButton.B))
            {
                flyVelocity.y = -40;
            }

            rigidbody.velocity = Vector3.Lerp(rigidbody.velocity, flyVelocity, 5 * Time.deltaTime);
        }



    }
    void StateFlyEnd()
    {

    }
    #endregion

    #region State Stomp
    void StateStompStart()
    {

    }
    void StateStomp()
    {
        rigidbody.velocity = Vector3.down * 40;

        if (IsGrounded())
        {
            stateMachine.ChangeState(StateTransition);
        }
    }
    void StateStompEnd()
    {
        //cameraTarget.Shake(0.2f);

    }
    #endregion

    #region State Airboost
    void StateAirboostStart()
    {
        rigidbody.useGravity = false;
        rigidbody.velocity = transform.forward * airboostVelocity;
    }
    void StateAirboost()
    {
        if (Time.time > stateMachine.lastStateTime + airboostTime)
        {
            stateMachine.ChangeState(StateFall);
        }
    }
    void StateAirboostEnd()
    {
        rigidbody.velocity *= airboostKeepVelocity;
        rigidbody.useGravity = true;
        canAirboost = false;
    }
    #endregion

    public override void StateFall()
    {
        base.StateFall();

        CheckAndStomp();
        CheckAndAirboost();
    }

    public override void StateJump()
    {
        base.StateJump();

        CheckAndStomp();
        CheckAndAirboost();
    }

    public override void StateBall()
    {
        base.StateBall();

        CheckAndStomp();
        CheckAndAirboost();
    }

    private void CheckAndStomp()
    {
        if (canStomp && Input.GetButtonDown(XboxButton.B))
        {
            stateMachine.ChangeState(StateStomp);
        }
    }

    private void CheckAndAirboost()
    {
        if (canAirboost && Input.GetButtonDown(XboxButton.X))
        {
            stateMachine.ChangeState(StateAirboost);
            return;
        }
    }


}
