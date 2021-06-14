using UnityEngine;

public class TranslateObject : MonoBehaviour
{
    public float velocity = 10;
    public Vector3 targetPosition;
    public Transform cameraPosition;
    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnEnable()
    {
        MainCamera.instance.enabled = false;
        Player.instance.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        MainCamera.instance.transform.position = Vector3.Lerp(MainCamera.instance.transform.position, cameraPosition.position, 10 * Time.deltaTime);
        MainCamera.instance.transform.rotation = Quaternion.Lerp(MainCamera.instance.transform.rotation, cameraPosition.rotation, 10 * Time.deltaTime);

        transform.position = Vector3.MoveTowards(transform.position, targetPosition, velocity * Time.deltaTime);

        if (transform.position == targetPosition)
        {
            this.enabled = false;
            MainCamera.instance.enabled = true;
            Player.instance.enabled = true;
        }
    }
}
