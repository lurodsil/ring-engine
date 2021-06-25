using UnityEngine;

public class GaniganiMissile : MonoBehaviour
{
    private new Rigidbody rigidbody;
    public float velocity = 8;
    bool shot;
    float lastStateTime;
    float keepVelocityDistance = 10;
    public GameObject explosion;
    public AudioClip missileShot;
    public AudioClip missileShotLoop;
    private AudioSource audioSource;
    public bool isHoming = true;
    public GameObject target;
    public ParticleSystem particle;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (shot)
        {
            target = gameObject.Closest(GameObject.FindGameObjectsWithTag(GameTags.playerTag), 0, 20, true);

            if (isHoming)
            {
                if (target)
                {
                    transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation((target.GetComponent<Collider>().bounds.center - transform.position).normalized), 3 * Time.deltaTime);
                }

                rigidbody.velocity = transform.forward * velocity;
            }
            else
            {
                if (Time.time < lastStateTime + PhysicsExtension.Time(keepVelocityDistance, velocity))
                {

                    rigidbody.velocity = transform.forward * velocity;
                }
                else
                {
                    transform.forward = rigidbody.velocity.normalized;
                }
            }


        }
        else
        {
            lastStateTime = Time.time;
        }
    }

    public void Shot(bool useGravity)
    {
        shot = true;
        transform.parent = null;
        rigidbody.isKinematic = false;
        rigidbody.useGravity = false;

        audioSource.clip = missileShotLoop;
        audioSource.loop = true;
        audioSource.PlayDelayed(missileShot.length);
        audioSource.PlayOneShot(missileShot);
        particle.Play();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (shot)
        {
            if (!collision.collider.CompareTag("Missile"))
            {
                Instantiate(explosion, transform.position, transform.rotation);
                Destroy(gameObject);
            }
        }
    }
}
