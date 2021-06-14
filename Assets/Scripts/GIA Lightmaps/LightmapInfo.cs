using UnityEngine;

[ExecuteInEditMode]
public class LightmapInfo : MonoBehaviour
{

    public int lightmapIndex = -1;
    public Vector4 lightmapScaleOffset = new Vector4(1, 1, 0, 0);

    void Awake()
    {
        SetupLightmap();
    }

    void OnEnable()
    {
        GiaLoader.OnSetupLightmapsEvent += SetupLightmap;
    }

    void OnDisable()
    {
        GiaLoader.OnSetupLightmapsEvent -= SetupLightmap;
    }


    void SetupLightmap()
    {
        GetComponent<Renderer>().lightmapIndex = lightmapIndex;
        GetComponent<Renderer>().lightmapScaleOffset = lightmapScaleOffset;
    }
}
