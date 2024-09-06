using System.Collections;
using UnityEngine;

public abstract class CameraCommon : MonoBehaviour
{
    public CameraTarget cameraTarget { get; set; }

    [Range(1, 20)]
    public float distance = 5;
    [Range(1, 50)]
    public float distanceWhenBoosting = 2;
    [Range(20, 90)]
    public float fieldOfView = 45;
    [Range(20, 90)]
    public float fieldOfWhenBoosting = 60;
    [Range(0.01f, 10)]
    public float easeIn = 0.5f;
    [Range(0.01f, 10)]
    public float easeOut = 0.5f;
    [Range(-10, 10)]
    public int priority = 0;
    
    public Vector3 targetOffset = Vector3.zero;

    [HideInInspector]
    public float cameraEnabledTime;
    [HideInInspector]
    public Quaternion rotation;
    [HideInInspector]
    public Vector3 offset;

    public float EaseIn()
    {
        return Mathf.Clamp01(Time.time - cameraEnabledTime) * (1 / (easeIn * 10));    
    }

    private void OnEnable()
    {
        cameraEnabledTime = Time.time;
        cameraTarget = MainCamera.Target;
        rotation = MainCamera.lastRotation;
        offset.z = Vector3.Distance(MainCamera.Position, cameraTarget.position);
        cameraTarget.offset = (cameraTarget.lookAt.position - cameraTarget.position) * 1.025f;
    }
}