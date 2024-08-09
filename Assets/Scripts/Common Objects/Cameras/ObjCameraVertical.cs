using UnityEngine;

public class ObjCameraVertical : CameraCommon
{
    public Vector3 lookOffset;
    void LateUpdate()
    {
        if (GameManager.instance.gameState == GameState.Playing)
        {
            offset.z = Mathf.Lerp(offset.z, distance, EaseIn());
            Camera.main.transform.position = cameraTarget.position - (Camera.main.transform.rotation * offset);
            Vector3 direction = Camera.main.transform.DirectionTo(transform.position + lookOffset);
            Camera.main.transform.rotation = Quaternion.Lerp(Camera.main.transform.rotation, Quaternion.LookRotation(direction), EaseIn());
            Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, fieldOfView, EaseIn());
        }
    }
    private void OnDisable()
    {
        cameraTarget.offset = Vector3.zero;
    }
}