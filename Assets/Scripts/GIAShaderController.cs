using UnityEngine;

public class GIAShaderController : MonoBehaviour
{
    [SerializeField]
    [Range(0,1)]
    private float giaBoost = 0f;

    [SerializeField]
    [Range(0, 10)]
    private float giaSaturation = 1.0f;

    [SerializeField]
    private Color giaColor = Color.white;

    [ContextMenu("Apply Settings")]
    private void SetShaderParameters()
    {
        Shader.SetGlobalFloat("_GIABoost", giaBoost);
        Shader.SetGlobalFloat("_GIASaturation", giaSaturation);
        Shader.SetGlobalColor("_GIAColor", giaColor);
    }

    private void Start()
    {
        SetShaderParameters();
    }
}
