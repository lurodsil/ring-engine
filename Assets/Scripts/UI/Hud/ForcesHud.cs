using UnityEngine;
using UnityEngine.UI;

namespace RingEngine.UI.Hud
{
    public class ForcesHud : HudCommon
    {
        public Text rings, timer, lives;

        public Image ringsBackground;
        public Image boostDepletion;
        public Image boostGaugeBarFront;

        public Image[] redStars;
        public Sprite grayStar;
        public Sprite redStar;

        private GameManager gameManager;
        private Player player;

        void Start()
        {
            gameManager = GameManager.instance;
            player = Player.instance;
        }

        void Update()
        {
            if (gameManager.rings == 0)
            {
                float pingPong = Mathf.PingPong(Time.time, 0.6f);
                rings.color = Color.Lerp(Color.white, Color.red, pingPong);
            }
            else
            {
                if (rings.color != Color.white)
                    rings.color = Color.white;
            }

            RedStars(gameManager.redStars, redStars, grayStar, redStar);

            rings.text = gameManager.rings.ToString();
            lives.text = gameManager.lives.ToString("d2");

            timer.text =
                $"{Timer.minutesRound:00}:{Timer.secondsRound:00}.{Timer.fractionRound:00}";

            boostDepletion.enabled = player.isBoosting;

            var rt = boostGaugeBarFront.rectTransform;

            rt.sizeDelta =
                new Vector2(player.ringEnergy * 5, rt.sizeDelta.y);
        }
    }
}