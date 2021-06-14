public class JumpSelector : GenerationsObject
{

    public float DownShotForce = 10f;
    public float DownShotOutOfControl = 0.3f;
    public float FrontJumpForce = 25f;
    public float FrontJumpOutOfControl = 0.3f;

    public float InputTime = 1f;
    public bool IsDownShot = false;
    public bool IsPathChange = false;
    public bool IsQuestion = false;
    public float SuccessButton = 2f;
    public float UpJumpForce = 21f;
    public float UpJumpOutOfControl = 0f;
    public float UpJumpPitch = 0f;

    public void SetupObject()
    {

    }
}