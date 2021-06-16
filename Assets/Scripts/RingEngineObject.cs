using UnityEngine;
using UnityEngine.Events;

public abstract class RingEngineObject : MonoBehaviour
{
    public bool active;
    private bool wasActive;

    [HideInInspector]
    public UnityEvent OnBecomeActive;
    [HideInInspector]
    public UnityEvent OnBecomeInactive;
    [HideInInspector]
    public UnityEvent OnStateStart;
    [HideInInspector]
    public UnityEvent OnStateEnd;
    public Player player { get; set; }
    public StateMachine.State objectState { get; set; }

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
        OnBecomeActive!.Invoke();
        active = true;
    }
    public virtual void Deactivate()
    {
        OnBecomeInactive!.Invoke();
        active = false;
    }

    public virtual void OnValidate()
    {
        if (!wasActive && active)
        {
            OnBecomeActive?.Invoke();
            wasActive = true;
        }
        else if (wasActive && !active)
        {
            OnBecomeInactive?.Invoke();
            wasActive = false;
        }
    }

    public virtual void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(GameTags.playerTag))
        {
            if (objectState == null)
            {
                Debug.Log("Object state is not defined");
                return;
            }

            try
            {
                player = other.GetComponent<Player>();
                player.stateMachine.ChangeState(objectState, gameObject);
            }
            catch
            {
                Debug.Log(other.name + " does't contain Player component");
                return;
            }
        }
    }
}
