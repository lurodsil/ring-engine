public class Balloon : GenerationsObject
{
    public float BalloonColor = 0;
    public float Dimension = 0;
    public float GroundOffset = 0;

    public bool IsDefaultPositionRecover = true;
    public bool IsGroup = false;

    public float ReviveTime = 3;
    public float SpeedMax = 20;
    public float SpeedMin = 10;
    public float UpSpeed = 10;

    public override void OnValidate()
    {

    }
}
