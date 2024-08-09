using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Glitch : MonoBehaviour
{
    [SerializeField] private Material glitchMaterial;

    [SerializeField] private float maxNoiseAmount = 50f;
    [SerializeField] private float maxGlitchStrenght = 10f;

    private float noiseAmount = 50f;
    private float glitchStrenght = 10f;

    [SerializeField] private AudioClip glitchSound;

    private AudioSource audioSource;


    public float updateStep = 0.1f;
    public int sampleDataLength = 1024;

    private float currentUpdateTime = 0f;

    public float clipLoudness;
    private float[] clipSampleData;

    public float sizeFactor = 1;

    public float minSize = 0;
    public float maxSize = 500;


    private void Awake()
    {
        clipSampleData = new float[sampleDataLength];
    }


    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        currentUpdateTime += Time.deltaTime;
        if (currentUpdateTime >= updateStep)
        {
            currentUpdateTime = 0f;
            audioSource.clip.GetData(clipSampleData, audioSource.timeSamples); //I read 1024 samples, which is about 80 ms on a 44khz stereo clip, beginning at the current sample position of the clip.
            clipLoudness = 0f;
            foreach (var sample in clipSampleData)
            {
                clipLoudness += Mathf.Abs(sample);
            }
            clipLoudness /= sampleDataLength; //clipLoudness is what you are looking for

            clipLoudness *= sizeFactor;
            clipLoudness = Mathf.Clamp(clipLoudness, minSize, maxSize);
        }

        noiseAmount = clipLoudness * maxNoiseAmount;
        glitchStrenght = clipLoudness * maxGlitchStrenght;


        glitchMaterial.SetFloat("_NoiseAmount", noiseAmount);
        glitchMaterial.SetFloat("_GlitchStrenght", glitchStrenght);
    }
}
