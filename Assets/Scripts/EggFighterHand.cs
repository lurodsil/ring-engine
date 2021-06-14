using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggFighterHand : MonoBehaviour
{
    public GameObject eggFighter;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(GameTags.playerTag))
        {
            other.GetComponent<IDamageable>().TakeDamage(eggFighter);
        }
    }
}
