using System.Collections;
using UnityEngine;
using UnityEngine.Video;

public class CameraTarget : MonoBehaviour
{
    public Vector3 offset { get; set; }
    public Vector3 position { get { return transform.position; }  }

    public Player player;
    public Transform lookAt;

    [Header("Y offset parameters")]
    [SerializeField] float yOffset = 1.7f;
    [SerializeField] float yOffsetInAir = 1.0f;
    [SerializeField] float yOffsetDamping = 5.0f;

    private Vector3 subTargetPosition;
    private Vector3 localOffset;
    private Vector3 velocity;
    private const float damping = 1;
    private bool isShaking;
    private float intensity;
    private float force;

    private void Start()
    {
        transform.parent = null;
        localOffset = new Vector3(0, yOffset, 0);
    }

    private void Update()
    {
        if (!isShaking)
        {
            localOffset.y = Mathf.Lerp(localOffset.y, (player.IsGrounded() || player.isGrindGrounded) ? yOffset : yOffsetInAir, yOffsetDamping * Time.deltaTime);
        }
        else
        {
            localOffset.y = Mathf.Lerp(yOffset - force, yOffset + force, Mathf.PingPong(Time.time * intensity, 1));
        }
   
        transform.position = player.transform.position + localOffset;
        subTargetPosition = player.transform.TransformPoint(offset) + localOffset;
        lookAt.transform.position = Vector3.SmoothDamp(lookAt.transform.position, subTargetPosition, ref velocity, damping);
    }

    public IEnumerator IEShake(float duration, float force, float intensity)
    {
        this.force = force; ;
        this.intensity = intensity;
        isShaking = true;        
        yield return new WaitForSeconds(duration);
        isShaking = false;
    }
}
