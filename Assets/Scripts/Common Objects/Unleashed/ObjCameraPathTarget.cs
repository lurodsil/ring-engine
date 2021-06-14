public class ObjCameraPathTarget : GenerationsObject
{

    public float Ease_Time_Enter = 0f;
    public float Ease_Time_Leave = 0f;
    public float EyePathType = 1f;
    public float EyeSpeed = 4f;
    public float Fovy = 45f;

    public bool IsCameraView = false;
    public bool IsCollision = true;
    public bool IsControllable = false;
    public float OffsetOnEyePath = 3.1f;
    public float PanAndTangentBlend = 0.3f;
    public float PathID = 0f;
    public int Target;
    public float TargetOffset_Front = 0f;
    public float TargetOffset_Right = 0f;
    public float TargetOffset_Up = -0.5f;
    public float Target_Type = 0f;
    public float ZRot = 0f;

    public void SetupObject()
    {

    }
}