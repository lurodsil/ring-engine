using UnityEngine;

public class CameraOffsetBoard : GenerationsObject
{
    public float Collision_Height = 15f;
    public float Collision_Width = 26f;
    public float EaseTimeIn = 0.1f;
    public float EaseTimeOut = 0.1f;
    public float ExecTime = 0.1f;
    public float FollowRatio = 1f;
    public float FollowRatioCam = 0.55f;
    public float FollowRatioTrg = 1f;
    public float FollowXYZ = 0f;
    public bool IsCameraView = false;
    public bool IsResetOld = false;
    public float OffsetPosX = 0f;
    public float OffsetPosY = 0f;
    public float OffsetPosZ = 0f;
    public float OffsetTrgX = 0f;
    public float OffsetTrgY = 0f;
    public float OffsetTrgZ = 0f;

    public override void OnValidate()
    {
        if (!gameObject.GetComponent<BoxCollider>())
        {
            gameObject.AddComponent<BoxCollider>();
        }

        gameObject.GetComponent<BoxCollider>().size = new Vector3(Collision_Width, Collision_Height, 0.001f);
    }
}