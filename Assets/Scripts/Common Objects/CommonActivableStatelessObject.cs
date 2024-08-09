using UnityEngine;
using UnityEngine.Events;


public abstract class CommonActivableStatelessObject : CommonObject
{
    public bool active;
    private bool wasActive;

    public UnityEvent OnBecomeActive;
    public UnityEvent OnBecomeInactive;

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
}
