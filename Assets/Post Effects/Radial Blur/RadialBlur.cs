using UnityEngine;

[ExecuteInEditMode]
public class RadialBlur : MonoBehaviour
{
    public Shader rbShader;

    public float blurStrength = 2.2f;
    public float blurWidth = 1.0f;

    private Material rbMaterial = null;


    private Material GetMaterial()
    {
        if (rbMaterial == null)
        {
            rbMaterial = new Material(rbShader);
            rbMaterial.hideFlags = HideFlags.HideAndDontSave;
        }
        return rbMaterial;
    }

    void Start()
    {
        if (rbShader == null)
        {
            Debug.LogError("shader missing!", this);
        }
    }

    void OnRenderImage(RenderTexture source, RenderTexture dest)
    {
        //If we run in OpenGL mode, our UV coords are
        //not in 0-1 range, because of the texRECT sampler
        float ImageWidth = 1;
        float ImageHeight = 1;
        /*if (isOpenGL)
        {
            ImageWidth = source.width;
            ImageHeight = source.height;
        }*/

        Material m_Material = GetMaterial();

        m_Material.SetFloat("_BlurStrength", blurStrength);
        m_Material.SetFloat("_BlurWidth", blurWidth);
        m_Material.SetFloat("_iHeight", ImageWidth);
        m_Material.SetFloat("_iWidth", ImageHeight);
        Graphics.Blit(source, dest, m_Material);
    }
}