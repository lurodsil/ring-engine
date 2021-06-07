using UnityEngine;

public class UnderwaterEffect : MonoBehaviour
{
    private Material underwaterEffectMaterial;
    public Shader underwaterEffectShader;
    public Texture2D underwaterEffectTexture;
    public Vector2 UVSpeed = new Vector2(0.5f, 1.0f);

    // Creates a private material used to the effect
    void Awake()
    {
        underwaterEffectShader = Shader.Find("Hidden/Underwater Effect");
        underwaterEffectMaterial = new Material(underwaterEffectShader);
    }

    // Postprocess the image
    void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        if (underwaterEffectShader && underwaterEffectMaterial && underwaterEffectTexture)
        {
            underwaterEffectMaterial.SetTexture("_DistortionMap", underwaterEffectTexture);
            underwaterEffectMaterial.SetFloat("_USpeed", UVSpeed.x);
            underwaterEffectMaterial.SetFloat("_VSpeed", UVSpeed.y);
        }
        Graphics.Blit(source, destination, underwaterEffectMaterial);
    }

    void Reset()
    {
        underwaterEffectShader = Shader.Find("Hidden/Underwater Effect");
    }
}