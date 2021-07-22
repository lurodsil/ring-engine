using System.Collections;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(Rigidbody))]
public class Enemy : GenerationsObject, IDamageable
{
    new public Collider collider { get; set; }
    new public Rigidbody rigidbody { get; set; }

    public StateMachine stateMachine = new StateMachine();
    public GameObject target { get; set; }

    public RaycastHit groundInfo;
    public Vector3 lastTargetPosition { get; set; }

    [Header("Enemy Common Parameters")]
    public bool isAlive;

    [Header("AI")]
    public EnemyType enemyType;
    public bool isChainDestroy;
    public bool isFlyMovement;
    public bool isGrounded;
    public bool isInstantDestroy;
    public bool isPlayerChase;
    public bool isTargetLook;

    [Header("Movement")]
    public EnemyMovementType movementType;

    public Transform waypoint;
    public Vector3[] waypoints { get; set; }
    public int waypointIndex { get; set; }

    public float movementVelocity = 5f;
    public float attackMovementVelocity = 10f;

    public BezierSpline spline;

    [Header("Field of View")]
    public float viewRange = 10;
    [Range(0, 360)]
    public float viewAngle = 45;

    [Header("Destroy")]
    public GameObject[] breakParts;
    public GameObject explosion;
    public UnityEvent onTakeDamage;

    private float groundSearchDistance;

    public virtual void Start()
    {
        collider = GetComponent<Collider>();
        rigidbody = GetComponent<Rigidbody>();

        groundSearchDistance = collider.bounds.size.y / 2 + 0.1f;

        if (waypoint)
        {
            waypoints = new Vector3[waypoint.childCount];

            for (int i = 0; i < waypoints.Length; i++)
            {
                waypoints[i] = waypoint.GetChild(i).position;
            }
        }

        isAlive = true;
    }

    public virtual void Update()
    {
        isGrounded = Physics.Raycast(collider.bounds.center, -transform.up, out groundInfo, groundSearchDistance);

        if (enemyType == EnemyType.Active)
        {
            target = gameObject.Closest(GameObject.FindGameObjectsWithTag(GameTags.playerTag), 0, viewRange, true, transform.forward, viewAngle);

            if (target)
            {
                lastTargetPosition = target.transform.position;
            }
        }
    }

    public void SimpleWaypointMovement()
    {
        if (Vector3.Distance(transform.position, waypoints[waypointIndex]) < 1f)
        {
            if (waypointIndex < waypoints.Length - 1)
            {
                waypointIndex++;
            }
            else
            {
                waypointIndex = 0;
            }
        }

        Vector3 movementDirection = (waypoints[waypointIndex] - transform.position).normalized;

        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(movementDirection), 10 * Time.deltaTime);

        rigidbody.velocity = movementVelocity * movementDirection;
    }

    public void TakeDamage(GameObject sender)
    {
        onTakeDamage.Invoke();

        Destroy(transform.Find("Target").gameObject);

        EventManager.UpdateTargetObjects();

        if (!isInstantDestroy && sender.CompareTag(GameTags.playerTag))
        {
            Vector3 senderPosition = sender.transform.position;
            senderPosition.y = transform.position.y;
            Vector3 receiverToSenderDirection = (senderPosition - transform.position).normalized;

            transform.forward = receiverToSenderDirection;

            GameObject closestEnemy = gameObject.Closest(GameObject.FindGameObjectsWithTag(GameTags.enemyTag), 0, viewRange, true, -receiverToSenderDirection, viewAngle);

            if (isChainDestroy && closestEnemy)
            {
                Vector3 enemyToClosestEnemyDirection = (closestEnemy.transform.position - gameObject.transform.position).normalized;

                rigidbody.velocity = (enemyToClosestEnemyDirection + Vector3.up).normalized * 20;
            }
            else
            {
                rigidbody.velocity = (-receiverToSenderDirection + Vector3.up).normalized * 20;
            }                    

            stateMachine.Pause();

            Explode(1);
        }
        else
        {
            Explode();
        }
    }

    public void Explode()
    {
        Destroy(gameObject);

        if (breakParts.Length > 0)
        {
            foreach (GameObject part in breakParts)
            {
                Instantiate(part, transform.position, transform.rotation);
            }
        }

        Instantiate(explosion, transform.position, transform.rotation);

        Player.instance.ringEnergy += 10;
    }

    public void Explode(float delay)
    {
        isAlive = false;
        StartCoroutine(ExplodeDelayed(delay));
    }

    private void OnDestroy()
    {
        EventManager.UpdateTargetObjects();
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        GizmosExtension.DrawViewRange(transform.position, transform.forward, viewAngle, viewRange);
    }

    private IEnumerator ExplodeDelayed(float delay)
    {
        yield return new WaitForSeconds(delay);
        Explode();
    }
}