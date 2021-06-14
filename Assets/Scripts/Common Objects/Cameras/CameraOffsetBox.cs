using UnityEngine;

public class CameraOffsetBox : GenerationsObject
{
    public float Collision_Height = 20f;
    public float Collision_Length = 35f;
    public float Collision_Width = 15f;
    public float DefaultStatus = 0f;
    public float EaseTimeIn = 1.5f;
    public float EaseTimeOut = 1.5f;
    public float FollowRatio = 1f;
    public float FollowRatioCam = 1f;
    public float FollowRatioTrg = 1f;
    public float FollowXYZ = 4f;
    public bool IsCameraView = false;
    public float OffsetPosX = 1f;
    public float OffsetPosY = 1f;
    public float OffsetPosZ = 0f;
    public float OffsetTrgX = 0f;
    public float OffsetTrgY = 0f;
    public float OffsetTrgZ = 0f;
    public float Shape_Type = 0f;

    public override void OnValidate()
    {
        if (!gameObject.GetComponent<BoxCollider>())
        {
            gameObject.AddComponent<BoxCollider>();
        }

        gameObject.GetComponent<BoxCollider>().size = new Vector3(Collision_Width, Collision_Height, Collision_Length);
    }
}