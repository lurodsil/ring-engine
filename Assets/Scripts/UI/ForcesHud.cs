using UnityEngine.UI;

public class ForcesHud : HudCommon
{
    public Text rings, timer;
    public Image ringsBackground;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        rings.text = GameManager.instance.rings.ToString();
        timer.text = Timer.minutesRound.ToString("d2") + ":" + Timer.secondsRound.ToString("d2") + "." + Timer.fractionRound.ToString("d2");
    }
}
