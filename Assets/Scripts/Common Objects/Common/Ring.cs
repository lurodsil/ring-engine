using UnityEngine;

public class Ring : MonoBehaviour
{
    public bool InitDisp = false;
    public bool IsLightSpeedDashTarget = false;
    public bool IsReset = false;

    public float ResetTime = 0f;
    public float TreasureSearchHideType = 0f;

    public float maxSpeed = 100;
    public float magneticForce = 50;

    public ParticleSystem getRing;
    public ParticleSystem lightSpeedDash;

    private bool folowPlayer;
    private float speed = 30;
    private GameObject itemCollision;

    private void OnEnable()
    {
        lightSpeedDash.gameObject.SetActive(IsLightSpeedDashTarget);

        gameObject.tag = IsLightSpeedDashTarget ? "LightSpeedDashRing" : "Untagged";
    }

    private void Update()
    {
        if (folowPlayer)
        {
            speed = Mathf.MoveTowards(speed, maxSpeed, magneticForce * Time.deltaTime);

            transform.position = Vector3.MoveTowards(transform.position, itemCollision.transform.position + itemCollision.transform.up * 0.5f, speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(GameTags.playerTag))
        {
            other.GetComponent<Player>().ringEnergy += 2;
            Instantiate(getRing, transform.position, Quaternion.identity);
            Destroy(gameObject);
            EventManager.UpdateRingAmount(1);
            return;
        }

        if (!folowPlayer && !IsLightSpeedDashTarget)
        {
            if (other.name == "ItemCollision")
            {
                itemCollision = other.gameObject;
                folowPlayer = true;
            }
        }
    }
}