using UnityEngine;

public class UpReel : GenerationsObject
{
    public float ImpulseVelocity = 18f;
    public bool IsWaitUp = false;
    public float Length = 8f;
    public float OutOfControl = 0f;
    public float UpSpeedMax = 50f;

    public GameObject target;
    public Transform handle;

    public Transform wire;


    public AudioClip start;
    public AudioClip loop;

    private Vector3 startPosition;
    private Vector3 endPosition;
    private Vector3 targetPosition;

    private bool pullUp;

    private SphereCollider sphereCollider;
    private AudioSource audioSource;
    private Vector3 playerOffset = new Vector3(0, -1.08f, 0.02f);

    void Start()
    {
        sphereCollider = GetComponent<SphereCollider>();
        audioSource = GetComponent<AudioSource>();

        audioSource.clip = loop;

        startPosition = transform.TransformPoint(new Vector3(0, -Length, 0));
        endPosition = transform.position;

        if (!IsWaitUp)
        {
            active = true;
        }
    }

    void Update()
    {
        if (active)
        {
            if (pullUp)
            {
                targetPosition = endPosition;
            }
            else
            {
                targetPosition = startPosition;
            }
        }
        else
        {
            targetPosition = endPosition;
        }

        if (handle.transform.position != targetPosition)
        {
            handle.transform.position = Vector3.MoveTowards(handle.transform.position, targetPosition, UpSpeedMax * Time.deltaTime);

            if (handle.position == endPosition)
            {
                pullUp = false;
            }

            sphereCollider.center = handle.transform.localPosition;
        }
        else
        {
            audioSource.Stop();
        }

        float distanceBetween = Vector3.Distance(handle.position, endPosition);

        wire.transform.localScale = new Vector3(wire.transform.localScale.x, distanceBetween - 0.5f, wire.transform.localScale.z);
        wire.GetComponent<Renderer>().material.SetTextureScale("_MainTex", new Vector2(10, distanceBetween * 10));
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(GameTags.playerTag))
        {
            player = other.GetComponent<Player>();
            pullUp = true;
            player.stateMachine.ChangeState(StateUpReel, gameObject);
        }
    }


    #region State Up Reel
    void StateUpReelStart()
    {
        player.rigidbody.useGravity = false;
        player.rigidbody.velocity = Vector3.zero;
        player.transform.parent = handle;
        player.transform.forward = -handle.forward;
        player.transform.localPosition = playerOffset;

        audioSource.PlayOneShot(start);
        audioSource.PlayDelayed(start.length);
    }
    void StateUpReel()
    {
        if (!pullUp)
        {
            player.stateMachine.ChangeState(player.StateTransition, gameObject);
        }
    }
    void StateUpReelEnd()
    {
        player.canHomming = true;
        player.transform.parent = null;
        player.rigidbody.useGravity = true;
        player.rigidbody.velocity = Vector3.Lerp(player.transform.forward, player.transform.up, 0.9f) * ImpulseVelocity;
    }
    #endregion

    private void OnDrawGizmos()
    {
        Vector3 handleOffset = transform.TransformPoint(new Vector3(0, -Length, 0));
        Gizmos.color = Color.red;
        Gizmos.DrawLine(handle.position, handleOffset);
        Gizmos.DrawSphere(handleOffset, 0.2f);
    }

    public void OnBecomeActive()
    {
        target.SetActive(true);
        sphereCollider.enabled = true;
    }

    public void OnBecomeInactive()
    {
        target.SetActive(false);
        sphereCollider.enabled = false;
    }
}