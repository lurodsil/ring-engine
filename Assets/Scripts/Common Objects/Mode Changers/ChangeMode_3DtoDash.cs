using UnityEngine;

public class ChangeMode_3DtoDash : GenerationsObject
{
    public float Collision_Height = 48f;
    public float Collision_Width = 15f;
    public Vector3 TargetDirection;
    public float Template = 0f;
    public float m_CurveCorrectionForce = 0f;
    public bool m_IsChangeCamera = true;
    public bool m_IsEnableFromBack = true;
    public bool m_IsEnableFromFront = true;
    public bool m_IsLimitEdge = true;
    public bool m_IsReverseCameraEnable = false;
    public float m_PathCorrectionForce = 0.5f;
    public BezierPath bezierPath;

    public override void OnValidate()
    {
        transform.localScale = new Vector3(Collision_Width, Collision_Height, 0.5f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(GameTags.playerTag))
        {
            player = other.GetComponent<Player>();
            if (player.pathType != BezierPathType.Dash)
            {
                player.bezierPath = bezierPath;
                player.pathType = BezierPathType.Dash;
            }
            else
            {
                player.bezierPath = null;
                player.pathType = BezierPathType.None;
            }
        }
    }
}