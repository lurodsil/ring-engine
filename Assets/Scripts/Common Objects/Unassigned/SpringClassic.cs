using UnityEngine;

public class SpringClassic : GenerationsObject
{

    public float AimDirection = 0f;
    public float DebugShotTimeLength = 2f;
    public float FirstSpeed = 20f;

    public bool IsBreak = false;

    public bool IsChangeCameraWhenPathChange = false;
    public bool IsHomingAttackEnable = false;
    public bool IsPathChange = false;
    public bool IsSideSet = false;
    public bool IsStartVelocityConstant = true;
    public bool IsWallWalk = false;
    public bool IsYawUpdate = false;
    public float KeepVelocityDistance = 6f;
    public float MotionType = 0f;
    public float OutOfControl = 0.25f;
    public float TreasureSearchHideType = 0f;
    public bool m_IsConstantFrame = false;
    public bool m_IsConstantPosition = true;
    public bool m_IsMonkeyHunting = false;
    public bool m_IsStopBoost = false;
    public bool m_IsTo3D = false;
    public Vector3 m_MonkeyTarget;

    public override void OnValidate()
    {

    }
}