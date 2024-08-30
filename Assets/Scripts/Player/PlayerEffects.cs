using System.Collections;
using UnityEngine;

public class PlayerEffects : MonoBehaviour
{
    public GameObject grindSparks;
    public GameObject spinBall;
    public GameObject spinBallSuper;
    public GameObject boost;
    public GameObject boostSuper;
    public TubeTrailRenderer tubeTrail;
    public TubeTrailRenderer tubeTrailSuper;
    public GameObject stompDown;
    public GameObject stompDownSuper;
    public Transform dashBall;
    public Transform dashBallSuper;
    public GameObject playerMesh;
    public ParticleSystem smoke;
    public ParticleSystem landing;
    public ParticleSystem boostWave;
    public ParticleSystem waterRun;
    public ParticleSystem superAura;
    public GameObject footprint;

    public Material[] playerMaterials;

    private Player player;
    public Texture2D stone, dirt, grass, metal, water, snow;

    public Material smokeMaterial;

    Vector3 dashBallSizeFast = new Vector3(0.9f, 0.7f, 0.7f);

    public Animator emeraldAnimator;

    public GameObject underwaterBubble;

    public GameObject snowBoard;

    public float damageTakeBlinkInterval = 0.1f;

    private void Awake()
    {
        player = GetComponent<Player>();
    }

    // Use this for initialization
    void Start()
    {
        grindSparks.SetActive(false);
        player = GetComponent<Player>();

        playerMaterials = playerMesh.GetComponentInChildren<SkinnedMeshRenderer>().sharedMaterials;
    }

    void StateChangeToSuperSonicStart()
    {
        emeraldAnimator.gameObject.SetActive(true);
        emeraldAnimator.SetTrigger("Start");
    }

    void StateChangeToSuperSonicEnd()
    {
        emeraldAnimator.gameObject.SetActive(false);
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
        if (player.isSuper)
        {
            if (!superAura.isEmitting)
            {
                superAura.Play();
            }
        }
        else
        {
            if (superAura.isEmitting)
            {
                superAura.Stop();
            }

        }

        foreach (Material m in playerMaterials)
        {
            m.SetFloat("_Super_Blend", player.normalSuperBlend);
        }


        if (player.isBoosting && player.isSuper && player.rigidbody.velocity.magnitude > 0.1f)
        {
            boostSuper.transform.rotation = Quaternion.LookRotation(player.rigidbody.velocity.normalized);
        }

        underwaterBubble.SetActive(player.isUnderwater);

        dashBall.localScale = dashBallSizeFast;
        dashBallSuper.localScale = dashBallSizeFast;

        boost.SetActive(player.isBoosting && !player.isSuper);
        boostSuper.SetActive(player.isBoosting && player.isSuper);

        if (player.rigidbody.velocity.magnitude > 1)
        {
            tubeTrail.transform.forward = player.rigidbody.velocity.normalized;
        }

        try
        {
            if (player.IsGrounded())
            {
                PhysicMaterial physicMaterial = player.GetGroundInformation().collider.sharedMaterial;

                if (physicMaterial == null)
                    return;

                string materialName = physicMaterial.name;

                if (materialName.Contains("Stone"))
                {
                    smokeMaterial.SetTexture("Texture2D_8FEEBB68", stone);
                }
                else if (materialName.Contains("Grass"))
                {
                    smokeMaterial.SetTexture("Texture2D_8FEEBB68", grass);
                }
                else if (materialName.Contains("Dirt"))
                {
                    smokeMaterial.SetTexture("Texture2D_8FEEBB68", dirt);
                }
                else if (materialName.Contains("Metal"))
                {
                    smokeMaterial.SetTexture("Texture2D_8FEEBB68", metal);
                }
                else if (materialName.Contains("Snow"))
                {
                    smokeMaterial.SetTexture("Texture2D_8FEEBB68", snow);
                }
            }
            else
            {
                smokeMaterial.SetTexture("Texture2D_8FEEBB68", stone);
            }
        }
        catch
        {
            smokeMaterial.SetTexture("Texture2D_8FEEBB68", stone);
        }

        try
        {
            if (player.IsGrounded() && !player.isUnderwater)
            {
                if (player.GetGroundInformation().collider.sharedMaterial && player.GetGroundInformation().collider.sharedMaterial.name != "Water")
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
        }
        catch
        {

        }
    }

    public void FootprintL()
    {
        Instantiate(footprint, transform.TransformPoint(-0.12f, 0.02f, 0.2f), transform.rotation);
    }

    public void FootprintR()
    {
        Instantiate(footprint, transform.TransformPoint(0.12f, 0.02f, 0.2f), transform.rotation);
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
        if (player.isSuper)
        {
            dashBallSuper.gameObject.SetActive(true);
        }
        else
        {
            dashBall.gameObject.SetActive(true);
        }
    }

    private void StateSpindashEnd()
    {
        if (player.isSuper)
        {
            dashBallSuper.gameObject.SetActive(false);
        }
        else
        {
            dashBall.gameObject.SetActive(false);
        }
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
        //if (collision.gameObject.CompareTag("Water"))
        //{
        //    waterRun.Play();
        //}
    }

    private void OnCollisionExit(Collision collision)
    {
        //if (collision.gameObject.CompareTag("Water"))
        //{
        //    waterRun.Stop();
        //}
    }

    //Animation Event
    void Land()
    {
        if (!player.isUnderwater)
        {
            Instantiate(landing, player.GetGroundInformation().point, new Quaternion());
        }
    }

    void StateBallStart()
    {
        if (player.isSuper)
        {
            spinBallSuper.SetActive(true);
        }
        else
        {
            spinBall.SetActive(true);
        }
    }

    void StateBallEnd()
    {
        if (player.isSuper)
        {
            spinBallSuper.SetActive(false);
        }
        else
        {
            spinBall.SetActive(false);
        }
    }

    void StateHomingStart()
    {
        if (player.isSuper)
        {
            tubeTrailSuper.emit = true;
        }
        else
        {
            tubeTrail.emit = true;
        }
    }

    void StateHomingEnd()
    {
        if (player.isSuper)
        {
            tubeTrailSuper.emit = false;
        }
        else
        {
            tubeTrail.emit = false;
        }
    }

    void StateStompStart()
    {
        if (player.isSuper)
        {
            tubeTrailSuper.emit = true;
            stompDownSuper.SetActive(true);
        }
        else
        {
            tubeTrail.emit = true;
            stompDown.SetActive(true);
        }
    }

    void StateStompEnd()
    {
        if (player.isSuper)
        {
            tubeTrailSuper.emit = false;
            stompDownSuper.SetActive(false);
        }
        else
        {
            tubeTrail.emit = false;
            stompDown.SetActive(false);
        }
    }

    void StateDashPanelStart()
    {
        if (player.isSuper)
        {
            dashBallSuper.gameObject.SetActive(true);
        }
        else
        {
            dashBall.gameObject.SetActive(true);
        }
        playerMesh.gameObject.SetActive(false);
    }

    void StateDashPanelEnd()
    {
        if (player.isSuper)
        {
            dashBallSuper.gameObject.SetActive(false);
        }
        else
        {
            dashBall.gameObject.SetActive(false);
        }
        playerMesh.gameObject.SetActive(true);
    }

    private void StateHurtStart()
    {
        StartCoroutine(BlinkObject(playerMesh, damageTakeBlinkInterval, player.ignoreDamageTime));
    }

    private void GrindDamage()
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
