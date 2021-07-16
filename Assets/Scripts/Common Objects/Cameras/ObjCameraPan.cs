using UnityEngine;

public class ObjCameraPan : GenerationsObject
{
    public float CameraPositionMode = 1f;
    public float Distance = 10f;
    public float Ease_Time_Enter = 0f;
    public float Ease_Time_Leave = 0f;
    public float FaceType = 0f;
    public float Fovy = 45f;
    public bool IsCameraView = false;
    public bool IsCollision = false;
    public bool IsControllable = false;
    public float OffsetPitch = 0f;
    public float OffsetYaw = 0f;
    public float Radius = 1f;
    public int Target;
    public float TargetOffset_Front = 0f;
    public float TargetOffset_Right = 0f;
    public float TargetOffset_Up = 0f;
    public float TargetOffset_Vel = 0f;
    public Vector3 TargetPositionFix;
    public float Target_Type = 0f;
    public float VelOffsetXYZ = 0f;
    public float ZRot = 0f;

    float startTime;
    public Transform target;
    private float sensitivity;
    Vector3 targetOffsetFinal;
    private new Camera camera;
    float lastStateTime;
    Vector3 offset;
    Quaternion rotation;
    Vector3 targetOffset;

    public override void OnValidate()
    {

    }

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

                        Vector3 direction = (target.transform.position - transform.position).normalized;

                        camera.transform.position = transform.position;// target.transform.position - (direction * Distance);
                            
                        camera.transform.LookAt(target);

                        Camera.main.fieldOfView = Fovy;

                        CameraTarget.instance.offset = targetOffset;
                    }
                    else
                    {
                        lastStateTime = Time.time;
                        offset.z = Vector3.Distance(camera.transform.position, target.position);
                    }
                }
                catch
                {
                    lastStateTime = Time.time;
                    offset.z = Vector3.Distance(camera.transform.position, target.position);
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