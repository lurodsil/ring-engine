using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class CameraCollisionBoard : CommonObject
{
    public CameraBoardSide SideForward = new CameraBoardSide();
    public CameraBoardSide SideBackward = new CameraBoardSide();

    [Header("Collision")]
    public float CollisionHeight = 20f;
    public float CollisionWidth = 10f;

    [Header("Transition")]
    public float EaseTime_AtoB = 1f;
    public float EaseTime_BtoA = 1f;

    [Header("Camera Settings")]
    public float GroundOffset = 0f;
    public bool IsCastShadow = true;
    public float Range = 100f;

    public float m_ValidFlag;

    public override void OnEnable()
    {
        base.OnEnable();

        OnPlayerTriggerEnter.AddListener(Activate);

        CacheCameras();
    }

    [ContextMenu("Attach Cameras")]
    private void CacheCameras()
    {
        if (SideForward.CameraID != 0)
        {
            SideForward.camera = FindObjectByID(SideForward.CameraID) as CameraCommon;
        }
        if (SideBackward.CameraID != 0)
        {
            SideBackward.camera = FindObjectByID(SideBackward.CameraID) as CameraCommon;
        }

        if (SideForward.LinkObjID != 0)
        {
            SideForward.linkObj = FindObjectByID(SideForward.LinkObjID) as CameraCollisionBoard;
        }
        if (SideBackward.LinkObjID != 0)
        {
            SideBackward.linkObj = FindObjectByID(SideBackward.LinkObjID) as CameraCollisionBoard;
        }
    }


    public void Activate()
    {
        CameraManager.blendCamera = null;

        float dot = Vector3.Dot(player.rigidbody.linearVelocity.normalized, transform.forward);

        bool nextPointForward = SideForward.linkObj != null &&
                                Vector3.Dot(transform.forward, SideForward.linkObj.transform.forward) > 0;

        bool backPointForward = SideBackward.linkObj != null &&
                                Vector3.Dot(transform.forward, SideBackward.linkObj.transform.forward) > 0;

        if (dot > 0)
        {

            if (SideBackward.CameraID != 0)
            {
                CameraManager.DeactivateTrigger(SideBackward.camera);
            }
            else if (SideBackward.LinkObjID != 0 && SideBackward.linkObj != null)
            {
                CameraManager.DeactivateTrigger(SideBackward.linkObj.SideForward.camera);
            }

            if (SideForward.CameraID != 0)
            {
                CameraManager.ActivateTrigger(SideForward.camera);

                if (SideForward.linkObj != null)
                {
                    if (nextPointForward)
                    {
                        if (SideForward.linkObj.SideBackward.CameraID != 0)
                            CameraManager.blendCamera = SideForward.linkObj.SideBackward.camera;
                    }
                    else
                    {
                        if (SideForward.linkObj.SideForward.CameraID != 0)
                            CameraManager.blendCamera = SideForward.linkObj.SideForward.camera;
                    }
                }
            }
            else if (SideForward.LinkObjID != 0 && SideForward.linkObj != null)
            {
                if (nextPointForward)
                    CameraManager.ActivateTrigger(SideForward.linkObj.SideBackward.camera);
                else
                    CameraManager.ActivateTrigger(SideForward.linkObj.SideForward.camera);
            }
        }
        else
        {

            if (SideForward.CameraID != 0)
            {
                CameraManager.DeactivateTrigger(SideForward.camera);
            }
            else if (SideForward.LinkObjID != 0 && SideForward.linkObj != null)
            {
                CameraManager.DeactivateTrigger(SideForward.linkObj.SideBackward.camera);
            }

            if (SideBackward.CameraID != 0)
            {
                CameraManager.ActivateTrigger(SideBackward.camera);

                if (SideBackward.linkObj != null)
                {
                    if (backPointForward)
                    {
                        if (SideBackward.linkObj.SideForward.CameraID != 0)
                            CameraManager.blendCamera = SideBackward.linkObj.SideForward.camera;
                    }
                    else
                    {
                        if (SideBackward.linkObj.SideBackward.CameraID != 0)
                            CameraManager.blendCamera = SideBackward.linkObj.SideBackward.camera; 
                    }
                }
            }
            else if (SideBackward.LinkObjID != 0 && SideBackward.linkObj != null)
            {
                if (backPointForward)
                    CameraManager.ActivateTrigger(SideBackward.linkObj.SideForward.camera);
                else
                    CameraManager.ActivateTrigger(SideBackward.linkObj.SideBackward.camera);
            }
        }
    }


    private void OnDrawGizmosSelected()
    {
        debugLastOffset = 0;

        DrawConnection(SideForward.LinkObjID, Color.cyan, "Camera Link Object with ID ");
        DrawConnection(SideForward.CameraID, Color.blue, "Camera Link Object with ID ");
        
        DrawConnection(SideBackward.CameraID, Color.yellow, "Camera Link Object with ID ", 1);
        DrawConnection(SideBackward.LinkObjID, Color.orange, "Camera Link Object with ID ", 1);
    }

    private void OnDrawGizmos()
    {
        float cameraDistance = GetSceneViewCameraDistance();

        if (cameraDistance < 500)
        {
            debugLastOffset = 0;

            Gizmos.color = new Color(0, 0.5f, 0, 0.5f);
            GizmosExtension.DrawBoxBoundaries(GetComponent<BoxCollider>());
        }
    }
}
