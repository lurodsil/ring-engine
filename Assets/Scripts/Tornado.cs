using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public enum TornadoStates
{
    Idle,
    Flying,
    AutoPilot
}

public class Tornado : GenerationsObject
{
    private Animator animator;
    private AudioSource audioSource;
    private bool autopilot;
    private bool onTornado;
    private bool tornadoBrake;
    private float absX;
    private float absY;
    private float dotRU;
    private float dotUU;
    private float lastReleasedTime;
    private float minAudioPitch;
    private float pitchSpeed;
    private float rollSpeed;
    private float t;
    private float yawSpeed;
    private int index;
    private new Rigidbody rigidbody;
    public Animator sonicAnimator;
    public bool grounded;
    public bool pathHold;
    public bool powerOn;

    public float accelerationForce = 10;
    public float decelerationForce = 10;
    public float maxSpeed = 80;
    public float pitch = 100;
    public float roll = 100;
    public float speed { get; private set; }
    public float takeoffSpeed = 40;
    public float tornadoLiftSpeed = 20;
    public float yaw = 10;
    public Material propelerBlur;
    public Transform alignPoint;
    public Transform chrSonic;
    public Transform sonicPosition;
    public Transform targetPos;
    public Transform tornado;
    public Vector3 alignPosition;
    public TornadoStates tornadoStates;
    Quaternion landRotation = Quaternion.Euler(-22, 0, 0);
    RaycastHit hit;
    RaycastHit hitFront;
    bool obstacle;
    public float obstacleForce = 10;
    private float obstacleFactor;

    public BezierPath path;
    BezierKnot knot;

    // Use this for initialization
    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
        speed = 0;
    }


    private void Update()
    {
        audioSource.pitch = minAudioPitch + speed * (0.5f / maxSpeed);
        minAudioPitch = Mathf.MoveTowards(minAudioPitch, 1, Time.deltaTime * 0.5f);
        propelerBlur.SetColor("_TintColor", new Color(0.5f, 0.5f, 0.5f, 0.5f * minAudioPitch));


        grounded = Physics.SphereCast(transform.position + transform.up, 0.2f, -transform.up, out hit, 1.0f);

        obstacle = Physics.SphereCast(transform.position + transform.up, 0.8f, transform.forward, out hit, 10);

        if (obstacle)
        {
            obstacleFactor = 1;
        }
        else
        {
            obstacleFactor = 0;
        }


        tornado.transform.localRotation = Quaternion.Lerp(landRotation, Quaternion.identity, (1 / tornadoLiftSpeed) * (speed - tornadoLiftSpeed));

        switch (tornadoStates)
        {
            case TornadoStates.Idle:
                if (grounded)
                {

                }
                break;
            case TornadoStates.Flying:
                break;
            case TornadoStates.AutoPilot:
                path.PutOnPath(transform, PutOnPathMode.BinormalAndNormal, out knot);
                rigidbody.velocity = knot.tangent * 40;
                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(knot.tangent, knot.normal), 5 *Time.deltaTime);
                audioSource.pitch = 1;
                break;
        }


    }

    #region State Tornado
    private void StateTornadoStart()
    {
        player.rigidbody.velocity = Vector3.zero;


        player.transform.parent = sonicPosition;
        player.transform.localPosition = Vector3.zero;
        player.transform.rotation = Quaternion.identity;
        player.playerMesh.enabled = false;
        player.DisablePhysics();
        sonicAnimator.gameObject.SetActive(true);

        tornadoStates = TornadoStates.Flying;

        MainCamera.SetCameraDistance(5, 5);
        MainCamera.SetEaseIn(5);
    }
    public void StateTornado()
    {
       
        UpdateAnimators();

        //yaw movement
        if (Input.GetButton(XboxButton.LeftShoulder))
        {
            yawSpeed = -1;
        }
        else if (Input.GetButton(XboxButton.RightShoulder))
        {
            yawSpeed = 1;
        }
        else
        {
            yawSpeed = 0;
        }

        speed += accelerationForce * Time.deltaTime * Input.GetAxis(XboxAxis.RightTrigger);
        speed -= decelerationForce * Time.deltaTime * Input.GetAxis(XboxAxis.LeftTrigger);

        float dotfu = Vector3.Dot(transform.forward, Vector3.down);

        speed += dotfu * 10 * Time.deltaTime;

        if (grounded)
        {
            speed = Mathf.Clamp(speed, 0, maxSpeed);
        }
        else
        {
            speed = Mathf.Clamp(speed, Mathf.Max(tornadoLiftSpeed, takeoffSpeed), maxSpeed);
        }

        pitchSpeed += Input.GetAxis(XboxAxis.LeftStickY) * pitch * Time.deltaTime;
        rollSpeed += Input.GetAxis(XboxAxis.LeftStickX) * -roll * Time.deltaTime;

        pitchSpeed = Mathf.Clamp(pitchSpeed, -pitch, pitch);
        rollSpeed = Mathf.Clamp(rollSpeed, -roll, roll);

        absX = Mathf.Abs(Input.GetAxis(XboxAxis.LeftStickX));
        absY = Mathf.Abs(Input.GetAxis(XboxAxis.LeftStickY));

        if (absX < 0.1f)
        {
            rollSpeed = Mathf.Lerp(rollSpeed, 0, 5 * Time.deltaTime);
        }

        if (absY < 0.1f)
        {
            pitchSpeed = Mathf.Lerp(pitchSpeed, 0, 5 * Time.deltaTime);
        }

        float dot = Vector3.Dot(transform.right, Vector3.down);

        if (speed >= takeoffSpeed)
        {
            transform.Rotate((-obstacleFactor * obstacleForce) + pitchSpeed * Time.deltaTime, (dot * yaw * Time.deltaTime) + (yawSpeed * yaw * Time.deltaTime), rollSpeed * Time.deltaTime);
        }
        else
        {
            transform.Rotate((-obstacleFactor * obstacleForce) * Time.deltaTime, yawSpeed * Time.deltaTime, 0);
        }


        if (absX < 0.1f && absY < 0.1f)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.FromToRotation(transform.up, Vector3.up) * transform.rotation, 0.5f * Time.deltaTime);
        }

        if (grounded)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.FromToRotation(transform.up, hit.normal) * transform.rotation, Time.deltaTime);
        }

        rigidbody.velocity = transform.forward * speed;

    }
    private void StateTornadoEnd()
    {
        player.playerMesh.enabled = true;
        player.EnablePhysics();
        sonicAnimator.gameObject.SetActive(false);
    }
    #endregion

    void UpdateAnimators()
    {
        dotRU = Vector3.Dot(transform.right, Vector3.down);
        dotUU = Vector3.Dot(transform.up, Vector3.up);

        sonicAnimator.SetFloat("DotRU", dotRU);
        sonicAnimator.SetFloat("DotUU", dotUU);

        animator.SetFloat("X", Input.GetAxis(XboxAxis.LeftStickX));
        animator.SetFloat("Y", Input.GetAxis(XboxAxis.LeftStickY));
    }

    public void SetPath(BezierPath path)
    {
        this.path = path;
    }

    public void SetPosition(Transform targetPosition)
    {
        if (!gameObject.activeSelf)
        {
            transform.position = targetPosition.position;
            transform.rotation = targetPosition.rotation;
        }
        
    }
}