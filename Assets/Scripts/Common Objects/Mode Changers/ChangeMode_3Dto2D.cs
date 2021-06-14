using UnityEngine;

public class ChangeMode_3Dto2D : GenerationsObject
{
    public float Collision_Height = 40f;
    public float Collision_Width = 25f;
    public Vector3 TargetDirection;
    public bool m_IsAutoChange2DPath = true;
    public bool m_IsChangeCamera = true;
    public bool m_IsEnableFromBack = true;
    public bool m_IsEnableFromFront = true;
    public bool m_IsPadCorrect = true;
    public float m_PathEaseTime = 0.5f;
    public BezierPath bezierPath;

    public override void OnValidate()
    {
        transform.localScale = new Vector3(Collision_Width, Collision_Height, 0.5f);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(GameTags.playerTag))
        {
            player = other.GetComponent<Player>();
            if (player.pathType != BezierPathType.SideView)
            {
                player.bezierPath = bezierPath;
                player.pathType = BezierPathType.SideView;
            }
            else
            {
                player.bezierPath = null;
                player.pathType = BezierPathType.None;
            }
        }
    }

    public void OnDrawGizmos()
    {
        Gizmos.DrawSphere(TargetDirection, 0.3f);
    }
}