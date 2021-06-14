using UnityEngine;

public class WallWalkEnableCollision : GenerationsObject
{

    public float Collision_Height = 10f;
    public float Collision_Length = 10f;
    public float Collision_Width = 10f;
    public float DefaultStatus = 0f;

    public float Shape_Type = 0f;
    public bool m_IsEnableWallWalk = true;

    public override void OnValidate()
    {
        if (!gameObject.GetComponent<BoxCollider>())
        {
            gameObject.AddComponent<BoxCollider>();
        }

        gameObject.GetComponent<BoxCollider>().size = new Vector3(Collision_Width, Collision_Height, Collision_Length);
    }
}