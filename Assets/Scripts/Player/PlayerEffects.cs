using System.Collections;
using UnityEngine;

public class PlayerEffects : MonoBehaviour
{

    public GameObject grindSparks;
    public GameObject spinBall;
    public GameObject boost;
    public TubeTrailRenderer tubeTrail;
    public GameObject stompDown;
    public GameObject stompUpPrefab;
    public GameObject stompLand;
    public Transform dashBall;
    public GameObject playerMesh;
    public ParticleSystem smoke;
    public ParticleSystem waterEnter;
    public ParticleSystem waterExit;
    GroundInfo groundInfo;
    public ParticleSystem landing;
    public ParticleSystem boostWave;
    public ParticleSystem waterRun;

    private Player player;
    public Texture2D stone, dirt, grass, metal, water, snow;

    public Material smokeMaterial;

    Vector3 dashBallSizeNormal = new Vector3(0.9f, 0.9f, 0.9f);
    Vector3 dashBallSizeFast = new Vector3(0.9f, 0.7f, 0.7f);
    float dashBallScaleRate;

    public ParticleSystem s1, s2;

    public ParticleSystem wave;

    public Animator emeraldAnimator;

    bool waved;

    bool stomp;

    public float lastStateTime;

    public GameObject underwaterBubble;

    public GameObject snowBoard;

    public SkinnedMeshRenderer playerMeshRenderer;
    public float damageTakeBlinkInterval = 0.1f;

    // Use this for initialization
    void Start()
    {
        s1.Stop();
        s2.Stop();
        grindSparks.SetActive(false);
        lastStateTime = Time.time;
        player = GetComponent<Player>();
    }

    void StateChangeToSuperSonicStart()
    {
        emeraldAnimator.gameObject.SetActive(true);
        emeraldAnimator.SetTrigger("Start");
    }

    void StateSnowBoardStart()
    {
        snowBoard.SetActive(true);
    }

    void StateSnowBoardEnd()
    {
        if (player.isSnowboarding == false)
        {
            snowBoard.SetActive(false);
        }
    }
    private void Update()
    {
        underwaterBubble.SetActive(player.underwater);

        if (player.groundInfo.grounded && player.groundInfo.groundHit.collider.sharedMaterial)
        {
            string materialName = player.groundInfo.groundHit.collider.sharedMaterial.name;

            if (materialName.Contains("Stone"))
            {
                smokeMaterial.SetTexture("_MainTex", stone);
            }
            else if (materialName.Contains("Grass"))
            {
                smokeMaterial.SetTexture("_MainTex", grass);
            }
            else if (materialName.Contains("Dirt"))
            {
                smokeMaterial.SetTexture("_MainTex", dirt);
            }
            else if (materialName.Contains("Metal"))
            {
                smokeMaterial.SetTexture("_MainTex", metal);
            }
            else if (materialName.Contains("Snow"))
            {
                smokeMaterial.SetTexture("_MainTex", snow);
            }
        }
        else
        {
            smokeMaterial.SetTexture("_MainTex", stone);
        }

        if (player.groundInfo.grounded && !player.underwater)
        {
            if (player.groundInfo.groundHit.collider.sharedMaterial && player.groundInfo.groundHit.collider.sharedMaterial.name != "Water")
            {
                if (smoke.isStopped)
                {
                    smoke.Play();
                }
            }
        }
        else
        {
            smoke.Stop();
        }

        dashBall.localScale = dashBallSizeFast;// Vector3.Lerp(dashBallSizeNormal, dashBallSizeFast, player.velocity * 3 * Time.deltaTime);

        //if (Player.boost)
        //{
        //    Instantiate(wave, transform.position, transform.rotation);
        //}

        boost.SetActive(player.isBoosting);
        if (player.rigidbody.velocity.magnitude > 1)
        {
            tubeTrail.transform.forward = player.rigidbody.velocity.normalized;
        }

        if (stomp)
        {
            s1.Play();
            s2.Play();
        }
        else
        {
            s1.Stop();
            s1.Clear();
            s2.Stop();
        }

    }

    void StateBoostStart()
    {
        boostWave.Play();
    }

    void StateBoostEnd()
    {

    }

    void StateAirboostStart()
    {
        boostWave.Play();
    }

    private void StateSpindashStart()
    {
        //player.mesh.gameObject.SetActive(false);
        dashBall.gameObject.SetActive(true);
    }

    private void StateSpindashEnd()
    {
        //player.mesh.gameObject.SetActive(true);
        dashBall.gameObject.SetActive(false);
    }

    void StateGrindStart()
    {
        grindSparks.SetActive(true);
    }

    void StateGrindEnd()
    {
        grindSparks.SetActive(false);
    }

    void StateSnowBoardGrindStart()
    {
        StateGrindStart();
    }

    void StateSnowBoardGrindEnd()
    {
        StateGrindEnd();
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Water"))
        {
            waterRun.Play();
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Water"))
        {
            waterRun.Stop();
        }
    }
    void Land()
    {
        if (!player.underwater)
        {
            landing.Play();
        }

    }

    void StateBallStart()
    {
        spinBall.SetActive(true);
    }

    void StateBallEnd()
    {
        spinBall.SetActive(false);
    }

    void StateHomingStart()
    {
        tubeTrail.emit = true;
    }

    void StateHomingEnd()
    {
        tubeTrail.emit = false;
    }

    void StateStompStart()
    {
        tubeTrail.emit = true;

        stomp = true;
    }

    void StateStompEnd()
    {
        lastStateTime = Time.time;
        tubeTrail.emit = false;
        stomp = false;
        stompLand.GetComponent<ParticleSystem>().Play();
    }

    void StateDashPanelStart()
    {
        dashBall.gameObject.SetActive(true);
        playerMesh.gameObject.SetActive(false);
    }

    void StateDashPanelEnd()
    {
        dashBall.gameObject.SetActive(false);
        playerMesh.gameObject.SetActive(true);
    }

    private void StateHurtStart()
    {
        StartCoroutine(BlinkObject(playerMesh, damageTakeBlinkInterval, player.ignoreDamageTime));
    }

    IEnumerator BlinkObject(GameObject target, float blinkInterval, float waitTime)
    {
        float endTime = Time.time + waitTime;
        do
        {
            target.SetActive(false);
            yield return new WaitForSeconds(blinkInterval);
            target.gameObject.SetActive(true);
            yield return new WaitForSeconds(blinkInterval);
        }
        while (Time.time < endTime);
    }
}
