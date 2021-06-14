using UnityEngine;

public class AutorunStartSimpleCollision : GenerationsObject
{
    public float Collision_Height = 200f;
    public float Collision_Width = 50f;
    public float Speed = 40f;
    public float Type = 0f;

    public override void OnValidate()
    {
        if (!gameObject.GetComponent<BoxCollider>())
        {
            gameObject.AddComponent<BoxCollider>();
        }

        gameObject.GetComponent<BoxCollider>().size = new Vector3(Collision_Width, Collision_Height, 0.001f);
    }
}