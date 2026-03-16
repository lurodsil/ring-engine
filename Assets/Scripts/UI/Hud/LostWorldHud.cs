
using UnityEngine;
using UnityEngine.UI;

namespace RingEngine.UI.Hud
{
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

        private GameManager gm;

        private void Start()
        {
            gm = GameManager.instance;
        }

        void Update()
        {
            Counter(gm.rings.ToString("d3"), numbers, ringCounterHud);
            Counter(gm.lives.ToString("d2"), numbers, livesCounterHud);
            Counter(Timer.secondsRound3Digits.ToString("d3"), numbers, secondsHud);
            Counter(gm.saveData.animalsFree.ToString("d4"), numbers, animalsHud);

            RedStars(gm.redStars, redStars, grayStar, redStar);

            Color color;

            if (gm.rings == 0)
            {
                float pingPong = Mathf.PingPong(Time.time, 0.6f);
                color = Color.Lerp(Color.white, Color.red, pingPong);
            }
            else
            {
                color = Color.white;
            }

            for (int i = 0; i < ringCounterHud.Length; i++)
            {
                ringCounterHud[i].color = color;
            }
        }
    }
}