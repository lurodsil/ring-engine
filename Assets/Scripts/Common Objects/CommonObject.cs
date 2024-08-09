using UnityEngine;
using UnityEngine.Events;

public abstract class CommonObject : MonoBehaviour
{
    public Player player { get; set; }

    public UnityEvent OnPlayerTriggerEnter;
    public UnityEvent OnPlayerTriggerExit;

    public virtual void OnEnable()
    {
        if (GetComponent<AudioSource>())
        {
            GameManager.OnPause += GetComponent<AudioSource>().Pause;
            GameManager.OnResume += GetComponent<AudioSource>().UnPause;
        }
    }

    public virtual void OnDisable()
    {
        if (GetComponent<AudioSource>())
        {
            GameManager.OnPause -= GetComponent<AudioSource>().Pause;
            GameManager.OnResume -= GetComponent<AudioSource>().UnPause;
        }
    }

    public virtual void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(GameTags.playerTag))
        {
            player = other.GetComponent<Player>();
            OnPlayerTriggerEnter?.Invoke();
        }
    }

    public virtual void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(GameTags.playerTag))
        {
            OnPlayerTriggerExit?.Invoke();
        }
    }

    public void DrawEventLines(UnityEvent unityEvent, Color color)
    {
        Gizmos.color = color;

        for (int i = 0; i < unityEvent.GetPersistentEventCount(); i++)
        {
            Component targetComponent = unityEvent.GetPersistentTarget(i) as Component;

            if (targetComponent != null)
            {
                Gizmos.DrawLine(transform.position, targetComponent.transform.position);
            }
        }
    }
}
