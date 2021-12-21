using UnityEngine;

public class EggmanMissile : MonoBehaviour
{
    new Rigidbody rigidbody;

    Transform target;

    public float speed = 100;
    public float angularSpeed = 30;

    private float startTime;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
        startTime = Time.time;
    }

    void Update()
    {
        rigidbody.velocity = transform.forward * speed;

        if (Time.time > startTime + 3)
        {
            Quaternion rotation = Quaternion.FromToRotation(transform.forward, target.transform.position - transform.position) * transform.rotation;

            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 30 * Time.deltaTime);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag(GameTags.playerTag) || collision.collider.CompareTag(GameTags.playerTag))
        {
            Destroy(gameObject);
        }
    }
}
