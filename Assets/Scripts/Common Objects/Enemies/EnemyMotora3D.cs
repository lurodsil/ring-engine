using UnityEngine;

public class EnemyMotora3D : Enemy
{
    [Header("Generations Properties")]
    public float ActionRange = 100f;
    public float AttackRange = 25f;
    public float ChargeTime = 2f;
    public float CliffHeight = 0.3f;
    public float DashSpeed = 4.5f;
    public float DashSpeedType = 2f;

    public bool IsAimTarget = false;
    public bool IsArrivalEffect = false;

    public bool IsDamageFromOnlyPlayer = true;
    public bool IsEnableAttack = false;
    public bool IsPathMove = false;
    public bool IsPlayFindMotion = true;
    public float LookAroundTime = 1.6f;
    public float MoveSpeed = 0.5f;
    public float MoveSpeedType = 0f;

    public float ReboundSpeed = 12f;
    public float SearchType = 0f;
    public Vector3 Target;
    public float TargetLostTime = 3f;
    public float TerrainCheckHeight = 1f;

    public override void OnValidate()
    {

    }
}