using UnityEngine;

[RequireComponent(typeof(RadialBlur))]
public class EnableRadialBlur : MonoBehaviour
{
    private RadialBlur radialBlur;
    private Player player;

    // Start is called before the first frame update
    void Start()
    {
        radialBlur = GetComponent<RadialBlur>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        radialBlur.blurStrength = Mathf.Lerp(0, 1.5f, (1f / 60f) * player.absoluteVelocity);
    }
}
