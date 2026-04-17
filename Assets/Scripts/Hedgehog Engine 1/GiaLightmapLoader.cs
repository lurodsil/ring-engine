using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

[ExecuteAlways]
public class GiaLightmapLoader : MonoBehaviour
{
    public GiaLightmapData lightmapData;
    [Range(0, 1)]
    public float shadowThreshold = 0.8f;

    void OnEnable()
    {
        Apply();
    }

    [ContextMenu("Apply Lightmaps")]
    public void Apply()
    {
        if (lightmapData == null || lightmapData.lightmaps == null)
            return;

        LightmapData[] data = new LightmapData[lightmapData.lightmaps.Length];

        for (int i = 0; i < data.Length; i++)
        {
            //Texture2D lightmapdir = ExtractDirectionalFromAlpha(lightmapData.lightmaps[i], shadowThreshold);
            data[i] = new LightmapData
            {
                lightmapColor = RemoveAlpha(lightmapData.lightmaps[i]),
                lightmapDir = RemoveAlpha(lightmapData.lightmaps[i]),
                //shadowMask = lightmapData.directionalLightmaps[i],
            };
        }

        LightmapSettings.lightmaps = data;

        MeshRenderer[] renderers = gameObject.GetComponentsInChildren<MeshRenderer>();

        foreach (var binding in lightmapData.bindings)
        {
            foreach (var renderer in renderers)
            {
                if (renderer.gameObject.name == binding.gameObjectName)
                {
                    renderer.lightmapIndex = binding.lightmapIndex;
                    renderer.lightmapScaleOffset = binding.scaleOffset;
                    break;
                }
            }
        }
    }

    Texture2D ExtractDirectionalFromAlpha(Texture2D source, float shadowThreshold = 0.8f)
    {
        int width = source.width;
        int height = source.height;

        Texture2D dir = new Texture2D(width, height, TextureFormat.RGB24, false);

        Color32[] pixels = source.GetPixels32();
        Color32[] dirPixels = new Color32[pixels.Length];

        for (int i = 0; i < pixels.Length; i++)
        {
            byte a = pixels[i].a;

            if (a < 128)
                a = (byte)(255 - (255 * shadowThreshold));

            dirPixels[i] = new Color32(a, a, a, 255);
        }

        dir.SetPixels32(dirPixels);
        dir.Apply();

        return dir;
    }

    Texture2D RemoveAlpha(Texture2D source)
    {
        int width = source.width;
        int height = source.height;

        Texture2D dir = new Texture2D(width, height, TextureFormat.RGB24, false);

        Color32[] pixels = source.GetPixels32();
        Color32[] dirPixels = new Color32[pixels.Length];

        for (int i = 0; i < pixels.Length; i++)
        {
            dirPixels[i] = new Color32(pixels[i].r, pixels[i].g, pixels[i].b,0);
        }

        dir.SetPixels32(dirPixels);
        dir.Apply();

        return dir;
    }

}
