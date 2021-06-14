using UnityEngine;

public class EnemyELauncher3D : GenerationsObject
{

    public float ActionRange = 50f;
    public float AttackRange = 50f;
    public float EquipType = 2f;

    public bool IsAimTarget = false;
    public bool IsArrivalEffect = true;

    public bool IsDamageFromOnlyPlayer = false;
    public bool IsPlayFindMotion = true;
    public Vector3 Target;
    public float m_ChargeTime = 1f;
    public bool m_IsFixRotate = false;
    public float m_NearAttackRange = 2f;

    public override void OnValidate()
    {

    }
}