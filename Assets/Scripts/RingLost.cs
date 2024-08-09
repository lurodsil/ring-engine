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

    private void OnTriggerEnter(Collider other)
    {
        if (canBeCollectible)
        {
            if (other.CompareTag("ItemTrigger"))
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
