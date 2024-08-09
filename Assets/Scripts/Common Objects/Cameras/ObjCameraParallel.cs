using System.Collections;
using UnityEngine;

public class ObjCameraParallel : CameraCommon
{
    void LateUpdate()
    {
        if(GameManager.instance.gameState == GameState.Playing)
        {
            offset.z = Mathf.Lerp(offset.z, distance, EaseIn());
            rotation = Quaternion.Lerp(rotation, transform.rotation, EaseIn());
            Camera.main.transform.position = cameraTarget.position - (rotation * offset);
            Camera.main.transform.LookAt(cameraTarget.lookAt);
            Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, fieldOfView, EaseIn());
            cameraTarget.offset = Vector3.Lerp(cameraTarget.offset, targetOffset, EaseIn());
            MainCamera.lastRotation = rotation;
        }        
    }
}