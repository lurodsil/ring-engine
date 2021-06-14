using UnityEngine;
using UnityEngine.UI;

public class Hud : HudCommon
{
    public static Animator animator;
    public Image ringImage;
    public Image clockPointer;
    public Image getLife;
    public float getLifeOffset;
    public Sprite[] numbersWhiteBlue;
    public Image[] ringCounterHud;
    public Image[] redRingCounterHud;
    public Image[] livesCounterHud;
    public Image[] minutesHud;
    public Image[] secondsHud;
    public Image[] fractionHud;
    public Image[] redStars;
    public Sprite grayStar;
    public Sprite redStar;
    private const float secondsToDegrees = 360f / 60f;

    void Start()
    {
        animator = ringImage.GetComponent<Animator>();
    }

    void Update()
    {
        ZeroRings();
        GetLife();

        clockPointer.transform.rotation =
            Quaternion.Euler(0f, 0f, Timer.secondsRound * -secondsToDegrees);

        Counter(GameManager.instance.rings.ToString("d3"), numbersWhiteBlue, ringCounterHud);
        Counter(GameManager.instance.lives.ToString("d2"), numbersWhiteBlue, livesCounterHud);
        Counter(Timer.minutesRound.ToString("d2"), numbersWhiteBlue, minutesHud);
        Counter(Timer.secondsRound.ToString("d2"), numbersWhiteBlue, secondsHud);
        Counter(Timer.fractionRound.ToString("d2"), numbersWhiteBlue, fractionHud);
        RedStars(GameManager.instance.redStars, redStars, grayStar, redStar);
    }

    void GetLife()
    {
        Vector3 getLifeTargetPos = new Vector3(Screen.width / 2 - 34, Screen.height / 2 + 100, 0);
        getLifeTargetPos.y = getLifeTargetPos.y + getLifeOffset;
        if (Main.getLife)
        {
            getLife.gameObject.SetActive(true);
            getLife.transform.position = Vector3.Lerp(getLife.transform.position, getLifeTargetPos, 1 * Time.deltaTime);
        }
        else
        {
            getLife.rectTransform.position = new Vector3(Screen.width / 2 - 34, Screen.height / 2 + 100, 0);
            getLife.gameObject.SetActive(false);
        }
    }

    void ZeroRings()
    {
        Color red = Color.red;
        if (GameManager.instance.rings == 0)
            red.a = Mathf.PingPong(Time.time, 0.6f);
        else red = Color.clear;

        redRingCounterHud[0].color = red;
        redRingCounterHud[1].color = red;
        redRingCounterHud[2].color = red;
    }
}
