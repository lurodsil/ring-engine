using System.Collections;
using UnityEngine;

public class Flame : RingEngineObject
{
    public float offTime = 2;
    public float onTime = 5;

    private void Start()
    {
        if (active)
        {
            StartCoroutine(OnOff(onTime, offTime));
        }
    }

    public override void Activate()
    {
        base.Activate();

        StartCoroutine(OnOff(onTime, offTime));
    }

    public override void Deactivate()
    {
        base.Deactivate();

        StopAllCoroutines();
    }

    private IEnumerator OnOff(float onTime, float offTime)
    {
        yield return new WaitForSeconds(offTime);
        OnStateStart.Invoke();
        yield return new WaitForSeconds(onTime);
        OnStateEnd?.Invoke();
        StartCoroutine(OnOff(onTime, offTime));       
    }
}