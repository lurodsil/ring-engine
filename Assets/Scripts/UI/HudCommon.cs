using UnityEngine;
using UnityEngine.UI;

public class HudCommon : MonoBehaviour
{
    public void Counter(string number, Sprite[] numbers, Image[] dest)
    {
        int un = 0;
        int dez = 0;
        int cen = 0;
        int mil = 0;
        int dezmil = 0;
        int cenmil = 0;
        int unmilh = 0;
        int dezmilh = 0;

        switch (dest.Length)
        {
            case 0: break;
            case 1:
                un = int.Parse(number[0].ToString());
                dest[0].sprite = numbers[un];
                break;
            case 2:
                un = int.Parse(number[1].ToString());
                dez = int.Parse(number[0].ToString());
                dest[0].sprite = numbers[un];
                dest[1].sprite = numbers[dez];
                break;
            case 3:
                un = int.Parse(number[2].ToString());
                dez = int.Parse(number[1].ToString());
                cen = int.Parse(number[0].ToString());
                dest[0].sprite = numbers[un];
                dest[1].sprite = numbers[dez];
                dest[2].sprite = numbers[cen];
                break;
            case 4:
                un = int.Parse(number[3].ToString());
                dez = int.Parse(number[2].ToString());
                cen = int.Parse(number[1].ToString());
                mil = int.Parse(number[0].ToString());
                dest[0].sprite = numbers[un];
                dest[1].sprite = numbers[dez];
                dest[2].sprite = numbers[cen];
                dest[3].sprite = numbers[mil];
                break;
            case 5:
                un = int.Parse(number[4].ToString());
                dez = int.Parse(number[3].ToString());
                cen = int.Parse(number[2].ToString());
                mil = int.Parse(number[1].ToString());
                dezmil = int.Parse(number[0].ToString());
                dest[0].sprite = numbers[un];
                dest[1].sprite = numbers[dez];
                dest[2].sprite = numbers[cen];
                dest[3].sprite = numbers[mil];
                dest[4].sprite = numbers[dezmil];
                break;
            case 6:
                un = int.Parse(number[5].ToString());
                dez = int.Parse(number[4].ToString());
                cen = int.Parse(number[3].ToString());
                mil = int.Parse(number[2].ToString());
                dezmil = int.Parse(number[1].ToString());
                cenmil = int.Parse(number[0].ToString());
                dest[0].sprite = numbers[un];
                dest[1].sprite = numbers[dez];
                dest[2].sprite = numbers[cen];
                dest[3].sprite = numbers[mil];
                dest[4].sprite = numbers[dezmil];
                dest[5].sprite = numbers[cenmil];
                break;
            case 7:
                un = int.Parse(number[6].ToString());
                dez = int.Parse(number[5].ToString());
                cen = int.Parse(number[4].ToString());
                mil = int.Parse(number[3].ToString());
                dezmil = int.Parse(number[2].ToString());
                cenmil = int.Parse(number[1].ToString());
                unmilh = int.Parse(number[0].ToString());
                dest[0].sprite = numbers[un];
                dest[1].sprite = numbers[dez];
                dest[2].sprite = numbers[cen];
                dest[3].sprite = numbers[mil];
                dest[4].sprite = numbers[dezmil];
                dest[5].sprite = numbers[cenmil];
                dest[6].sprite = numbers[unmilh];
                break;
            case 8:
                un = int.Parse(number[7].ToString());
                dez = int.Parse(number[6].ToString());
                cen = int.Parse(number[5].ToString());
                mil = int.Parse(number[4].ToString());
                dezmil = int.Parse(number[3].ToString());
                cenmil = int.Parse(number[2].ToString());
                unmilh = int.Parse(number[1].ToString());
                dezmilh = int.Parse(number[0].ToString());
                dest[0].sprite = numbers[un];
                dest[1].sprite = numbers[dez];
                dest[2].sprite = numbers[cen];
                dest[3].sprite = numbers[mil];
                dest[4].sprite = numbers[dezmil];
                dest[5].sprite = numbers[cenmil];
                dest[6].sprite = numbers[unmilh];
                dest[7].sprite = numbers[dezmilh];
                break;
        }
    }

    public void RedStars(int amount, Image[] redStars, Sprite grayStar, Sprite redStar)
    {
        switch (amount)
        {
            case 0:
                redStars[0].sprite = grayStar;
                redStars[1].sprite = grayStar;
                redStars[2].sprite = grayStar;
                redStars[3].sprite = grayStar;
                redStars[4].sprite = grayStar;
                break;
            case 1:
                redStars[0].sprite = redStar;
                redStars[1].sprite = grayStar;
                redStars[2].sprite = grayStar;
                redStars[3].sprite = grayStar;
                redStars[4].sprite = grayStar;
                break;
            case 2:
                redStars[0].sprite = redStar;
                redStars[1].sprite = redStar;
                redStars[2].sprite = grayStar;
                redStars[3].sprite = grayStar;
                redStars[4].sprite = grayStar;
                break;
            case 3:
                redStars[0].sprite = redStar;
                redStars[1].sprite = redStar;
                redStars[2].sprite = redStar;
                redStars[3].sprite = grayStar;
                redStars[4].sprite = grayStar;
                break;
            case 4:
                redStars[0].sprite = redStar;
                redStars[1].sprite = redStar;
                redStars[2].sprite = redStar;
                redStars[3].sprite = redStar;
                redStars[4].sprite = grayStar;
                break;
            case 5:
                redStars[0].sprite = redStar;
                redStars[1].sprite = redStar;
                redStars[2].sprite = redStar;
                redStars[3].sprite = redStar;
                redStars[4].sprite = redStar;
                break;
        }
    }
}
