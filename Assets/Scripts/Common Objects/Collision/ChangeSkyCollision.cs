using UnityEngine;

public class ChangeSkyCollision : GenerationsObject
{
    public float Collision_Height = 25f;
    public float Collision_Width = 24f;
    public float FollowUpRatioYBack = 0f;
    public float FollowUpRatioYFront = 0.5f;
    public float IntensityBack = 1.3f;
    public float IntensityFront = 1.2f;
    public float ModelTailNumberBack = 0f;
    public float ModelTailNumberFront = 1f;

    public override void OnValidate()
    {
        if (!gameObject.GetComponent<BoxCollider>())
        {
            gameObject.AddComponent<BoxCollider>();
        }

        gameObject.GetComponent<BoxCollider>().size = new Vector3(Collision_Width, Collision_Height, 0.001f);
    }
}