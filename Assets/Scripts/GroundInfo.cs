using UnityEngine;

[RequireComponent(typeof(Collider))]
public class GroundInfo : MonoBehaviour
{
    public LayerMask layerMask;
    public float maxDistanceInLowSpeed = 0.5f;
    public float maxDistanceInHighSpeed = 1f;
    public float groundSearchRadiusInLowSpeed = 0.15f;
    public float groundSearchRadiusInHighSpeed = 0.25f;
    public float lowToHighSpeed = 20;
    public bool grounded = false;
    public bool grindGrounded = false;
    public GroundState groundState;

    new private Collider collider;
    private new Rigidbody rigidbody;

    public RaycastHit groundHit;

    private readonly int angleMin = 10;
    private readonly int angleMid = 45;
    private readonly int angleMax = 135;

    float distance;
    float radius;
    float velocityCoeficient;

    private Vector3 lastNormal = Vector3.up;

    public Vector3 LastNormal { get => lastNormal; set => lastNormal = value; }

    private void Awake()
    {
        collider = GetComponent<Collider>();
        rigidbody = GetComponent<Rigidbody>();
    }

    public void SearchGroundHighSpeed()
    {
        SearchGround(groundSearchRadiusInHighSpeed, maxDistanceInHighSpeed);
    }

    public void SearchGround()
    {
        SearchGround(groundSearchRadiusInLowSpeed, maxDistanceInLowSpeed);
    }

    public void SearchGround(float radius, float distance)
    {
        //grounded = Physics.Raycast(collider.bounds.center, -transform.up, out groundHit, 0.7f, layerMask, QueryTriggerInteraction.Ignore);

        grounded = Physics.SphereCast(collider.bounds.center, radius,
            -transform.up,
            out groundHit,
            distance,
            layerMask,
            QueryTriggerInteraction.Ignore);

        if (grounded)
        {
            float angle = Vector3.Angle(groundHit.normal, Vector3.up);

            if (angle < 10)
            {
                groundState = GroundState.onGround;
            }
            else if (angle > angleMin && angle < angleMid)
            {
                groundState = GroundState.onSlope;
            }
            else if (angle > angleMid && angle < angleMax)
            {
                groundState = GroundState.onWall;
            }
            else if (angle > angleMax)
            {
                groundState = GroundState.onCeiling;
            }
        }

        if (rigidbody.velocity.magnitude < 15)
        {
            switch (groundState)
            {
                case GroundState.onWall: grounded = false; break;
                case GroundState.onCeiling: grounded = false; break;
            }
        }

        if (Vector3.Angle(groundHit.normal, LastNormal) > 50)
        {
            grounded = false;
        }

        LastNormal = groundHit.normal;
    }

    private void OnDrawGizmos()
    {
        collider = GetComponent<Collider>();
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(collider.bounds.center - transform.up * distance, radius);
    }
}