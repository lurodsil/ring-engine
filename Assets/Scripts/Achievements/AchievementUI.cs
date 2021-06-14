using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class AchievementUI : MonoBehaviour
{
    public float autoHideTime = 5;
    public Image achievement;
    public Text achievementUnlocked;
    public Text achievementReason;
    public Text achievementName;
    private Vector2 show = new Vector2(0, 64);
    private Vector2 hide = new Vector2(0, -64);
    private Vector2 target;

    void Awake()
    {
        target = hide;
        achievement.rectTransform.anchoredPosition = target;
    }

    void Update()
    {
        achievement.rectTransform.anchoredPosition = Vector2.Lerp(achievement.rectTransform.anchoredPosition, target, 10 * Time.deltaTime);
    }

    public void Show(Achievement achievement, LanguageType language)
    {
        achievementUnlocked.text = language == LanguageType.English ? "achievement unlocked" : "conquista desbloqueada";
        achievementReason.text = language == LanguageType.English ? achievement.reasonEn : achievement.reasonPt;
        achievementName.text = language == LanguageType.English ? achievement.achievmentEn : achievement.achievmentPt;
        target = show;
        StartCoroutine(AutoHide(autoHideTime));
    }

    public void Hide()
    {
        target = hide;
    }

    IEnumerator AutoHide(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        Hide();
    }
}
