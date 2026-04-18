#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

public class GameplayModeChanger : CommonObject
{
    public Vector3 TargetDirection;
    public float Template = 0f;
    public float m_CurveCorrectionForce = 0f;
    public bool m_IsChangeCamera = true;
    public bool m_IsEnableFromBack = true;
    public bool m_IsEnableFromFront = true;
    public bool m_IsLimitEdge = true;
    public bool m_IsReverseCameraEnable = false;
    public float m_PathCorrectionForce = 0.5f;
    public bool m_IsAutoChange2DPath = true;
    public bool m_IsPadCorrect = true;
    public float m_PathEaseTime = 0.5f;
    public float m_DashPathSideMoveRate = 0.6f;
    public bool m_IsGravityControl = false;
    public Color debugColor = Color.blue;

    public GameplayMode frontGameplayMode = GameplayMode.Forward;
    public GameplayMode backGameplayMode = GameplayMode.Forward;

    private void Start()
    {
        OnPlayerTriggerEnter.AddListener(ChangeMode);
    }

    public void ChangeMode()
    {
        //MainCamera.instance.useGuidePath = m_IsChangeCamera;

        //MainCamera.instance.directionMultiplier = m_IsReverseCameraEnable ? -1 : 1;

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

        if (m_IsChangeCamera)
        {
            if(player.gameplayMode == GameplayMode.Forward)
            {
                CameraManager.DeactivateAll();
            }
        }
    }

#if UNITY_EDITOR
    private static Mesh gizmoMesh;

    public virtual void OnDrawGizmos()
    {
        if (gizmoMesh == null)
            LoadGizmoMesh();

        if (gizmoMesh == null)
            return;

        Gizmos.color = Selection.activeGameObject == gameObject
            ? Color.yellow
            : debugColor;

        Gizmos.DrawMesh(
            gizmoMesh,
            transform.position,
            Quaternion.LookRotation(transform.forward, Vector3.up),
            Vector3.one * 20
        );

        float cameraDistance = GetSceneViewCameraDistance();

        if (cameraDistance < 500)
        {
            debugLastOffset = 0;

            Gizmos.color = new Color(0, 0, 0.5f, 0.5f);
            GizmosExtension.DrawBoxBoundaries(GetComponent<BoxCollider>());
        }
    }

    static void LoadGizmoMesh()
    {
        var obj = Resources.Load<GameObject>("Gizmos/Arrow");

        if (obj != null && obj.TryGetComponent(out MeshFilter mf))
        {
            gizmoMesh = mf.sharedMesh;
        }
        else
        {
            Debug.LogWarning("Arrow Gizmo mesh not found at Resources/Gizmos/Arrow");
        }
    }
#endif
}