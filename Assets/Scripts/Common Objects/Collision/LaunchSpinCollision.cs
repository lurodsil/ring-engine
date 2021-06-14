using UnityEngine;

public class LaunchSpinCollision : GenerationsObject
{

    public float Depth = 1f;

    public float Height = 1.56f;
    public float IgnoreInputSecond = 2f;

    public float LaunchType = 1f;

    public float Velocity = 55f;
    public float Width = 1f;

    public override void OnValidate()
    {
        if (!gameObject.GetComponent<BoxCollider>())
        {
            gameObject.AddComponent<BoxCollider>();
        }

        gameObject.GetComponent<BoxCollider>().size = new Vector3(Width, Height, Depth);
    }
}