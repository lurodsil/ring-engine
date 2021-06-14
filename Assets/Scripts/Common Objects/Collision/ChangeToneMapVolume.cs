using UnityEngine;

public class ChangeToneMapVolume : GenerationsObject
{
    public float Collision_Height = 110f;
    public float Collision_Length = 30f;
    public float Collision_Width = 30f;
    public float DefaultStatus = 0f;
    public float EaseTime = 1f;
    public float ID = 0f;
    public float LuminanceHigh = 1.74f;
    public float LuminanceLow = 0.25f;
    public float Shape_Type = 0f;
    public float ToneMapMiddleGray = 0.82f;
    public float ToneMapSimpleScale = 1f;

    public override void OnValidate()
    {
        if (!gameObject.GetComponent<BoxCollider>())
        {
            gameObject.AddComponent<BoxCollider>();
        }

        gameObject.GetComponent<BoxCollider>().size = new Vector3(Collision_Width, Collision_Height, Collision_Length);
    }
}