public class ThornSpring : GenerationsObject
{

    public float DebugShotTimeLength = 2f;
    public float DownThornTime = 1f;
    public float FirstSpeed = 25f;

    public bool IsChangeCameraWhenPathChange = true;
    public bool IsPathChange = false;
    public bool IsStartVelocityConstant = true;
    public bool IsWallWalk = false;
    public bool IsYawUpdate = false;
    public float KeepVelocityDistance = 5f;
    public float OutOfControl = 0.25f;
    public float Phase = 0f;
    public float UpThornTime = 2f;

    public void SetupObject()
    {

    }
}