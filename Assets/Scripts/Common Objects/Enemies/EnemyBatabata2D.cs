using UnityEngine;

public class EnemyBatabata2D : GenerationsObject
{

    public float ActionRange = 100f;
    public float AttackRange = 0f;

    public bool IsAimTarget = false;
    public bool IsArrivalEffect = false;

    public bool IsDamageFromOnlyPlayer = false;
    public bool IsPlayFindMotion = true;
    public bool IsReverse = false;
    public bool IsUseZOffset = true;
    public float LaunchSpeed = 15f;
    public float SideMoveSpeed = 5f;
    public Vector3 Target;
    public float WaitTime = 0f;
    public float ZBackOffset = 10f;

    public override void OnValidate()
    {

    }
}