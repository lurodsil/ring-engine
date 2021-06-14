using UnityEngine;

public class DestroyOnEnable : MonoBehaviour
{
    public float delay = 0;

    void OnEnable()
    {
        Destroy(gameObject, delay);
    }
}
