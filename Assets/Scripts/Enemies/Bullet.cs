using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float velocity;
    public GameObject explosion;

    private void Update()
    {
        transform.Translate(transform.forward * velocity * Time.deltaTime);
    }

    private void OnParticleCollision(GameObject other)
    {
        Instantiate(explosion, transform.position, transform.rotation);
        other.SendMessage("Damage", SendMessageOptions.DontRequireReceiver);
        Destroy(gameObject);
    }
}
