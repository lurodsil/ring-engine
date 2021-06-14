using UnityEngine;

public class ChangePathCollision : GenerationsObject
{
    public float Collision_Height = 10f;
    public float Collision_Length = 10f;
    public float Collision_Width = 10f;
    public float DefaultStatus = 0f;
    public float Shape_Type = 0f;
    public Vector3 TargetDirection;
    public float Type = 0f;

    public DualBezierSpline path;

    public override void OnValidate()
    {
        //if (!gameObject.GetComponent<BoxCollider>())
        //{
        //    gameObject.AddComponent<BoxCollider>();
        //}

        //gameObject.GetComponent<BoxCollider>().size = new Vector3(Collision_Width, Collision_Height, Collision_Length);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(GameTags.playerTag))
        {
            //Sonic.instance.dualBezierSpline = path;
        }
    }
}