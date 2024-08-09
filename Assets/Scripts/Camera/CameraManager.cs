using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    private static CameraManager instance;
    public List<CameraCommon> cameras = new List<CameraCommon>();
    private CameraCommon[] camerasSorted = new CameraCommon[0];

    private void Start()
    {
        if (instance == null) 
        { 
            instance = this; 
        }
    }

    private void Update()
    {
        if(camerasSorted.Length != cameras.Count)
        {
            camerasSorted = cameras.OrderBy(i => i.priority).ToArray();

            for (int i = 0; i < camerasSorted.Length; i++)
            {
                if (i == 0)
                {
                    camerasSorted[i].enabled = true;
                }
                else
                {
                    camerasSorted[i].enabled = false;
                }
            }
        }
    }

    public static void ActivateCamera(CameraCommon camera)
    {
        instance.cameras.Add(camera);
        MainCamera.SetActive(false);
    }

    public static void DeactivateCamera(CameraCommon camera)
    {   
        camera.enabled = false;
        instance.cameras.Remove(camera);
        MainCamera.SetEaseIn(camera.easeOut);        
        if (instance.cameras.Count == 0)
        {
            MainCamera.SetActive(true);
        }
    }

    public static int GetCameraCount()
    {
        return instance.cameras.Count;
    }

    public static void DeactivateAllCameras()
    {
        instance.cameras.Clear();

        for (int i = 0; i < instance.camerasSorted.Length; i++)
        {
            instance.camerasSorted[i].enabled = false;
        }

    }
}