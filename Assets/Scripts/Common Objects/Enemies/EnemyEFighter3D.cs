using UnityEngine;

public class EnemyEFighter3D : GenerationsObject
{

    public float ActionRange = 100f;
    public float AttackRange = 2f;
    public int BarrelID;
    public int ChaserManagerID;

    public bool IsAimTarget = false;
    public bool IsArrivalEffect = true;

    public bool IsDamageFromOnlyPlayer = true;
    public bool IsPlayFindMotion = true;
    public float SearchType = 1f;
    public Vector3 Target;
    public Vector3 WayPointA;
    public Vector3 WayPointB;
    public float m_AttackMoveSpeedRatio = 1f;
    public float m_ChargeTime = 0.5f;
    public float m_ChaserModeVelocity = 5f;
    public float m_FindMotionType = 1f;
    public bool m_IsAllRangeSearch = false;
    public bool m_IsAttack = true;
    public bool m_IsChaseAfter = false;
    public bool m_IsChaserMode = true;
    public bool m_IsForceSmartTurn = false;
    public bool m_IsPushBarrelMode = false;
    public bool m_IsPushBarrelOnce = false;
    public bool m_IsPushDirRight = true;
    public bool m_IsRestrictMove = false;
    public float m_LostTime = 10f;
    public float m_MoveSpeedRatio = 1f;
    public float m_PushBarrelSpanTime = 2f;
    public float m_SeekSpanTime = 3f;
    public float m_TurnAccel = 4f;
    public float m_WaitTime = 0.3f;

    public override void OnValidate()
    {

    }

    void OnDrawGizmosSelected()
    {
        Gizmos.DrawLine(WayPointA, WayPointB);
    }
}