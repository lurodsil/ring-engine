using UnityEngine;

public class RotateObject : MonoBehaviour
{
    public Vector3 rotationSpeed;
    public GameObject target;
    // Use this for initialization
    void Start()
    {
        if (!target)
        {
            target = gameObject;
        }
    }

    // Update is called once per frame
    void Update()
    {
        target.transform.Rotate(rotationSpeed * Time.deltaTime);
    }
}
