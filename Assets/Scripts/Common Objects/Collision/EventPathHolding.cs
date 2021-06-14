using UnityEngine;

public class EventPathHolding : GenerationsObject
{
    public float Collision_Height = 13f;
    public float Collision_Length = 13f;
    public float Collision_Width = 10f;
    public float DefaultStatus = 0f;
    public float Shape_Type = 0f;

    public override void OnValidate()
    {
        transform.localScale = new Vector3(Collision_Width, Collision_Height, Collision_Length);
    }
}