using UnityEngine;

public class EggmanMobile : MonoBehaviour
{
    public float velocity = 10;
    public float angularVelocity = 10;
    private Player player;
    private new Rigidbody rigidbody;
    public BezierPath bezierPath;
    public BlinkMaterials blinkMaterials;

    public AudioClip hitSound;
    public AudioClip[] hitPlayerVoices;
    public AudioClip[] hitVoices;
    AudioSource audioSource;

    public bool active
    {
        get
        {
            return Active;
        }
        set
        {
            if (Active != value)
            {
                if (Active == false)
                {
                    SendMessage("OnBecomeActive", SendMessageOptions.DontRequireReceiver);
                }
                else
                {
                    SendMessage("OnBecomeInactive", SendMessageOptions.DontRequireReceiver);
                }
            }

            Active = value;
        }
    }

    private bool Active;


    public int health = 10;
    public GameObject explosion;

    public Stage stage;

    public Animator animator;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        rigidbody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        if (active)
        {
            RaycastHit hit = new RaycastHit();

            Physics.Raycast(transform.position, -transform.up, out hit);


            if (Vector3.Distance(transform.position, player.transform.position) > 10)
            {
                rigidbody.AddForce(transform.forward * velocity, ForceMode.Acceleration);
            }

            Vector3 playerPos = player.transform.position;

            playerPos.y = transform.position.y;

            float y = Mathf.Lerp(transform.position.y, hit.point.y + 7, Time.deltaTime);

            y = Mathf.Clamp(y, 3, 100);

            transform.position = new Vector3(transform.position.x, y, transform.position.z);

            Quaternion rotation = Quaternion.LookRotation((playerPos - transform.position).normalized);

            transform.rotation = Quaternion.Lerp(transform.rotation, rotation, angularVelocity * Time.deltaTime);
        }
    }

    public void Damage(Vector3 playerToEnemyDirection)
    {
        if (health <= 0)
        {
            Instantiate(explosion, transform.position, transform.rotation);
            //Destroy(gameObject);
            player.UpdateTargets();
            stage.SendMessage("BossDied");
            SendMessage("OnBossDestroy");
            animator.SetBool("Died", true);


            rigidbody.constraints = RigidbodyConstraints.None;
            rigidbody.constraints = RigidbodyConstraints.FreezeRotation;

        }
        else
        {
            blinkMaterials.Blink();
            audioSource.PlayOneShot(hitSound);
            audioSource.PlayOneShot(hitVoices[Random.Range(0, hitVoices.Length)]);
            health--;

            animator.SetTrigger("Damage");
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (!collision.collider.CompareTag(GameTags.playerTag))
        {
            rigidbody.AddForce(-transform.right * velocity, ForceMode.Acceleration);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(GameTags.playerTag))
        {
            audioSource.PlayOneShot(hitPlayerVoices[Random.Range(0, hitPlayerVoices.Length)]);

            animator.SetTrigger("Hit");
        }
    }

    private void OnBecomeActive()
    {
        animator.SetTrigger("Attack Start");
    }
}
