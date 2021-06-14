using UnityEngine;

public class EventPathHoldingFinish : GenerationsObject
{
    public float Collision_Height = 40f;
    public float Collision_Width = 10f;

    public override void OnValidate()
    {
        if (!gameObject.GetComponent<BoxCollider>())
        {
            gameObject.AddComponent<BoxCollider>();
        }

        gameObject.GetComponent<BoxCollider>().size = new Vector3(Collision_Width, Collision_Height, 0.001f);
    }
}