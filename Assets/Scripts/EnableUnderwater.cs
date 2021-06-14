using UnityEngine;

public class EnableUnderwater : MonoBehaviour
{

    UnderwaterEffect underwater;

    private void Start()
    {
        underwater = GetComponent<UnderwaterEffect>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Underwater"))
        {
            underwater.enabled = true;
            GameManager.instance.SendMessage("UnderwaterStart", SendMessageOptions.DontRequireReceiver);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Underwater"))
        {
            underwater.enabled = false;
            GameManager.instance.SendMessage("UnderwaterEnd", SendMessageOptions.DontRequireReceiver);
        }
    }
}
