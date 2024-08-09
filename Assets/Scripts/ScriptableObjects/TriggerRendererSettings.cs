using UnityEngine;

[ExecuteInEditMode]
public class TriggerRendererSettings : ScriptableObject
{
    public Material[] materials;

    public static TriggerRendererSettings instance;

    private void OnEnable()
    {
        instance = this;
    }
}
