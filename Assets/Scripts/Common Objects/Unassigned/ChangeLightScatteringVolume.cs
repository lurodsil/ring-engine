public class ChangeLightScatteringVolume : GenerationsObject
{

    public float Collision_Height = 85f;
    public float Collision_Length = 243f;
    public float Collision_Width = 25f;
    public float ColorB = 0.47f;
    public float ColorG = 0.21f;
    public float ColorR = 0.1f;
    public float DefaultStatus = 0f;
    public float Density = 0.5f;
    public float DepthScale = 9.1f;
    public float EaseTime = 1f;
    public float Far = 1370f;


    public bool IsChangeCommon = true;
    public bool IsChangeFog = true;
    public bool IsChangeLightScattering = true;
    public float Mie = 0.101f;
    public float MieP = 0.7f;
    public float Mode = 4f;
    public float Near = 60f;
    public float Rayleigh = 0.125f;
    public float ScatteringScale = 30f;
    public float Shape_Type = 0f;

    public override void OnValidate()
    {

    }
}