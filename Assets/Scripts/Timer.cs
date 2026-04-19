using UnityEngine;

public class Timer : MonoBehaviour
{
    static float startTime;
    static float displayTimer;

    public static int minutesRound;
    public static int secondsRound;
    public static int fractionRound;
    public static int secondsRound3Digits;

    static float seconds3Digits;

    public static bool isTimerPaused = true;

    void Update()
    {
        if (!isTimerPaused)
        {
            UpdateTimer();
        }
    }

    public static void StartTimer()
    {
        isTimerPaused = false;
    }

    public static void PauseTimer()
    {
        isTimerPaused = true;
    }

    public static void ResetTimer()
    {
        startTime = Time.time;
        UpdateTimer();
    }

    public static void UpdateTimer()
    {
        displayTimer = Time.time - startTime;

        float minutes = displayTimer / 60f;
        float seconds = displayTimer % 60f;
        float fraction = (displayTimer * 100f) % 100f;

        seconds3Digits = displayTimer % 999f;

        minutesRound = Mathf.FloorToInt(minutes);
        secondsRound = Mathf.FloorToInt(seconds);
        fractionRound = Mathf.FloorToInt(fraction);
        secondsRound3Digits = Mathf.FloorToInt(seconds3Digits);
    }
}