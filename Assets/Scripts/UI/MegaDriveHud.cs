using UnityEngine;
using UnityEngine.UI;

public class MegaDriveHud : HudCommon
{

    public Sprite[] numbers;
    public Image[] minutesHud;
    public Image[] secondsHud;
    public Image[] fractionHud;
    public Image[] ringCounterHud;
    public Image[] livesHud;
    public Image[] score;

    public Image rings;
    public Sprite ringsYellow;
    public Sprite ringsRed;

    public float interval = 0.1f;

    float lastBlinkTime;

    // Use this for initialization
    void Start()
    {
        lastBlinkTime = Time.time;
    }



    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.rings == 0)
        {
            if (Time.time > lastBlinkTime + interval)
            {
                if (rings.sprite == ringsYellow)
                {
                    rings.sprite = ringsRed;
                }
                else
                {
                    rings.sprite = ringsYellow;
                }
                lastBlinkTime = Time.time;
            }
        }
        else
        {
            rings.sprite = ringsYellow;
        }

        Counter(GameManager.instance.saveData.score.ToString("d8"), numbers, score);
        Counter(GameManager.instance.lives.ToString("d2"), numbers, livesHud);
        Counter(GameManager.instance.rings.ToString("d3"), numbers, ringCounterHud);
        Counter(Timer.fractionRound.ToString("d2"), numbers, fractionHud);
        Counter(Timer.minutesRound.ToString("d1"), numbers, minutesHud);
        Counter(Timer.secondsRound.ToString("d2"), numbers, secondsHud);
    }








}
