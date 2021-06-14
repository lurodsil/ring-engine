using UnityEngine;

public class RingEngineObject : MonoBehaviour
{
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
