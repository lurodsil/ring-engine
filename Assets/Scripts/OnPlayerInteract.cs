using UnityEngine;
using UnityEngine.Events;

public class OnPlayerInteract : MonoBehaviour
{
    public UnityEvent OnPlayerTriggerEnter;
    public UnityEvent OnPlayerTriggerExit;
    private Player player;

    public virtual void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(GameTags.playerTag))
        {
            player = other.GetComponent<Player>();
            OnPlayerTriggerEnter!.Invoke();
        }
    }

    public virtual void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(GameTags.playerTag))
        {
            OnPlayerTriggerExit!.Invoke();
        }
    }
}
