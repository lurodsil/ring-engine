using UnityEngine;

public class MakeParent : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag(GameTags.playerTag))
        {
            collision.collider.transform.parent = transform;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.CompareTag(GameTags.playerTag))
        {
            collision.collider.transform.parent = null;
        }
    }
}
