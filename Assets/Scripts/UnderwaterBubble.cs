using UnityEngine;

public class UnderwaterBubble : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Underwater"))
        {
            GetComponent<ParticleSystem>().Play();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Underwater"))
        {
            GetComponent<ParticleSystem>().Stop();
        }
    }
}
