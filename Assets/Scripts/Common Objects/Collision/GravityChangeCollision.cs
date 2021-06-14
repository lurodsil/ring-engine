using UnityEngine;

public class GravityChangeCollision : GenerationsObject
{

    public float Collision_Height = 10f;
    public float Collision_Length = 20f;
    public float Collision_Width = 10f;
    public float DefaultStatus = 0f;
    public float EnteringLimitTime = 3f;
    public float Gravity = 32.5f;



    public float Shape_Type = 0f;

    public override void OnValidate()
    {
        if (!gameObject.GetComponent<BoxCollider>())
        {
            gameObject.AddComponent<BoxCollider>();
        }

        gameObject.GetComponent<BoxCollider>().size = new Vector3(Collision_Width, Collision_Height, Collision_Length);
    }
}