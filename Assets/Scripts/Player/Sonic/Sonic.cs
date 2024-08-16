
using UnityEngine;

public class Sonic : Player
{
    public float cameraTargetUpOffset = 1.7f;
    public float cameraTargetUpOffsetInAir = 1.0f;

    private bool canStomp;
    private bool canAirboost;
    private bool canDoubleJump;
    [Header("Airboost")]
    public float airboostVelocity = 70;
    public float airboostTime = 0.25f;
    public float airboostKeepVelocity = 0.8f;

    float stompVelocity;

    public float startTime;
    bool paused;
    public float doubleJumpForce;
    public float doubleJumpTime;


    public bool isSuperSonic;

    public override void Start()
    {
        base.Start();

        stateMachine.Initialize(this, StateIdle);

        if (GetComponent<Animator>().GetCurrentAnimatorClipInfo(0)[0].clip.name == "sn_start_wait_a")
        {
            stateMachine.Pause();
            paused = true;
            
        }

        
    }

    public override void Update()
    {
        if (isSuper)
        {
            if (Input.GetButtonDown(XboxButton.DPadDown))
            {
                isSuper = false;
            }
        }

        base.Update();

        if (IsGrounded())
        {
            canStomp = true;
            canAirboost = true;
            canDoubleJump = true;
        }

        if (paused)
        {
            if (GetComponent<Animator>().GetCurrentAnimatorClipInfo(0)[0].clip.name != "sn_start_wait_a")
            {
                stateMachine.Play();
                paused = false;

                

                if (GameManager.instance.firstTimeLoad || GameManager.instance.activeCheckpoints.Count == 0)
                {
                    GameManager.instance.firstTimeLoad = false;
                    Timer.ResetTimer();

                }
                Timer.StartTimer();
            }
        }

        stateMachine.OnUpdate();
    }

    public void EnableDoubleJump()
    {
        canDoubleJump = true;
    }

    public override void FixedUpdate()
    {
        base.FixedUpdate();

        stateMachine.OnFixedUpdate();
    }

    #region State Stomp
    void StateStompStart()
    {
        canStomp = false;
        stompVelocity = 30;
        isAttacking = true;
        transform.rotation = Quaternion.FromToRotation(transform.up, Vector3.up) * transform.rotation;
    }
    void StateStomp()
    {
        if (IsGrounded())
        {
            stateMachine.ChangeState(StateTransition);
        }

        stompVelocity += 50 * Time.deltaTime;




    }
    public void StateStompPhysics()
    {
        if (rigidbody.velocity.y > -60)
        {
            rigidbody.velocity = Vector3.down * stompVelocity * SuperRate;
        }
    }
    void StateStompEnd()
    {
        isAttacking = false;
        MainCamera.Shake(0.2f);

        Collider stompTarget = GetGroundInformation().collider;

        if (stompTarget.GetComponent<StompingTarget>())
        {
            stompTarget.GetComponent<StompingTarget>().ReceiveStomp();
        }
    }
    #endregion

    #region State Airboost
    void StateAirboostStart()
    {
        rigidbody.velocity = (transform.forward + transform.up * 0.2f).normalized * airboostVelocity * SuperRate;
        canAirboost = false;
    }
    void StateAirboost()
    {
        transform.rotation = Quaternion.LookRotation(rigidbody.velocity.normalized);

        if (IsGrounded())
        {
            stateMachine.ChangeState(StateMove);
        }
        if (Time.time > stateMachine.lastStateTime + airboostTime)
        {
            stateMachine.ChangeState(StateFall);
        }
        CheckAndStomp();
    }
    void StateAirboostEnd()
    {
        rigidbody.velocity *= airboostKeepVelocity;

    }
    #endregion

    #region State Double Jump
    void StateDoubleJumpStart()
    {
        canDoubleJump = false;

        rigidbody.AddForce(transform.up * (doubleJumpForce - rigidbody.velocity.y), ForceMode.Impulse);
        UpdateTargets();
    }
    void StateDoubleJump()
    {
        if (IsGrounded())
        {
            stateMachine.ChangeState(StateMove);
        }
        if (Time.time > stateMachine.lastStateTime + doubleJumpTime)
        {
            stateMachine.ChangeState(StateFall);
        }
        CheckAndStomp();
        CheckAndAirboost();
    }
    private void StateDoubleJumpPhysics()
    {
        AirMotion();
    }
    void StateDoubleJumpEnd()
    {
        rigidbody.velocity *= airboostKeepVelocity;
    }
    #endregion

    #region State Change To Super Sonic
    void StateChangeToSuperSonicStart()
    {

    }
    void StateChangeToSuperSonic()
    {
        if (Time.time > stateMachine.lastStateTime + 1.8f)
        {

        }
    }
    void StateChangeToSuperSonicEnd()
    {

    }
    #endregion

    public override void StateFall()
    {
        base.StateFall();

        CheckAndStomp();
        CheckAndAirboost();
        CheckAndDoubleJump();

        //if (Input.GetButtonDown(XboxButton.DPadUp))
        //{
        //    isSuper = true;
        //    stateMachine.ChangeState(StateFly);
        //}
    }

    public override void StateJump()
    {
        base.StateJump();

        CheckAndStomp();
        CheckAndAirboost();
        CheckAndDoubleJump();
    }

    public override void StateBall()
    {
        base.StateBall();

        CheckAndStomp();
        CheckAndAirboost();
        CheckAndDoubleJump();
    }

    private void CheckAndStomp()
    {
        if (canStomp && Input.GetButtonDown(XboxButton.B))
        {
            stateMachine.ChangeState(StateStomp);
            return;
        }
    }

    private void CheckAndAirboost()
    {
        if (canAirboost && Input.GetButtonDown(XboxButton.RightTrigger))
        {
            stateMachine.ChangeState(StateAirboost);

        }
    }

    private void CheckAndDoubleJump()
    {
        if (canDoubleJump && Input.GetButtonDown(XboxButton.A))
        {
            stateMachine.ChangeState(StateDoubleJump);
            return;
        }
    }

    #region State Fly
    void StateFlyStart()
    {
        rigidbody.useGravity = false;

        rigidbody.drag = 1;

        isSuperSonic = true;
    }
    void StateFly()
    {
        CheckBoost();

        if (Input.GetButtonDown(XboxButton.Y))
        {
            stateMachine.ChangeState(StateFall);
        }
    }
    public void StateFlyPhysics()
    {
        float acceleration = 150;

        if (isBoosting)
        {
            acceleration = 300;
        }


        Vector3 direction = VectorExtension.InputDirection(Input.GetAxis(XboxAxis.LeftStickX), Input.GetAxis(XboxAxis.LeftStickY), Camera.main.transform, Camera.main.transform);

        rigidbody.AddForce(direction * acceleration, ForceMode.Acceleration);

        if (rigidbody.HorizontalVelocity().magnitude > 0.1f && !isBraking)
        {
            if (rigidbody.HorizontalVelocity().magnitude > 40)
            {
                transform.rotation = Quaternion.LookRotation(rigidbody.velocity.normalized, Vector3.up);
            }
            else
            {
                transform.rotation = Quaternion.LookRotation(rigidbody.HorizontalVelocity().normalized, Vector3.up);
            }

        }

        if (!isSuperSonic)
        {
            stateMachine.ChangeState(StateFall);
        }

        //rigidbody.velocity = Vector3.Lerp(transform.forward, direction, 6 * Time.fixedDeltaTime) * rigidbody.velocity.magnitude;

        if (Input.GetButton(XboxButton.A))
        {
            rigidbody.AddForce(Vector3.up * acceleration, ForceMode.Acceleration);
        }
        else if (Input.GetButton(XboxButton.B))
        {
            rigidbody.AddForce(Vector3.down * acceleration, ForceMode.Acceleration);
        }

    }

    void StateFlyEnd()
    {
        rigidbody.drag = 0;

        rigidbody.useGravity = true;

    }
    #endregion

}

