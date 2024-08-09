using UnityEngine;

public class ObjCameraPoint : CameraCommon
{
    public float Distance = 5f;
    public float Ease_Time_Enter = 0f;
    public float Ease_Time_Leave = 0f;
    public float Fovy = 80f;
    public bool IsCameraView = false;
    public bool IsCollision = false;
    public bool IsControllable = false;
    public int Target;
    public float TargetOffset_Front = 1f;
    public float TargetOffset_Right = 0f;
    public float TargetOffset_Up = -1f;
    public float TargetOffset_Vel = 0f;
    public Vector3 TargetPositionFix;
    public float Target_Type = 0f;
    public float VelOffsetXYZ = 0f;
    public float ZRot = 0f;

    Vector3 cameraFinalPosition;
    public Transform target;
    public float delay = 3;
    float sensitivity;

    public void OnValidate()
    {
        enabled = false;
    }

    Vector3 targetFinalPosition;
    private float adaptationSpeed;


    new Camera camera;
    float lastStateTime;


    void Start()
    {
        camera = Camera.main;
        rotation = camera.transform.rotation;
    }

    void LateUpdate()
    {
        camera.transform.LookAt(transform);
        offset.z = Mathf.Lerp(offset.z, Distance, (Time.time - lastStateTime) / Ease_Time_Enter);
        rotation = Quaternion.Lerp(rotation, camera.transform.rotation, (Time.time - lastStateTime) / Ease_Time_Enter);
        camera.transform.position = (target.transform.position + new Vector3(0,TargetOffset_Up, 0)) - (rotation * offset);
        camera.transform.LookAt(transform);
        Camera.main.fieldOfView = Fovy;
        MainCamera.lastRotation = rotation;
    }
}