public class ChangeCamera2D_Begin : GenerationsObject
{

    public float BaseSpacePathPosition = 166.925f;
    public float Collision_Height = 10f;
    public float Collision_Width = 10f;
    public float Distance = 20f;
    public float Ease_Time = 0.5f;

    public float ID = 1f;
    public bool IsBaseSpacePlayer = true;
    public bool IsCameraView = true;
    public bool IsPositionBasePlayer = true;
    public float Rotation_Y = 0f;
    public float Rotation_Z = -0.1314f;
    public float Target_Front_Offset_Bias = 1.8f;
    public float Target_Front_Offset_Max = 4f;
    public float Target_Front_Offset_Speed_Scale = 0.1f;
    public float Target_Up_Offset = 2f;

    public void SetupObject()
    {

    }

    public override void OnValidate()
    {
        base.OnValidate();

        //BoxCollider collider = GetComponent<BoxCollider>();
        //collider.isTrigger = true;
        //collider.size = new Vector3(Collision_Width, Collision_Height, 1);
    }
}