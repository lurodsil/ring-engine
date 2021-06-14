using UnityEngine;

public class GeneralFloor : GenerationsObject
{
    public float Amplitude = 1f;
    public float AttachOffsetX = 0f;
    public float AttachOffsetY = 0f;
    public float AttachOffsetZ = 0f;
    public bool BeginEdge = false;
    public float Cycle = 1f;
    public float FallPointIndex = -1f;
    public float FallPointTime = -0.1f;
    public float FallTime = 0f;
    public float FloorSize = 1f;
    public float FloorType = 0f;
    public bool ForceGrid = false;
    public float Gravity = 45f;
    public float InitOffset = 0f;
    public bool IsBreakable = false;
    public bool IsEnableFall = false;
    public bool IsMessageON = false;
    public bool IsRelativePosition = true;
    public bool IsReverse = false;
    public bool IsWallJump = false;
    public Vector3 LightFieldOffset;
    public float ModelInterval = 3f;
    public float ModelNum = 1f;
    public float MoveType = 0f;
    public float MoveTypeGeneral = 0f;
    public float MoveVel = 5f;
    public float OnFloorTime = 5f;
    public float Phase = 0f;
    public float RailDir = 0f;
    public float Ratio = 0f;
    public float ResetTime = 10f;
    public bool StartByNotify = false;
    public bool UsePointFloor = true;
    public bool UseStartSE = false;
    public bool VisibleRail = true;
    public float WaitShakeTime = -0.1f;

    public override void OnValidate()
    {

    }
}