using UnityEngine;
using UnityEngine.Rendering.HighDefinition;

[ExecuteAlways]
[RequireComponent(typeof(HDAdditionalReflectionData))]
public class UpdateReflectionProbe : MonoBehaviour
{
    private HDAdditionalReflectionData hDAdditionalReflectionData;
    private float nextRenderTime = 0;

    [SerializeField]
    private float renderInterval = 1.0f;

    private void Awake()
    {
        hDAdditionalReflectionData = GetComponent<HDAdditionalReflectionData>();
    }

    private void LateUpdate()
    {
        if (nextRenderTime >= renderInterval)
        {
            hDAdditionalReflectionData.RequestRenderNextUpdate();

            nextRenderTime = 0;
        }
        else
        {
            nextRenderTime += Time.deltaTime;
        }
    }
}