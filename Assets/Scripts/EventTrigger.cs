using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class EventTrigger : MonoBehaviour
{
    public UnityEvent OnPlayerTriggerEnter;
    public UnityEvent OnPlayerTriggerStay;
    public UnityEvent OnPlayerTriggerExit;

    private Player player;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(GameTags.playerTag))
        {
            player = other.GetComponent<Player>();
            OnPlayerTriggerEnter?.Invoke();
        }            
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag(GameTags.playerTag))
        {
            player = other.GetComponent<Player>();
            OnPlayerTriggerStay?.Invoke();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(GameTags.playerTag))
        {
            player = other.GetComponent<Player>();
            OnPlayerTriggerExit?.Invoke();
        }
    }
}
