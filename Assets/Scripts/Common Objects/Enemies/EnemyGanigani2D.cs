using UnityEngine;

public class EnemyGanigani2D : GenerationsObject
{

    public float ActionRange = 100f;
    public float AttackRange = 10f;
    public float ChargeTime = 1f;
    public float DistanceMissile = 10f;
    public float DistanceStepMove = 3f;

    public bool IsAimTarget = false;
    public bool IsArrivalEffect = false;

    public bool IsChargeInPose = false;
    public bool IsContinueAttack = false;
    public bool IsDamageFromOnlyPlayer = false;
    public bool IsEnableAttack = true;
    public bool IsPlayFindMotion = true;
    public bool IsSimpleAttack = false;
    public bool IsTurnOver = false;
    public float MoveSpeed = 0.5f;
    public float SearchType = 0f;
    public float SeekSpanTime = 5f;
    public float SpeedMissile = 5f;
    public Vector3 Target;
    public float TargetLostTime = 1f;
    public float TargetLostWaitTime = 0f;
    public float TurnTime = 1f;
    public Vector3 WayPointA;
    public Vector3 WayPointB;

    public override void OnValidate()
    {

    }
}