using UnityEngine;

public class AddExplosionForce : MonoBehaviour
{
    public float explosionForce = 10;
    public float explosionRadius = 2;
    public LayerMask layerMask;

    private void Start()
    {
        Vector3 explosionPos = transform.position;
        Collider[] colliders = Physics.OverlapSphere(explosionPos, explosionRadius, layerMask);

        foreach (Collider hit in colliders)
        {
            Rigidbody rigidbody = hit.GetComponent<Rigidbody>();

            if (rigidbody != null)
            {
                rigidbody.AddExplosionForce(explosionForce, explosionPos, explosionRadius, 0.1f);
            }
        }
    }
}
