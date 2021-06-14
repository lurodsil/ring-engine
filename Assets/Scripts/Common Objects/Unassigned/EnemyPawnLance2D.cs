using UnityEngine;

public class EnemyPawnLance2D : GenerationsObject
{

    public float ActionRange = 20f;
    public float AttackMoveSpeed = 1f;
    public float AttackRange = 5.5f;
    public float ChargeTime = 0.3f;

    public bool IsAimTarget = false;
    public bool IsArrivalEffect = true;

    public bool IsDamageFromOnlyPlayer = false;
    public bool IsPlayFindMotion = true;
    public float MoveSearchTime = 3f;
    public float MoveSpeed = 1f;
    public float SearchType = 0f;
    public Vector3 Target;
    public float WaitTime = 1f;
    public Vector3 WayPointA;
    public Vector3 WayPointB;
    public float fallGravRate = 1f;
    public float fallSpeed = 5f;
    public bool isAttackMove = true;
    public bool isFallDown = true;

    public override void OnValidate()
    {

    }
}