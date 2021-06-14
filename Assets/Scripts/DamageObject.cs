using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class DamageObject: GenerationsObject
{
    public UnityEvent OnPlayerContact;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(GameTags.playerTag))
        {
            IDamageable damageable = other.GetComponent<IDamageable>();
            damageable.TakeDamage(gameObject);
            OnPlayerContact?.Invoke();
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag(GameTags.playerTag))
        {
            IDamageable damageable = collision.collider.GetComponent<IDamageable>();
            damageable.TakeDamage(gameObject);
            OnPlayerContact?.Invoke();
        }
    }
    private void OnParticleCollision(GameObject other)
    {
        if (other.CompareTag(GameTags.playerTag))
        {
            IDamageable damageable = other.GetComponent<IDamageable>();
            damageable.TakeDamage(gameObject);
            OnPlayerContact?.Invoke();
        }
    }
}
