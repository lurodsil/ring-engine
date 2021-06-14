using UnityEngine;

public class ObjCameraObjectLook : GenerationsObject
{
    public float Distance = 5f;
    public float Ease_Time_Enter = 0f;
    public float Ease_Time_Leave = 0f;
    public float Fovy = 50.0999f;
    public bool IsCameraView = false;
    public bool IsCollision = false;
    public bool IsControllable = false;
    public int Target;
    public int TargetObject;
    public float TargetOffset_Front = 0f;
    public float TargetOffset_Right = 0f;
    public float TargetOffset_Up = 0f;
    public float TargetOffset_Vel = 0f;
    public float TargetOffset_WorldX = 0f;
    public float TargetOffset_WorldY = 6.1f;
    public float TargetOffset_WorldZ = 0f;
    public Vector3 TargetPositionFix;
    public float Target_Type = 0f;
    public float VelOffsetXYZ = 0f;
    public float ZRot = 0f;

    public override void OnValidate()
    {

    }
}