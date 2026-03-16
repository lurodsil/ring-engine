using UnityEngine;
using UnityEngine.UI;

namespace RingEngine.UI.Hud
{
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

        private GameManager gameManager;

        void Start()
        {
            lastBlinkTime = Time.time;
            gameManager = GameManager.instance;
        }

        void Update()
        {
            HandleRingBlink();

            Counter(gameManager.saveData.score.ToString("d8"), numbers, score);
            Counter(gameManager.lives.ToString("d2"), numbers, livesHud);
            Counter(gameManager.rings.ToString("d3"), numbers, ringCounterHud);

            Counter(Timer.fractionRound.ToString("d2"), numbers, fractionHud);
            Counter(Timer.minutesRound.ToString("d1"), numbers, minutesHud);
            Counter(Timer.secondsRound.ToString("d2"), numbers, secondsHud);
        }

        void HandleRingBlink()
        {
            if (gameManager.rings == 0)
            {
                if (Time.time - lastBlinkTime > interval)
                {
                    rings.sprite = rings.sprite == ringsYellow ? ringsRed : ringsYellow;
                    lastBlinkTime = Time.time;
                }
            }
            else
            {
                if (rings.sprite != ringsYellow)
                    rings.sprite = ringsYellow;
            }
        }
    }
}