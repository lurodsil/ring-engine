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
        MainCamera.SetActive(false);
        Player.instance.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        MainCamera.Position = Vector3.Lerp(MainCamera.Position, cameraPosition.position, 10 * Time.deltaTime);
        MainCamera.Rotation = Quaternion.Lerp(MainCamera.Rotation, cameraPosition.rotation, 10 * Time.deltaTime);

        transform.position = Vector3.MoveTowards(transform.position, targetPosition, velocity * Time.deltaTime);

        if (transform.position == targetPosition)
        {
            this.enabled = false;
            MainCamera.SetActive(true);
            Player.instance.enabled = true;
        }
    }
}
