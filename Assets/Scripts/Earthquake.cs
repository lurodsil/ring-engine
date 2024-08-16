using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Earthquake : CommonActivableStatelessObject
{
    private void Start()
    {
        OnBecomeActive.AddListener(StartEarthquake);
    }

    public void StartEarthquake()
    {        
        MainCamera.Shake(18, 0.6f, 20);
        Input.SetVibration(1, 1, 15);
    }
}

