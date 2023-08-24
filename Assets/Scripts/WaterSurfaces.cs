using UnityEngine;

public class WaterSurfaces : MonoBehaviour
{
    public BoxCollider surface;
    BoxCollider boxCollider;
    public GameObject waterSplash;

    float centerY;

    // Use this for initialization
    void Start()
    {
        boxCollider = GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Instantiate(waterSplash, new Vector3(other.transform.position.x, other.bounds.max.y + 0.1f, other.transform.position.z), Quaternion.identity);
        }
       
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag(GameTags.playerTag))
        {
            //Vector3 otherVelocity = other.GetComponent<Rigidbody>().velocity;

            //Vector3 otherHorizontalVelocity = new Vector3(otherVelocity.x, 0, otherVelocity.z);

            ////surface.transform.localPosition = Vector3.Lerp( new Vector3(0, -5, 0), Vector3.zero, otherHorizontalVelocity.magnitude / 60);

            //if (otherHorizontalVelocity.magnitude < 42)
            //{
            //    surface.isTrigger = true;
            //}
            //else
            //{
            //    surface.isTrigger = false;
            //}
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(GameTags.playerTag))
        {
            other.transform.parent = null;

            surface.isTrigger = true;

            Instantiate(waterSplash, other.transform.position, Quaternion.identity);
        }
    }
}
