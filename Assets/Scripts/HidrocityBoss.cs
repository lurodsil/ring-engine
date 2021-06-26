using UnityEngine;

public class HidrocityBoss : GenerationsObject
{

    public float force = 10;
    public ParticleSystem waterSwirl;
    public Transform targetPos;

    public bool working;
    private StateMachine stateMachine = new StateMachine();
    new Rigidbody rigidbody;

    public BezierPath path;

    public float vel;
    public float attractForce;

    public GameObject bomb;
    public Transform bombOrigin;

    private float lastBombTime;

    public float minBombTime = 3;
    public float maxBombTime = 6;

    public float timeOnState = 10;

    public Transform waterSwirlPos;
    public Vector3 waterSwirlPosA;
    public Vector3 waterSwirlPosB;

    public Animator animatorHydro;

    public GameObject target;

    public AudioClip helixStart;
    public AudioClip helixLoop;
    public AudioSource helixSource;

    public GameObject explosionPart;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();

        waterSwirlPosA = waterSwirlPos.position + Vector3.up;
        waterSwirlPosB = waterSwirlPos.position + Vector3.up * 6;
        animatorHydro.speed = 0;

        stateMachine.Initialize(this, StateWait);
    }

    void Update()
    {
        stateMachine.OnUpdate();

        waterSwirl.transform.position = new Vector3(transform.position.x, waterSwirlPos.position.y, transform.position.z);
    }

    void StateWaitStart()
    {

    }
    void StateWait()
    {

    }
    void StateWaitEnd()
    {

    }

    void StateRunAwayStart()
    {

    }
    void StateRunAway()
    {
        rigidbody.velocity = Vector3.up * 3;
    }
    void StateRunAwayEnd()
    {

    }


    void StateMoveStart()
    {
        lastBombTime = Time.time;
        target.SetActive(false);
        timeOnState = Time.time;
        target.SetActive(false);
        player.UpdateTargets();
    }
    void StateMove()
    {
        if (Time.time > stateMachine.lastStateTime + 2)
        {
            BezierKnot bezierKnot = new BezierKnot();

            path.PutOnPath(transform, PutOnPathMode.BinormalOnly, out bezierKnot, out _, attractForce);

            transform.rotation = Quaternion.LookRotation(bezierKnot.tangent);

            rigidbody.AddForce(bezierKnot.tangent * vel, ForceMode.VelocityChange);

            if (Time.time > lastBombTime + Random.Range(minBombTime, maxBombTime))
            {
                Instantiate(bomb, bombOrigin.position, bombOrigin.rotation);

                lastBombTime = Time.time;
            }

            if (Time.time > timeOnState + 15)
            {
                stateMachine.ChangeState(StateWaterSwirlA);
            }
        }


        animatorHydro.speed = Mathf.Lerp(animatorHydro.speed, 0, Time.deltaTime);
    }
    void StateMoveEnd()
    {

    }

    void StateWaterSwirlStart()
    {


        timeOnState = Time.time;
    }
    void StateWaterSwirl()
    {
        transform.position = Vector3.MoveTowards(transform.position, waterSwirlPosB, 3 * Time.deltaTime);

        if (Vector3.Distance(transform.position, waterSwirlPosB) < 0.5f)
        {
            working = true;
            target.SetActive(false);
            player.UpdateTargets();
        }
        if (Time.time > timeOnState + 10)
        {
            stateMachine.ChangeState(StateMove);
        }

        if (Time.time > stateMachine.lastStateTime + 0.5)
        {
            if (!waterSwirl.isPlaying)
            {
                waterSwirl.Play();
            }
        }

        rigidbody.velocity = Vector3.zero;

    }
    void StateWaterSwirlEnd()
    {
        waterSwirl.Stop();
        working = false;
        helixSource.Stop();
    }


    void StateWaterSwirlAStart()
    {

    }
    void StateWaterSwirlA()
    {
        transform.position = Vector3.MoveTowards(transform.position, waterSwirlPosB, 10 * Time.deltaTime);

        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(waterSwirlPosB - transform.position), 3 * Time.deltaTime);

        if (Vector3.Distance(transform.position, waterSwirlPosB) < 0.5f)
        {
            stateMachine.ChangeState(StateWaterSwirlB);
        }
    }
    void StateWaterSwirlAEnd()
    {

    }


    void StateWaterSwirlBStart()
    {
        target.SetActive(true);
        player.UpdateTargets();
        helixSource.clip = helixLoop;
        helixSource.PlayOneShot(helixStart);
        helixSource.PlayDelayed(helixStart.length);
    }
    void StateWaterSwirlB()
    {
        transform.position = Vector3.MoveTowards(transform.position, waterSwirlPosA, 3 * Time.deltaTime);

        transform.rotation = Quaternion.Lerp(transform.rotation, waterSwirlPos.rotation, 3 * Time.deltaTime);

        animatorHydro.speed = Mathf.Lerp(animatorHydro.speed, 1, Time.deltaTime);

        if (Vector3.Distance(transform.position, waterSwirlPosA) < 0.5f)
        {
            stateMachine.ChangeState(StateWaterSwirl);
        }

        rigidbody.velocity = Vector3.zero;
    }
    void StateWaterSwirlBEnd()
    {

    }

    void StateWaterSwirlGetPlayerStart()
    {
        player.rigidbody.useGravity = false;
        player.rigidbody.velocity = Vector3.zero;

    }
    void StateWaterSwirlGetPlayer()
    {
        player.transform.RotateAround(targetPos.position, Vector3.up, 360 * Time.deltaTime);
        player.transform.position = Vector3.MoveTowards(player.transform.position, transform.position + Vector3.up, 3 * Time.deltaTime);

    }
    void StateWaterSwirlGetPlayerEnd()
    {


    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(GameTags.playerTag))
        {
            if (stateMachine.currentStateName == "StateWait")
            {
                stateMachine.ChangeState(StateMove);
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (working)
        {
            if (other.CompareTag(GameTags.playerTag))
            {
                if (Vector3.Distance(transform.position, player.transform.position) > 7)
                {
                    Vector3 dir = targetPos.position - player.transform.position;
                    player.transform.Translate(player.transform.InverseTransformDirection(dir) * force * Time.deltaTime);
                }
                else
                {
                    player.stateMachine.ChangeState(StateWaterSwirlGetPlayer, gameObject);
                }
            }

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(GameTags.playerTag) && working)
        {
            player.velocity *= 0.1f;
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag(GameTags.playerTag) && !player.isAttacking)
        {
            //player = collision.collider.GetComponent<Player>();
            //interactingGameObjects = new GameObject[2] { player.gameObject, gameObject };
            //player.stateMachine.ChangeState(interactingGameObjects, player.StateHurt);

            player.rigidbody.useGravity = true;
            player.rigidbody.velocity = Vector3.zero;

            stateMachine.ChangeState(StateMove);
        }
    }

    public void OnBossDestroy()
    {
        explosionPart.SetActive(false);
        stateMachine.ChangeState(StateRunAway);
        target.SetActive(false);
        player.UpdateTargets();
    }
}
