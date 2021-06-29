using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public CapsuleCollider wallCollider;
    public float wallColliderHeight = 0.95f;
    public float wallColliderSquatHeight = 0.4f;
    public float collisionPushingRadius = 0.45f;
    public float collisionRadius = 0.15f;
    public float collisionSquatHeight = 0.4f;
    public float collisionStandHeight = 1.0f;
    public float itemCollisionHeightInDiving = 1.0f;
    public float itemCollisionRadius = 0.3f;
    public float itemCollisionRadiusInBoost = 0.75f;
    public float itemCollisionRadiusInDiving = 0.75f;
    public float itemCollisionSquatHeight = 0.75f;
    public float itemCollisionSquatHeightInBoost = 0.5f;
    public float itemCollisionStandHeight = 1.0f;
    public float itemCollisionStandHeightInBoost = 1.0f;

    CapsuleCollider collision;
    public CapsuleCollider itemCollision;
    Player player;

    //void Awake()
    //{
    //    player = GetComponent<Player>();
    //    collision = GetComponent<CapsuleCollider>();
    //    //itemCollision = new GameObject("Item Collision").AddComponent<CapsuleCollider>();
    //    itemCollision.tag = "Item Collision";
    //    itemCollision.isTrigger = true;
    //    itemCollision.gameObject.layer = LayerMask.NameToLayer("Ignore Raycast");
    //    //itemCollision.hideFlags = HideFlags.HideInHierarchy;
    //}

    //void Start()
    //{
    //    collision.height = collisionStandHeight;
    //    collision.radius = collisionRadius;
    //    itemCollision.height = itemCollisionStandHeight;
    //    itemCollision.radius = itemCollisionRadius;
    //}

    //void Update()
    //{

    //    if (player.isBoosting)
    //    {
    //        itemCollision.height = itemCollisionStandHeightInBoost;
    //        itemCollision.radius = itemCollisionRadiusInBoost;
    //    }
    //    else
    //    {
    //        itemCollision.height = itemCollisionStandHeight;
    //        itemCollision.radius = itemCollisionRadius;
    //    }
    //}

    //void StateRollStart()
    //{
    //    SquatCollider();
    //}

    //void StateRollEnd()
    //{
    //    StandCollider();
    //}

    //void StateSquatStart()
    //{
    //    SquatCollider();
    //}

    //void StateSquatEnd()
    //{
    //    StandCollider();
    //}

    //void StateSlidingStart()
    //{
    //    SquatCollider();
    //}

    //void StateSlidingEnd()
    //{
    //    StandCollider();
    //}

    //void StateCrawlingStart()
    //{
    //    SquatCollider();
    //}

    //void StateCrawlingEnd()
    //{
    //    StandCollider();
    //}


    //void StateStompStart()
    //{
    //    itemCollision.height = itemCollisionStandHeightInBoost;
    //    itemCollision.radius = 2;
    //}

    //void StateStompEnd()
    //{
    //    itemCollision.height = itemCollisionStandHeight;
    //    itemCollision.radius = itemCollisionRadius;
    //}

    //void SquatCollider()
    //{
    //    collision.height = collisionSquatHeight;
    //    itemCollision.height = itemCollisionSquatHeight;
    //    wallCollider.height = wallColliderSquatHeight;
    //    CenterCollider();
    //}

    //void StandCollider()
    //{
    //    collision.height = collisionStandHeight;
    //    collision.radius = collisionRadius;
    //    itemCollision.height = itemCollisionStandHeight;
    //    itemCollision.radius = itemCollisionRadius;
    //    wallCollider.height = wallColliderHeight;
    //    CenterCollider();
    //}

    //void PushingCollider()
    //{
    //    collision.height = collisionStandHeight;
    //    collision.radius = collisionPushingRadius;
    //    itemCollision.height = itemCollisionStandHeight;
    //    itemCollision.radius = itemCollisionRadius;
    //    CenterCollider();
    //}

    //void DivingCollider()
    //{
    //    collision.height = collisionStandHeight;
    //    collision.radius = collisionRadius;
    //    itemCollision.height = itemCollisionHeightInDiving;
    //    itemCollision.radius = itemCollisionRadiusInDiving;

    //    CenterCollider();
    //}

    //void CenterCollider()
    //{
    //    collision.center = new Vector3(0, collision.height / 2, 0);
    //    itemCollision.center = new Vector3(0, itemCollision.height / 2, 0);
    //    wallCollider.center = collision.center;
    //}
}
