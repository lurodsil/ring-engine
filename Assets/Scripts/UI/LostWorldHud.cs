using UnityEngine;
using UnityEngine.UI;

public class LostWorldHud : HudCommon
{

    public Sprite[] numbers;
    public Image[] ringCounterHud;
    public Image[] livesCounterHud;
    public Image[] secondsHud;
    public Image[] animalsHud;
    public Sprite grayStar;
    public Sprite redStar;
    public Image[] redStars;
    public int animals;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Counter(GameManager.instance.rings.ToString("d3"), numbers, ringCounterHud);
        Counter(GameManager.instance.saveData.lives.ToString("d2"), numbers, livesCounterHud);
        Counter(Timer.secondsRound3Digits.ToString("d3"), numbers, secondsHud);
        Counter(GameManager.instance.saveData.animalsFree.ToString("d4"), numbers, animalsHud);
        RedStars(GameManager.instance.redStars, redStars, grayStar, redStar);

        if (GameManager.instance.rings == 0)
        {
            float pingPong = Mathf.PingPong(Time.time, 0.6f);
            ringCounterHud[0].color = Color.Lerp(Color.white, Color.red, pingPong);
            ringCounterHud[1].color = Color.Lerp(Color.white, Color.red, pingPong);
            ringCounterHud[2].color = Color.Lerp(Color.white, Color.red, pingPong);
        }
        else
        {
            ringCounterHud[0].color = Color.white;
            ringCounterHud[1].color = Color.white;
            ringCounterHud[2].color = Color.white;
        }


    }
}
