using UnityEngine;

public abstract class DamageObject: RingEngineObject
{
    public override void OnTriggerEnter(Collider other)
    {
        if (active && other.CompareTag(GameTags.playerTag))
        {
            IDamageable damageable = other.GetComponent<IDamageable>();
            damageable.TakeDamage(gameObject);
            OnStateStart?.Invoke();
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (active && collision.collider.CompareTag(GameTags.playerTag))
        {
            IDamageable damageable = collision.collider.GetComponent<IDamageable>();
            damageable.TakeDamage(gameObject);
            OnStateStart?.Invoke();
        }
    }
    private void OnParticleCollision(GameObject other)
    {
        if (active && other.CompareTag(GameTags.playerTag))
        {
            IDamageable damageable = other.GetComponent<IDamageable>();
            damageable.TakeDamage(gameObject);
            OnStateStart?.Invoke();
        }
    }
}
