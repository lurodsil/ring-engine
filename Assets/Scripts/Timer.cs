using System.Collections;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public bool startTimer;
    public bool pauseGame;
    public bool resetTimer;
    public static bool start;
    public static bool reset;
    static float startTime;
    static float minutes;
    static float seconds;
    static float seconds3Digits;
    static float fraction;
    static float displayTimer;
    public static int minutesRound;
    public static int secondsRound;
    public static int fractionRound;
    public static int secondsRound3Digits;

    public static bool isTimerPaused = true;

    private void Update()
    {
        if (!isTimerPaused)
        {
            displayTimer = Time.time - startTime;

            minutes = displayTimer / 60;
            seconds = displayTimer % 60;
            fraction = (displayTimer * 100) % 100;
            seconds3Digits = displayTimer % 999;

            minutesRound = Mathf.FloorToInt(minutes);
            secondsRound = Mathf.FloorToInt(seconds);
            fractionRound = Mathf.FloorToInt(fraction);
            secondsRound3Digits = Mathf.FloorToInt(seconds3Digits);
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
    }
}
