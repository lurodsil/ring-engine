using UnityEngine;

public class EnemyBeeton3D : GenerationsObject
{

    public float ActionRange = 100f;
    public float ActionType = 0f;
    public float AfterMoveLength = 1f;
    public float AttackRange = 20f;
    public float ChargeTime = 0f;
    public float DashSpeed = 5f;

    public float HoveringType = 0f;
    public bool IsAimTarget = false;
    public bool IsArrivalEffect = false;

    public bool IsDamageFromOnlyPlayer = false;
    public bool IsMessageOn = false;
    public bool IsOneShotOnOneWay = false;
    public bool IsPlayFindMotion = true;
    public bool IsRevive = false;
    public bool IsShotEnable = true;
    public float MoveSpeed = 0f;
    public float MoveWidth = 0f;

    public float ReviveTime = 3f;
    public float ShotSpeed = 2f;
    public Vector3 Target;
    public Vector3 TargetPosition;
    public float TurnTime = 1f;
    public float WaitAfterShot = 0f;
    public Vector3 WayPointA;
    public Vector3 WayPointB;

    public override void OnValidate()
    {

    }
}