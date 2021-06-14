using UnityEngine;
using UnityEngine.Events;

public abstract class RingEngineObject : MonoBehaviour
{
    public Player player { get; set; }

    [HideInInspector]
    public UnityEvent OnBecomeActive;
    [HideInInspector]
    public UnityEvent OnBecomeInactive;

    public bool showEventsInInspector { get; set; }

    public bool active
    {
        get
        {
            return Active;
        }
        set
        {
            if (Active != value)
            {
                if (Active == false)
                {
                    OnBecomeActive?.Invoke();
                }
                else
                {
                    OnBecomeInactive?.Invoke();
                }
            }

            Active = value;
        }
    }

    private bool Active;

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

    public virtual void Activate()
    {
        active = true;
    }
    public virtual void Deactivate()
    {
        active = false;
    }
}
