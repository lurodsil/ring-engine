using System.Collections;
using System.Collections.Generic;
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

    private void OnEnable()
    {
        EventManager.OnTrickStart += OnTrickStart;
        EventManager.OnTrickEnd += OnTrickEnd;
        EventManager.OnButtonPress += OnButtonPress;
    }

    private void OnDisable()
    {
        EventManager.OnTrickStart -= OnTrickStart;
        EventManager.OnTrickEnd -= OnTrickEnd;
        EventManager.OnButtonPress -= OnButtonPress;
    }

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void OnTrickStart(string seed)    
    {
        buttonsHolder.SetActive(true);
        audioSource.PlayOneShot(navigation);

        seedChar = seed.ToCharArray();

        for (int i = 0; i < seedChar.Length; i++)
        {
            buttons[i].sprite = buttonsReleased[int.Parse(seedChar[i].ToString())];
        }
    }

    public void OnButtonPress(int index)
    {
        audioSource.PlayOneShot(buttonPress);
        buttons[index].sprite = buttonsPressed[int.Parse(seedChar[index].ToString())];
    }

    public void OnTrickEnd()
    {
        buttonsHolder.SetActive(false);
    }
}
