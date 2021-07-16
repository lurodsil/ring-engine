using UnityEngine;

public class ObjCameraVertical : GenerationsObject
{
    public float Distance = 8f;
    public float Ease_Time_Enter = 0f;
    public float Ease_Time_Leave = 0f;
    public float Fovy = 45f;
    public bool IsCameraView = false;
    public bool IsCollision = true;
    public bool IsControllable = false;
    public int Target;
    public float TargetOffset_Front = 0f;
    public float TargetOffset_Right = 0f;
    public float TargetOffset_Up = 0.5f;
    public float TargetOffset_Vel = 0f;
    public Vector3 TargetPositionFix;
    public float Target_Type = 0f;
    public float VelOffsetXYZ = 0f;
    public float ZRot = 0f;

    private Transform cameraTarget;
    new private Camera camera;
    private float startTime;
    private float sensitivity;
    Vector3 offset;

    public override void OnValidate()
    {

    }

    void Start()
    {
        cameraTarget = GameObject.FindGameObjectWithTag("Player").transform;
        camera = Camera.main;
    }

    void LateUpdate()
    {

            if (CameraManager.activeCamera == gameObject)
            {
                sensitivity = 1;

                offset.x = TargetOffset_Right;

                offset.y = -TargetOffset_Up;

                offset.z = -TargetOffset_Front;

                Vector3 cameraTargetPosition = cameraTarget.position + offset;

                Vector3 direction = (transform.position - cameraTarget.position).normalized;

                Vector3 targetPosition = cameraTargetPosition - (direction * Distance);

                camera.transform.position = Vector3.Lerp(camera.transform.position, targetPosition, sensitivity);

                camera.transform.LookAt(transform);

                camera.fieldOfView = Mathf.Lerp(camera.fieldOfView, Fovy, sensitivity);
            }
            else
            {
                startTime = Time.time;

                sensitivity = 0;
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