using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public static GameObject activeCamera;

    public static GameObject[] cameras;

    private void Start()
    {
        cameras = new GameObject[10];
    }

    private void Update()
    {
        for(int i = 0; i < cameras.Length; i++)
        {
            if(cameras[i] != null)
            {
                activeCamera = cameras[i];
                break;
            }

            activeCamera = Camera.main.gameObject;
        }
    }
}