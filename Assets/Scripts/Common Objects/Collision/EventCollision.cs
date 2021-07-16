using UnityEngine;

public class EventCollision : GenerationsObject
{
    public float Collision_Height = 14f;
    public float Collision_Length = 6f;
    public float Collision_Width = 15f;
    public float DefaultStatus = 0f;
    public float Durability = 0f;
    public float Event0 = 0f;
    public float Event1 = 0f;
    public float Event2 = 0f;
    public float Event3 = 0f;
    public float Shape_Type = 0f;
    public int TargetList3;
    public float Timer0 = 0f;
    public float Timer1 = 0f;
    public float Timer2 = 0f;
    public float Timer3 = 0f;
    public int Trigger;
    public float TriggerType = 0f;

    public override void OnValidate()
    {
        if (!gameObject.GetComponent<BoxCollider>())
        {
            gameObject.AddComponent<BoxCollider>();
        }

        gameObject.GetComponent<BoxCollider>().size = new Vector3(Collision_Width, Collision_Height, Collision_Length);
    }

    public override void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(GameTags.playerTag))
        {
            Activate();
        }
    }
}