using RingEngine.UI.Hud;
using UnityEngine;
using UnityEngine.UI;

public class Hud : HudCommon
{
    private Animator animator;
    private Transform clockPointerTransform;

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

    private const float secondsToDegrees = 6f;
    private GameManager gameManager;

    void Start()
    {
        animator = ringImage.GetComponent<Animator>();
        clockPointerTransform = clockPointer.transform;
        gameManager = GameManager.instance;
    }

    void Update()
    {
        ZeroRings();
        GetLife();

        clockPointerTransform.rotation =
            Quaternion.Euler(0f, 0f, -Timer.secondsRound * secondsToDegrees);

        Counter(gameManager.rings.ToString("d3"), numbersWhiteBlue, ringCounterHud);
        Counter(gameManager.lives.ToString("d2"), numbersWhiteBlue, livesCounterHud);

        Counter(Timer.minutesRound.ToString("d2"), numbersWhiteBlue, minutesHud);
        Counter(Timer.secondsRound.ToString("d2"), numbersWhiteBlue, secondsHud);
        Counter(Timer.fractionRound.ToString("d2"), numbersWhiteBlue, fractionHud);

        RedStars(gameManager.redStars, redStars, grayStar, redStar);
    }

    public void GetLife()
    {
        Vector3 getLifeTargetPos = new Vector3(
            Screen.width * 0.5f - 34,
            Screen.height * 0.5f + 100 + getLifeOffset,
            0
        );

        if (Main.getLife)
        {
            if (!getLife.gameObject.activeSelf)
                getLife.gameObject.SetActive(true);

            getLife.transform.position =
                Vector3.Lerp(getLife.transform.position, getLifeTargetPos, Time.deltaTime);
        }
        else
        {
            if (getLife.gameObject.activeSelf)
                getLife.gameObject.SetActive(false);

            getLife.rectTransform.position =
                new Vector3(Screen.width * 0.5f - 34, Screen.height * 0.5f + 100, 0);
        }
    }

    void ZeroRings()
    {
        Color red = Color.red;

        if (GameManager.instance.rings == 0)
            red.a = Mathf.PingPong(Time.time, 0.6f);
        else
            red = Color.clear;

        for (int i = 0; i < redRingCounterHud.Length; i++)
        {
            redRingCounterHud[i].color = red;
        }
    }
}