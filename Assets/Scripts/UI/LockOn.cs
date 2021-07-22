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
    private Vector3 lastLockPosition;
    private Player player;
    private AudioSource audioSource;
    private GameObject lastTarget;
    private GameObject currentTarget;
    private bool enableLockOn;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    void LateUpdate()
    {
        if (player.closestTarget && !player.isGrounded && !player.isGrindGrounded && player.stateMachine.currentStateName == "StateBall")
        {
            if (player.canHomming)
            {
                enableLockOn = true;
            }
            else
            {
                enableLockOn = false;
            }
        }
        else
        {
            enableLockOn = false;
        }

        if (enableLockOn)
        {
            lockon.SetActive(true);

            currentTarget = player.closestTarget;

            if (currentTarget != lastTarget)
            {
                audioSource.PlayOneShot(lockOnSound);
                circle.transform.localScale = startLockOnOffset;
                arrow.transform.localScale = circle.transform.localScale;
            }
            else
            {
                circle.transform.localScale = Vector3.Lerp(circle.transform.localScale, lockedOffset, lockVelocity * Time.deltaTime);
                arrow.transform.localScale = circle.transform.localScale;
            }


            lockon.transform.position = Camera.main.WorldToScreenPoint(player.closestTarget.transform.position);

            circle.transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
            arrow.transform.Rotate(0, 0, -rotationSpeed * Time.deltaTime);

            lastTarget = currentTarget;
        }
        else
        {
            lockon.SetActive(false);
            lastTarget = null;
        }
    }
}
