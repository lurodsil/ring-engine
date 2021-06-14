using UnityEngine;

public class EnemyPawnPla2D : GenerationsObject
{

    public float ActionRange = 40f;
    public float AttackMoveSpeed = 0f;
    public float AttackRange = 3.5f;
    public float AttackType = 0f;
    public float ChargeTime = 0.5f;
    public float FarAttackRange = 20f;
    public float FirstState = 0f;

    public bool IsAimTarget = false;
    public bool IsArrivalEffect = true;

    public bool IsDamageFromOnlyPlayer = false;
    public bool IsNoWait = false;
    public bool IsPlayFindMotion = true;
    public float MoveSearchTime = 0f;
    public float MoveSpeed = 0f;
    public float PickChargeTime = 1f;
    public float PickDistance = 4f;
    public float PickSwing = 0f;
    public float PickThrowTime = 2.5f;

    public float SearchType = 0f;
    public Vector3 Target;
    public float WaitTime = 3f;
    public Vector3 WayPointA;
    public Vector3 WayPointB;
    public float fallGravRate = 1f;
    public float fallSpeed = 5f;
    public bool isAttackMove = false;
    public bool isFallDown = true;

    public override void OnValidate()
    {

    }
}