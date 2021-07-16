using UnityEngine;

public class ChangePathCollision : RingEngineObject
{
    public BezierPath path;

    public override void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(GameTags.playerTag))
        {
            player = other.GetComponent<Player>();
            player.sideViewPath = path;
        }
    }
}