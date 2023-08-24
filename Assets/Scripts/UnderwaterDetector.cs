using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnderwaterDetector : MonoBehaviour
{
   
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Underwater")) {
            GameManager.instance.underwaterManager.UnderwaterStart();
        }

    }

    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Underwater"))
        {
            GameManager.instance.underwaterManager.UnderwaterEnd();
        }
    }
}
