using UnityEngine;

public class PanelLights : MonoBehaviour
{
    public float interval = 0.5f;
    public Material[] lightMaterials;
    public Texture[] lightTextures;

    private float lastStateTime;
    private int textureIndex;
    private int maxTextureIndex;

    void Start()
    {
        maxTextureIndex = lightTextures.Length - 1;
        ResetTimer();
    }

    void Update()
    {
        if (Time.time > lastStateTime + interval)
        {
            if (textureIndex < maxTextureIndex)
            {
                textureIndex++;
            }
            else
            {
                textureIndex = 0;
            }

            foreach (Material material in lightMaterials)
            {
                material.SetTexture("_MainTex", lightTextures[textureIndex]);
                material.SetTexture("_EmissionMap", lightTextures[textureIndex]);
            }

            ResetTimer();
        }
    }

    void ResetTimer()
    {
        lastStateTime = Time.time;
    }
}
