using UnityEngine;

public class ObjCameraPathParallel : GenerationsObject
{
    public float Distance = 18f;
    public float Ease_Time_Enter = 0f;
    public float Ease_Time_Leave = 0f;
    public float Fovy = 45f;
    public float Pitch = 10f;
    public float Yaw = -20f;
    public float ZRot = 0f;
    public float TargetOffset_Front = 0f;
    public float TargetOffset_Right = 0f;
    public float TargetOffset_Up = 0f;
    public bool IsCameraView = true;
    public bool IsCollision = false;
    public bool IsControllable = false;
    public float LerpRatio = 0.5f;
    public float OffsetPitch = 0f;
    public float OffsetYaw = -10f;
    public int Target;
    public float TargetOffset_Vel = 0.5f;
    public Vector3 TargetPositionFix;
    public float Target_Type = 0f;
    public float VelOffsetXYZ = 1f;

    public BezierSpline spline;
    public Transform target;
    public float delay = 3;
    float sensitivity;

    new Camera camera;

    float closestTimeOnSpline;

    public ObjCameraPathTarget objCameraPathTarget;


    float lastStateTime;
    Vector3 offset;
    Quaternion rotation;
    private Vector3 targetOffset;

    public override void OnValidate()
    {
        transform.eulerAngles = new Vector3(Pitch, -Yaw + 180, ZRot);
        objCameraPathTarget = PathTarget(SetObjectID);
    }

    void Start()
    {
        camera = Camera.main;
        rotation = camera.transform.rotation;
        //player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    private ObjCameraPathTarget PathTarget(int id)
    {
        ObjCameraPathTarget[] objCameraPathTargets = FindObjectsOfType<ObjCameraPathTarget>();

        foreach (ObjCameraPathTarget pt in objCameraPathTargets)
        {
            if (pt.SetObjectID == id)
            {
                return pt;
            }
        }

        return null;
    }


    void LateUpdate()
    {
        targetOffset = new Vector3(TargetOffset_Right, TargetOffset_Up, TargetOffset_Front);
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
                    if (GameManager.instance.cameras[0] == gameObject || GameManager.instance.cameras[0] == objCameraPathTarget.gameObject)
                    {
                        BezierKnot bezierKnot = spline.GetKnot(spline.ClosestPointFast(target.position));

                        Vector3 targetPos = Vector3.Lerp(CameraTarget.instance.subTarget.position, bezierKnot.point, objCameraPathTarget.PanAndTangentBlend);

                        CameraTarget.instance.offset = targetOffset;

                        camera.transform.LookAt(targetPos);

                        float playerDotUp = Vector3.Dot(player.transform.up, Vector3.up);

                        Vector3 bezierPointWithPlayerY = new Vector3(bezierKnot.point.x, targetPos.y + 1, bezierKnot.point.z);

                        Vector3 tgpos = Vector3.Lerp(bezierKnot.point, bezierPointWithPlayerY, Mathf.Clamp01(playerDotUp));

                        camera.transform.position = Vector3.Lerp(camera.transform.position, tgpos + (bezierKnot.tangent * objCameraPathTarget.OffsetOnEyePath), (Time.time - lastStateTime) / Ease_Time_Enter);

                        camera.transform.LookAt(targetPos);

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
        }
        catch
        {

        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.TransformPoint(TargetPositionFix), 0.3f);
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