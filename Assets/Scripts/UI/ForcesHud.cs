using UnityEngine.UI;

public class ForcesHud : HudCommon
{
    public Text rings, timer;
    public Image ringsBackground;
    public Image boostDepletion;

    void Start()
    {

    }

    void Update()
    {
        rings.text = GameManager.instance.rings.ToString();
        timer.text = Timer.minutesRound.ToString("d2") + ":" + Timer.secondsRound.ToString("d2") + "." + Timer.fractionRound.ToString("d2");
        boostDepletion.enabled = Player.instance.isBoosting;
    }
}
