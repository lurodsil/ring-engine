using UnityEngine;

[System.Serializable]
public class CameraBoardSide
{
    public int CameraID;
    public float CameraPriority = 0f;

    public int LinkObjID;
    public CameraLinkSide LinkSide;

    public float ObjType = 0f;

    public CameraCommon camera;
    public CameraCollisionBoard linkObj;
}
