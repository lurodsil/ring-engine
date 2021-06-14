using UnityEngine;

public class EnemySpanner : GenerationsObject
{

    public float AppearPattern = 0f;
    public Vector3 AppearPoint;
    public float AppearTime = 3f;
    public float ElecTime_Exec = 0.4f;
    public float ElecTime_Interval = 1.2f;
    public float ElecTime_Pre = 0.5f;


    public bool IsLookPlayer = true;
    public bool IsWaitElec = false;
    public float MovePattern = 0f;
    public float MoveVel = 0.5f;
    public float RebirthPattern = 0f;
    public Vector3 RebirthPoint;
    public float RebirthTime = 5f;
    public Vector3 WayPointA;
    public Vector3 WayPointB;

    public override void OnValidate()
    {

    }
}