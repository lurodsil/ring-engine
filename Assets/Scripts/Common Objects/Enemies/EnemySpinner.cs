using UnityEngine;

public class EnemySpinner : GenerationsObject
{

    public float AppearPattern = 0f;
    public Vector3 AppearPoint;
    public float AppearTime = 3f;


    public bool IsLookPlayer = true;
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