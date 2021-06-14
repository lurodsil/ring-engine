using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Flame : GenerationsObject
{
    public float FlameType = 1f;
    public float LengthType = 1f;
    public float OffTime = 0.1f;
    public float OnTime = 5.00002f;
    public float PhaseRate = 0f;

    public float AppearTime = 0.2f;
    public float Length = 10f;
    public float Phase = 0f;
    public float Type = 1f;

    public ParticleSystem flames;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        StartCoroutine(OnOff(OnTime, OffTime));
    }

    private IEnumerator OnOff(float onTime, float offTime)
    {
        yield return new WaitForSeconds(offTime);
        audioSource.Play();
        flames.Play();
        yield return new WaitForSeconds(onTime);
        audioSource.Stop();
        flames.Stop();
        StartCoroutine(OnOff(onTime, offTime));
    }
}