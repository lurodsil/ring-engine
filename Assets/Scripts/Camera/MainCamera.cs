using UnityEngine;

public class MainCamera : MonoBehaviour
{
    private static MainCamera instance;

    public static Transform Transform
    {
        get => instance.transform;

    }

    public static Vector3 Position
    {
        get => instance.transform.position;
        set => instance.transform.position = value;
    }

    public static Quaternion Rotation
    {
        get => instance.transform.rotation;
        set => instance.transform.rotation = value;
    }

    public static Vector3 lastPosition;
    public static Quaternion lastRotation = Quaternion.identity;

    public static Transform CameraTransform => instance.transform;

    public static CameraTarget Target => instance.target;

    public CameraTarget target;

    [Range(1, 20)] public float distance = 5;
    [Range(1, 50)] public float distanceWhenBoosting = 2;
    [Range(20, 90)] public float fieldOfView = 45;
    [Range(20, 90)] public float fieldOfViewWhenBoosting = 90;
    [Range(0.01f, 10)] public float easeIn = 0.5f;

    public Vector3 targetOffset = Vector3.zero;

    public float cameraEnabledTime;
    public float minAngleX = -10;
    public float maxAngleX = 45;

    public Vector2 sensitivity = new Vector2(10, 10);

    private Player player;
    private RaycastHit hit;
    private Vector2 inputAxis;
    private Vector2 inputAxisDamped;

    private Vector3 targetPosition;
    private Vector3 offset;
    private float follow;

    private bool reset;
    private Vector3 playerForward;
    private bool cut;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        offset = new Vector3(0, 0, distance);
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    private void FixedUpdate()
    {
        Vector3 targetToCameraDirection = (transform.position - target.position).normalized;
        Physics.SphereCast(target.position, 0.5f, targetToCameraDirection, out hit, distance, 1, QueryTriggerInteraction.Ignore);
    }

    private void LateUpdate()
    {
        HandleInput();
        UpdateCameraPositionAndRotation();
    }

    private void HandleInput()
    {
        inputAxis = new Vector2(Input.GetAxis(XboxAxis.RightStickX), Input.GetAxis(XboxAxis.RightStickY));
        inputAxisDamped = Vector2.Lerp(inputAxisDamped, inputAxis, 10 * Time.deltaTime);

        if (Input.GetButtonDown(XboxButton.RightStick))
        {
            reset = true;
            playerForward = player.transform.forward;
        }
    }

    private void UpdateCameraPositionAndRotation()
    {
        targetPosition = target.position + target.offset;

        if (inputAxis != Vector2.zero)
        {
            transform.RotateAround(target.position, Vector3.up, sensitivity.x * inputAxisDamped.x);
            transform.RotateAround(target.position, transform.right, sensitivity.y * inputAxisDamped.y);
        }
        else
        {
            Vector3 direction = Vector3.Lerp(transform.forward, (targetPosition - transform.position).normalized, 0.2f);
            direction.y = transform.forward.y;
            transform.rotation = Quaternion.LookRotation(direction);
        }

        if (reset)
        {
            float dot = Vector3.Dot(playerForward, transform.forward);
            transform.RotateAround(target.position, Vector3.up, 1 - dot);
            Vector3 direction = Vector3.Lerp(transform.forward, playerForward, 10 * Time.deltaTime);
            transform.rotation = Quaternion.LookRotation(direction);

            if (dot > 0.999f)
            {
                reset = false;
            }
        }

        Vector3 euler = transform.eulerAngles;
        euler.x = ClampAngle(euler.x, minAngleX, maxAngleX);
        transform.eulerAngles = euler;

        AdjustCameraDistanceAndFieldOfView();

        transform.position = targetPosition - (transform.rotation * offset);

        target.offset = Vector3.Lerp(target.offset, targetOffset, EaseIn());

        lastRotation = transform.rotation;
    }

    private void AdjustCameraDistanceAndFieldOfView()
    {
        if (hit.distance > 0)
        {
            offset.z = Mathf.Lerp(offset.z, hit.distance, EaseIn());
        }
        else
        {
            if (player.isBoosting)
            {
                Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, fieldOfViewWhenBoosting, EaseIn());
                offset.z = Mathf.Lerp(offset.z, distanceWhenBoosting, EaseIn());
            }
            else
            {
                Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, fieldOfView, EaseIn());
                offset.z = Mathf.Lerp(offset.z, distance, EaseIn());
            }
        }
    }

    private float ClampAngle(float angle, float from, float to)
    {
        if (angle < 0f) angle = 360 + angle;
        if (angle > 180f) return Mathf.Max(angle, 360 + from);
        return Mathf.Min(angle, to);
    }

    private float EaseIn()
    {
        float ease = (Time.time - cameraEnabledTime) * (1 / (easeIn * 10));
        return ease > 0.99f ? 1 : ease;
    }

    private void OnEnable()
    {
        ResetTime();
    }

    public void OnCameraAnimationEnd()
    {
        GetComponent<Animator>().enabled = false;
        if (CameraManager.GetCameraCount() == 0)
        {            
            enabled = true;
        }

        ResetTime();
    }

    public static bool IsCameraPlayingAnimation()
    {
        return instance.GetComponent<Animator>().enabled;
    }

    public static void SetFollowRate(float follow)
    {
        instance.follow = follow;
    }

    public static bool IsEnabled()
    {
        return instance.enabled;
    }

    public static void Shake(float duration = 0.2f, float force = 0.2f, float intensity = 20)
    {
        instance.StartCoroutine(instance.target.IEShake(duration, force, intensity));
    }

    public static void SetActive(bool active)
    {
        if (instance != null) { instance.enabled = active; }

    }

    public static void SetCameraDistance(float distance, float distanceWhenBoost)
    {
        instance.distance = distance;
        instance.distanceWhenBoosting = distanceWhenBoost;
    }

    public static void SetEaseIn(float easeIn)
    {
        instance.easeIn = easeIn;
    }

    public static void SetCameraTarget(Player target)
    {
        instance.target.player = target;
    }

    public static void ResetTime()
    {
        if (instance.cut)
        {
            instance.cut = false;
            return;
        }

        instance.cameraEnabledTime = Time.time;
        instance.offset.z = Vector3.Distance(instance.transform.position, instance.target.lookAt.position);
        instance.target.offset = instance.target.lookAt.position - instance.target.position;
        lastRotation = instance.transform.rotation;
    }

    public static void ReturnFromCutscene(bool cut = false)
    {
        instance.cut = cut;
        SetActive(true);
        instance.transform.LookAt(instance.target.lookAt);
    }
}
