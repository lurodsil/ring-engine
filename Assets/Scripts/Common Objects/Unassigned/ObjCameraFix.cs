using UnityEngine;

public class ObjCameraFix : GenerationsObject
{

    public float Ease_Time_Enter = 0f;
    public float Ease_Time_Leave = 0f;
    public float Fovy = 30.0002f;

    public bool IsCameraView = false;

    public bool IsCollision = false;
    public bool IsControllable = true;
    public Vector3 TargetPosition;
    public float ZRot = 0f;

    public override void OnValidate()
    {

    }
}