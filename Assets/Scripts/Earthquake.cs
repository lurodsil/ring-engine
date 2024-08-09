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
        MainCamera.Shake(18, 1, 20);
        Input.SetVibration(1, 1, 15);
    }
}

