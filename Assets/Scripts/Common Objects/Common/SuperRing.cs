using UnityEngine;

public class SuperRing : GenerationsObject
{
    public ParticleSystem getSuperRing;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(GameTags.playerTag))
        {
            Instantiate(getSuperRing, transform.position, Quaternion.identity);
            Destroy(gameObject);
            EventManager.UpdateRingAmount(10);
        }
    }
}