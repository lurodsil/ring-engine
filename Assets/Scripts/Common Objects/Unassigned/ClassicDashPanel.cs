public class ClassicDashPanel : GenerationsObject
{



    public bool IsChangeCameraWhenChangePath = false;
    public bool IsChangePath = false;
    public bool IsConstantStartVelocity = true;
    public bool IsInvisible = false;
    public bool IsTo3D = false;
    public bool IsUseDelayCamera = true;
    public float OutOfControl = 0.25f;
    public float Speed = 35f;
    public float SpeedMax = 60f;
    public float SpeedMin = 30f;

    public override void OnValidate()
    {

    }
}