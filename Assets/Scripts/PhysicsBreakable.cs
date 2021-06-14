using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
[RequireComponent(typeof(AudioSource))]
public class PhysicsBreakable : MonoBehaviour
{

    public float breakForce = 20f;

    public float bounceForce = 18f;

    public AudioClip breakSound;

    public GameObject objectToBreak;

    public GameObject[] parts;

    void OnCollisionEnter(Collision other)
    {
        float relativeVelocity = other.relativeVelocity.magnitude;

        if (relativeVelocity > breakForce)
        {
            Destroy(objectToBreak);

            GetComponent<BoxCollider>().enabled = false;

            foreach (GameObject go in parts)
            {
                GameObject ga = Instantiate(go, transform.position, Quaternion.identity);

                ga.gameObject.AddComponent<MeshCollider>().convex = true;

                ga.gameObject.AddComponent<Rigidbody>();
            }

            GetComponent<AudioSource>().PlayOneShot(breakSound);

            Destroy(gameObject, breakSound.length);
        }

    }
}