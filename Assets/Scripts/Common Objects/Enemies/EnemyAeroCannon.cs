using UnityEngine;

public class EnemyAeroCannon : GenerationsObject
{
    public float ActionRange = 50f;
    public float AttackRange = 30f;

    public bool IsAimTarget = false;
    public bool IsArrivalEffect = true;

    public bool IsDamageFromOnlyPlayer = false;
    public bool IsPlayFindMotion = true;

    public Vector3 Target;
    public float m_ChargeTime = 1f;
    public float m_GapTime = 2f;
    public bool m_Is2DMode = false;
    public bool m_IsAttack = true;
    public bool m_IsFixRotate = false;
    public bool m_IsRebirth = false;
    public bool m_IsShotSpanRotate = false;
    public float m_LostTime = 10f;
    public float m_NumShots = 3f;
    public float m_RebirthTime = 5f;
    public float m_ShotSpanTime = 1.4f;
    public float m_ShotSpeed = 1f;
    public float m_TurnAccel = 4f;

    public GameObject[] breakParts;
    public GameObject explosion;

    public override void OnValidate()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {

        foreach (GameObject part in breakParts)
        {
            Instantiate(part, transform.position, transform.rotation);
        }

        Instantiate(explosion, transform.position, transform.rotation);

        Destroy(gameObject);

    }

    private void Update()
    {

    }

    private void OnDestroy()
    {
        try
        {
            GameObject.FindGameObjectWithTag("Player").SendMessage("UpdateTargets");
        }
        catch
        {

        }

    }
}