using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartAnimationManagerCamera : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        if (!GameManager.instance.firstTimeLoad)
        {
            GetComponent<Animator>().enabled = false;
            GetComponent<MainCamera>().enabled = true;
        }
    }
}
