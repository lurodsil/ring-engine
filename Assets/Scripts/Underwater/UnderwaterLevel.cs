using UnityEngine;

[ExecuteInEditMode]
public class UnderwaterLevel : MonoBehaviour
{
    public Material[] materials;
    void Update()
    {
        foreach (Material m in materials)
        {
            m.SetFloat("_UnderwaterLevel", transform.position.y);
        }
    }
}
