using System.Collections;
using UnityEngine;

public class BlinkMaterials : MonoBehaviour
{
    public Material[] materials;
    public int numberOfTimes = 10;
    public float interval = 0.05f;
    public Color color = Color.white;

    public void Blink()
    {
        StartCoroutine(BlinkWhite(numberOfTimes, interval));
    }
    private IEnumerator BlinkWhite(int times, float interval)
    {
        for (int i = 0; i < times; i++)
        {
            foreach (Material m in materials)
            {
                m.SetColor("_EmissionColor", color);
            }
            yield return new WaitForSeconds(interval);
            foreach (Material m in materials)
            {
                m.SetColor("_EmissionColor", Color.black);
            }
            yield return new WaitForSeconds(interval);
        }
    }
}
