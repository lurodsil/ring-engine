using UnityEngine;

public class Sonic : Player
{
    public SuperSonic superSonic;

    public float cameraTargetUpOffset = 1.7f;
    public float cameraTargetUpOffsetInAir = 1.0f;

    private bool canStomp;
    private bool canAirboost;
    [Header("Airboost")]
    public float airboostVelocity = 70;
    public float airboostTime = 0.25f;
    public float airboostKeepVelocity = 0.8f;

    public override void Update()
    {
        base.Update();

        if (groundInfo.grounded)
        {
            canStomp = true;
            canAirboost = true;
        }

        if (GameManager.instance.gameState == GameState.Playing)
        {
            stateMachine.Update();
        }

        if (Input.GetButtonDown(XboxButton.DPadUp))
        {
            stateMachine.ChangeState(StateChangeToSuperSonic);
        }
    }

    #region State Stomp
    void StateStompStart()
    {

    }
    void StateStomp()
    {
        SearchGround();

        rigidbody.velocity = Vector3.down * 40;

        if (groundInfo.grounded)
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

    #region State Change To Super Sonic
    void StateChangeToSuperSonicStart()
    {

    }
    void StateChangeToSuperSonic()
    {
        if (Time.time > stateMachine.lastStateTime + 1.8f)
        {
            superSonic.gameObject.transform.position = transform.position;
            superSonic.gameObject.transform.rotation = transform.rotation;
            superSonic.gameObject.SetActive(true);
            CameraTarget.instance.player = superSonic;
            gameObject.SetActive(false);
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
