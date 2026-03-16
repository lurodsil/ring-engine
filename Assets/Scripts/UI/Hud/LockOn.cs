using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class LockOn : MonoBehaviour
{
    public GameObject lockon;
    public GameObject circle;
    public GameObject arrow;

    public AudioClip lockOnSound;

    public float rotationSpeed = 100;
    public float lockVelocity = 50;

    private Vector3 startLockOnOffset = new Vector3(5, 5, 5);
    private Vector3 lockedOffset = Vector3.one;

    private Player player;
    private AudioSource audioSource;
    private Camera cam;

    private GameObject lastTarget;
    private GameObject currentTarget;

    private bool enableLockOn;

    private Transform circleTransform;
    private Transform arrowTransform;
    private Transform lockonTransform;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

        cam = Camera.main;

        circleTransform = circle.transform;
        arrowTransform = arrow.transform;
        lockonTransform = lockon.transform;
    }

    void Update()
    {
        enableLockOn =
            player.closestTarget &&
            !player.IsGrounded() &&
            !player.isGrindGrounded &&
            player.canHomming;

        if (enableLockOn)
        {
            if (!lockon.activeSelf)
                lockon.SetActive(true);

            currentTarget = player.closestTarget;

            if (currentTarget != lastTarget)
            {
                audioSource.PlayOneShot(lockOnSound);

                circleTransform.localScale = startLockOnOffset;
                arrowTransform.localScale = startLockOnOffset;
            }
            else
            {
                Vector3 scale =
                    Vector3.Lerp(circleTransform.localScale, lockedOffset, lockVelocity * Time.deltaTime);

                circleTransform.localScale = scale;
                arrowTransform.localScale = scale;
            }

            lockonTransform.position =
                cam.WorldToScreenPoint(currentTarget.transform.position);

            circleTransform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
            arrowTransform.Rotate(0, 0, -rotationSpeed * Time.deltaTime);

            lastTarget = currentTarget;
        }
        else
        {
            if (lockon.activeSelf)
                lockon.SetActive(false);

            lastTarget = null;
        }
    }
}