using UnityEngine;

public class ObjectPhysics : GenerationsObject
{

    public float AddRange = 0f;
    public float CullingRange = 15f;
    public Vector3 DebrisTarget;


    public bool IsDynamic = false;
    public bool IsReset = false;

    public string Type = "ghz_obj_tn1_purplerock";
    public int WrappedObjectID;

    public override void OnValidate()
    {

    }
}