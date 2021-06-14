using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public delegate void TargetObjectsChanged();
    public static event TargetObjectsChanged OnTargetObjectsChanged;

    public delegate void RingAmountChanged();
    public static event RingAmountChanged OnRingAmountChanged;

    public delegate void RedStarsChanged();
    public static event RedStarsChanged OnRedStarsChanged;

    public static void UpdateTargetObjects()
    {
        OnTargetObjectsChanged?.Invoke();
    }

    public static void UpdateRingAmount(int amount)
    {
        GameManager.instance.rings += amount;
        OnRingAmountChanged?.Invoke();
    }

    public static void UpdateRedStars(int id)
    {
        GameManager.instance.redStars++;
        OnRedStarsChanged?.Invoke();
    }
}
