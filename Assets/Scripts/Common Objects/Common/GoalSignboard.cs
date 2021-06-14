using UnityEngine;

public class GoalSignboard : GenerationsObject
{
    public float DefaultPreGoalCameraFovy = 30f;
    public float DefaultPreGoalCameraOffsetPositionX = 0f;
    public float DefaultPreGoalCameraOffsetPositionY = 3f;
    public float DefaultPreGoalCameraOffsetPositionZ = 15f;
    public float DefaultPreGoalCameraOffsetTargetX = 0f;
    public float DefaultPreGoalCameraOffsetTargetY = 2f;
    public float DefaultPreGoalCameraOffsetTargetZ = 0f;
    public bool IsCustomPreGoalCameraParam = false;
    public bool IsMessageOn = false;
    public bool IsPopCameraAll = true;
    public bool IsUsePreGoalCameraParam = true;
    public float OverrideDiffuse = 1f;
    public float PreGoalCameraCollisionSizeX = 4.2f;
    public float PreGoalCameraCollisionSizeY = 32f;
    public float PreGoalCameraCollisionSizeZ = 3f;
    public float ResultDegree = 0f;
    public Vector3 ResultPosition;

    public override void OnValidate()
    {

    }
}