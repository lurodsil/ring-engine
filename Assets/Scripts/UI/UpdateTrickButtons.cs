using UnityEngine;
using UnityEngine.UI;

public class UpdateTrickButtons : MonoBehaviour
{
    public AudioClip navigation;
    public AudioClip buttonPress;

    public GameObject buttonsHolder;

    public Sprite[] buttonsReleased;
    public Sprite[] buttonsPressed;

    public Image[] buttons;

    private char[] seedChar;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void OnEnable()
    {
        EventManager.OnTrickStart += OnTrickStart;
        EventManager.OnTrickEnd += OnTrickEnd;
        EventManager.OnButtonPress += OnButtonPress;
    }

    void OnDisable()
    {
        EventManager.OnTrickStart -= OnTrickStart;
        EventManager.OnTrickEnd -= OnTrickEnd;
        EventManager.OnButtonPress -= OnButtonPress;
    }

    public void OnTrickStart(string seed)
    {
        if (!buttonsHolder.activeSelf)
            buttonsHolder.SetActive(true);

        audioSource.PlayOneShot(navigation);

        seedChar = seed.ToCharArray();

        int length = Mathf.Min(seedChar.Length, buttons.Length);

        for (int i = 0; i < length; i++)
        {
            int digit = seedChar[i] - '0';
            buttons[i].sprite = buttonsReleased[digit];
        }
    }

    public void OnButtonPress(int index)
    {
        audioSource.PlayOneShot(buttonPress);

        int digit = seedChar[index] - '0';

        buttons[index].sprite = buttonsPressed[digit];
    }

    public void OnTrickEnd()
    {
        if (buttonsHolder.activeSelf)
            buttonsHolder.SetActive(false);
    }
}