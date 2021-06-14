public class ObjCameraBlend : GenerationsObject
{

    public float BlendBase = 0f;
    public float BlendSpeed = 3.5f;
    public float BlendType = 0f;
    public float Ease_Time_Enter = 0f;
    public float Ease_Time_Leave = 0f;

    public bool IsCameraView = false;
    public bool IsCollision = true;
    public int Target;
    public float TargetOffset_Front = -3f;
    public float TargetOffset_Right = 0f;
    public float TargetOffset_Up = 0f;
    public float Target_Type = 0f;

    public void SetupObject()
    {

    }
}