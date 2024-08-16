using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Shot : MonoBehaviour
{
    public float velocity = 10;
    public float maxDuration = 10;
    public bool useGravity = false;
    public float initialForce = 0;
    public GameObject shotExplosion;
    private new Rigidbody rigidbody;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        Destroy(gameObject, maxDuration);

        rigidbody.AddForce(transform.forward * initialForce, ForceMode.Impulse);

    }

    void Update()
    {
        if (!useGravity)
        {
            rigidbody.velocity = transform.forward * velocity;
        }       
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag(GameTags.playerTag))
        {
            IDamageable damageable = collision.collider.GetComponent<IDamageable>();
            damageable.TakeDamage(gameObject);
        }
        Instantiate(shotExplosion, collision.contacts[0].point, Quaternion.identity);
        Destroy(gameObject);
    }
}
