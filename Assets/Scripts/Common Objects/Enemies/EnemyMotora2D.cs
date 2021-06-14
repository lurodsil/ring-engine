using UnityEngine;

public class EnemyMotora2D : GenerationsObject
{

    public float ActionRange = 100f;
    public float AttackRange = 10f;
    public float ChargeTime = 1f;
    public float CliffHeight = 0.3f;
    public float DashSpeed = 6f;
    public float DashSpeedType = 3f;

    public bool IsAimTarget = false;
    public bool IsArrivalEffect = false;

    public bool IsDamageFromOnlyPlayer = false;
    public bool IsEnableAttack = true;
    public bool IsPathMove = false;
    public bool IsPlayFindMotion = true;
    public float LookAroundTime = 1.6f;
    public float MoveSpeed = 2f;
    public float MoveSpeedType = 3f;
    public float ReboundSpeed = 12f;
    public float SearchType = 0f;
    public Vector3 Target;
    public float TargetLostTime = 1.5f;
    public float TerrainCheckHeight = 1f;

    public override void OnValidate()
    {

    }
}