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
    public GameplayMode frontGameplayMode = GameplayMode.Dash;
    public GameplayMode backGameplayMode = GameplayMode.Forward;

    private void Start()
    {
        OnPlayerTriggerEnter.AddListener(ChangeMode);
    }

    public void ChangeMode()
    {
        Vector3 velocity = player.rigidbody.linearVelocity;

        if (velocity.sqrMagnitude < 0.01f)
            velocity = player.transform.forward;

        Vector3 moveDir = Vector3.ProjectOnPlane(velocity, Vector3.up).normalized;
        Vector3 forward = Vector3.ProjectOnPlane(transform.forward, Vector3.up).normalized;

        float dot = Vector3.Dot(moveDir, forward);

        const float threshold = 0.2f;

        if (dot > threshold)
        {
            if (m_IsEnableFromFront)
                player.gameplayMode = frontGameplayMode;
        }
        else if (dot < -threshold)
        {
            if (m_IsEnableFromBack)
                player.gameplayMode = backGameplayMode;
        }
    }


    public void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(TargetDirection, 0.3f);
    }
}