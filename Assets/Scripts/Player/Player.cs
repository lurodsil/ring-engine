using System.Collections;
using UnityEngine;

[RequireComponent(typeof(PlayerAnimation))]
public abstract class Player : PlayerCore, IDamageable
{
    // Instance (must be removed in future)
    public static Player instance { get; set; }

    //Maybe it's a good idea to move to player collision
    [Header("Physics Materials")]
    public PhysicMaterial playerMaterial;
    public PhysicMaterial noFriction;

    // Animation
    public PlayerAnimation playerAnimation { get; set; }

    [Header("Physics Motion Values")]
    public PhysicsMotionValues groundMotion;
    public PhysicsMotionValues airMotion;
    public PhysicsMotionValues iceMotion;
    public PhysicsMotionValues rollMotion;
    public PhysicsMotionValues snowboardingMotion;
    public PhysicsMotionValues currentPhysicsMotion { get; set; }

    [Header("Layer Masks")]
    public LayerMask targetFindLayerMask;
    public LayerMask wallSearchLayerMask;

    // Grinding Settings
    [Header("Grinding Settings")]
    public PhysicsMotionValues grindMotion;
    public float grindingMinimumVelocity = 20f;
    public float grindJumpForce = 11f;
    public SplineSensor grindSensor;
    public SplineSensor grindSplineSensorL;
    public SplineSensor grindSplineSensorR;
    public BezierKnot grindKnot = new BezierKnot();
    public bool isGrinding { get; private set; }
    public bool isGrindGrounded { get; private set; }
    private BezierPath grindSwitchPath { get; set; }
    private const float grindPathAtractForce = 15f;
    private const float grindSwitchDelay = 0.15f;
    private const float returnFromSwitchTime = 0.5f;
    private const float grindTurnBendingFactor = 0.15f;
    private const float grindVertivalVelocityRate = 3f;

    // State Management
    public StateMachine stateMachine = new StateMachine();
    public SpeedMode speedMode { get; set; }
    public bool isUnderwater { get; set; }
    public bool isStruggling { get; set; }
    public bool isAttacking { get; set; }
    public bool isSnowboarding { get; set; }
    public bool isBraking { get; set; }
    public bool isBoosting { get; set; }
    public bool isPhysicEnabled { get; set; }
    public bool isSuper { get; set; }
    public bool canStand { get; set; }
    public bool canHomming { get; set; }
    public bool canCancelState { get; set; }
    public bool drown { get; set; }
    public bool ignoreDamage { get; set; }

    // Targeting
    [Header("Find Closest Target Settings")]
    public float targetFindRange = 10f;
    [Range(0, 360)] public float targetFindAngle = 180f;
    public GameObject closestTarget { get; set; }
    public GameObject hommingAttackTarget { get; set; }
    private GameObject[] targets { get; set; }
    private Vector3 lastHommingDirection { get; set; }
    public GameObject closestLightSpeedDashRing { get; set; }

    // Movement

    public float lowToHighVelocity = 15f;
    public float absoluteLeftStick { get; set; }
    public Vector3 leftStickDirection { get; set; }
    public Vector3 movingDirection { get; private set; }
    private Vector3 lastMovingDir { get; set; }
    //must change this velocity name
    public float velocity { get; set; }
    public float autorunVelocity { get; set; }

    public float absoluteVelocity { get; private set; }

    //pushable
    private GameObject pushable { get; set; }
    public Vector3 pushableNormal { get; set; }
    public Vector3 pushableCenter { get; set; }    


    //Drift not used for now
    public float rawDirection { get; set; }
    public float driftStartDirection { get; set; }

    //Super
    public float superMultiplier = 1.3f;
    public float SuperRate { get; set; }
    private Tornado tornado { get; set; }

    public ContactPoint contactPoint { get; set; }

    // Jump Settings
    [Header("Jump Settings")]
    public float JumpPowerMin = 11f;
    public float JumpPower = 50f;
    public float JumpShortReleaseTime = 0.1f;
    private bool jumpReachedApex { get; set; }

    [Header("Quickstep")]
    public float quickstepVelocity = 10f;
    public float quickstepTime = 0.2f;
    public Vector3 quickStepStartVelocity { get; set; }
    public Vector3 quickStepStartDirection { get; set; }

    [Header("Homming Attack")]
    public float hommingAttackVelocityNoTarget = 40f;
    public float hommingAttackKeepVelocity = 0.2f;
    public float hommingAttackVelocity = 70f;
    public float hommingAttackHitKeepVelocity = 0.05f;
    public float hommingAttackHitUpVelocity = 18f;
    public bool enableHommingAfterTrick = true;

    [Header("Underwater")]
    public float underwaterGravityScale = 0.27f;
    public float underwaterRigidbodyDrag = 2f;

    [Header("Miscellaneous")]
    // Miscellaneous
    public float lightSpeedDashVelocity = 50f;
    public float ignoreDamageTime = 5f;
    private float lastGroundedTime { get; set; }
    public float lostGroundDelay = 0.2f;

    //for what is used?
    public Vector3 hitPoint { get; set; }
    public float outOfControl { get; set; }

    private float forwardVelocity { get; set; }
    private Vector3 normal { get; set; }

    //Side View
    public BezierPath sideViewPath;
    public BezierKnot sideViewKnot = new BezierKnot();
    public Vector3 tangent { get; private set; }
    public float tangentMultiplier { get; set; }

    // Bezier Paths

    public BezierPath pathHelper;
    public BezierKnot pathHelperKnot;
    public BezierPath bezierPath { get; set; }
    public BezierPathType pathType { get; set; }
    public float ringEnergy { get; set; }
    public float normalSuperBlend { get; set; }
    public Vector3 ceilingPoint { get; set; }

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
        instance = GetComponent<Player>();
        rigidbody = GetComponent<Rigidbody>();
        collider = GetComponent<CapsuleCollider>();
        playerAnimation = GetComponent<PlayerAnimation>();
        Physics.gravity = Vector3.down * 35;
    }

    public virtual void Start()
    {
        UpdateTargets();
        currentPhysicsMotion = groundMotion;

        canStand = true;
    }
    public override void Update()
    {
        base.Update();

        if (isSuper)
        {
            ringEnergy = 100;
            SuperRate = superMultiplier;
            normalSuperBlend = Mathf.Lerp(normalSuperBlend, 1, 5 * Time.deltaTime);
        }
        else
        {
            SuperRate = 1;
            normalSuperBlend = Mathf.Lerp(normalSuperBlend, 0, 5 * Time.deltaTime);
        }

        ringEnergy = Mathf.Clamp(ringEnergy, 0, 100);

        if (isBoosting)
        {
            ringEnergy -= 10 * Time.deltaTime;
        }

        if (ringEnergy <= 0)
        {
            isBoosting = false;
        }

        

        speedMode = rigidbody.velocity.magnitude <= 15f ? SpeedMode.Low : SpeedMode.High;

        if (grindSensor.bezierPath)
        {
            if (!isGrinding)
            {
                if (grindSensor.bezierPath.name.Contains("@GR"))
                {
                    if (rigidbody.velocity.y < 0)
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
        }

        absoluteVelocity = rigidbody.velocity.magnitude;

        UpdateInputAxis();

        closestLightSpeedDashRing = collider.Closest(GameObject.FindGameObjectsWithTag("LightSpeedDashRing"), 1, 5, true, transform.forward, 180);

        if (closestLightSpeedDashRing && Input.GetButtonDown(XboxButton.LeftStick))
        {
            stateMachine.ChangeState(StateLightSpeedDash);
        }

        if (IsGrounded())
        {
            jumpReachedApex = false;
            canHomming = true;
            outOfControl = 0;
            //lastGroundedNormal = GetGroundInformation().normal;
        }

        if (Input.GetAxisRaw(XboxAxis.LeftStickX) > 0)
        {
            rawDirection = -1;
        }
        else if (Input.GetAxisRaw(XboxAxis.LeftStickX) < 0)
        {
            rawDirection = 1;
        }

    }
    public virtual void FixedUpdate()
    {
        HandleSideView();
    }

    private void HandleSideView()
    {
        if (sideViewPath && !grindSensor.bezierPath && !isGrinding && !isStruggling)
        {
            try
            {
                sideViewPath.PutOnPath(transform, PutOnPathMode.BinormalOnly, out sideViewKnot, out _, 15);

                float x = Input.GetAxis(XboxAxis.LeftStickX);
                float y = Input.GetAxis(XboxAxis.LeftStickY);
                float xy = Mathf.Clamp(x + y, -1, 1);

                if (rigidbody.HorizontalVelocity().magnitude < 1f || !IsGrounded())
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

                if (autorunVelocity > 0)
                {
                    tangentMultiplier = 1;
                }

                tangent = sideViewKnot.tangent * tangentMultiplier;
            }
            catch
            {

            }
        }
    }

    public void CheckBoost()
    {
        if (ringEnergy > 0 && Input.GetButtonDown(XboxButton.RightTrigger))
        {
            SendMessage("StateBoostStart");
        }
        else if (Input.GetButtonUp(XboxButton.RightTrigger) || Physics.Raycast(collider.bounds.center, transform.forward, .4f))
        {
            SendMessage("StateBoostEnd");
        }
    }

    public void DoQuickstep()
    {
        if (Input.GetButtonDown(XboxButton.LeftShoulder))
        {
            if (Vector3.Dot(transform.forward, Camera.main.transform.forward) > 0)
            {
                stateMachine.ChangeState(StateQuickstepLeft);
            }
            else
            {
                stateMachine.ChangeState(StateQuickstepRight);
            }
        }
        else if (Input.GetButtonDown(XboxButton.RightShoulder))
        {
            if (Vector3.Dot(transform.forward, Camera.main.transform.forward) > 0)
            {
                stateMachine.ChangeState(StateQuickstepRight);
            }
            else
            {
                stateMachine.ChangeState(StateQuickstepLeft);
            }
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

        closestTarget = collider.Closest(targets, 2, targetFindRange, false, closestDirection, targetFindAngle, Camera.main.transform.forward, 360, targetFindLayerMask);
    }

    public void SearchWall()
    {
        ////Make Player stop if have a wall in front of the player
        if (Physics.SphereCast(transform.position + transform.up, 0.2f, transform.forward, out _, GetComponent<CapsuleCollider>().radius, wallSearchLayerMask))
        {
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
        leftStickDirection = VectorExtension.InputDirection(Input.GetAxis(XboxAxis.LeftStickX), Input.GetAxis(XboxAxis.LeftStickY), Camera.main.transform, transform);
        leftStickDirection.Normalize();
        Debug.DrawRay(collider.bounds.center, leftStickDirection, Color.magenta);
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
    public void AlignPlayerUpToDirection(Vector3 up)
    {
        transform.rotation = Quaternion.FromToRotation(transform.up, normal) * transform.rotation;
    }
    public void PutOnGround()
    {
        if (IsGrounded())
        {
            rigidbody.MovePosition(GetGroundInformation().point);
        }
    }
    private void BubbleBreath()
    {
        stateMachine.ChangeState(StateBubbleBreath);
    }
    private void StateBoostStart()
    {
        if (ringEnergy > 0)
        {
            isBoosting = true;
            isAttacking = true;
            MainCamera.Shake();
            MainCamera.ResetTime();
        }
    }
    private void StateBoostEnd()
    {
        if (isBoosting)
        {
            isBoosting = false;
            isAttacking = false;
            MainCamera.ResetTime();
        }
    }
    public void DoDamageOrDie()
    {
        if (GameManager.instance.rings > 0)
        {
            stateMachine.ChangeState(StateHurt);
            GameManager.instance.rings = 0;
        }
        else
        {
            stateMachine.ChangeState(StateDie);
        }
    }
    private void Zero()
    {
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
    public void AirMotion()
    {
        float currentInput = sideViewPath ? Mathf.Abs(Input.GetAxis(XboxAxis.LeftStickX)) : leftStickDirection.magnitude;

        if (currentInput > deadZone)
        {
            Vector3 tangentCopy = tangent;
            tangentCopy.y = 0;

            if (sideViewPath)
            {
                rigidbody.AddForce(tangentCopy * airMotion.accelerationForce * SuperRate, ForceMode.Acceleration);

                Vector3 currentVelocity = Vector3.Lerp(rigidbody.velocity.normalized, tangentCopy, Time.deltaTime) * rigidbody.velocity.magnitude;

                currentVelocity.y = rigidbody.velocity.y;

                rigidbody.velocity = Vector3.ClampMagnitude(currentVelocity, currentPhysicsMotion.maxSpeed * SuperRate);

                transform.rotation = Quaternion.LookRotation(rigidbody.HorizontalVelocity(), Vector3.up);
            }
            else
            {
                rigidbody.AddForce(leftStickDirection * airMotion.accelerationForce * SuperRate, ForceMode.Acceleration);

                Vector3 currentVelocity = Vector3.Lerp(rigidbody.velocity.normalized, leftStickDirection, Time.deltaTime) * rigidbody.velocity.magnitude;

                currentVelocity.y = rigidbody.velocity.y;

                rigidbody.velocity = Vector3.ClampMagnitude(currentVelocity, currentPhysicsMotion.maxSpeed * SuperRate);

                transform.rotation = Quaternion.LookRotation(rigidbody.HorizontalVelocity(), Vector3.up);
            }

            lastMovingDir = transform.forward;
        }
        else
        {
            if (rigidbody.HorizontalVelocity().magnitude > 0.1f && Time.time > stateMachine.lastStateTime + outOfControl)
            {
                rigidbody.AddForce(-rigidbody.HorizontalVelocity() * airMotion.decelerationForce * SuperRate, ForceMode.Acceleration);
            }
        }

        transform.rotation = Quaternion.FromToRotation(transform.up, Vector3.up) * transform.rotation;
    }

    public void SetRotation2D(Vector3 groundNormal)
    {
        if (Vector3.Distance(transform.position, sideViewKnot.point) < 1f)
        {
            transform.rotation = Quaternion.LookRotation(tangent, groundNormal);
        }
        else
        {
            transform.rotation = Quaternion.LookRotation(tangent);
        }

        //if (Vector3.Dot(transform.up, groundNormal) > 0.2f)
        //{
        transform.rotation = Quaternion.FromToRotation(transform.up, groundNormal) * transform.rotation;
        //}
    }

    public void SetRotation3D(Vector3 groundNormal)
    {
        if (rigidbody.velocity.magnitude > 0.1f && !isBraking && Time.time > stateMachine.lastStateTime + 0.1f)
        {
            transform.rotation = Quaternion.LookRotation(rigidbody.velocity.normalized, transform.up);
        }

        if (Vector3.Angle(transform.up, groundNormal) < 80)
        {
            transform.rotation = Quaternion.FromToRotation(transform.up, groundNormal) * transform.rotation;
        }
    }

    #region State Transition
    public void StateTransition()
    {
        if (IsGrounded())
        {
            if (rigidbody.velocity.magnitude > minimunMovementVelocity)
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
    #endregion

    #region State Idle
    public virtual void StateIdle()
    {
        if (closestLightSpeedDashRing && Input.GetButtonDown(XboxButton.Y))
        {
            stateMachine.ChangeState(StateLightSpeedDash);
        }

        if (Input.GetButtonDown(XboxButton.A))
        {
            stateMachine.ChangeState(StateJump);
        }

        if (Input.GetButton(XboxButton.B) || !canStand)
        {
            stateMachine.ChangeState(StateSquat);
        }

        if (Input.GetButtonDown(XboxButton.RightTrigger))
        {
            stateMachine.ChangeState(StateMove);
        }

        if (rigidbody.velocity.magnitude > minimunMovementVelocity || leftStickDirection.magnitude > deadZone)
        {
            stateMachine.ChangeState(StateMove);
        }

        if (Input.GetButtonDown(XboxButton.RightTrigger))
        {
            if (isBoosting == false)
            {
                SendMessage("StateBoostStart");
                isBoosting = true;
                isAttacking = true;
            }
            stateMachine.ChangeState(StateMove);
        }

        if (IsGrounded())
        {
            lastGroundedTime = Time.time;

            switch (transform.GetGroundState())
            {
                case GroundState.onGround:
                    break;
                case GroundState.onSlope:

                    break;
                case GroundState.onWall:

                    //float dot = Vector3.Dot(transform.forward, Vector3.up);

                    if (rigidbody.velocity.magnitude < 15)
                    {
                        stateMachine.ChangeState(StateFall);
                    }

                    if (rigidbody.velocity.magnitude < 15)
                    {
                        stateMachine.ChangeState(StateFall);
                    }
                    break;
                case GroundState.onCeiling:

                    if (rigidbody.velocity.magnitude < 15)
                    {
                        stateMachine.ChangeState(StateFall);
                    }
                    break;
            }
        }
        else
        {
            if (Time.time > lastGroundedTime + lostGroundDelay)
            {
                stateMachine.ChangeState(StateFall);
            }
        }

        DoQuickstep();
    }
    private void StateIdleEnd()
    {
    }
    #endregion

    #region State Hurdle

    private void StateHurdleStart()
    {
        Vector3 jumpDirection = Vector3.Lerp(transform.up, Vector3.up, 0.5f);

        rigidbody.AddForce(jumpDirection * (8 - rigidbody.velocity.y), ForceMode.Impulse);
    }

    public void StateHurdle()
    {
        FindClosestTarget();


        if (Input.GetButtonUp(XboxButton.A))
        {
            stateMachine.ChangeState(StateMove);
            return;
        }

        if (Time.time > stateMachine.lastStateTime + 0.14f)
        {
            stateMachine.ChangeState(StateBall);
            rigidbody.AddForce(Vector3.up * (3 - rigidbody.velocity.y), ForceMode.Impulse);
            return;
        }


    }

    private void StateHurdleEnd()
    {

    }

    #endregion State Hurdle

    #region State Move
    private void StateMoveStart()
    {
        currentPhysicsMotion = groundMotion;
    }
    public void StateMove()
    {
        if (sideViewPath)
        {
            stateMachine.ChangeState(StateMove2D);
        }
        else
        {
            stateMachine.ChangeState(StateMove3D);
        }

        //switch (pathType)
        //{
        //    case BezierPathType.Dash:
        //        stateMachine.ChangeState(StateDash);
        //        break;
        //    case BezierPathType.QuickStep:
        //        stateMachine.ChangeState(StateMoveQuickStep);
        //        break;
        //    case BezierPathType.SideView:
        //        stateMachine.ChangeState(StateMove2D);
        //        break;
        //    default:
        //        stateMachine.ChangeState(StateMove3D);
        //        break;
        //}
    }
    private void StateMoveEnd() { }
    #endregion State Move

    #region State Move 3D
    private void StateMove3DStart() { }
    public void StateMove3D()
    {
        CheckBoost();

        if (sideViewPath)
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
        if (Input.GetButton(XboxButton.B) || !canStand)
        {
            stateMachine.ChangeState(StateSliding);
            return;
        }
        if (Input.GetButton(XboxButton.Y) && Time.time > stateMachine.lastStateTime + 0.5f)
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

        DoQuickstep();
    }
    public void StateMove3DPhysics()
    {

        RaycastHit groundInfo = GetGroundInformation();

        movingDirection = leftStickDirection;
        Vector3 boostMovementDirection = leftStickDirection.magnitude < deadZone ? transform.forward : leftStickDirection;

        if (pathHelper)
        {
            try
            {
                if (rigidbody.velocity.magnitude > currentPhysicsMotion.maxSpeed * 0.6f)
                {
                    pathHelper.GetClosestKnot(transform.position, out pathHelperKnot);

                    movingDirection = pathHelperKnot.tangent * Vector3.Dot(pathHelperKnot.tangent, transform.forward);

                    boostMovementDirection = movingDirection;
                }
            }
            catch
            {

            }
        }

        if (!isBraking && rigidbody.velocity.magnitude > currentPhysicsMotion.brakeMinSpeed && leftStickDirection.magnitude > deadZone && Vector3.Angle(-rigidbody.velocity.normalized, movingDirection) < 45 && Vector3.Dot(transform.up, Vector3.up) > 0)
        {
            SendMessage("StateBrakeStart");
            SendMessage("StateBoostEnd");
            isBraking = true;
        }

        if (leftStickDirection.magnitude > deadZone && !isBraking && !isBoosting)
        {
            if (rigidbody.velocity.magnitude < currentPhysicsMotion.maxSpeed * absoluteLeftStick * SuperRate)
            {
                rigidbody.AddForce(movingDirection.normalized * currentPhysicsMotion.accelerationForce * SuperRate, ForceMode.Acceleration);
            }
        }
        else if (isBraking)
        {
            rigidbody.AddForce(-rigidbody.velocity.normalized * currentPhysicsMotion.brakeForce * SuperRate, ForceMode.Acceleration);

            if (rigidbody.velocity.magnitude < currentPhysicsMotion.brakeMinSpeed)
            {
                isBraking = false;
                rigidbody.Sleep();
            }
        }
        else if (isBoosting)
        {
            movingDirection = leftStickDirection.magnitude < deadZone ? transform.forward : leftStickDirection;

            if (rigidbody.velocity.magnitude < currentPhysicsMotion.maxSpeedInBoost * SuperRate)
            {
                rigidbody.AddForce(boostMovementDirection.normalized * currentPhysicsMotion.accelerationForceInBoost * SuperRate, ForceMode.Acceleration);
            }
        }
        else
        {
            if (rigidbody.velocity.magnitude < 0.1f)
            {
                rigidbody.Sleep();
                stateMachine.ChangeState(StateIdle);
            }
            else
            {
                rigidbody.AddForce(-rigidbody.velocity.normalized * currentPhysicsMotion.decelerationForce * SuperRate, ForceMode.Acceleration);
            }
        }

        SetRotation3D(groundInfo.normal);

        transform.StickToGround(groundInfo, 10);

        if (IsGrounded())
        {
            lastGroundedTime = Time.time;

            switch (transform.GetGroundState())
            {
                case GroundState.onGround:
                    break;
                case GroundState.onSlope:

                    break;
                case GroundState.onWall:

                    //float dot = Vector3.Dot(transform.forward, Vector3.up);

                    if (rigidbody.velocity.magnitude < 15)
                    {
                        stateMachine.ChangeState(StateFall);
                    }

                    if (rigidbody.velocity.magnitude < 15)
                    {
                        stateMachine.ChangeState(StateFall);
                    }
                    break;
                case GroundState.onCeiling:

                    if (rigidbody.velocity.magnitude < 15)
                    {
                        stateMachine.ChangeState(StateFall);
                    }
                    break;
            }
        }
        else
        {
            if (Time.time > lastGroundedTime + lostGroundDelay)
            {
                stateMachine.ChangeState(StateFall);
            }
        }

        if ((leftStickDirection.magnitude > deadZone || isBoosting) && !isBraking && Vector3.Angle(lastMovingDir, transform.forward) < 30 && Time.time > stateMachine.lastStateTime + 0.2f)
        {
            rigidbody.velocity = Vector3.Lerp(transform.forward, movingDirection, 6 * Time.fixedDeltaTime) * rigidbody.velocity.magnitude;
        }

        lastMovingDir = transform.forward;
    }
    private void StateMove3DEnd() { }
    float groundSpeed;

    #endregion State Move 3D

    #region State Move 2D
    private void StateMove2DStart()
    {
        //velocity = horizontalVelocity.magnitude;
        tangentMultiplier = Mathf.Sign(Vector3.Dot(transform.forward, sideViewKnot.tangent));
    }
    private void StateMove2D()
    {
        if (!sideViewPath)
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
        if (Input.GetButton(XboxButton.B) || !canStand)
        {
            stateMachine.ChangeState(StateSliding);
            return;
        }
        if (Input.GetButton(XboxButton.Y))
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

        CheckBoost();

        tangent = sideViewKnot.tangent * tangentMultiplier;
    }
    private void StateMove2DEnd()
    {

    }
    public void StateMove2DPhysics()
    {
        RaycastHit groundInfo = GetGroundInformation();

        movingDirection = transform.forward;// Vector3.Cross(transform.right, groundInfo.normal).normalized;

        if (autorunVelocity == 0)
        {
            float x = Input.GetAxis(XboxAxis.LeftStickX);
            float y = Input.GetAxis(XboxAxis.LeftStickY);
            float xy = Mathf.Clamp(x + y, -1, 1);

            //Brake
            if (rigidbody.velocity.magnitude > 1f)
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

            if (leftStickDirection.normalized.magnitude > deadZone && !isBraking && !isBoosting)
            {
                if (rigidbody.velocity.magnitude < currentPhysicsMotion.maxSpeed * SuperRate)
                {
                    rigidbody.AddForce(movingDirection * currentPhysicsMotion.accelerationForce * SuperRate, ForceMode.Acceleration);
                }
            }
            else if (isBraking)
            {
                rigidbody.AddForce(-rigidbody.velocity.normalized * currentPhysicsMotion.brakeForce * SuperRate, ForceMode.Acceleration);

                if (rigidbody.velocity.sqrMagnitude < 0.1f)
                {
                    isBraking = false;
                    rigidbody.Sleep();
                }
            }
            else if (isBoosting)
            {
                Vector3 boostMovementDirection = movingDirection == Vector3.zero ? transform.forward : movingDirection;

                if (rigidbody.velocity.magnitude < currentPhysicsMotion.maxSpeedInBoost * SuperRate)
                {
                    rigidbody.AddForce(boostMovementDirection * currentPhysicsMotion.accelerationForceInBoost * SuperRate, ForceMode.Acceleration);
                }
            }
            else
            {
                rigidbody.AddForce(-rigidbody.velocity.normalized * currentPhysicsMotion.decelerationForce * SuperRate, ForceMode.Acceleration);

                if (rigidbody.velocity.magnitude < 0.1f)
                {
                    rigidbody.Sleep();
                    stateMachine.ChangeState(StateIdle);
                }
            }
        }

        SetRotation2D(groundInfo.normal);

        transform.StickToGround(groundInfo, 20);

        if (IsGrounded())
        {
            lastGroundedTime = Time.time;

            switch (transform.GetGroundState())
            {
                case GroundState.onGround:
                    break;
                case GroundState.onSlope:
                    break;
                case GroundState.onWall:
                    if (rigidbody.velocity.magnitude < 10)
                    {
                        rigidbody.AddForce(transform.up, ForceMode.Impulse);
                        tangentMultiplier *= -1;
                        stateMachine.ChangeState(StateFall);
                    }
                    break;
                case GroundState.onCeiling:
                    if (rigidbody.velocity.magnitude < 15)
                    {
                        rigidbody.AddForce(transform.up, ForceMode.Impulse);
                        stateMachine.ChangeState(StateFall);
                    }
                    break;
            }
        }
        else
        {
            if (Time.time > lastGroundedTime + lostGroundDelay)
            {
                stateMachine.ChangeState(StateFall);
            }
        }

        if (autorunVelocity > 0)
        {
            rigidbody.velocity = transform.forward * autorunVelocity;
        }
        else if ((leftStickDirection.magnitude > deadZone || isBoosting) && !isBraking && Vector3.Angle(lastMovingDir, transform.forward) < 30 && Time.time > stateMachine.lastStateTime + 0.2f)
        {
            rigidbody.velocity = transform.forward * rigidbody.velocity.magnitude;
        }

        lastMovingDir = transform.forward;
    }

    #endregion State Move 2D  

    #region State Quickstep Left
    private void StateQuickstepLeftStart()
    {
        quickStepStartVelocity = rigidbody.velocity;
        quickStepStartDirection = transform.forward;
        rigidbody.velocity -= transform.right * quickstepVelocity;
    }
    private void StateQuickstepLeft()
    {
        stateMachine.ChangeState(StateMove, quickstepTime);
    }
    private void StateQuickstepLeftEnd()
    {
        rigidbody.velocity = quickStepStartVelocity;
        transform.forward = quickStepStartDirection;
    }
    #endregion

    #region State Quickstep Right
    private void StateQuickstepRightStart()
    {
        quickStepStartVelocity = rigidbody.velocity;
        quickStepStartDirection = transform.forward;
        rigidbody.velocity += transform.right * quickstepVelocity;
    }
    private void StateQuickstepRight()
    {
        stateMachine.ChangeState(StateMove, quickstepTime);
    }
    private void StateQuickstepRightEnd()
    {
        rigidbody.velocity = quickStepStartVelocity;
        transform.forward = quickStepStartDirection;
    }
    #endregion State

    #region State Spindash
    private void StateSpindashStart()
    {
        velocity = 30;
        isAttacking = true;
    }
    private void StateSpindash()
    {

        AlignPlayerUpToDirection(GetGroundInformation().normal);
        transform.StickToGround(GetGroundInformation());

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
    }
    private void StateSpindashEnd()
    {
        rigidbody.AddForce(transform.forward * velocity, ForceMode.Impulse);
    }
    #endregion State

    #region State Roll
    private void StateRollStart()
    {
        isAttacking = true;
        collider.sharedMaterial = noFriction;
        currentPhysicsMotion = rollMotion;
    }
    private void StateRoll()
    {
        movingDirection = leftStickDirection;

        if (pathHelper)
        {
            try
            {
                if (rigidbody.velocity.magnitude > currentPhysicsMotion.maxSpeed * 0.6f)
                {
                    pathHelper.GetClosestKnot(transform.position, out pathHelperKnot);

                    movingDirection = pathHelperKnot.tangent * Vector3.Dot(pathHelperKnot.tangent, transform.forward);
                }
            }
            catch
            {

            }
        }

        if (Input.GetButtonDown(XboxButton.A))
        {

                stateMachine.ChangeState(StateJump);
            
        }

        if (Input.GetButtonDown(XboxButton.Y))
        {
            stateMachine.ChangeState(StateMove);
        }

        if (rigidbody.HorizontalVelocity().magnitude > 0.1f)
        {
            transform.rotation = Quaternion.LookRotation(rigidbody.velocity.normalized, transform.up);
        }

        transform.rotation = Quaternion.FromToRotation(transform.up, GetGroundInformation().normal) * transform.rotation;

        if (rigidbody.velocity.magnitude < 3 && IsGrounded())
        {
            stateMachine.ChangeState(StateIdle);
        }
    }

    public void StateRollPhysics()
    {
        if (IsGrounded())
        {
            if (leftStickDirection.magnitude > deadZone && Vector3.Dot(lastMovingDir, transform.forward) > 0.95f && Time.time > stateMachine.lastStateTime + 0.2f)
            {
                rigidbody.velocity = Vector3.Lerp(transform.forward, movingDirection, 3 * Time.fixedDeltaTime) * rigidbody.velocity.magnitude;
            }

            lastMovingDir = transform.forward;
        }
    }
    private void StateRollEnd()
    {
        collider.sharedMaterial = playerMaterial;
        currentPhysicsMotion = groundMotion;
    }
    #endregion State

    #region State Squat
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



        if (Input.GetButtonDown(XboxButton.A))
        {
            stateMachine.ChangeState(StateJump);
        }

        if (leftStickDirection.magnitude > deadZone && transform.GetGroundState() == GroundState.onGround && Time.time > stateMachine.lastStateTime + 0.5f)
        {
            stateMachine.ChangeState(StateCrawling);
            return;
        }

        if (rigidbody.velocity.magnitude > 5)
        {
            stateMachine.ChangeState(StateSliding);
        }

        if (!Input.GetButton(XboxButton.B) && canStand)
        {
            stateMachine.ChangeState(StateIdle);
        }
    }
    #endregion State Squat

    #region State Squat Kick
    private void StateSquatKick()
    {
        stateMachine.ChangeState(StateSquat, 1);
    }
    #endregion State Squat Kick

    #region State Crawling
    private void StateCrawling()
    {
        if (Input.GetButtonDown(XboxButton.A))
        {
            stateMachine.ChangeState(StateJump);
        }

        if (leftStickDirection.magnitude < 0.1f && rigidbody.velocity.magnitude < 0.1f || !Input.GetButton(XboxButton.B) && canStand)
        {
            stateMachine.ChangeState(StateSquat);
        }
    }

    public void StateCrawlingPhysics()
    {
        if (rigidbody.velocity.magnitude < 1)
        {
            rigidbody.AddForce(leftStickDirection * currentPhysicsMotion.accelerationForce, ForceMode.Acceleration);
        }

        if (rigidbody.velocity.magnitude > minimunMovementVelocity)
        {
            transform.rotation = Quaternion.LookRotation(rigidbody.HorizontalVelocity().normalized);
        }
    }
    #endregion State Crawling

    #region State Sliding
    private void StateSliding()
    {
        if (!Input.GetButton(XboxButton.B))
        {
            if (canStand)
            {
                stateMachine.ChangeState(StateMove);
            }

        }

        if (absoluteVelocity < 2f)
        {
            stateMachine.ChangeState(StateSquat);
        }

        if (Input.GetButtonDown(XboxButton.A))
        {
            stateMachine.ChangeState(StateJump);
        }

        RaycastHit groundInfo = GetGroundInformation();

        if (rigidbody.velocity.magnitude > minimunMovementVelocity)
        {
            transform.rotation = Quaternion.LookRotation(rigidbody.velocity.normalized, transform.up);
        }

        transform.rotation = Quaternion.FromToRotation(transform.up, groundInfo.normal) * transform.rotation;

        if (IsGrounded())
        {
            transform.StickToGround(groundInfo, 10);
        }
        else
        {
            stateMachine.ChangeState(StateFall);
        }
    }
    public void StateSlidingPhysics()
    {
        rigidbody.AddForce(leftStickDirection * 10, ForceMode.Acceleration);
    }
    #endregion State Sliding

    #region State Empty

    private void StateStart()
    {
    }

    private void State()
    {
    }

    private void StateEnd()
    {
    }

    #endregion

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
            rigidbody.velocity = transform.DirectionTo(closestLightSpeedDashRing.transform.position + Vector3.down * 0.5f) * lightSpeedDashVelocity;
            transform.forward = rigidbody.velocity.normalized;
        }
    }

    private void StateLightSpeedDashEnd()
    {
    }

    #endregion State

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

        if (Input.GetAxisRaw(XboxAxis.RightTrigger) == 0)
        {
            stateMachine.ChangeState(StateMove);
        }

        SearchWall();

        AlignPlayerUpToDirection(GetGroundInformation().normal);

        Vector3 direction = Vector3.Cross(transform.right, GetGroundInformation().normal);
        rigidbody.velocity = direction * rigidbody.velocity.magnitude;

        if (speedMode == SpeedMode.High)
        {
            PutOnGround();
        }


        //If Sonic isn't on ground change to state fall
        if (!IsGrounded())
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
        RaycastHit hit = new RaycastHit();
        Physics.Raycast(transform.position + Vector3.up * 0.5f, transform.forward, out hit);

        float distance = Vector3.Distance(pushable.transform.position, transform.position);
        Vector3 offset = transform.position + transform.forward * distance;

        pushable.transform.position = new Vector3(offset.x, pushable.transform.position.y, offset.z);
        Quaternion pushableTargetRotation = Quaternion.FromToRotation(hit.normal, -transform.forward) * pushable.transform.rotation;

        pushable.transform.rotation = Quaternion.Lerp(pushable.transform.rotation, pushableTargetRotation, rigidbody.velocity.magnitude * Time.deltaTime);
        transform.RotateAround(pushable.transform.position, Vector3.up, 45 * Vector3.Dot(transform.right, leftStickDirection) * Time.deltaTime);
        rigidbody.velocity = transform.forward * absoluteLeftStick * 3;



        if (leftStickDirection.magnitude < 0.1f)
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
        isGrinding = false;
        isBoosting = false;
        contactPoint = new ContactPoint();
        isAttacking = false;
        UpdateTargets();

    }
    public virtual void StateFall()
    {
        FindClosestTarget();

        if (Input.GetButtonDown(XboxButton.X))
        {
            if (canHomming)
            {
                stateMachine.ChangeState(StateHoming);
            }
        }

        if (IsGrounded())
        {
            stateMachine.ChangeState(StateTransition);
        }
    }
    public void StateFallPhysics()
    {
        AirMotion();
    }
    private void StateFallEnd()
    {

    }
    #endregion State Fall

    #region State Jump
    private void StateJumpStart()
    {
        Vector3 jumpDirection = Vector3.Lerp(transform.up, Vector3.up, 0.5f).normalized;

        rigidbody.AddForce(transform.up * (JumpPowerMin * SuperRate - rigidbody.velocity.y), ForceMode.Impulse);
        UpdateTargets();
    }
    public virtual void StateJump()
    {
        FindClosestTarget();

        if (Input.GetButtonUp(XboxButton.A))
        {
            stateMachine.ChangeState(StateFall);
            return;
        }

        if (Input.GetButtonDown(XboxButton.X))
        {
            if (canHomming)
            {
                stateMachine.ChangeState(StateHoming);
            }
        }

        if (Time.time > stateMachine.lastStateTime + JumpShortReleaseTime)
        {
            stateMachine.ChangeState(StateBall);
            return;
        }
    }
    private void StateJumpPhysics()
    {
        AirMotion();
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
        UpdateTargets();
    }
    public virtual void StateBall()
    {
        FindClosestTarget();

        if (Input.GetButtonDown(XboxButton.X))
        {
            if (canHomming)
            {
                stateMachine.ChangeState(StateHoming);
            }
        }

        if (!Input.GetButton(XboxButton.A) || Time.time > stateMachine.lastStateTime + 0.15f)
        {
            jumpReachedApex = true;
        }

        if (isUnderwater)
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

        if (IsGrounded() && Time.time > stateMachine.lastStateTime + 0.15f)
        {
            stateMachine.ChangeState(StateIdle);
        }
    }
    public void StateBallPhysics()
    {
        AirMotion();
        if (!jumpReachedApex)
        {
            rigidbody.AddForce(Vector3.up * (JumpPower * SuperRate + (rigidbody.ConformVelocity(currentPhysicsMotion.maxSpeed) * JumpPower)), ForceMode.Acceleration);
        }
    }
    private void StateBallEnd()
    {
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

        if (GetGroundInformation().distance < 1)
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
        Timer.PauseTimer();
    }

    public void StateDie()
    {
        if (Time.time > stateMachine.lastStateTime + 3)
        {
            GameManager.instance.lives--;
            GameManager.instance.ReloadSceneWithLoading();
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
        GameManager.instance.rings = 0;

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

        if (closestTarget)
        {
            hommingAttackTarget = closestTarget;

            lastHommingDirection = transform.DirectionTo(closestTarget.transform.position).normalized;
        }
        else
        {
            hommingAttackTarget = null;

            lastHommingDirection = Vector3.zero;
        }
       

        MainCamera.SetFollowRate(1);
    }
    public virtual void StateHoming()
    {
        if (hommingAttackTarget)
        {
            transform.LookAt(hommingAttackTarget.transform);

            rigidbody.velocity = transform.forward * hommingAttackVelocity * SuperRate;
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

        isAttacking = false;
        MainCamera.SetFollowRate(0);
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
        if (sideViewPath)
        {
            SetRotation2D(Vector3.up);
        }
        else
        {
            transform.rotation = Quaternion.LookRotation(lastHommingDirection);
        }
        stateMachine.ChangeState(StateFall, 0.25f);
    }
    private void StateHomingTrickEnd()
    {
        UpdateTargets();
        canHomming = enableHommingAfterTrick;
        isAttacking = false;
    }
    #endregion State Homing Trick

    #region State Ceiling Hang

    private void StateCeilingHangStart()
    {
        rigidbody.useGravity = false;

    }
    private void StateCeilingHang()
    {
        Debug.DrawLine(transform.position, ceilingPoint);

        if (Input.GetButtonDown(XboxButton.A))
        {
            stateMachine.ChangeState(StateFall);
        }
    }
    public void StateCeilingHangPhysics()
    {
        rigidbody.MovePosition(new Vector3(transform.position.x, ceilingPoint.y - 1, transform.position.z));

        if (leftStickDirection.magnitude > deadZone && rigidbody.velocity.magnitude < 4)
        {
            if (sideViewPath)
            {
                print("Side view");
                rigidbody.AddForce(tangent * 5);
            }
            else
            {
                rigidbody.AddForce(leftStickDirection * 5);
            }
        }
        else
        {
            rigidbody.AddForce(-rigidbody.velocity.normalized * 5, ForceMode.Acceleration);

            if (rigidbody.velocity.sqrMagnitude < 0.01f)
            {
                rigidbody.Sleep();
            }
        }

        if (rigidbody.HorizontalVelocity().magnitude > 0.1f)
        {
            transform.rotation = Quaternion.LookRotation(rigidbody.HorizontalVelocity().normalized, transform.up);
        }
    }

    private void StateCeilingHangEnd()
    {
        rigidbody.useGravity = true;
    }
    #endregion State

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
        rigidbody.drag = 2;

        if (rigidbody.HorizontalVelocity().magnitude > 0.1f)
        {
            transform.rotation = Quaternion.LookRotation(rigidbody.HorizontalVelocity().normalized);
        }
    }
    public void StateSkydive()
    {


        if (Input.GetAxis(XboxAxis.RightTrigger) > deadZone)
        {
            rigidbody.drag = 0;
        }
        else
        {
            rigidbody.drag = 2;
        }

        transform.rotation = Quaternion.LookRotation(new Vector3(rigidbody.velocity.x, 0, rigidbody.velocity.z).normalized);

        if (IsGrounded())
        {
            rigidbody.drag = 0;
            stateMachine.ChangeState(StateIdle);
        }
    }
    public void StateSkydivePhysics()
    {
        rigidbody.AddForce(leftStickDirection * currentPhysicsMotion.accelerationForce);
    }
    private void StateSkydiveEnd()
    {
        rigidbody.drag = 0;
    }

    #endregion State Skydive

    #region Snowboard States
    #region State Snow Board
    void StateSnowBoardStart()
    {
        if (!isSnowboarding)
        {
            isSnowboarding = true;
            collider.material = noFriction;
            currentPhysicsMotion = snowboardingMotion;
        }
    }
    public void StateSnowBoard()
    {
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
        if (!IsGrounded())
        {
            stateMachine.ChangeState(StateSnowBoardFall);
            return;
        }
        if (canCancelState && Input.GetButtonDown(XboxButton.Y))
        {
            isSnowboarding = false;
            stateMachine.ChangeState(StateJump);
        }
    }

    public void StateSnowBoardPhysics()
    {
        movingDirection = leftStickDirection;

        if (Input.GetAxis(XboxAxis.LeftStickY) > deadZone)
        {
            if (rigidbody.velocity.magnitude < currentPhysicsMotion.maxSpeed * absoluteLeftStick)
            {
                rigidbody.AddForce(transform.forward * currentPhysicsMotion.accelerationForce, ForceMode.Acceleration);
            }
        }
        else if (Input.GetAxis(XboxAxis.LeftStickY) < -deadZone)
        {
            rigidbody.AddForce(-rigidbody.velocity.normalized * currentPhysicsMotion.brakeForce, ForceMode.Acceleration);

            if (rigidbody.velocity.magnitude < currentPhysicsMotion.brakeMinSpeed)
            {
                isBraking = false;
                rigidbody.Sleep();
            }
        }

        if (rigidbody.HorizontalVelocity().magnitude > 0.1f && !isBraking)
        {
            transform.rotation = Quaternion.LookRotation(rigidbody.velocity.normalized, transform.up);
        }

        transform.rotation = Quaternion.FromToRotation(transform.up, GetGroundInformation().normal) * transform.rotation;

        if (leftStickDirection.magnitude > deadZone && Vector3.Dot(lastMovingDir, transform.forward) > 0.95f && Time.time > stateMachine.lastStateTime + 0.2f)
        {
            rigidbody.velocity = Vector3.Lerp(transform.forward, movingDirection, 1 * Time.fixedDeltaTime) * rigidbody.velocity.magnitude;
        }

        lastMovingDir = transform.forward;
    }
    void StateSnowBoardEnd()
    {
        if (!isSnowboarding)
        {
            collider.material = playerMaterial;
            currentPhysicsMotion = groundMotion;
        }
    }
    #endregion
    #region State Snow Board Fall
    void StateSnowBoardFallStart()
    {

    }
    public void StateSnowBoardFall()
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(rigidbody.velocity.normalized, Vector3.up), 10 * Time.deltaTime);

        if (IsGrounded())
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







        movingDirection = leftStickDirection;

        if (Input.GetAxis(XboxAxis.LeftStickY) > deadZone)
        {
            if (rigidbody.velocity.magnitude < currentPhysicsMotion.maxSpeed * absoluteLeftStick)
            {
                rigidbody.AddForce(transform.forward * currentPhysicsMotion.accelerationForce, ForceMode.Acceleration);
            }
        }
        else if (Input.GetAxis(XboxAxis.LeftStickY) < -deadZone)
        {
            rigidbody.AddForce(-rigidbody.velocity.normalized * currentPhysicsMotion.brakeForce, ForceMode.Acceleration);

            if (rigidbody.velocity.magnitude < currentPhysicsMotion.brakeMinSpeed)
            {
                isBraking = false;
                rigidbody.Sleep();
            }
        }

        if (rigidbody.HorizontalVelocity().magnitude > 0.1f && !isBraking)
        {
            transform.rotation = Quaternion.LookRotation(rigidbody.velocity.normalized, transform.up);
        }

        transform.rotation = Quaternion.FromToRotation(transform.up, GetGroundInformation().normal) * transform.rotation;

        Drift();

        rigidbody.velocity = transform.forward * rigidbody.velocity.magnitude;



        if (!IsGrounded())
        {
            stateMachine.ChangeState(StateSnowBoardFall);
        }
    }
    void StateSnowBoardDriftEnd()
    {

    }
    #endregion
    #region State Snow Board Jump
    void StateSnowBoardJumpStart()
    {
        rigidbody.AddForce(transform.up * 15, ForceMode.Impulse);
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
        StateGrindStart();
    }
    public void StateSnowBoardGrind()
    {
        StateGrind();
    }
    public void StateSnowBoardGrindPhysics()
    {
        StateGrindPhysics();
    }
    void StateSnowBoardGrindEnd()
    {
        StateGrindEnd();
    }
    #endregion
    #endregion

    #region Grind States
    #region State Grind
    private void StateGrindStart()
    {
        isGrinding = true;
        isGrindGrounded = true;
        rigidbody.useGravity = false;
        GrindSensorSetActive(true);
        currentPhysicsMotion = grindMotion;
        canHomming = true;

    }
    public void StateGrind()
    {
        if (!playerAnimation.currentAnimationName.Contains("jump") && !playerAnimation.currentAnimationName.Contains("move") && !playerAnimation.currentAnimationName.Contains("switch") && !playerAnimation.currentAnimationName.Contains("landing"))
        {
            if (grindSplineSensorL.bezierPath && Input.GetButtonDown(XboxButton.LeftShoulder) && !Input.GetButton(XboxButton.B))
            {
                if(Vector3.Dot(transform.forward, Camera.main.transform.forward) > 0)
                {
                    grindSwitchPath = grindSplineSensorL.bezierPath;

                    stateMachine.ChangeState(StateGrindSwitchLeft);
                }
                else
                {
                    grindSwitchPath = grindSplineSensorR.bezierPath;

                    stateMachine.ChangeState(StateGrindSwitchRight);
                }

                return;
            }
            else if (grindSplineSensorR.bezierPath && Input.GetButtonDown(XboxButton.RightShoulder) && !Input.GetButton(XboxButton.B))
            {
                if (Vector3.Dot(transform.forward, Camera.main.transform.forward) > 0)
                {
                    grindSwitchPath = grindSplineSensorR.bezierPath;

                    stateMachine.ChangeState(StateGrindSwitchRight);                    
                }
                else
                {
                    grindSwitchPath = grindSplineSensorL.bezierPath;

                    stateMachine.ChangeState(StateGrindSwitchLeft);
                }

                return;
            }
            else if (Input.GetButtonDown(XboxButton.A))
            {
                stateMachine.ChangeState(StateGrindJump);

                return;
            }
        }

        CheckBoost();

        if (!grindSensor.bezierPath)
        {
            isGrinding = false;
            GrindSensorSetActive(false);
            if (isSnowboarding)
            {
                stateMachine.ChangeState(StateSnowBoardFall);
            }
            else
            {
                stateMachine.ChangeState(StateFall);
            }

            return;
        }
    }
    private void StateGrindEnd()
    {


        rigidbody.useGravity = true;
        isGrindGrounded = false;
    }
    public void StateGrindPhysics()
    {
        grindSensor.bezierPath.PutOnPath(transform, PutOnPathMode.BinormalAndNormal, out grindKnot, out _, grindPathAtractForce);

        //Sign to get if player is moving forward on grind direction
        float sign = Mathf.Sign(Vector3.Dot(transform.forward, grindKnot.tangent));
        //Multiply by grind direction, if sign is negative player will move in oposite direction
        Vector3 tangent = grindKnot.tangent * sign;
        //Multiply by binormal direction to get bendings
        Vector3 binormal = grindKnot.binormal * sign;
        //Calculate normal bending based on binormal and tangent
        Vector3 normal = isBoosting ? grindKnot.normal : Vector3.Lerp(grindKnot.normal - binormal, grindKnot.normal + binormal, halfOfOne + playerAnimation.grindTangent * grindTurnBendingFactor);

        transform.rotation = Quaternion.LookRotation(tangent, normal);

        if (isBoosting)
        {
            if (rigidbody.velocity.magnitude < currentPhysicsMotion.maxSpeedInBoost * SuperRate)
            {
                rigidbody.AddForce(tangent * currentPhysicsMotion.accelerationForceInBoost * SuperRate, ForceMode.Acceleration);
            }
        }
        else
        {
            if (rigidbody.velocity.magnitude > grindingMinimumVelocity)
            {
                rigidbody.AddForce(-tangent * grindVertivalVelocityRate * Mathf.Sign(rigidbody.velocity.normalized.y), ForceMode.Acceleration);
            }
        }

        rigidbody.velocity = tangent * Mathf.Clamp(rigidbody.velocity.magnitude, grindingMinimumVelocity, currentPhysicsMotion.maxSpeedInBoost * SuperRate);
    }
    #endregion State Grind
    #region State Grind Jump
    private void StateGrindJumpStart()
    {
        rigidbody.AddForce(transform.up * (grindJumpForce - rigidbody.velocity.y), ForceMode.Impulse);
        isGrindGrounded = true;
    }
    private void StateGrindJump()
    {
        if (Input.GetButton(XboxButton.A))
        {
            if (Time.time > stateMachine.lastStateTime + 0.14f)
            {
                isGrinding = false;
                grindSensor.bezierPath = null;
                rigidbody.useGravity = true;
                rigidbody.AddForce(transform.up * (grindJumpForce - rigidbody.velocity.y), ForceMode.Impulse);
                stateMachine.ChangeState(StateBall);
                return;
            }
        }

        if (Time.time > stateMachine.lastStateTime + 0.7 || !grindSensor.bezierPath)
        {
            isGrinding = false;
            grindSensor.bezierPath = null;
            GrindSensorSetActive(false);
            stateMachine.ChangeState(StateFall);

            return;
        }

        grindSensor.bezierPath.PutOnPath(transform, PutOnPathMode.BinormalOnly, out sideViewKnot);

        grindSensor.transform.localPosition = transform.InverseTransformPoint(sideViewKnot.point);

        CheckBoost();

        //Sign to get if player is moving forward on grind direction
        float sign = Mathf.Sign(Vector3.Dot(transform.forward, sideViewKnot.tangent));
        //Multiply by grind direction, if sign is negative player will move in oposite direction
        Vector3 tangent = sideViewKnot.tangent * sign;

        transform.rotation = Quaternion.LookRotation(tangent, sideViewKnot.normal);

        if (transform.position.y < sideViewKnot.point.y)
        {
            stateMachine.ChangeState(StateGrind);
        }
    }
    private void StateGrindJumpEnd()
    {
        isGrindGrounded = false;
        grindSensor.transform.localPosition = Vector3.zero;
    }
    #endregion State Grind
    #region State Grind Switch
    private void StateGrindSwitchStart()
    {
        rigidbody.useGravity = false;
        isGrindGrounded = true;
    }
    public void StateGrindSwitch()
    {
        stateMachine.ChangeState(StateGrind, returnFromSwitchTime);
    }
    public void StateGrindSwitchPhysics()
    {
        if (Time.time > stateMachine.lastStateTime + grindSwitchDelay)
        {
            grindSwitchPath.PutOnPath(transform, PutOnPathMode.BinormalAndNormal, out grindKnot, out _, grindPathAtractForce * (Time.time - stateMachine.lastStateTime));
        }
        //Sign to get if player is moving forward on grind direction
        float sign = Mathf.Sign(Vector3.Dot(transform.forward, grindKnot.tangent));
        //Multiply by grind direction, if sign is negative player will move in oposite direction
        Vector3 tangent = grindKnot.tangent * sign;

        transform.rotation = Quaternion.LookRotation(tangent, grindKnot.normal);
    }
    private void StateGrindSwitchEnd()
    {
        rigidbody.useGravity = true;
        isGrindGrounded = false;
        grindSwitchPath = null;
    }
    #endregion
    #region State Grind Switch Left
    private void StateGrindSwitchLeftStart()
    {
        StateGrindSwitchStart();
    }
    public void StateGrindSwitchLeft()
    {
        StateGrindSwitch();
    }
    public void StateGrindSwitchLeftPhysics()
    {
        StateGrindSwitchPhysics();
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
    public void StateGrindSwitchRight()
    {
        StateGrindSwitch();
    }
    public void StateGrindSwitchRightPhysics()
    {
        StateGrindSwitchPhysics();
    }
    private void StateGrindSwitchRightEnd()
    {
        StateGrindSwitchEnd();
    }
    #endregion
    #endregion

    void AirAlign()
    {

        Vector3 hVelocity = rigidbody.velocity;
        hVelocity.y = 0;
        transform.rotation = Quaternion.LookRotation(hVelocity);
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
        if (collision.collider.sharedMaterial)
        {
            if (collision.collider.sharedMaterial.name == "Ice")
            {
                currentPhysicsMotion = iceMotion;
            }
        }

        if (collision.collider.CompareTag("Pushable"))
        {
            RaycastHit hit = new RaycastHit();
            Physics.Raycast(collider.center, transform.forward, out hit);
            pushableCenter = hit.point;
            pushableNormal = hit.normal;
            pushable = collision.gameObject;
            stateMachine.ChangeState(StatePushing);
        }

        if (stateMachine.currentStateName != "StateHurt")
        {
            Vector3 otherPositionNormalized = new Vector3(collision.transform.position.x, transform.position.y, collision.transform.position.z);

            if (collision.collider.CompareTag(GameTags.enemyTag) || collision.collider.CompareTag("Boss"))
            {
                IDamageable damageable = collision.collider.GetComponent<IDamageable>();

                if (isBoosting)
                {
                    damageable.TakeDamage(gameObject);
                }
                else if (isAttacking || isSuper)
                {
                    transform.LookAt(otherPositionNormalized);

                    if (stateMachine.currentStateName == "StateHoming")
                    {
                        stateMachine.ChangeState(StateHomingTrick);
                    }

                    damageable.TakeDamage(gameObject);
                }
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.sharedMaterial)
        {
            if (collision.collider.sharedMaterial.name == "Ice")
            {

            }
        }
    }

    private void OnCollisionStay(Collision other)
    {
        //if (other.collider.CompareTag("WaterSurface"))
        //{
        //    if (horizontalVelocity.magnitude < 40 || isBraking && verticalVelocity >= 0)
        //    {
        //        other.collider.isTrigger = true;
        //    }
        //}

        contactPoint = other.contacts[0];
    }

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetButtonDown(XboxButton.Y) && stateMachine.currentStateName != "StateTornado" && other.CompareTag("Tornado"))
        {
            tornado = other.GetComponent<Tornado>();
            tornado.player = this;
            stateMachine.ChangeState(tornado.StateTornado, tornado.StateTornadoPhysics, tornado.gameObject);
        }

        if (other.CompareTag("Underwater") && (transform.position.y + 1) < other.bounds.max.y)
        {
            isUnderwater = true;
            StoreRigidbodyState();
            rigidbody.drag = underwaterRigidbodyDrag;
            Physics.gravity = new Vector3(0, -35 - 0) * underwaterGravityScale;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Ceiling"))
        {
            stateMachine.ChangeState(StateFall);
        }

        if (other.CompareTag("Underwater"))
        {
            isUnderwater = false;
            ResetRigidbodyState();
            Physics.gravity = new Vector3(0, -35, 0);
            GameManager.instance.SendMessage("UnderwaterReset", SendMessageOptions.DontRequireReceiver);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ceiling"))
        {
            ceilingPoint = other.transform.position;
            stateMachine.ChangeState(StateCeilingHang);
        }

        if (other.CompareTag("SkydiveStart"))
        {
            stateMachine.ChangeState(StateSkydive);
        }

        if (other.CompareTag("SkydiveEnd"))
        {
            if (stateMachine.currentStateName == "StateSkyDive")
            {
                stateMachine.ChangeState(StateFall);
            }
        }
    }

    public void TakeDamage(GameObject sender)
    {
        if (ignoreDamage || isAttacking || isSuper)
        {
            return;
        }

        Input.SetVibration(1, 1, 0.2f);

        IgnoreDamage();

        if (GameManager.instance.rings > 0)
        {
            if (isGrinding)
            {
                gameObject.SendMessage("GrindDamage");
                return;
            }
            stateMachine.ChangeState(StateHurt);
        }
        else
        {
            bezierPath = null;
            stateMachine.ChangeState(StateDie);
        }

        Vector3 senderPosition = sender.transform.position;
        senderPosition.y = transform.position.y;
        Vector3 playerToSenderDirection = transform.DirectionTo(senderPosition);

        transform.forward = playerToSenderDirection;
        rigidbody.velocity = -playerToSenderDirection * 15;
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

    private void OnDrawGizmos()
    {
        if (!collider)
        {
            collider = GetComponent<CapsuleCollider>();
        }
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(collider.center - transform.up * isGroundedMaxDistance, isGroundedRadius);

        Gizmos.color = Color.magenta;
        Gizmos.DrawWireSphere(collider.center - transform.up * groundInformationMaxDistance, groundInformationRadius);
    }

    public void DisablePhysics()
    {
        rigidbody.velocity = Vector3.zero;
        rigidbody.collisionDetectionMode = CollisionDetectionMode.Discrete;
        rigidbody.interpolation = RigidbodyInterpolation.None;
        rigidbody.useGravity = false;
        //rigidbody.isKinematic = true;
        isPhysicEnabled = false;
    }

    public void EnablePhysics()
    {
        rigidbody.useGravity = true;
        //rigidbody.isKinematic = false;
        rigidbody.interpolation = RigidbodyInterpolation.None;
        rigidbody.collisionDetectionMode = CollisionDetectionMode.Continuous;
        isPhysicEnabled = true;
    }
}