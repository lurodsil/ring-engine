using UnityEngine;

public class MainCamera : MonoBehaviour
{
    public static MainCamera instance;

    public Transform target;
    [Range(0, 50)]
    public float distance = 5;
    public float fieldOfView = 45;
    public float easeIn = 0.5f;

    public float minAngleX = -10;
    public float maxAngleX = 45;

    public Vector2 sensitivity = new Vector2(10, 10);

    public float resetTime = 2;

    public Player player;

    private Vector3 offset;
    private float lastStateTime;

    private float lastCameraSetTime;
    Vector2 inputAxis;
    Vector2 inputAxisDamped;

    private bool lockCamera;

    private void Start()
    {
        instance = GetComponent<MainCamera>();
        offset = new Vector3(0, 0, distance);
        target = GameObject.FindGameObjectWithTag("Camera Target").transform;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    float ClampAngle(float angle, float from, float to)
    {
        if (angle < 0f) angle = 360 + angle;
        if (angle > 180f) return Mathf.Max(angle, 360 + from);
        return Mathf.Min(angle, to);
    }

    private void LateUpdate()
    {
        if (!target)
        {
            target = GameObject.FindGameObjectWithTag("Camera Target").transform;
        }

        if ((player.stateMachine.currentStateName == "StateQuickstepLeft") || (player.stateMachine.currentStateName == "StateQuickstepRight"))
        {
            lastCameraSetTime = Time.time;
        }

        if (CameraManager.activeCamera == gameObject)
        {
            inputAxis = new Vector2(Input.GetAxis(XboxAxis.RightStickX), Input.GetAxis(XboxAxis.RightStickY));
            inputAxisDamped = Vector2.Lerp(inputAxisDamped, inputAxis, 5 * Time.deltaTime);

            if (inputAxisDamped != Vector2.zero)
            {
                transform.RotateAround(target.position, Vector3.up, sensitivity.x * inputAxisDamped.x * Time.deltaTime);
                transform.RotateAround(target.position, transform.right, sensitivity.y * inputAxisDamped.y * Time.deltaTime);

                lastCameraSetTime = Time.time;
            }
            else if (Time.time > lastCameraSetTime + resetTime)
            {
                //transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation((target.position - transform.position).normalized), 30 * Time.deltaTime);
                transform.LookAt(target);
            }

            Vector3 euler = transform.eulerAngles;
            euler.x = ClampAngle(euler.x, minAngleX, maxAngleX);
            transform.eulerAngles = euler;

            offset.z = Mathf.Lerp(offset.z, distance, (Time.time - lastStateTime) / easeIn);

            transform.position = target.transform.position - (transform.rotation * offset);

            Camera.main.fieldOfView = fieldOfView;

            CameraTarget.instance.offset = Vector3.zero;
        }
        else
        {
            lastStateTime = Time.time;
            offset.z = Vector3.Distance(transform.position, target.position);
        }
    }

    public void OnCameraAnimationEnd()
    {
        GetComponent<Animator>().enabled = false;
        GetComponent<MainCamera>().enabled = true;
        lastCameraSetTime = Time.time;

    }

    public void Enable()
    {
        enabled = true;
    }

    public void Disable()
    {
        enabled = false;
    }

    public void ResetTime()
    {
        lastStateTime = Time.time;
    }
}
