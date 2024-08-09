using UnityEngine;
using UnityEngine.UI;

public class ForcesHud : HudCommon
{
    public Text rings, timer, lives;
    public Image ringsBackground;
    public Image boostDepletion;
    public Image boostGaugeBarFront;
    public Image[] redStars;
    public Sprite grayStar;
    public Sprite redStar;


    void Start()
    {
       
    }

    public void Update()
    {

        if (GameManager.instance.rings == 0)
        {
            float pingPong = Mathf.PingPong(Time.time, 0.6f);
            rings.color = Color.Lerp(Color.white, Color.red, pingPong);
        }
        else
        {
            rings.color = Color.white;
        }

        RedStars(GameManager.instance.redStars, redStars, grayStar, redStar);

        rings.text = GameManager.instance.rings.ToString();
        lives.text = GameManager.instance.lives.ToString("d2");
        timer.text = Timer.minutesRound.ToString("d2") + ":" + Timer.secondsRound.ToString("d2") + "." + Timer.fractionRound.ToString("d2");
        boostDepletion.enabled = Player.instance.isBoosting;

        boostGaugeBarFront.rectTransform.sizeDelta = new Vector2(Player.instance.ringEnergy * 5, boostGaugeBarFront.rectTransform.sizeDelta.y);
    }
}
