using RingEngine;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

[AddComponentMenu("Ring Engine/Player/Player Script")]
[RequireComponent(typeof(CapsuleCollider))]
[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour, IDamageable
{
    public LayerMask targetFindLayerMask;
    public float binormalTargetOffset;

    public LayerMask wallSearchLayerMask;
    //Cross between ground normal and right
    public Vector3 direction { get; set; }
    public Vector3 tangentCopy;
    public BezierPath bezierPath { get; set; }
    public BezierPathType pathType { get; set; }
    public BezierKnot knot = new BezierKnot();

    public ContactPoint contactPoint { get; set; }

    private Tornado tornado { get; set; }

    private float quickstepBinormalRate { get; set; } = 0.5f;

    new public Collider collider { get; set; }

    private Vector3 lastGroundedNormal;

    public bool stickToGround;

    public bool isGrinding;

    private float inputTime { get; set; }

    public new Rigidbody rigidbody { get; set; }

    //References
    new private Camera camera { get; set; }

    public GameObject playerCenter;

    //Ground Find Settings
    public GroundInfo groundInfo;

    public bool isSnowboarding;

    //Find Closest Target Settings
    private GameObject[] targets;

    [Header("Find Closest Target Settings")]
    public float targetFindRange = 10;
    public GameObject closestTarget { get; set; }

    public GameObject hommingAttackTarget { get; set; }


    [Range(0, 360)]
    public float targetFindAngle = 180;

    private SplineSensor tempSensor;
    public SplineSensor splineSensor;
    public SplineSensor grindSplineSensorL;
    public SplineSensor grindSplineSensorR;

    public static Player instance { get; set; }

    private float closestTimeOnSpline;

    public Vector3 stateStartVelocity { get; set; }
    public Vector3 stateStartDirection { get; set; }

    private Vector3 normal { get; set; }
    private Vector3 tangent;

    public bool enableHommingAfterTrick;

    [Header("Velocity")]
    //Generations variables

    public float accelerationForceLowSpeed = 12.1f;
    public float accelerationForceHighSpeed = 25f;
    public float accelerationForceBoost = 50;

    public float decelerationForceLowSpeed = 50.1f;
    public float decelerationForceHighSpeed = 25f;

    public float isBrakingForceLowSpeed = 150f;
    public float isBrakingForceHighSpeed = 100f;

    public float lowToHighVelocity = 15f;

    public float maxVelocity = 44f;
    public float maxBoostVelocity = 60f;
    public float maxDownVelocity = 60f;
    public float maxUpVelocity = 70f;

    public float sonicToSpinVelocity = 85f;
    public float spinToSonicVelocity = 75f;


    float ignoreDamageCollision;
    private float accelerationForce { get; set; }
    private float decelerationForce { get; set; }
    private float isBrakingForce { get; set; }

    public float lightSpeedDashVelocity = 30;

    //public float AccelerationForceBaseUp = 20;
    //public float AccelerationForceBySkill = 30;
    //public float AccelerationForceOnBoard = 25;
    //public float AccelerationForceOnBoardSlow = 0.3f;
    //public float AccelerationForceSps = 35.1f;
    //public float DecelerationForceBoardTurn = 20;
    //public float DecelerationForceHigh = 25;
    //public float DecelerationForceLow = 50.1f;
    //public float InAirForceAccelRate = 0.71f;
    //public float InAirForceAccelRateInLowSpd = 1.4f;
    //public float InAirForceAccelRateOnBoard = 0.15f;
    //public float InAirForceBrakeRate = 0.81f;
    //public float InAirForceBrakeRateInLowSpd = 0.7f;
    //public float InAirForceBrakeRateOnBoard = 0.4f;
    //public float InAirForceDecRate = 0.61f;
    //public float InAirForceDecRateInLowSpd = 0.41f;
    //public float InAirForceDecRateOnBoard = 0.18f;
    //public float InAirLowSpdThreshold = 15.5f;
    //public float InAirMaxAccelVelocity = 50.1f;
    //public float InAirMaxAccelVelocityInLowSpd = 15f;
    //public float InAirMaxAccelVelocityOfNormalJump = 23f;
    //public float LOW_SPEED_MAX = 30f;
    //public float LOW_TO_HIGH_TIME = 0.1f;
    //public float LimitTimeOfSpin = 0.5f;

    //public float MaxVelocityBasis = 70f;
    //public float MaxVelocityBasisBaseUp = 40f;
    //public float MaxVelocityBasisSps = 81.9993f;
    //public float MaxVelocityFinalMax = 90f;

    //public float NoPadStopWalkBeginMaxVelocity = 15f;
    //public float NoPadStopWalkDecelerationForce = 50f;
    //public float NoPadStopWalkPadLengthLimit = 0.3f;
    //public float SIDE_DECRASE_FORCE_IN_HIGHMODE = 5f;
    //public float SIDE_DECRASE_FORCE_IN_LOWMODE = 20f;
    //public float SlipToWalkVelocity = 26f;
    //public float SlopeVelocityKeepRate = 0f;
    //public float VelocityUpInFloatingBoost0 = 30f;
    //public float VelocityUpInFloatingBoost1 = 350f;

    [Header("Jump")]
    public float JumpGroundVelocityXZRate = 1;

    public float JumpGroundVelocityYRate = 1;
    public float JumpPower = 17;
    public float JumpPowerAllRounder = 4.5f;
    public float JumpPowerBySkill = 2;
    public float JumpPowerDamageAir = 20;
    public float JumpPowerMin = 6;
    public float JumpPowerMinOnBoard = 6;
    public float JumpPowerOnBoard = 15;
    public float KickbackPower = 10;
    public float MaxUpSpeedWhenJump = 18;

    public float BallJumpAirDragRateScale = 5.9f;
    public float JumpShortGroundResetDistance = 5;
    public float JumpShortReleaseTime = 0.14f;
    public float PrecedeJumpEnableTime = 0.15f;
    public float VertVelocityBallToFall = -10;

    [Header("Quickstep")]
    public float quickstepVelocity = 10;
    public float quickstepTime = 0.2f;
    public float forwardRight = 0.5f;

    [Header("Homming Attack")]
    public float hommingAttackVelocityNoTarget = 40;
    public float hommingAttackKeepVelocity = 0.2f;
    public float hommingAttackVelocity = 70;
    public float hommingAttackHitKeepVelocity = 0.05f;
    public float hommingAttackHitUpVelocity = 18;

    public float velocity;

    public Vector3 hitPoint;
    public Vector3 leftStickDirection { get; set; }
    private Vector3 horizontalVelocity { get; set; }
    private float absoluteLeftStick { get; set; }
    private float activeStick { get; set; }

    private float deadZone { get; set; } = 0.1f;

    public SpeedMode speedMode { get; set; }

    private float lastBrakeTime;

    public bool underwater { get; set; }

    private float frontAcceleration { get; set; }
    private float sideAcceleration { get; set; }

    public StateMachine stateMachine = new StateMachine();
    private Vector3 playerToEnemyDirection { get; set; }
    public bool isAttacking { get; set; }

    private GameObject pushable { get; set; }
    public Vector3 pushableNormal { get; set; }
    public Vector3 pushableCenter { get; set; }

    [HideInInspector]
    public new Transform transform;

    public float absoluteVelocity { get; private set; }

    public float rawDirection { get; set; }
    public float driftStartDirection { get; set; }

    //Velocitys from rigidbody
    private float verticalVelocity { get; set; }

    private float forwardVelocity { get; set; }

    private Transform rope { get; set; }

    public bool isBraking;
    public bool isBoosting;

    public static float transformVelocity { get; set; }

    //Jump
    private bool jumpReachedApex { get; set; }

    public bool canHomming { get; set; }
    public bool canCancelState { get; set; }

    public SkinnedMeshRenderer meshRenderer;

    public CameraTarget cameraTarget;

    [Range(0, 360)]
    public float dirMultiplier;

    float angle { get; set; }

    float tangentMultiplier { get; set; }

    public GameObject closestLightSpeedDashRing { get; set; }

    private PlayerAnimation playerAnimation { get; set; }

    public bool drown { get; set; }

    public bool ignoreDamage = false;
    public float ignoreDamageTime = 5;

    private void SetCameraTarget()
    {
        //CameraTarget.instance.player = this;
        //MainCamera.instance.player = this;
    }

    private void OnEnable()
    {
        EventManager.OnTargetObjectsChanged += UpdateTargets;
    }

    private void OnDisable()
    {
        EventManager.OnTargetObjectsChanged -= UpdateTargets;
    }

    private void Awake()
    {
        groundInfo = GetComponent<GroundInfo>();
        instance = GetComponent<Player>();
        rigidbody = GetComponent<Rigidbody>();
        transform = GetComponent<Transform>();
        collider = GetComponent<Collider>();
        camera = Camera.main;
        playerAnimation = GetComponent<PlayerAnimation>();

    }

    void Start()
    {
        stateMachine.Initialize(gameObject, StateIdle);
        SetCameraTarget();
        UpdateTargets();
    }

    public virtual void Update()
    {

        Debug.DrawRay(transform.position + transform.up, Quaternion.Euler(0, dirMultiplier, 0) * transform.forward);


        speedMode = rigidbody.velocity.magnitude <= 15f ? SpeedMode.Low : SpeedMode.High;

        if (splineSensor.bezierPath)
        {
            if (!isGrinding)
            {
                if (splineSensor.bezierPath.name.Contains("@GR"))
                {

                    if (verticalVelocity < 0)
                    {
                        if (isSnowboarding)
                        {
                            stateMachine.ChangeState(StateSnowBoardGrind);
                        }
                        else
                        {
                            stateMachine.ChangeState(StateGrind);
                        }
                    }
                }
            }

            if (pathType == BezierPathType.SideView && bezierPath != splineSensor.bezierPath)
            {
                if (splineSensor.bezierPath.name.Contains("@SV"))
                {
                    bezierPath = splineSensor.bezierPath;
                }
            }
        }

        transformVelocity = Tasks.GetTransformVelocity(transform);
        absoluteVelocity = rigidbody.velocity.magnitude;
        horizontalVelocity = new Vector3(rigidbody.velocity.x, 0, rigidbody.velocity.z);
        verticalVelocity = rigidbody.velocity.y;

        //Update The stick XboxAxis
        UpdateInputAxis();

        closestLightSpeedDashRing = gameObject.Closest(GameObject.FindGameObjectsWithTag("LightSpeedDashRing"), 1, 5, true, transform.forward, 180);



        if (groundInfo.grounded)
        {
            jumpReachedApex = false;
            canHomming = true;
            lastGroundedNormal = groundInfo.groundHit.normal;
        }

        if (Input.GetAxisRaw(XboxAxis.LeftStickX) > 0)
        {
            rawDirection = -1;
        }
        else if (Input.GetAxisRaw(XboxAxis.LeftStickX) < 0)
        {
            rawDirection = 1;
        }

        if (pathType == BezierPathType.SideView && !isGrinding)
        {
            float closestT;
            try
            {
                bezierPath.PutOnPath(transform, PutOnPathMode.BinormalOnly, out knot, out closestT, 10);
            }
            catch
            {

            }
        }

        Vector3 cross = Vector3.Cross(transform.right, groundInfo.groundHit.normal).normalized;

        if (cross != Vector3.zero)
        {
            direction = cross;
        }

        if (underwater)
        {
            rigidbody.drag = 2;

            Physics.gravity = new Vector3(0, -35 - 0) * 0.27f;
        }
        else
        {
            rigidbody.drag = 0;

            Physics.gravity = new Vector3(0, -35 - 0);
        }
    }

    public void CheckBoost()
    {
        if (Input.GetButtonDown(XboxButton.X))
        {
            SendMessage("StateBoostStart");
        }
        else if (Input.GetButtonUp(XboxButton.X))
        {
            SendMessage("StateBoostEnd");
        }
    }

    private void GrindSensorSetActive(bool active)
    {
        grindSplineSensorL.gameObject.SetActive(active);
        grindSplineSensorR.gameObject.SetActive(active);
    }

    public void UpdateTargets()
    {
        targets = GameObject.FindGameObjectsWithTag("Target");
    }

    public void FindClosestTarget()
    {
        Vector3 closestDirection = leftStickDirection != Vector3.zero ? leftStickDirection : transform.forward;

        closestTarget = playerCenter.Closest(targets, 1, targetFindRange, false, closestDirection, targetFindAngle, camera.transform.forward, 180, targetFindLayerMask);
    }

    public void SearchGround()
    {
        groundInfo.SearchGround();
    }

    public void SearchWall()
    {
        ////Make Player stop if have a wall in front of the player
        if (Physics.SphereCast(transform.position + transform.up, 0.2f, transform.forward, out _, GetComponent<CapsuleCollider>().radius, wallSearchLayerMask))
        {
            velocity = 0;

            if (isBoosting == true)
            {
                SendMessage("StateBoostEnd");
            }
        }
    }

    private void UpdateInputAxis()
    {
        //Clamp X and Y of left stick in a number between 0 and 1
        absoluteLeftStick = Mathf.Clamp01(Mathf.Abs(Input.GetAxis(XboxAxis.LeftStickX)) + Mathf.Abs(Input.GetAxis(XboxAxis.LeftStickY)));
        //Convert the X and Y of left stick to the stick pointing direction relative to the camera
        leftStickDirection = MathfExtension.StickDirection(Input.GetAxis(XboxAxis.LeftStickX), Input.GetAxis(XboxAxis.LeftStickY), camera.transform);
    }

    public void FreeMovement()
    {
        if (absoluteLeftStick > 0.1f)
        {
            //Change Sonic Rotation Based On Camera
            Quaternion targetRotation = Quaternion.LookRotation(leftStickDirection, transform.up);

            if (!isBraking)
            {
                //Apply Rotation to Sonic
                float rotationLerp = Mathf.Lerp(10f, 1f, absoluteVelocity / 15);
                transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationLerp * Time.deltaTime);
            }

        }
    }

    public void ForwardView()
    {
        //Apply Rotation to Sonic
        float rotationLerp = Mathf.Lerp(90f, 60f, absoluteVelocity / 40);
        //Rotate Sonic Based On His Forward
        //transform.Rotate(transform.up, rotationLerp * Input.GetAxis(XboxAxis.LeftStickX) * Mathf.RoundToInt(Vector3.Dot(transform.forward.normalized, Camera.main.transform.forward.normalized)) * Time.deltaTime);
        transform.Rotate(0, 40 * Input.GetAxis(XboxAxis.LeftStickX) * Mathf.RoundToInt(Vector3.Dot(transform.forward.normalized, Camera.main.transform.forward.normalized)) * Time.deltaTime, 0);
    }

    public void Drift()
    {
        //Rotate Sonic Based On His Forward
        transform.Rotate(0, -driftStartDirection * 100 * Time.deltaTime, 0);
    }

    private void AlignPlayerToMovingDirection(float minVelocity)
    {
        //If player absolute velocity is greater than min velocity.
        if (horizontalVelocity.magnitude > minVelocity)
        {
            switch (speedMode)
            {
                case SpeedMode.Low:
                    transform.rotation = Quaternion.LookRotation(direction, groundInfo.groundHit.normal);
                    break;
                case SpeedMode.High:
                    transform.rotation = Quaternion.LookRotation(direction, groundInfo.groundHit.normal);
                    break;
            }

        }
    }

    public void AlignPlayer()
    {
        angle = Vector3.Angle(transform.up, Vector3.up);

        //If player is on ground
        if (groundInfo.grounded)
        {
            switch (speedMode)
            {
                case SpeedMode.Low:
                    transform.rotation = Quaternion.FromToRotation(transform.up, groundInfo.groundHit.normal) * transform.rotation;
                    break;
                case SpeedMode.High:
                    transform.rotation = Quaternion.FromToRotation(transform.up, groundInfo.groundHit.normal) * transform.rotation;
                    break;
            }
        }
        //If player isn't on ground and the ground distance is grater than 1.
        else
        {
            if (angle > 70)
            {
                //Linear interpolate the player up to world up.
                transform.Rotate(-360 * Time.deltaTime, 0, 0);
            }
            else
            {
                //Linear interpolate the player up to world up.

                Quaternion finalRotation = Quaternion.FromToRotation(transform.up, Vector3.up) * transform.rotation;
                transform.rotation = Quaternion.Lerp(transform.rotation, finalRotation, Time.deltaTime);
            }
        }
    }

    public void PutOnGround()
    {
        if (groundInfo.grounded)
        {
            rigidbody.MovePosition(groundInfo.groundHit.point);
        }
    }

    private void BubbleBreath()
    {
        stateMachine.ChangeState(StateBubbleBreath);
    }

    private void StateBoostStart()
    {
        //MainCamera.instance.ResetSensitivity();
        isBoosting = true;
        isAttacking = true;
        cameraTarget.Shake(0.1f);
    }

    private void StateBoostEnd()
    {
        isBoosting = false;
        isAttacking = false;

    }

    public void DoDamageOrDie()
    {
        if (GameManager.instance.rings > 0)
        {
            stateMachine.ChangeState(StateHurt);
        }
        else
        {
            stateMachine.ChangeState(StateDie);
        }
    }

    private void Zero()
    {
    }

    private void CalculateVelocity()
    {
        float lowToHigh = rigidbody.velocity.magnitude / lowToHighVelocity;

        accelerationForce = Mathf.Lerp(accelerationForceLowSpeed, accelerationForceHighSpeed, lowToHigh);
        decelerationForce = Mathf.Lerp(decelerationForceLowSpeed, decelerationForceHighSpeed, lowToHigh);
        isBrakingForce = Mathf.Lerp(isBrakingForceLowSpeed, isBrakingForceHighSpeed, lowToHigh);

        if (underwater)
        {
            accelerationForce *= 0.5f;
        }
    }

    private bool RigidbodyStepClimb()
    {
        Ray ray = new Ray(transform.position + (transform.up * 0.2f) + (transform.forward * 0.3f), -transform.up);
        RaycastHit raycastHit = new RaycastHit();

        if (Physics.Raycast(ray, out raycastHit, 0.1f))
        {
            rigidbody.MovePosition(raycastHit.point);
            return true;
        }
        else
        {
            return false;
        }
    }

    private void MovementRules()
    {
        float isBrakingAngleMax = 120;
        float isBrakingAngle = Vector3.Angle(transform.forward, leftStickDirection);

        bool wallCeiling = groundInfo.groundState == GroundState.onCeiling || groundInfo.groundState == GroundState.onWall;

        if (isBrakingAngle > isBrakingAngleMax && absoluteVelocity > 0.1f && !wallCeiling)
        {
            if (isBraking == false)
            {
                SendMessage("StateBrakeStart");
                SendMessage("StateBoostEnd");
                isBraking = true;
            }
        }
        else
        {
            isBraking = false;
        }

        if (isBraking)
        {
            lastBrakeTime = Time.time;
        }
        else
        {
            if (!isBoosting && !wallCeiling && absoluteVelocity < lowToHighVelocity)
            {
                FreeMovement();
            }
            else
            {
                ForwardView();
            }
        }

        CalculateVelocity();

        if (Mathf.Abs(absoluteLeftStick) > deadZone && !isBraking && !isBoosting)
        {
            if (isBrakingAngle < 60)
            {
                velocity = Mathf.MoveTowards(velocity, maxVelocity, (accelerationForce - rigidbody.velocity.y) * Time.deltaTime);
            }
            else
            {
                velocity = Mathf.MoveTowards(velocity, rigidbody.velocity.magnitude, (decelerationForce + rigidbody.velocity.y) * Time.deltaTime);
            }
        }
        else if (isBraking)
        {
            velocity = Mathf.MoveTowards(velocity, 0, (isBrakingForce + rigidbody.velocity.y) * Time.deltaTime);
        }
        else if (isBoosting)
        {
            velocity = Mathf.MoveTowards(velocity, maxBoostVelocity, accelerationForceBoost * Time.deltaTime);
        }
        else if (Time.time > stateMachine.lastStateTime + 0.1f && rigidbody.velocity.magnitude > 0.01f)
        {
            velocity = Mathf.MoveTowards(velocity, rigidbody.velocity.magnitude, (decelerationForce + rigidbody.velocity.y) * Time.deltaTime);

            if (Mathf.Abs(Input.GetAxis(XboxAxis.LeftStickX)) < deadZone)
            {
                AlignPlayerToMovingDirection(0.02f);
            }
        }

        velocity = Mathf.Clamp(velocity, 0, 150);
    }

    #region State Transition
    private void StateTransitionStart()
    {
    }
    public void StateTransition()
    {
        SearchGround();

        if (groundInfo.grounded)
        {
            if (rigidbody.velocity.magnitude > 2)
            {
                if (Input.GetButton(XboxButton.B))
                {
                    stateMachine.ChangeState(StateSliding);
                }
                else
                {
                    stateMachine.ChangeState(StateMove);
                }
            }
            else
            {
                if (Input.GetButton(XboxButton.B))
                {
                    stateMachine.ChangeState(StateSquat);
                }
                else
                {
                    stateMachine.ChangeState(StateIdle);
                }
            }
        }
        else
        {
            if (!isSnowboarding)
            {
                stateMachine.ChangeState(StateFall);
            }
            else
            {
                stateMachine.ChangeState(StateSnowBoardFall);
            }
        }
    }
    private void StateTransitionEnd()
    {
    }
    #endregion

    #region State Idle
    private void StateIdleStart()
    {
        velocity = 0;
    }
    public virtual void StateIdle()
    {
        groundInfo.SearchGround();
        AlignPlayer();

        if (closestLightSpeedDashRing && Input.GetButtonDown(XboxButton.Y))
        {
            stateMachine.ChangeState(StateLightSpeedDash);
        }

        if (Input.GetButtonDown(XboxButton.LeftShoulder))
        {
            stateMachine.ChangeState(StateQuickstepLeft);
            return;
        }
        else if (Input.GetButtonDown(XboxButton.RightShoulder))
        {
            stateMachine.ChangeState(StateQuickstepRight);
            return;
        }

        if (Input.GetButtonDown(XboxButton.A))
        {
            stateMachine.ChangeState(StateJump);
        }

        if (Input.GetButton(XboxButton.B))
        {
            stateMachine.ChangeState(StateSquat);
        }

        if (Input.GetButtonDown(XboxButton.X))
        {
            stateMachine.ChangeState(StateMove);
        }

        if (absoluteVelocity > 0.02f || absoluteLeftStick > 0)
        {
            stateMachine.ChangeState(StateMove);
        }

        if (Input.GetButtonDown(XboxButton.X))
        {
            if (isBoosting == false)
            {
                SendMessage("StateBoostStart");
                isBoosting = true;
                isAttacking = true;
            }
            stateMachine.ChangeState(StateMove);
        }

        if (!groundInfo.grounded)
        {
            stateMachine.ChangeState(StateFall);
        }
    }
    private void StateIdleEnd()
    {
    }
    #endregion

    #region State Hurdle

    private void StateHurdleStart()
    {
        rigidbody.velocity += normal * JumpPowerMin;
    }

    public void StateHurdle()
    {
        FindClosestTarget();
        SearchGround();

        if (Input.GetButtonUp(XboxButton.A))
        {
            stateMachine.ChangeState(StateMove);
            return;
        }

        if (Time.time > stateMachine.lastStateTime + 0.14f)
        {
            stateMachine.ChangeState(StateBall);
            return;
        }

        Vector3 rbVel = rigidbody.velocity;
        rbVel.y = JumpPower;
        rigidbody.velocity = rbVel;
    }

    private void StateHurdleEnd()
    {
        velocity = absoluteVelocity;
    }

    #endregion State Hurdle

    #region State Move
    private void StateMoveStart()
    {
    }
    private void StateMove()
    {
        switch (pathType)
        {
            case BezierPathType.Dash:
                stateMachine.ChangeState(StateDash);
                break;
            case BezierPathType.QuickStep:
                stateMachine.ChangeState(StateMoveQuickStep);
                break;
            case BezierPathType.SideView:
                stateMachine.ChangeState(StateMove2D);
                break;
            default:
                stateMachine.ChangeState(StateMove3D);
                break;
        }
    }
    private void StateMoveEnd()
    {
    }

    #endregion State Move

    #region State Move 3D
    private void StateMove3DStart()
    {
        velocity = horizontalVelocity.magnitude;
    }
    public void StateMove3D()
    {
        if (pathType != BezierPathType.None)
        {
            stateMachine.ChangeState(StateMove);
            return;
        }

        if (Input.GetButtonDown(XboxButton.A))
        {
            if (absoluteVelocity > lowToHighVelocity)
            {
                stateMachine.ChangeState(StateHurdle);
            }
            else
            {
                stateMachine.ChangeState(StateJump);
            }
        }

        if (Input.GetButton(XboxButton.B))
        {
            stateMachine.ChangeState(StateSliding);
            return;
        }

        if (Input.GetButtonDown(XboxButton.X))
        {
            if (isBoosting == false)
            {
                SendMessage("StateBoostStart");
            }
        }

        if (Input.GetButtonUp(XboxButton.X))
        {
            if (isBoosting == true)
            {
                SendMessage("StateBoostEnd");
            }
        }

        if (Input.GetButtonDown(XboxButton.Y))
        {
            if (closestLightSpeedDashRing)
            {
                stateMachine.ChangeState(StateLightSpeedDash);
                return;
            }
            else
            {
                stateMachine.ChangeState(StateRoll);
                return;
            }
        }

        if (Input.GetButtonDown(XboxButton.LeftShoulder))
        {
            stateMachine.ChangeState(StateQuickstepLeft);
            return;
        }
        else if (Input.GetButtonDown(XboxButton.RightShoulder))
        {
            stateMachine.ChangeState(StateQuickstepRight);
            return;
        }

        if (Input.GetAxisRaw(XboxAxis.RightTrigger) > 0)
        {
            stateMachine.ChangeState(StateDrift);
            return;
        }

        if (absoluteVelocity < 0.2f && absoluteLeftStick == 0 && !isBoosting)
        {
            stateMachine.ChangeState(StateIdle);
            return;
        }

        SearchWall();
        groundInfo.SearchGroundHighSpeed();
        AlignPlayer();
        MovementRules();
        if (!RigidbodyStepClimb())
        {
            PutOnGround();
        }

        rigidbody.velocity = direction * velocity;

        if (!groundInfo.grounded)
        {
            stateMachine.ChangeState(StateFall);
        }
    }
    private void StateMove3DEnd()
    {
        stickToGround = true;
    }
    #endregion State Move 3D

    #region State Move 2D

    private void StateMove2DStart()
    {
        velocity = horizontalVelocity.magnitude;


        tangentMultiplier = Mathf.Sign(Vector3.Dot(transform.forward, knot.tangent));
    }

    private void StateMove2D()
    {
        groundInfo.SearchGroundHighSpeed();
        SearchWall();

        //If Sonic stops return to State Idle
        if (absoluteVelocity < 0.01f && absoluteLeftStick == 0)
        {
            stateMachine.ChangeState(StateIdle);
            return;
        }
        //Change to Jump State
        if (Input.GetButtonDown(XboxButton.A))
        {
            stateMachine.ChangeState(StateJump);
            return;
        }

        if (Input.GetButton(XboxButton.B))
        {
            stateMachine.ChangeState(StateSliding);
            return;
        }

        //Boost
        if (Input.GetButtonDown(XboxButton.X))
        {
            if (isBoosting == false)
            {
                SendMessage("StateBoostStart");
                isBoosting = true;
                isAttacking = true;
            }
        }
        else if (Input.GetButtonUp(XboxButton.X))
        {
            if (isBoosting == true)
            {
                SendMessage("StateBoostEnd");
                isBoosting = false;
                isAttacking = false;
            }
        }


        float x = Input.GetAxis(XboxAxis.LeftStickX);
        float y = Input.GetAxis(XboxAxis.LeftStickY);
        float xy = Mathf.Clamp(x + y, -1, 1);

        //Brake
        if (absoluteVelocity > 1f)
        {
            if (tangentMultiplier == 1 && xy < 0)
            {
                if (isBraking == false)
                {
                    SendMessage("StateBrakeStart");
                    SendMessage("StateBoostEnd");
                    isBraking = true;
                }
            }
            else if (tangentMultiplier == -1 && xy > 0)
            {
                if (isBraking == false)
                {
                    SendMessage("StateBrakeStart");
                    SendMessage("StateBoostEnd");
                    isBraking = true;
                }
            }
            else
            {
                isBraking = false;
            }
        }
        else
        {
            isBraking = false;
        }

        if (absoluteVelocity < 1f)
        {
            if (xy > 0)
            {
                tangentMultiplier = 1;
            }
            else if (xy < 0)
            {
                tangentMultiplier = -1;
            }
        }

        tangent = knot.tangent * tangentMultiplier;

        tangent.y = direction.y;

        transform.rotation = Quaternion.LookRotation(tangent, transform.up);

        if (Mathf.Abs(xy) > deadZone && !isBraking && !isBoosting)
        {
            velocity = Mathf.MoveTowards(velocity, 44, (accelerationForce - rigidbody.velocity.y) * Time.deltaTime);
        }
        else if (isBraking)
        {
            velocity = Mathf.MoveTowards(velocity, 0, (isBrakingForce + rigidbody.velocity.y) * Time.deltaTime);
        }
        else if (isBoosting)
        {
            velocity = Mathf.MoveTowards(velocity, maxBoostVelocity, accelerationForceBoost * Time.deltaTime);
        }
        else if (Time.time > stateMachine.lastStateTime + 0.1f && rigidbody.velocity.magnitude > 0.01f)
        {
            velocity = Mathf.MoveTowards(velocity, rigidbody.velocity.magnitude, (25f + rigidbody.velocity.y) * Time.deltaTime);
        }

        AlignPlayer();

        rigidbody.velocity = direction * velocity;

        PutOnGround();

        //If Sonic isn't on ground change to state fall
        if (!groundInfo.grounded)
        {
            stateMachine.ChangeState(StateFall);
            return;
        }
    }

    private void StateMove2DEnd()
    {
    }

    #endregion State Move 2D   

    #region State Move Quickstep
    private void StateMoveQuickStepStart()
    {
        velocity = horizontalVelocity.magnitude;
    }
    private void StateMoveQuickStep()
    {
        groundInfo.SearchGroundHighSpeed();
        SearchWall();

        if (pathType != BezierPathType.QuickStep)
        {
            stateMachine.ChangeState(StateMove);
            return;
        }

        if (Input.GetButtonDown(XboxButton.A))
        {
            if (absoluteVelocity > lowToHighVelocity)
            {
                stateMachine.ChangeState(StateHurdle);
            }
            else
            {
                stateMachine.ChangeState(StateJump);
            }
        }

        if (Input.GetButton(XboxButton.B))
        {
            stateMachine.ChangeState(StateSliding);
            return;
        }

        if (Input.GetButtonDown(XboxButton.X))
        {
            if (isBoosting == false)
            {
                SendMessage("StateBoostStart");
            }
        }

        if (Input.GetButtonUp(XboxButton.X))
        {
            if (isBoosting == true)
            {
                SendMessage("StateBoostEnd");
            }
        }

        if (Input.GetButtonDown(XboxButton.Y))
        {
            if (closestLightSpeedDashRing)
            {
                stateMachine.ChangeState(StateLightSpeedDash);
                return;
            }
            else
            {
                stateMachine.ChangeState(StateRoll);
                return;
            }
        }

        //if (Input.GetButtonDown(XboxButton.LeftShoulder))
        //{
        //    stateMachine.ChangeState( StateQuickstepLeft);
        //    return;
        //}
        //else if (Input.GetButtonDown(XboxButton.RightShoulder))
        //{
        //    stateMachine.ChangeState( StateQuickstepRight);
        //    return;
        //}

        if (Input.GetAxisRaw(XboxAxis.RightTrigger) > 0)
        {
            stateMachine.ChangeState(StateDrift);
            return;
        }

        if (absoluteVelocity < 0.2f && absoluteLeftStick == 0 && !isBoosting)
        {
            stateMachine.ChangeState(StateIdle);
            return;
        }

        BezierKnot knot = new BezierKnot();
        float dotTangent = Vector3.Dot(knot.tangent, transform.forward);
        tangent = knot.tangent * dotTangent;


        if (speedMode == SpeedMode.High)
        {
            bezierPath.PutOnPath(transform, PutOnPathMode.BinormalOnly, out knot, out _, 0, binormalTargetOffset);

            transform.rotation = Quaternion.FromToRotation(transform.forward, tangent) * transform.rotation;////Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(knot.tangent, groundInfo.groundHit.normal), 30 * Time.deltaTime);
        }

        SearchWall();
        groundInfo.SearchGroundHighSpeed();
        AlignPlayer();
        MovementRules();



        if (!RigidbodyStepClimb())
        {
            PutOnGround();
        }

        rigidbody.velocity = direction * velocity;

        if (!groundInfo.grounded)
        {
            stateMachine.ChangeState(StateFall);
        }
    }
    private void StateMoveQuickStepEnd()
    {
    }

    #endregion State Move Quickstep  

    #region State Dash
    private void StateDashStart()
    {
        velocity = horizontalVelocity.magnitude;
    }

    private void StateDash()
    {
        //if (pathType != BezierPathType.Dash)
        //{
        //    stateMachine.ChangeState( StateMove);
        //    return;
        //}

        ////If Sonic stops return to State Idle
        //if (absoluteVelocity < 0.01f && absoluteLeftStick == 0)
        //{
        //    stateMachine.ChangeState( StateIdle);
        //    return;
        //}

        ////Change to Jump State
        //if (Input.GetButtonDown(XboxButton.A))
        //{
        //    stateMachine.ChangeState( StateJump);
        //    return;
        //}

        ////Boost
        //if (Input.GetButtonDown(XboxButton.X))
        //{
        //    if (isBoosting == false)
        //    {
        //        SendMessage("StateBoostStart");
        //        isBoosting = true;
        //        velocityConstants = isBoostingConstants;
        //        isAttacking = true;
        //    }
        //}

        //if (Input.GetButtonUp(XboxButton.X))
        //{
        //    if (isBoosting == true)
        //    {
        //        SendMessage("StateBoostEnd");
        //        isBoosting = false;
        //        isAttacking = false;
        //        velocityConstants = defaultConstants;
        //    }
        //}

        //speedMode = rigidbody.velocity.magnitude < 15f ? SpeedMode.Low : SpeedMode.High;

        //switch (speedMode)
        //{
        //    case SpeedMode.Low:
        //        activeStick = absoluteLeftStick;
        //        FreeMovement();
        //        break;

        //    case SpeedMode.High:
        //        activeStick = Input.GetAxis(XboxAxis.LeftStickY);
        //        ForwardView();
        //        break;
        //}

        //float dotTFLS = Vector3.Dot(transform.forward, leftStickDirection);

        ////Brake
        //if (dotTFLS < -0.5f && absoluteVelocity > 1f)
        //{
        //    if (isBraking == false)
        //    {
        //        SendMessage("StateBrakeStart");
        //        SendMessage("StateBoostEnd");
        //        isBraking = true;
        //    }
        //}
        //else
        //{
        //    isBraking = false;
        //}

        //if (Mathf.Abs(activeStick) > deadZone && !isBraking && !isBoosting)
        //{
        //    if (dotTFLS > 0.3f)
        //    {
        //        velocity = Mathf.MoveTowards(velocity, 44, (AccelerationForce - rigidbody.velocity.y) * Time.deltaTime);
        //    }
        //    else
        //    {
        //        velocity = Mathf.MoveTowards(velocity, rigidbody.velocity.magnitude, (DecelerationForceHigh + rigidbody.velocity.y) * Time.deltaTime);
        //    }
        //}
        //else if (isBraking)
        //{
        //    velocity = Mathf.MoveTowards(velocity, 0, (DecelerationForceLow + rigidbody.velocity.y) * Time.deltaTime);
        //}
        //else if (isBoosting)
        //{
        //    velocity = Mathf.MoveTowards(velocity, MaxVelocityBasis, 150 * Time.deltaTime);
        //}
        //else if (Time.time > stateMachine.lastStateTime + 0.1f && rigidbody.velocity.magnitude > 0.01f)
        //{
        //    velocity = Mathf.MoveTowards(velocity, rigidbody.velocity.magnitude, (25f + rigidbody.velocity.y) * Time.deltaTime);
        //}

        //SearchGround();
        //SearchWall();
        //BezierKnot knot = new BezierKnot();
        //float closestTimeOnSpline = 0;
        //if (speedMode == SpeedMode.High)
        //{
        //    bezierPath.PutOnPath(transform, PutOnPathMode.BinormalOnly, out knot, out closestTimeOnSpline, 0, 0.5f);
        //    transform.rotation = Quaternion.FromToRotation(transform.forward, knot.tangent) * transform.rotation;////Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(knot.tangent, groundInfo.groundHit.normal), 30 * Time.deltaTime);
        //}
        //AlignPlayer();
        //rigidbody.velocity = transform.forward * velocity;
        //PutOnGround();

        ////If Sonic isn't on ground change to state fall
        //if (!groundInfo.grounded)
        //{
        //    stateMachine.ChangeState( StateFall);
        //    return;
        //}
    }

    private void StateDashEnd()
    {
    }

    #endregion State Dash

    #region State Quickstep Left
    private void StateQuickstepLeftStart()
    {
        stateStartVelocity = rigidbody.velocity;
        stateStartDirection = transform.forward;
    }
    private void StateQuickstepLeft()
    {
        rigidbody.velocity -= transform.right * quickstepVelocity;
        stateMachine.ChangeState(StateMove, quickstepTime);
    }
    private void StateQuickstepLeftEnd()
    {
        rigidbody.velocity = stateStartVelocity;
        transform.forward = stateStartDirection;
    }
    #endregion

    #region State Quickstep Right
    private void StateQuickstepRightStart()
    {
        stateStartVelocity = rigidbody.velocity;
        stateStartDirection = transform.forward;
    }
    private void StateQuickstepRight()
    {
        rigidbody.velocity += transform.right * quickstepVelocity;
        stateMachine.ChangeState(StateMove, quickstepTime);
    }
    private void StateQuickstepRightEnd()
    {
        rigidbody.velocity = stateStartVelocity;
        transform.forward = stateStartDirection;
    }
    #endregion State

    #region State Spindash
    private void StateSpindashStart()
    {
        velocity = 30;
    }
    private void StateSpindash()
    {
        FreeMovement();
        SearchGround();
        AlignPlayer();
        PutOnGround();

        rigidbody.velocity = Vector3.zero;

        if (Input.GetButtonUp(XboxButton.B))
        {
            stateMachine.ChangeState(StateRoll);
        }

        if (Input.GetButtonDown(XboxButton.Y))
        {
            if (velocity < 80)
            {
                velocity += 10;
            }
        }

        velocity = Mathf.Lerp(velocity, 30, Time.deltaTime);

        print(velocity);
    }
    private void StateSpindashEnd()
    {
        rigidbody.velocity = transform.forward * velocity;
    }
    #endregion State

    #region State Roll
    private void StateRollStart()
    {
        velocity = rigidbody.velocity.magnitude;
    }
    private void StateRoll()
    {
        UpdateInputAxis();
        if (Input.GetButtonDown(XboxButton.Y))
        {
            stateMachine.ChangeState(StateMove);
        }

        SearchGround();
        AlignPlayer();
        if (absoluteLeftStick < deadZone && absoluteVelocity > 1)
        {
            transform.rotation = Quaternion.LookRotation(rigidbody.velocity.normalized, transform.up);
        }

        if (groundInfo.grounded)
        {
            velocity = Mathf.MoveTowards(rigidbody.velocity.magnitude, 0, (2 * rigidbody.velocity.y) * Time.deltaTime);

            Vector3 direction = Vector3.Cross(transform.right, groundInfo.groundHit.normal);

            rigidbody.velocity = direction * velocity;
        }
        PutOnGround();

        switch (speedMode)
        {
            case SpeedMode.Low:
                activeStick = absoluteLeftStick;
                FreeMovement();
                break;

            case SpeedMode.High:
                activeStick = Input.GetAxis(XboxAxis.LeftStickY);
                ForwardView();
                break;
        }

        if (absoluteVelocity < 2)
        {
            stateMachine.ChangeState(StateIdle);
        }
    }
    private void StateRollEnd()
    {
    }
    #endregion State

    #region State Squat
    private void StateSquatStart()
    {
        velocity = 0;

    }
    private void StateSquat()
    {
        if (Input.GetButtonDown(XboxButton.Y))
        {
            stateMachine.ChangeState(StateSpindash);
        }

        if (Input.GetButtonDown(XboxButton.X))
        {
            stateMachine.ChangeState(StateSquatKick);
        }

        if (!Input.GetButton(XboxButton.B))
        {
            stateMachine.ChangeState(StateIdle);
        }

        if (Input.GetButtonDown(XboxButton.A))
        {
            stateMachine.ChangeState(StateJump);
        }

        if (absoluteLeftStick > 0.1f && groundInfo.groundState == GroundState.onGround && Time.time > stateMachine.lastStateTime + 0.5f)
        {
            stateMachine.ChangeState(StateCrawling);
        }

        if (rigidbody.velocity.magnitude > 2)
        {
            stateMachine.ChangeState(StateSliding);
        }

        rigidbody.velocity = Vector3.zero;
    }
    private void StateSquatEnd()
    {
    }
    #endregion State Squat

    #region State Squat Kick

    private void StateSquatKickStart()
    {
    }

    private void StateSquatKick()
    {
        stateMachine.ChangeState(StateSquat);
    }

    private void StateSquatKickEnd()
    {
    }

    #endregion State Squat Kick

    #region State Crawling

    private void StateCrawlingStart()
    {
    }

    private void StateCrawling()
    {
        FreeMovement();

        if (absoluteLeftStick > 0.1f)
        {
            rigidbody.velocity = transform.forward * 2;
        }
        else
        {
            stateMachine.ChangeState(StateSquat);
        }
    }

    private void StateCrawlingEnd()
    {
    }

    #endregion State Crawling

    #region State Sliding

    private void StateSlidingStart()
    {
        ForwardView();
    }

    private void StateSliding()
    {
        if (!Input.GetButton(XboxButton.B))
        {
            stateMachine.ChangeState(StateMove);
        }

        if (absoluteVelocity < 0.015f)
        {
            stateMachine.ChangeState(StateSquat);
        }

        if (Input.GetButtonDown(XboxButton.A))
        {
            stateMachine.ChangeState(StateJump);
        }

        if (!groundInfo.grounded)
        {
            stateMachine.ChangeState(StateFall);
        }

        if (Input.GetAxisRaw(XboxAxis.LeftStickX) == 0)
        {
            AlignPlayerToMovingDirection(1);
        }

        velocity = Mathf.MoveTowards(rigidbody.velocity.magnitude, 0, (10 + rigidbody.velocity.y) * Time.deltaTime);

        ForwardView();
        SearchWall();
        SearchGround();
        AlignPlayer();

        Vector3 direction = Vector3.Cross(transform.right, groundInfo.groundHit.normal);
        rigidbody.velocity = direction * velocity;

        if (speedMode == SpeedMode.High)
        {
            PutOnGround();
        }
    }

    private void StateSlidingEnd()
    {
    }

    #endregion State Sliding

    #region State

    private void StateStart()
    {
    }

    private void State()
    {
    }

    private void StateEnd()
    {
    }

    #endregion State

    #region State Wall Jump
    private void StateWallJumpStart()
    {
        velocity = 0;


    }
    private void StateWallJump()
    {
        transform.rotation = Quaternion.LookRotation(-contactPoint.normal);

        SearchGround();

        if (groundInfo.grounded)
        {
            stateMachine.ChangeState(StateIdle);
        }

        velocity = Mathf.MoveTowards(velocity, Physics.gravity.y, 3 * Time.deltaTime);

        rigidbody.velocity = Vector3.up * velocity;

        if (Input.GetButtonDown(XboxButton.A))
        {
            rigidbody.velocity = (contactPoint.normal + Vector3.up) * 15;

            stateMachine.ChangeState(StateFall);
        }

        if (!Physics.Raycast(transform.position, transform.forward, 0.5f))
        {
            stateMachine.ChangeState(StateFall);
        }
    }
    private void StateWallJumpEnd()
    {
        transform.forward = contactPoint.normal;
    }

    #endregion State

    #region State Light Speed Dash

    private void StateLightSpeedDashStart()
    {
    }

    private void StateLightSpeedDash()
    {
        if (!closestLightSpeedDashRing)
        {
            stateMachine.ChangeState(StateFall);
        }
        else
        {
            rigidbody.velocity = Vector3Extension.Direction(transform.position, closestLightSpeedDashRing.transform.position + Vector3.down * 0.5f) * lightSpeedDashVelocity;
            transform.forward = rigidbody.velocity.normalized;
        }
    }

    private void StateLightSpeedDashEnd()
    {
    }

    #endregion State

    #region State Grind
    private void StateGrindStart()
    {
        isGrinding = true;
        rigidbody.useGravity = false;
        groundInfo.grindGrounded = true;

        GrindSensorSetActive(true);
        velocity = rigidbody.velocity.magnitude;
    }
    private void StateGrind()
    {
        if (!splineSensor.bezierPath)
        {
            isGrinding = false;
            GrindSensorSetActive(false);
            stateMachine.ChangeState(StateFall);
            return;
        }

        if (Time.time > stateMachine.lastStateTime + 0.5f)
        {
            if (Input.GetButtonDown(XboxButton.LeftShoulder) && grindSplineSensorL.bezierPath)
            {
                tempSensor.bezierPath = grindSplineSensorL.bezierPath;
                stateMachine.ChangeState(StateGrindSwitchLeft);
                return;
            }
            else if (Input.GetButtonDown(XboxButton.RightShoulder) && grindSplineSensorR.bezierPath)
            {
                tempSensor.bezierPath = grindSplineSensorR.bezierPath;
                stateMachine.ChangeState(StateGrindSwitchRight);
                return;
            }
            else if (Input.GetButtonDown(XboxButton.A))
            {
                stateMachine.ChangeState(StateGrindJump);
                return;
            }
        }

        CheckBoost();

        splineSensor.bezierPath.PutOnPath(transform, PutOnPathMode.BinormalAndNormal, out knot, out _, 15);

        //Sign to get if player is moving forward on grind direction
        float sign = Mathf.Sign(Vector3.Dot(transform.forward, knot.tangent));
        //Multiply by grind direction, if sign is negative player will move in oposite direction
        Vector3 tangent = knot.tangent * sign;
        //Multiply by binormal direction to get bendings
        Vector3 binormal = knot.binormal * sign;
        //Calculate normal bending based on binormal and tangent
        Vector3 normal = isBoosting ? knot.normal : Vector3.Lerp(knot.normal - binormal, knot.normal + binormal, 0.5f + playerAnimation.tangent * 0.2f);

        transform.rotation = Quaternion.LookRotation(tangent, normal);

        if (isBoosting)
        {
            velocity = 50;
        }
        else
        {
            velocity = Mathf.Clamp(Mathf.MoveTowards(velocity, 0, (0.5f + rigidbody.velocity.y * 0.5f) * Time.deltaTime), 10, 40);
        }

        rigidbody.velocity = tangent * velocity;
    }
    private void StateGrindEnd()
    {
        rigidbody.useGravity = true;
        groundInfo.grindGrounded = false;
    }
    #endregion State Grind

    #region State Grind Jump
    private void StateGrindJumpStart()
    {
        rigidbody.velocity = new Vector3(rigidbody.velocity.x, 10, rigidbody.velocity.z);
        groundInfo.grindGrounded = true;
    }
    private void StateGrindJump()
    {
        if (Input.GetButton(XboxButton.A))
        {
            if (Time.time > stateMachine.lastStateTime + 0.2f)
            {
                isGrinding = false;
                splineSensor.bezierPath = null;
                rigidbody.velocity = new Vector3(rigidbody.velocity.x, 8, rigidbody.velocity.z);
                stateMachine.ChangeState(StateBall);
                return;
            }
        }

        if (Time.time > stateMachine.lastStateTime + 0.6f || !splineSensor.bezierPath)
        {
            isGrinding = false;
            splineSensor.bezierPath = null;
            GrindSensorSetActive(false);
            stateMachine.ChangeState(StateFall);
            return;
        }

        splineSensor.bezierPath.PutOnPath(transform, PutOnPathMode.BinormalOnly, out knot);

        splineSensor.transform.localPosition = transform.InverseTransformPoint(knot.point);

        CheckBoost();

        //Sign to get if player is moving forward on grind direction
        float sign = Mathf.Sign(Vector3.Dot(transform.forward, knot.tangent));
        //Multiply by grind direction, if sign is negative player will move in oposite direction
        Vector3 tangent = knot.tangent * sign;

        transform.rotation = Quaternion.LookRotation(tangent, knot.normal);

        if (transform.position.y < knot.point.y)
        {
            stateMachine.ChangeState(StateGrind);
        }
    }
    private void StateGrindJumpEnd()
    {
        groundInfo.grindGrounded = false;
        splineSensor.transform.localPosition = Vector3.zero;
    }
    #endregion State Grind

    #region State Grind Switch
    private void StateGrindSwitchStart()
    {
        rigidbody.useGravity = false;
        groundInfo.grindGrounded = true;

    }
    private void StateGrindSwitch()
    {
        CheckBoost();

        if (Time.time > stateMachine.lastStateTime + 0.15f)
        {
            tempSensor.bezierPath.PutOnPath(transform, PutOnPathMode.BinormalAndNormal, out knot, out _, 15 * (Time.time - stateMachine.lastStateTime));

            if (Time.time > stateMachine.lastStateTime + 0.65f)
            {
                stateMachine.ChangeState(StateGrind);
                return;
            }
        }

        //Sign to get if player is moving forward on grind direction
        float sign = Mathf.Sign(Vector3.Dot(transform.forward, knot.tangent));
        //Multiply by grind direction, if sign is negative player will move in oposite direction
        Vector3 tangent = knot.tangent * sign;

        transform.rotation = Quaternion.LookRotation(tangent, knot.normal);

        rigidbody.velocity = tangent * velocity;
    }
    private void StateGrindSwitchEnd()
    {
        rigidbody.useGravity = true;
        groundInfo.grindGrounded = false;
    }
    #endregion

    #region State Grind Switch Left
    private void StateGrindSwitchLeftStart()
    {
        StateGrindSwitchStart();
    }
    private void StateGrindSwitchLeft()
    {
        StateGrindSwitch();
    }
    private void StateGrindSwitchLeftEnd()
    {
        StateGrindSwitchEnd();
    }
    #endregion

    #region State Grind Switch Right
    private void StateGrindSwitchRightStart()
    {
        StateGrindSwitchStart();
    }
    private void StateGrindSwitchRight()
    {
        StateGrindSwitch();
    }
    private void StateGrindSwitchRightEnd()
    {
        StateGrindSwitchEnd();
    }
    #endregion

    #region State Drift

    private void StateDriftStart()
    {
        driftStartDirection = rawDirection;
    }

    private void StateDrift()
    {
        if (Input.GetButtonUp(XboxButton.X))
        {
            if (isBoosting == true)
            {
                SendMessage("StateBoostEnd");
            }
        }

        Drift();

        rigidbody.velocity = transform.forward * velocity;

        if (Input.GetAxisRaw(XboxAxis.RightTrigger) == 0)
        {
            stateMachine.ChangeState(StateMove);
        }

        SearchWall();
        groundInfo.SearchGroundHighSpeed();
        AlignPlayer();

        Vector3 direction = Vector3.Cross(transform.right, groundInfo.groundHit.normal);
        rigidbody.velocity = direction * velocity;

        if (speedMode == SpeedMode.High)
        {
            PutOnGround();
        }


        //If Sonic isn't on ground change to state fall
        if (!groundInfo.grounded)
        {
            stateMachine.ChangeState(StateFall);
            return;
        }
    }

    private void StateDriftEnd()
    {
    }

    #endregion State Drift

    #region State Pushing

    private void StatePushingStart()
    {
    }

    private void StatePushing()
    {
        Vector3 offset = transform.position + transform.forward;

        pushable.transform.position = new Vector3(offset.x, pushable.transform.position.y, offset.z);
        pushable.transform.rotation = transform.rotation;
        transform.RotateAround(pushable.transform.position, Vector3.up, 45 * Input.GetAxis(XboxAxis.LeftStickX) * Time.deltaTime);
        rigidbody.velocity = transform.forward * absoluteLeftStick * 2;

        if (absoluteVelocity < 0.1f)
        {
            stateMachine.ChangeState(StateIdle);
        }
    }

    private void StatePushingEnd()
    {
    }

    #endregion State Pushing

    #region State Fall
    private void StateFallStart()
    {
        isBoosting = false;
        contactPoint = new ContactPoint();
        print(stateMachine.lastStateName);
        UpdateTargets();
    }
    public virtual void StateFall()
    {
        FindClosestTarget();
        SearchGround();
        AlignPlayer();


        //float dotTForwardSDirection = Vector3.Dot(transform.forward.normalized, leftStickDirection.normalized);
        if (stateMachine.lastStateName == "StateWallJump")
        {
            float angle = Vector3.Angle(contactPoint.normal, Vector3.up);
            if (contactPoint.point != Vector3.zero && angle > 85 && angle < 95)
            {
                transform.position = contactPoint.point + contactPoint.normal * 0.4f;
                transform.forward = -contactPoint.normal;
                stateMachine.ChangeState(StateWallJump);
            }
        }


        if (Input.GetButtonDown(XboxButton.A))
        {
            float angle = Vector3.Angle(contactPoint.normal, Vector3.up);
            if (contactPoint.point != Vector3.zero && angle > 85 && angle < 95)
            {
                transform.position = contactPoint.point + contactPoint.normal * 0.4f;
                transform.forward = -contactPoint.normal;
                stateMachine.ChangeState(StateWallJump);
            }
            else if (canHomming)
            {
                stateMachine.ChangeState(StateHoming);
            }
        }

        if (groundInfo.grounded)
        {
            stateMachine.ChangeState(StateIdle);
        }

        if (pathType == BezierPathType.SideView)
        {
            AirAlign();
        }
        else
        {

            if (absoluteLeftStick > 0)
            {
                rigidbody.AddForce(leftStickDirection * 100 * GameManager.deltaStep);
            }

            if (rigidbody.HorizontalVelocity().magnitude > 1)
            {
                transform.rotation = Quaternion.LookRotation(rigidbody.HorizontalVelocity().normalized);
            }
        }

        rigidbody.velocity = ClampVelocity(rigidbody.velocity, maxVelocity, maxDownVelocity, maxUpVelocity);
    }
    private void StateFallEnd()
    {
        //MainCamera.cameraMode = CameraMode.defaultCameraMode;
        //playerMesh.transform.localRotation = Quaternion.Euler(90, 0, 0);
        velocity = horizontalVelocity.magnitude;
        if (groundInfo.grounded)
        {
            AlignPlayerToMovingDirection(1);
        }
    }
    #endregion State Fall

    #region State Jump
    private void StateJumpStart()
    {
        rigidbody.velocity += lastGroundedNormal * JumpPowerMin;
    }
    public virtual void StateJump()
    {
        FindClosestTarget();
        SearchGround();

        if (Input.GetButtonUp(XboxButton.A))
        {
            stateMachine.ChangeState(StateFall);
            return;
        }

        if (Time.time > stateMachine.lastStateTime + 0.14f)
        {
            stateMachine.ChangeState(StateBall);
            return;
        }

        Vector3 rbVel = rigidbody.velocity;
        rbVel.y = JumpPower;
        rigidbody.velocity = rbVel;

        if (absoluteLeftStick > 0)
        {
            rigidbody.AddForce(leftStickDirection * 100 * GameManager.deltaStep);
        }

        if (rigidbody.HorizontalVelocity().magnitude > 1)
        {
            transform.rotation = Quaternion.LookRotation(rigidbody.HorizontalVelocity().normalized);
        }

        rigidbody.velocity = ClampVelocity(rigidbody.velocity, maxVelocity, maxDownVelocity, maxUpVelocity);
    }
    private void StateJumpEnd()
    {
    }
    #endregion State Jump

    #region State Ball
    private void StateBallStart()
    {
        isAttacking = true;
        isBoosting = false;
    }
    public virtual void StateBall()
    {
        FindClosestTarget();
        SearchGround();

        if (Input.GetButtonDown(XboxButton.A))
        {
            //float angle = Vector3.Angle(contactPoint.normal, Vector3.up);
            //if (contactPoint.point != Vector3.zero && angle > 85 && angle < 95)
            //{
            //    transform.position = contactPoint.point + contactPoint.normal * 0.4f;
            //    transform.forward = -contactPoint.normal;
            //    stateMachine.ChangeState( StateWallJump);
            //}
            //else 
            if (canHomming)
            {
                stateMachine.ChangeState(StateHoming);
            }
        }

        if (!Input.GetButton(XboxButton.A))
        {
            jumpReachedApex = true;
        }

        if (Time.time > stateMachine.lastStateTime + 0.15f)
        {
            jumpReachedApex = true;
        }

        if (underwater)
        {
            if (rigidbody.velocity.y < 0)
            {
                stateMachine.ChangeState(StateFall);
            }
        }
        else
        {
            if (rigidbody.velocity.y < -10)
            {
                stateMachine.ChangeState(StateFall);
            }
        }


        if (groundInfo.grounded)
        {
            stateMachine.ChangeState(StateIdle);
        }


        if (!jumpReachedApex)
        {
            Vector3 rbVel = rigidbody.velocity;
            rbVel.y = JumpPower;
            rigidbody.velocity = rbVel;
        }

        if (pathType == BezierPathType.SideView)
        {
            AirAlign();
        }
        else
        {
            if (absoluteLeftStick > 0)
            {
                rigidbody.AddForce(leftStickDirection * 100 * GameManager.deltaStep);
            }

            if (rigidbody.HorizontalVelocity().magnitude > 1)
            {
                transform.rotation = Quaternion.LookRotation(rigidbody.HorizontalVelocity().normalized);
            }
        }

        AlignPlayer();
        rigidbody.velocity = ClampVelocity(rigidbody.velocity, maxVelocity, maxDownVelocity, maxUpVelocity);
    }
    private void StateBallEnd()
    {
        //MainCamera.cameraMode = CameraMode.defaultCameraMode;
        isAttacking = false;
    }
    #endregion State Ball

    #region State Carry

    private void StateCarryStart()
    {
        rigidbody.velocity += transform.up * 10;

        //MainCamera.cameraMode = CameraMode.ChangeSensitivity(50);
    }

    private void StateCarry()
    {
        SearchGround();

        float currentVerticalSpeed = rigidbody.velocity.y;

        if (absoluteLeftStick > 0.1f)
        {
            forwardVelocity += 5 * Time.deltaTime;
        }
        //Decelerate Sonic
        else
        {
            forwardVelocity -= 5 * Time.deltaTime;
        }

        forwardVelocity = Mathf.Clamp(forwardVelocity, 0, 20);

        rigidbody.velocity = transform.forward * forwardVelocity;

        if (Input.GetButton(XboxButton.A))
        {
            currentVerticalSpeed += 50 * Time.deltaTime;
        }
        else
        {
            currentVerticalSpeed += 25 * Time.deltaTime;
        }

        rigidbody.velocity = new Vector3(rigidbody.velocity.x, currentVerticalSpeed, rigidbody.velocity.z);

        if (groundInfo.groundHit.distance < 1)
        {
            stateMachine.ChangeState(StateFall);
        }
    }

    private void StateCarryEnd()
    {
        //MainCamera.cameraMode = CameraMode.ChangeSensitivity(30);
    }

    #endregion State Carry

    #region State Die

    private void StateDieStart()
    {

    }

    private void StateDie()
    {
        SearchGround();
        if (Time.time > stateMachine.lastStateTime + 3)
        {
            //Main.lives--;
            //SceneManager.LoadScene(0);
        }
    }

    private void StateDieEnd()
    {
    }

    #endregion State Die

    #region State Hurt

    private void StateHurtStart()
    {

    }

    public void StateHurt()
    {
        SearchGround();

        if (Time.time > stateMachine.lastStateTime + 1.8f)
        {
            stateMachine.ChangeState(StateIdle);
        }
    }

    private void StateHurtEnd()
    {
    }

    #endregion State Hurt

    #region State Homing
    private void StateHomingStart()
    {
        FindClosestTarget();
        isAttacking = true;
        canHomming = false;

        hommingAttackTarget = closestTarget;
    }
    public virtual void StateHoming()
    {
        if (hommingAttackTarget)
        {
            transform.LookAt(hommingAttackTarget.transform);
            rigidbody.velocity = transform.forward * hommingAttackVelocity;
        }
        //If no targets and the time on the state is greater than 0.2 seconds.
        else
        {
            rigidbody.velocity = transform.forward * hommingAttackVelocityNoTarget;
            stateMachine.ChangeState(StateFall, 0.2f);
        }
    }
    private void StateHomingEnd()
    {
        if (stateMachine.nextStateName == "StateFall")
        {
            rigidbody.velocity *= hommingAttackKeepVelocity;
        }

        FindClosestTarget();
    }
    #endregion State Homing

    #region State Homing Trick
    private void StateHomingTrickStart()
    {
        isAttacking = true;

        Vector3 rigidbodyKeepVelocity = rigidbody.velocity * hommingAttackHitKeepVelocity;
        rigidbodyKeepVelocity.y = hommingAttackHitUpVelocity;
        rigidbody.velocity = rigidbodyKeepVelocity;
    }
    private void StateHomingTrick()
    {
        stateMachine.ChangeState(StateFall, 0.25f);
    }
    private void StateHomingTrickEnd()
    {
        canHomming = enableHommingAfterTrick;
        isAttacking = false;
    }
    #endregion State Homing Trick

    //#region StateLightSpeedDash
    //void StateLightSpeedDashStart()
    //{
    //}
    //void StateLightSpeedDash()
    //{
    //
    //    if (!closestLightSpeedDashRing)
    //    {
    //        stateMachine.ChangeState( StateTransition);
    //    }
    //    else
    //    {
    //        rigidbody.velocity = ((closestLightSpeedDashRing.transform.position + Vector3.down * 0.5f) - transform.position).normalized * 50;
    //        transform.forward = rigidbody.velocity.normalized;
    //    }

    //}
    //void StateLightSpeedDashEnd()
    //{
    //    ForwardView();
    //    rigidbody.velocity /= 2;
    //}
    //#endregion

    #region State Bubble Breath
    private void StateBubbleBreathStart()
    {
        GameManager.instance.SendMessage("UnderwaterReset", SendMessageOptions.DontRequireReceiver);
    }
    private void StateBubbleBreath()
    {
        stateMachine.ChangeState(StateFall, 1);
        rigidbody.velocity = Vector3.up * 2;
    }
    private void StateBubbleBreathEnd()
    {
    }
    #endregion State Bubble Breath

    #region State Skydive
    private void StateSkydiveStart()
    {
        rigidbody.useGravity = false;
    }
    public void StateSkydive()
    {
        SearchGround();
        if (Input.GetAxis(XboxAxis.LeftStickY) > 0)
        {
            frontAcceleration += 0.7f * Time.deltaTime;

            if (frontAcceleration > 20)
            {
                frontAcceleration = 20;
            }
        }
        else if (Input.GetAxis(XboxAxis.LeftStickY) < 0)
        {
            frontAcceleration -= 0.7f * Time.deltaTime;

            if (frontAcceleration < -20)
            {
                frontAcceleration = -20;
            }
        }
        else
        {
            if (frontAcceleration > 0)
            {
                frontAcceleration -= 0.4f * Time.deltaTime;

                if (frontAcceleration < 0)
                {
                    frontAcceleration = 0;
                }
            }
            else
            {
                frontAcceleration += 0.4f * Time.deltaTime;

                if (frontAcceleration > 0)
                {
                    frontAcceleration = 0;
                }
            }
        }

        if (Input.GetAxis(XboxAxis.LeftStickX) > 0)
        {
            sideAcceleration += 0.7f * Time.deltaTime;

            if (sideAcceleration > 20)
            {
                sideAcceleration = 20;
            }
        }
        else if (Input.GetAxis(XboxAxis.LeftStickX) < 0)
        {
            sideAcceleration -= 0.7f * Time.deltaTime;

            if (sideAcceleration < -20)
            {
                sideAcceleration = -20;
            }
        }
        else
        {
            if (sideAcceleration > 0)
            {
                sideAcceleration -= 0.4f * Time.deltaTime;

                if (sideAcceleration < 0)
                {
                    sideAcceleration = 0;
                }
            }
            else
            {
                sideAcceleration += 0.4f * Time.deltaTime;

                if (sideAcceleration > 0)
                {
                    sideAcceleration = 0;
                }
            }
        }

        Vector3 velocity = transform.TransformDirection(new Vector3(sideAcceleration, 0, frontAcceleration));

        if (Input.GetButton(XboxButton.X))
        {
            velocity.y = -25;
        }
        else
        {
            velocity.y = -10;
        }

        rigidbody.velocity = velocity;

        //transform.Rotate(0, Input.GetAxis(XboxAxis.LeftStickX) * Time.deltaTime * 45, 0);

        if (groundInfo.groundHit.distance > 0 && groundInfo.groundHit.distance < 20)
        {
            stateMachine.ChangeState(StateFall);
        }
    }
    private void StateSkydiveEnd()
    {
        rigidbody.useGravity = true;
    }

    #endregion State Skydive

    #region State Rope

    private void StateRopeStart()
    {
    }

    private void StateRope()
    {
        transform.position = rope.position;
        transform.forward = rope.forward;
    }

    private void StateRopeEnd()
    {
    }

    #endregion State Rope

    #region State Snow Board
    void StateSnowBoardStart()
    {
        if (!isSnowboarding)
        {
            isSnowboarding = true;
            velocity = 20;
        }
    }
    public void StateSnowBoard()
    {



        //SearchWall();
        groundInfo.SearchGroundHighSpeed();
        AlignPlayer();

        if (Input.GetAxis(XboxAxis.LeftStickY) > 0.1f)
        {
            velocity = Mathf.MoveTowards(velocity, 50, 10 * Time.deltaTime);
        }
        else if (Input.GetAxis(XboxAxis.LeftStickY) < -0.1)
        {
            velocity = Mathf.MoveTowards(velocity, 20, 10 * Time.deltaTime);
        }
        else
        {
            velocity = Mathf.MoveTowards(velocity, 30, 1 * Time.deltaTime);
        }

        float dot = -Vector3.Dot(transform.right, Vector3.up);

        if (Mathf.Abs(Input.GetAxis(XboxAxis.LeftStickX)) < 0.1f)
        {
            transform.Rotate(0, 60 * dot * Mathf.RoundToInt(Vector3.Dot(transform.forward.normalized, Camera.main.transform.forward.normalized)) * Time.deltaTime, 0);

        }
        if (!Input.GetButton(XboxButton.B))
        {
            if (Input.GetButtonDown(XboxButton.A))
            {
                stateMachine.ChangeState(StateSnowBoardJump);
            }

            if (Input.GetAxisRaw(XboxAxis.RightTrigger) > 0)
            {
                stateMachine.ChangeState(StateSnowBoardDrift);
                return;
            }

            transform.Rotate(0, 60 * Input.GetAxis(XboxAxis.LeftStickX) * Mathf.RoundToInt(Vector3.Dot(transform.forward.normalized, Camera.main.transform.forward.normalized)) * Time.deltaTime, 0);

        }



        if (!groundInfo.grounded)
        {
            stateMachine.ChangeState(StateSnowBoardFall);
            return;
        }

        rigidbody.velocity = direction * velocity;

        if (canCancelState && Input.GetButtonDown(XboxButton.Y))
        {
            isSnowboarding = false;
            stateMachine.ChangeState(StateJump);
        }
    }
    void StateSnowBoardEnd()
    {

    }
    #endregion

    #region State Snow Board Fall
    void StateSnowBoardFallStart()
    {

    }
    public void StateSnowBoardFall()
    {
        groundInfo.SearchGround();
        AlignPlayer();

        if (groundInfo.grounded)
        {
            stateMachine.ChangeState(StateSnowBoard);
        }
    }
    void StateSnowBoardFallEnd()
    {

    }
    #endregion

    #region State Snow Board Drift
    void StateSnowBoardDriftStart()
    {
        driftStartDirection = rawDirection;
    }
    public void StateSnowBoardDrift()
    {
        if (Input.GetAxisRaw(XboxAxis.RightTrigger) == 0)
        {
            stateMachine.ChangeState(StateSnowBoard);
            return;
        }

        SearchWall();
        groundInfo.SearchGroundHighSpeed();
        AlignPlayer();
        Drift();

        rigidbody.velocity = direction * velocity;

        if (!groundInfo.grounded)
        {
            stateMachine.ChangeState(StateSnowBoardFall);
        }
    }
    void StateSnowBoardDriftEnd()
    {

    }
    #endregion

    #region State Snow Board
    void StateSnowBoardJumpStart()
    {
        rigidbody.AddForce(transform.up * 150, ForceMode.Impulse);
    }
    public void StateSnowBoardJump()
    {
        if (Time.time > stateMachine.lastStateTime + .5f)
        {
            stateMachine.ChangeState(StateSnowBoardFall);
            return;
        }

        //Vector3 rbVel = rigidbody.velocity;
        //rbVel.y = JumpPower;
        //rigidbody.velocity = rbVel;

        //if (absoluteLeftStick > 0)
        //{
        //    rigidbody.AddForce(leftStickDirection * 100 * GameManager.deltaStep);
        //}

        //if (rigidbody.HorizontalVelocity().magnitude > 1)
        //{
        //    transform.rotation = Quaternion.LookRotation(rigidbody.HorizontalVelocity().normalized);
        //}

        //rigidbody.velocity = ClampVelocity(rigidbody.velocity, maxVelocity, maxDownVelocity, maxUpVelocity);
    }
    void StateSnowBoardJumpEnd()
    {

    }
    #endregion

    #region State Snow Board Grind
    void StateSnowBoardGrindStart()
    {
        isGrinding = true;
        rigidbody.useGravity = false;
        groundInfo.grindGrounded = true;

        GrindSensorSetActive(true);
    }
    public void StateSnowBoardGrind()
    {


        if (Time.time > stateMachine.lastStateTime + 0.5f)
        {
            //if (Input.GetButtonDown(XboxButton.LeftShoulder) && grindSplineSensorL.bezierPath)
            //{
            //    tempSensor.bezierPath = grindSplineSensorL.bezierPath;
            //    stateMachine.ChangeState( StateGrindSwitchLeft);
            //    return;
            //}
            //else if (Input.GetButtonDown(XboxButton.RightShoulder) && grindSplineSensorR.bezierPath)
            //{
            //    tempSensor.bezierPath = grindSplineSensorR.bezierPath;
            //    stateMachine.ChangeState( StateGrindSwitchRight);
            //    return;
            //}
            if (Input.GetButtonDown(XboxButton.A))
            {
                isGrinding = false;
                GrindSensorSetActive(false);
                stateMachine.ChangeState(StateSnowBoardJump);
                return;
            }
        }

        if (!splineSensor.bezierPath)
        {
            isGrinding = false;
            GrindSensorSetActive(false);
            stateMachine.ChangeState(StateSnowBoardFall);
            return;
        }

        CheckBoost();

        splineSensor.bezierPath.PutOnPath(transform, PutOnPathMode.BinormalAndNormal, out knot, out _, 15);

        //Sign to get if player is moving forward on grind direction
        float sign = Mathf.Sign(Vector3.Dot(transform.forward, knot.tangent));
        //Multiply by grind direction, if sign is negative player will move in oposite direction
        Vector3 tangent = knot.tangent * sign;
        //Multiply by binormal direction to get bendings
        Vector3 binormal = knot.binormal * sign;
        //Calculate normal bending based on binormal and tangent
        Vector3 normal = isBoosting ? knot.normal : Vector3.Lerp(knot.normal - binormal, knot.normal + binormal, 0.5f + playerAnimation.tangent * 0.2f);

        transform.rotation = Quaternion.LookRotation(tangent, normal);

        if (isBoosting)
        {
            velocity = 50;
        }
        else
        {
            velocity = Mathf.Clamp(Mathf.MoveTowards(velocity, 0, (0.5f + rigidbody.velocity.y * 0.5f) * Time.deltaTime), 10, 40);
        }

        rigidbody.velocity = tangent * velocity;
    }
    void StateSnowBoardGrindEnd()
    {
        rigidbody.useGravity = true;
        groundInfo.grindGrounded = false;
    }
    #endregion

    void AirAlign()
    {
        if (Mathf.Abs(Vector3.Dot(tangentCopy, Vector3.up)) > 0.2f)
        {

        }
        tangentCopy = knot.tangent;
        tangentCopy.z = 0;

        //float dotTangent = Vector3.Dot(transform.forward, tangentCopy);

        //float x = Input.GetAxis(XboxAxis.LeftStickX);
        //float y = Input.GetAxis(XboxAxis.LeftStickY);

        //float xy = Mathf.Clamp(x, -1, 1);

        //if (horizontalVelocity.magnitude < 1)
        //{
        //    if (xy > 0)
        //    {
        //        tangent = tangentCopy;
        //    }
        //    else if (xy < 0)
        //    {
        //        tangent = -tangentCopy;
        //    }
        //}

        //if (dotTangent > 0.5f)
        //{
        //    tangent = tangentCopy;
        //}
        //else if (dotTangent < -0.5f)
        //{
        //    tangent = -tangentCopy;
        //}

        //tangent.y = 0;

        float dot = Vector3.Dot(transform.forward, tangentCopy);

        rigidbody.AddForce(transform.forward * dot * Input.GetAxis(XboxAxis.LeftStickX) * 1000 * GameManager.deltaStep);

        //transform.rotation = Quaternion.LookRotation(tangent, Vector3.up);

    }

    private Vector3 ClampVelocity(Vector3 velocity, float maxHorizontalVelocity, float maxDownVelocity, float maxUpVelocity)
    {
        float y = velocity.y;
        Vector3 clampedVelocity = Vector3.ClampMagnitude(velocity, maxHorizontalVelocity);
        clampedVelocity.y = Mathf.Clamp(y, -maxDownVelocity, maxUpVelocity);

        return clampedVelocity;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Pushable"))
        {
            RaycastHit hit = new RaycastHit();
            Physics.Raycast(playerCenter.transform.position, transform.forward, out hit);
            pushableCenter = hit.point;
            pushableNormal = hit.normal;
            pushable = collision.gameObject;
            transform.forward = -pushableNormal;
            transform.position = collision.transform.position + pushableNormal;
            stateMachine.ChangeState(StatePushing);
        }

        if (stateMachine.currentStateName != "StateHurt")
        {
            Vector3 otherPositionNormalized = new Vector3(collision.transform.position.x, transform.position.y, collision.transform.position.z);

            playerToEnemyDirection = Vector3Extension.Direction(transform.position, otherPositionNormalized).normalized;

            if (collision.collider.CompareTag(GameTags.enemyTag) || collision.collider.CompareTag("Boss"))
            {
                IDamageable damageable = collision.collider.GetComponent<IDamageable>();

                if (isBoosting)
                {
                    damageable.TakeDamage(gameObject);
                }
                else if (isAttacking)
                {
                    transform.LookAt(otherPositionNormalized);
                    enableHommingAfterTrick = true;
                    stateMachine.ChangeState(StateHomingTrick);
                    damageable.TakeDamage(gameObject);
                }
            }
        }
    }

    private void OnCollisionStay(Collision other)
    {
        if (other.collider.CompareTag("WaterSurface"))
        {
            if (horizontalVelocity.magnitude < 40 || isBraking && verticalVelocity >= 0)
            {
                other.collider.isTrigger = true;
            }
        }

        contactPoint = other.contacts[0];

    }

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetButtonDown(XboxButton.Y) && stateMachine.currentStateName != "StateTornado" && other.CompareTag("Tornado"))
        {
            tornado = other.GetComponent<Tornado>();
            //tornado.player = this;
            stateMachine.ChangeState(tornado.StateTornado, tornado.gameObject);
        }

        if (other.CompareTag("Underwater") && (transform.position.y + 1) < other.bounds.max.y)
        {
            underwater = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Underwater"))
        {
            underwater = false;
            GameManager.instance.SendMessage("UnderwaterReset", SendMessageOptions.DontRequireReceiver);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Rope"))
        {
            rope = other.transform;
            rigidbody.isKinematic = true;
            GetComponent<Collider>().enabled = false;
            stateMachine.ChangeState(StateRope);
        }
    }

    public void TakeDamage(GameObject sender)
    {
        if (ignoreDamage || isAttacking)
        {
            return;
        }

        Vector3 senderPosition = sender.transform.position;
        senderPosition.y = transform.position.y;
        Vector3 playerToSenderDirection = Vector3Extension.Direction(transform.position, senderPosition);

        if (GameManager.instance.rings > 0)
        {
            stateMachine.ChangeState(StateHurt);
        }
        else
        {
            stateMachine.ChangeState(StateDie);
        }

        transform.forward = playerToSenderDirection;
        rigidbody.velocity = -playerToSenderDirection * 15;

        Input.SetVibration(1, 1, 0.2f);

        IgnoreDamage();
    }

    private void IgnoreDamage()
    {
        ignoreDamage = true;
        StartCoroutine(EnableDamageTake(ignoreDamageTime));
    }

    private IEnumerator EnableDamageTake(float time)
    {
        yield return new WaitForSeconds(time);
        ignoreDamage = false;
    }
}