using UnityEngine;

[ExecuteInEditMode]
public class GiaLoader : MonoBehaviour
{
    public string giaFolder;
    public string giaFormat = "*.dds";
    public Texture2D[] lightmapsTextures;
    public delegate void OnSetupLightmaps();
    public static event OnSetupLightmaps OnSetupLightmapsEvent;
    public bool apply;

    public void Start()
    {
        SetupLightmaps();
        //OnSetupLightmapsEvent();
        apply = true;

        //if (!Application.isPlaying && apply)
        //{
        //    SetupLightmaps();
        //    OnSetupLightmapsEvent();
        //    apply = false;
        //}
    }

    public void SetupLightmaps()
    {
        LightmapData[] lightmaps = new LightmapData[lightmapsTextures.Length];

        for (int i = 0; i < lightmaps.Length; i++)
        {
            lightmaps[i] = new LightmapData();
            lightmaps[i].lightmapColor = lightmapsTextures[i];
        }

        LightmapSettings.lightmaps = lightmaps;
    }
}
