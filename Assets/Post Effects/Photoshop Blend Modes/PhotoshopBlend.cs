using UnityEngine;

[ExecuteInEditMode]
public class PhotoshopBlend : MonoBehaviour
{

    public enum BlendMode
    {
        Normal,
        Darken,
        Multiply,
        ColorBurn,
        LinearBurn,
        Lighten,
        Screen,
        ColorDodge,
        LinearDodge,
        Overlay,
        SoftLight,
        HardLight,
        VividLight,
        LinearLight,
        PinLight,
        HardMix,
        Difference,
        Exclusion,
        Subtract,
        Divide,
    }

    public BlendMode blendMode;

    int blendModes = 26;
    int[] index = new int[26];


    private Material effectMaterial;
    public Shader effectShader;
    public Texture2D blendTexture;
    [Range(0, 1)]
    public float opacity = 1;



    // Creates a private material used to the effect
    void Awake()
    {
        effectShader = Shader.Find("Hidden/PhotoshopBlendModes");
        effectMaterial = new Material(effectShader);
    }

    // Postprocess the image
    void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        if (effectShader && effectMaterial)
        {
            //effectMaterial.SetTexture("_MainTex", source);
            effectMaterial.SetFloat("_Opacity", opacity);

            if (blendTexture != null)
            {
                effectMaterial.SetTexture("_BlendTex", blendTexture);
            }
            else
            {
                effectMaterial.SetTexture("_BlendTex", source);
            }

            SetBlendMode((int)blendMode);
        }
        Graphics.Blit(source, destination, effectMaterial);
    }

    void SetBlendMode(int index)
    {
        for (int i = 0; i < blendModes; i++)
        {
            if (i != index)
            {
                this.index[i] = 0;
            }
            else
            {
                this.index[i] = 1;
            }
        }

        effectMaterial.SetFloat("_Normal", this.index[0]);
        effectMaterial.SetFloat("_Darken", this.index[1]);
        effectMaterial.SetFloat("_Multiply", this.index[2]);
        effectMaterial.SetFloat("_ColorBurn", this.index[3]);
        effectMaterial.SetFloat("_LinearBurn", this.index[4]);
        effectMaterial.SetFloat("_Lighten", this.index[5]);
        effectMaterial.SetFloat("_Screen", this.index[6]);
        effectMaterial.SetFloat("_ColorDodge", this.index[7]);
        effectMaterial.SetFloat("_LinearDodge", this.index[8]);
        effectMaterial.SetFloat("_Overlay", this.index[9]);
        effectMaterial.SetFloat("_SoftLight", this.index[10]);
        effectMaterial.SetFloat("_HardLight", this.index[11]);
        effectMaterial.SetFloat("_VividLight", this.index[12]);
        effectMaterial.SetFloat("_LinearLight", this.index[13]);
        effectMaterial.SetFloat("_PinLight", this.index[14]);
        effectMaterial.SetFloat("_HardMix", this.index[15]);
        effectMaterial.SetFloat("_Difference", this.index[16]);
        effectMaterial.SetFloat("_Exclusion", this.index[17]);
        effectMaterial.SetFloat("_Subtract", this.index[18]);
        effectMaterial.SetFloat("_Divide", this.index[19]);
    }

    void Reset()
    {
        effectShader = Shader.Find("Hidden/PhotoshopBlendModes");
    }
}
