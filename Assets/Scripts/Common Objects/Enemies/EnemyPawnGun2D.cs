using UnityEngine;

public class EnemyPawnGun2D : GenerationsObject
{

    public float ActionRange = 20f;
    public float AttackMoveSpeed = 1f;
    public float AttackNum = 1f;
    public float AttackRange = 15f;
    public float BulletLifeTime = 2f;
    public float BulletNum = 1f;
    public float BulletSpeed = 20f;
    public float ChargeTime = 0.7f;

    public bool IsAimTarget = false;
    public bool IsArrivalEffect = true;

    public bool IsDamageFromOnlyPlayer = false;
    public bool IsJoy = true;
    public bool IsPlayFindMotion = false;
    public float MoveSearchTime = 3f;
    public float MoveSpeed = 1f;
    public float SearchType = 0f;
    public float ShotInterval = 0.2f;
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