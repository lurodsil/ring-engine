using System.Collections;
using UnityEngine;

public class Timer : MonoBehaviour
{

    bool resetOnStart;
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

    private void Update()
    {

        if (Main.canControl)
        {
            startTimer = true;
        }


        //if (pauseGame)
        //    Time.timeScale = 0;
        //if (!pauseGame)
        //    Time.timeScale = 1;

        if (reset || resetTimer)
            StartCoroutine(ResetTimer());

        if (start || startTimer)
        {
            if (resetOnStart)
                StartCoroutine(ResetTimer());

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
        else resetOnStart = true;
    }

    private IEnumerator ResetTimer()
    {
        yield return new WaitForSeconds(0.01f);
        startTime = Time.time;
        resetOnStart = false;
        resetTimer = false;
    }
}
