using UnityEngine;

public class SpeedDownCollision : GenerationsObject
{
    public float Collision_Height = 50f;
    public float Collision_Length = 100f;
    public float Collision_Width = 105f;
    public float DefaultStatus = 0f;

    public float Shape_Type = 0f;
    public float Speed = 25f;

    public override void OnValidate()
    {
        if (!gameObject.GetComponent<BoxCollider>())
        {
            gameObject.AddComponent<BoxCollider>();
        }

        gameObject.GetComponent<BoxCollider>().size = new Vector3(Collision_Width, Collision_Height, Collision_Length);
    }
}