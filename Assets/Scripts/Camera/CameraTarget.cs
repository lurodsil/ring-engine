using UnityEngine;

public class CameraTarget : MonoBehaviour
{
    public static CameraTarget instance;

    public float OffsetSensitive = 10.0f;
    public float UpOffset = 1.7f;
    public float UpOffsetInAir = 1.0f;
    public float UpOffsetSensitive = 5.0f;
    public float ShakeUpOffsetMax = 1.7f;
    public float ShakeUpOffsetMin = 1.5f;
    public float shakeIntensity = 20;
    public float shakeDuration = 1;
    public bool shake { get; set; }
    public float damping = 0.25f;

    public Player player;
    private Vector3 localOffset;
    private Transform playerMesh;
    private Vector3 velocity;
    private float lastIdleTime;

    public Vector3 offset;
    public Vector3 lookAt;
    public Transform subTarget;

    public float delay = 15;

    void Start()
    {
        instance = GetComponent<CameraTarget>();
        transform.parent = null;
        localOffset = new Vector3(0, UpOffset, 0);
    }

    void Update()
    {
        if (shake)
        {
            localOffset.y = Mathf.Lerp(ShakeUpOffsetMin, ShakeUpOffsetMax, Mathf.PingPong(Time.time * shakeIntensity, 1));

            if (Time.time > lastIdleTime + shakeDuration)
            {
                shake = false;
            }
        }
        else
        {
            localOffset.y = Mathf.Lerp(localOffset.y, (player.IsGrounded() || player.isGrindGrounded) ? UpOffset : UpOffsetInAir, UpOffsetSensitive * Time.deltaTime);

            lastIdleTime = Time.time;
        }

        float dot = Vector3.Dot(transform.forward, player.transform.forward);

        transform.position = player.transform.position + localOffset;
        transform.rotation = Quaternion.Lerp(transform.rotation, player.transform.rotation, damping * Time.deltaTime);
        lookAt = player.transform.TransformPoint(offset * dot) + localOffset;
        subTarget.transform.position = Vector3.SmoothDamp(subTarget.transform.position, lookAt, ref velocity, damping * 0.5f);
    }

    public void Shake(float duration)
    {
        shakeDuration = duration;
        shake = true;
    }

    public void Shake(float duration, float intensity)
    {
        shakeDuration = duration;
        shakeIntensity = intensity;
        shake = true;
    }
}
