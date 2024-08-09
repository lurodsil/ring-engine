using UnityEngine;

public class ObjCameraPan : CameraCommon
{
    public bool moveToPosition;

    private void FixedUpdate()
    {
        if (moveToPosition)
        {
            MainCamera.Position = Vector3.Lerp(MainCamera.Position, transform.position, EaseIn());
        }
    }
    void LateUpdate()
    {
        MainCamera.CameraTransform.LookAt(cameraTarget.lookAt);
        Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, fieldOfView, EaseIn());
        cameraTarget.offset = Vector3.Lerp(cameraTarget.offset, targetOffset, EaseIn());
        MainCamera.lastRotation = Camera.main.transform.rotation;
    }
}