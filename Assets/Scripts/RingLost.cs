using System.Collections;
using UnityEngine;

public class RingLost : MonoBehaviour
{
    public float timeToBeCollectible;
    public bool canBeCollectible = false;

    public ParticleSystem getRing;

    void Start()
    {
        StartCoroutine(WaitToBeBollectible(timeToBeCollectible));
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (canBeCollectible)
        {
            if (collision.collider.CompareTag(GameTags.playerTag))
            {
                Instantiate(getRing, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
        }
    }

    IEnumerator WaitToBeBollectible(float time)
    {
        yield return new WaitForSeconds(time);
        canBeCollectible = true;
    }

    private void OnDestroy()
    {
        GameManager.instance.rings++;
    }
}
