using UnityEngine;

public class RedMedal : MonoBehaviour
{
    public float MedalID = 1;
    public ParticleSystem getSpecialRing;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(GameTags.playerTag))
        {
            Instantiate(getSpecialRing, transform.position, Quaternion.identity);
            Destroy(gameObject);
            EventManager.UpdateRedStars((int)MedalID);
        }
    }
}