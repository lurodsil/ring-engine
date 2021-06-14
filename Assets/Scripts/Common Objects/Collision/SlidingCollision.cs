using UnityEngine;

public class SlidingCollision : GenerationsObject
{
    public float Depth = 4.9f;
    public float Height = 3f;
    public float Velocity = 10f;
    public float Width = 4.1f;

    public override void OnValidate()
    {
        gameObject.GetComponent<BoxCollider>().isTrigger = true;
        transform.localScale = new Vector3(Width, Height, Depth);
    }
}