using UnityEngine;

public class LostRing : MonoBehaviour
{

    public GameObject ringLost;
    public float lastStateTime;

    public float dirMultiplier;

    public bool hurt;

    public float radius;

    public float ringSpreadForce = 1000;

    // Use this for initialization
    void Start()
    {
        lastStateTime = Time.time;
    }

    void StateHurtStart()
    {
        LostRings();
    }

    private void GrindDamage()
    {
        LostRings();
    }

    void LostRings()
    {
        int rings = Mathf.Clamp(GameManager.instance.rings, 0, 20);

        if (rings == 0)
            return;

        int ringsToAngle = 360 / rings;

        for (int i = 0; i < rings; i++)
        {
            GameObject newRing = Instantiate(ringLost, transform.position + transform.up * 2, Quaternion.identity);
            Vector3 spreadDirection = Quaternion.Euler(0, i * ringsToAngle, 0) * Vector3.forward;
            newRing.GetComponent<Rigidbody>().AddForce(spreadDirection * (ringSpreadForce * Random.Range(1, 2)), ForceMode.Impulse);
            Destroy(newRing, 10);
        }

        GameManager.instance.rings = 0;
    }
}
