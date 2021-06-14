using UnityEngine;

[System.Serializable]
public class CameraSettings
{
    [Range(0, 50)]
    public float distance = 5;
    public Vector3 position = Vector3.zero;
    public Vector3 offset = Vector3.zero;
    public Vector3 direction = Vector3.zero;
    public float sensitivity = 10.0f;
    public float fieldOfView = 45;
    public float easeIn = 0.5f;
    public float easeOut = 0.5f;

    public CameraSettings()
    {

    }

    public CameraSettings(Vector3 direction, Vector3 offset, float distance, float easeIn = 0.5f, float easeOut = 0.5f, float fieldOfView = 45)
    {
        this.direction = direction;
        this.offset = offset;
        this.distance = distance;
        this.easeIn = easeIn;
        this.easeOut = easeOut;
        this.fieldOfView = fieldOfView;
    }
}
