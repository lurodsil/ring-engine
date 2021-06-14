using UnityEngine;

public class ChangeMode_3DtoForward : GenerationsObject
{
    public float Collision_Height = 35f;
    public float Collision_Width = 10f;
    public Vector3 TargetDirection;
    public float Template = 3f;
    public float m_CurveCorrectionForce = 1f;
    public float m_DashPathSideMoveRate = 0.6f;
    public bool m_IsChangeCamera = true;
    public bool m_IsEnableAirBoost = false;
    public bool m_IsEnableFromBack = true;
    public bool m_IsEnableFromFront = true;
    public bool m_IsGravityControl = false;
    public bool m_IsLimitEdge = false;
    public bool m_IsReverseCameraEnable = false;
    public float m_PathCorrectionForce = 1f;
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
            if (player.pathType != BezierPathType.QuickStep)
            {
                player.bezierPath = bezierPath;
                player.pathType = BezierPathType.QuickStep;
            }
            else
            {
                player.bezierPath = null;
                player.pathType = BezierPathType.None;
            }
        }
    }
}