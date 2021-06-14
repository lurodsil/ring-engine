public class ClassicJumpBoard : GenerationsObject
{

    public float ClassicJumpAngleOnBoost = 60f;
    public float ClassicJumpAngleOnNormal = 60f;

    public float ImpulseSpeedOnBoost = 41f;
    public float ImpulseSpeedOnNormal = 41f;

    public bool IsTo3D = false;
    public float OutOfControl = 2f;
    public float m_ClassicSpinThreshold = 30f;

    public override void OnValidate()
    {

    }
}