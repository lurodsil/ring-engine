using UnityEngine;

public class EggmanDoomsday : MonoBehaviour
{
    public BezierPath bezierPath;

    private new Rigidbody rigidbody;
    private AudioSource audioSource;
    public AudioClip rockShock;

    public GameObject missile;

    private GameObject player;
    private float playerInRange;

    public Transform missilePosA, missilePosB;

    GameObject missileA, missileB;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        BezierKnot knot = new BezierKnot();
        bezierPath.PutOnPath(transform, PutOnPathMode.BinormalAndNormal, out knot);

        transform.rotation = Quaternion.LookRotation(knot.tangent, knot.normal);

        rigidbody.velocity = transform.forward * 55;

        if (Vector3.Distance(transform.position, player.transform.position) < 300)
        {
            if (Time.time > playerInRange + 3)
            {
                if (!missileA && !missileB)
                {
                    missileA = Instantiate(missile, missilePosA.position, missilePosA.rotation);
                    missileB = Instantiate(missile, missilePosB.position, missilePosB.rotation);
                }


                playerInRange = Time.time;
            }


        }
        else
        {
            playerInRange = Time.time;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        audioSource.PlayOneShot(rockShock);
    }
}
