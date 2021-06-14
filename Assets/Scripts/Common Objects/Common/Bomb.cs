using System.Collections;
using UnityEngine;

public class Bomb : DamageObject
{
    public float BlastPower = 15f;
    public float ThresholdStumble = 30f;
    public float timeToExplode = -1;

    public GameObject explosion;
    public GameObject waterSplash;

    public bool isOnWater = false;

    private void Start()
    {
        if (timeToExplode > 0)
        {
            Explode(timeToExplode);
        }
    }

    public void Explode()
    {
        Destroy(gameObject);

        Instantiate(explosion, transform.position, transform.rotation);

        if (isOnWater)
        {
            Instantiate(waterSplash, transform.position + new Vector3(0, -0.5f, 0), transform.rotation);
        }
    }

    private void Explode(float delay)
    {
        StartCoroutine(DestroyDelayed(delay));
    }

    private IEnumerator DestroyDelayed(float delay)
    {
        yield return new WaitForSeconds(delay);
        Explode();        
    }
}