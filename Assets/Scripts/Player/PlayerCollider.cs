using UnityEngine;

[RequireComponent(typeof(CapsuleCollider))]
[RequireComponent(typeof(Player))]
public abstract class PlayerCollider : MonoBehaviour
{
    private Player player;
    private new CapsuleCollider collider;

    [SerializeField] SphereCollider wallCollider;
    [SerializeField] SphereCollider itemTrigger;
    [SerializeField] float colliderRadius = 0.3f;
    [SerializeField] float colliderPushingRadius = 0.45f;
    [SerializeField] float colliderSquatHeight = 0.3f;
    [SerializeField] float colliderStandHeight = 1.0f;
    [SerializeField] float itemTriggerRadiusNormal = 1f;
    [SerializeField] float itemTriggerRadiusExpanded = 2f;

    void Awake()
    {
        collider = GetComponent<CapsuleCollider>();
        player = GetComponent<Player>();
    }
    public virtual void Start()
    {
        StandCollider();
        ColapseItemTrigger();
    }
    public void SquatCollider()
    {
        collider.height = colliderSquatHeight;
        CenterCollider();
    }
    public void StandCollider()
    {
        collider.height = colliderStandHeight;
        collider.radius = colliderRadius;
        CenterCollider();
    }
    public void PushingCollider()
    {
        collider.height = colliderStandHeight;
        collider.radius = colliderPushingRadius;
        CenterCollider();
    }
    private void CenterCollider()
    {
        collider.center = new Vector3(0, Mathf.Max(collider.radius, collider.height / 2), 0);
        wallCollider.radius = Mathf.Max(collider.radius, collider.height / 2) - 0.1f;
        wallCollider.center = collider.center;
    }
    public void ExpandItemTrigger()
    {
        itemTrigger.radius = itemTriggerRadiusExpanded;
    }
    public void ColapseItemTrigger()
    {
        itemTrigger.radius = itemTriggerRadiusNormal;
    }
}
