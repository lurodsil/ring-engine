using UnityEngine;

public class CameraOffsetReset : GenerationsObject
{
    public float Collision_Height = 22f;
    public float Collision_Width = 24f;
    public float EaseTimeIn = 0.2f;

    public override void OnValidate()
    {
        if (!gameObject.GetComponent<BoxCollider>())
        {
            gameObject.AddComponent<BoxCollider>();
        }

        gameObject.GetComponent<BoxCollider>().size = new Vector3(Collision_Width, Collision_Height, 0.001f);
    }
}