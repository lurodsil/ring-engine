using UnityEngine;
using UnityEngine.Events;

public abstract class RingEngineObject : MonoBehaviour
{
    public Player player { get; set; }

    public UnityEvent OnBecomeActive;
    public UnityEvent OnBecomeInactive;

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
}
