using UnityEngine;

public class ObjCameraPoint : GenerationsObject
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

    public override void OnValidate()
    {

    }

    Vector3 targetFinalPosition;
    private float adaptationSpeed;
    Vector3 offset;
    public Transform cameraTarget;
    new Camera camera;
    float lastStateTime;
    Quaternion rotation;

    void Start()
    {
        camera = Camera.main;
        rotation = camera.transform.rotation;
    }

    void LateUpdate()
    {
        try
        {
            if (!target)
                target = MainCamera.instance.target;

            try
            {
                if (CameraManager.activeCamera == gameObject)
                {
                    camera.transform.LookAt(transform);

                    offset.z = Mathf.Lerp(offset.z, Distance, (Time.time - lastStateTime) / Ease_Time_Enter);

                    rotation = Quaternion.Lerp(rotation, camera.transform.rotation, (Time.time - lastStateTime) / Ease_Time_Enter);

                    camera.transform.position = (target.transform.position + new Vector3(0,TargetOffset_Up, 0)) - (rotation * offset);

                    camera.transform.LookAt(transform);

                    Camera.main.fieldOfView = Fovy;
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