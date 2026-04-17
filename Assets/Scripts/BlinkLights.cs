using System.Collections.Generic;
using UnityEngine;

public class BlinkLights : MonoBehaviour
{
    public Color blinkColor = Color.red;
    public GameObject lightsHolder;
    private List<Light> Lights = new List<Light>();
    private List<Color> originalColors = new List<Color>();
    public float interval = 1f;
    public bool active = false;

    void Start()
    {
        if (lightsHolder != null)
        {
            Lights.AddRange(lightsHolder.GetComponentsInChildren<Light>());
        }

        originalColors.Clear();

        foreach (Light light in Lights)
        {
            if (light != null)
                originalColors.Add(light.color);
            else
                originalColors.Add(Color.white);
        }
    }

    void Update()
    {
        if (active)
        {
            float t = Mathf.PingPong(Time.time / interval, 1f);

            for (int i = 0; i < Lights.Count; i++)
            {
                if (Lights[i] != null)
                {
                    Lights[i].color = Color.Lerp(originalColors[i], blinkColor, t);
                }
            }
        }
        else
        {
            for (int i = 0; i < Lights.Count; i++)
            {
                if (Lights[i] != null)
                {
                    Lights[i].color = originalColors[i];
                }
            }
        }
    }

    public void SetActive(bool active)
    {
        this.active = active;
    }
}