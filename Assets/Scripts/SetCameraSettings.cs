using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetCameraSettings : MonoBehaviour
{
    public void SetCameraDistance(float distance)
    {
        MainCamera.SetCameraDistance(distance,distance);
    }

}
