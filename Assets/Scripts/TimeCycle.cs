using UnityEngine;

public class TimeCycle : MonoBehaviour
{

    public bool skyDayStatic = true;
    public bool skyNightStatic = false;
    public bool layer1Static = false;
    public bool layer2Static = false;

    public Vector3 skyDaySpeed;
    public Vector3 skyNightSpeed;
    public Vector3 layer1Speed;
    public Vector3 layer2Speed;

    void Update()
    {
        SetMaterialMatrix("_SkyBoxDayRot", skyDaySpeed, skyDayStatic);
        SetMaterialMatrix("_SkyBoxNightRot", skyNightSpeed, skyNightStatic);
        SetMaterialMatrix("_Layer1Rot", layer1Speed, layer2Static);
        SetMaterialMatrix("_Layer2Rot", layer2Speed, layer2Static);
    }

    void SetMaterialMatrix(string MatrixName, Vector3 Speed, bool staticRotation)
    {
        Quaternion rotation = new Quaternion();
        if (staticRotation)
        {
            rotation = Quaternion.Euler(Speed.x, Speed.y, Speed.z);
        }
        else
        {
            rotation = Quaternion.Euler(Speed.x * Time.time, Speed.y * Time.time, Speed.z * Time.time);
        }
        Matrix4x4 matrix = new Matrix4x4();
        matrix.SetTRS(Vector3.zero, rotation, new Vector3(1, 1, 1));
        RenderSettings.skybox.SetMatrix(MatrixName, matrix);
    }
}