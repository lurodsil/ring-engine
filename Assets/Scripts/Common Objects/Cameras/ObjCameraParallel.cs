using UnityEngine;

public class ObjCameraParallel : GenerationsObject
{
    public float Distance = 12f;
    public float Ease_Time_Enter = 0f;
    public float Ease_Time_Leave = 0f;
    public float Fovy = 45f;
    public float Pitch = 22f;
    public float Yaw = -25f;
    public float ZRot = 0f;
    public float TargetOffset_Front = 0.5f;
    public float TargetOffset_Right = 0f;
    public float TargetOffset_Up = 0f;
    public bool IsCameraView = false;
    public bool IsCollision = false;
    public bool IsControllable = false;
    public float OffsetPitch = 0f;
    public float OffsetYaw = 0f;
    public int Target;
    public float TargetOffset_Vel = 0.5f;
    public Vector3 TargetPositionFix;
    public float Target_Type = 0f;
    public float VelOffsetXYZ = 0f;

    float startTime;
    public Transform target;
    private float sensitivity;
    Vector3 targetOffsetFinal;
    private new Camera camera;
    float lastStateTime;
    Vector3 offset;
    Quaternion rotation;
    Vector3 targetOffset;



    void Start()
    {
        camera = Camera.main;
        rotation = camera.transform.rotation;
        targetOffset = new Vector3(TargetOffset_Right, TargetOffset_Up, TargetOffset_Front);
    }

    void LateUpdate()
    {
        try
        {
            if (!target)
            {
                target = MainCamera.instance.target;
            }
            else
            {
                try
                {
                    if (CameraManager.activeCamera == gameObject)
                    {
                        offset.z = Mathf.Lerp(offset.z, Distance, (Time.time - lastStateTime) / Ease_Time_Enter);

                        rotation = Quaternion.Lerp(rotation, transform.rotation, (Time.time - lastStateTime) / Ease_Time_Enter);

                        camera.transform.position = target.transform.position - (rotation * offset);

                        camera.transform.LookAt(CameraTarget.instance.subTarget);

                        Camera.main.fieldOfView = Fovy;

                        CameraTarget.instance.offset = targetOffset;
                    }
                    else
                    {
                        lastStateTime = Time.time;
                        offset.z = Vector3.Distance(camera.transform.position, target.position);
                        rotation = camera.transform.rotation;
                    }
                }
                catch
                {
                    lastStateTime = Time.time;
                    offset.z = Vector3.Distance(camera.transform.position, target.position);
                    rotation = camera.transform.rotation;
                }
            }
        }
        catch
        {

        }
    }

    void EaseTimeEnter(float ease)
    {
        Ease_Time_Enter = ease;
    }

    void EaseTimeLeave(float ease)
    {
        Ease_Time_Leave = ease;
    }
}