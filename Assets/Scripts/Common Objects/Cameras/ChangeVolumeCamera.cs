using UnityEngine;

[RequireComponent (typeof(BoxCollider))]
public class ChangeVolumeCamera : MonoBehaviour
{
    public CameraCommon target;

    [Range(-10, 10)]
    public int priority = 0;

    private void OnValidate()
    {
        if (target != null)
        {
            target.priority = priority;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(GameTags.playerTag))
        {
            CameraManager.ActivateCamera(target);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(GameTags.playerTag))
        {
            CameraManager.DeactivateCamera(target);
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(0, 0.5f, 0, 0.5f);
        GizmosExtension.DrawBoxBoundaries(GetComponent<BoxCollider>());
        Gizmos.color = new Color(0, 0, 0.5f, 0.5f);
        //if (target != null)
        //{
        //    Gizmos.DrawSphere(target.transform.position, 0.05f);
        //}        
    }
    private void OnDisable()
    {
        
            CameraManager.DeactivateCamera(target);
        
    }
}