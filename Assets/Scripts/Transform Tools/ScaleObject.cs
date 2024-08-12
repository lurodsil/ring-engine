using UnityEngine;

public class ScaleObject : MonoBehaviour
{

    public float multiplyScale = 10;
    public float duration = 10;
    public float speed = 10;

    void Update()
    {
        //transform.localScale = Vector3.Lerp(transform.localScale, Vector3.one * multiplyScale, duration * Time.deltaTime);
        //transform.Translate(Vector3.up * speed * Time.deltaTime);
    }
}
