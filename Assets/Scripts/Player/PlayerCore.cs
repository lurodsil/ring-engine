using System.Collections;
using UnityEngine;

public abstract class PlayerCore : MonoBehaviour
{
    //Player global constants
    public const float minimunMovementVelocity = 0.1f;
    public const float deadZone = 0.3f;
    public const float halfOfOne = 0.5f;

    //Components
    new public CapsuleCollider collider { get; set; }
    public new Rigidbody rigidbody { get; set; }

    [Header("Ground Insformation")]
    public float isGroundedMaxDistance = 0.3f;
    public float isGroundedRadius = 0.1f;
    public float groundInformationMaxDistance = 1;
    public float groundInformationRadius = 0.02f;
    public LayerMask groundSearchLayerMask;

    private float rigidbodyDragTemp { get; set; }

    public bool IsGrounded(QueryTriggerInteraction queryTriggerInteraction = QueryTriggerInteraction.Ignore)
    {
        
        Ray isGroundedRay = new Ray(collider.bounds.center, -transform.up);
        return Physics.SphereCast(isGroundedRay, isGroundedRadius, isGroundedMaxDistance, groundSearchLayerMask, queryTriggerInteraction);
    }

    public RaycastHit GetGroundInformation(QueryTriggerInteraction queryTriggerInteraction = QueryTriggerInteraction.Ignore)
    {
        Ray groundInformationRay = new Ray(collider.bounds.center + transform.forward * rigidbody.ConformVelocity(60) * 0.5f, -transform.up);
        RaycastHit groundInformationHit = new RaycastHit();
        Physics.SphereCast(groundInformationRay, groundInformationRadius, out groundInformationHit, groundInformationMaxDistance, groundSearchLayerMask, queryTriggerInteraction);
        return groundInformationHit;
    }


    public void StoreRigidbodyState()
    {
        rigidbodyDragTemp = rigidbody.drag;
    }

    public void ResetRigidbodyState()
    {
        rigidbody.drag = rigidbodyDragTemp;
        rigidbodyDragTemp = 0;
    }
    public virtual void Update()
    {

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;    
        Gizmos.DrawWireSphere(collider.bounds.center - transform.up * ((collider.height * halfOfOne) + isGroundedMaxDistance), isGroundedRadius);
    }

}
