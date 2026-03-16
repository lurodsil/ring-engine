using UnityEngine;
using UnityEngine.UI;

namespace RingEngine.UI.Hud
{
    public class HudCommon : MonoBehaviour
    {
        public void Counter(string number, Sprite[] numbers, Image[] dest)
        {
            int length = Mathf.Min(number.Length, dest.Length);

            for (int i = 0; i < length; i++)
            {
                int index = number.Length - 1 - i;

                int digit = number[index] - '0';

                if (digit >= 0 && digit < numbers.Length)
                {
                    dest[i].sprite = numbers[digit];
                }
            }
        }

        public void RedStars(int amount, Image[] redStars, Sprite grayStar, Sprite redStar)
        {
            for (int i = 0; i < redStars.Length; i++)
            {
                redStars[i].sprite = i < amount ? redStar : grayStar;
            }
        }
    }
}