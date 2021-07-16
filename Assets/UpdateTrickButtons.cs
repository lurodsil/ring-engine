using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateTrickButtons : MonoBehaviour
{
    public AudioClip navigation;
    public GameObject buttonsHolder;
    public Sprite[] buttonsSource;
    public Image[] buttons;

    public static string seed;


    private void OnEnable()
    {
        EventManager.OnTrickStart += OnTrickStart;
        EventManager.OnTrickEnd += OnTrickEnd;
    }

    private void OnDisable()
    {
        EventManager.OnTrickStart -= OnTrickStart;
        EventManager.OnTrickEnd -= OnTrickEnd;
    }

    public void OnTrickStart()    
    {
        buttonsHolder.SetActive(true);
        GetComponent<AudioSource>().PlayOneShot(navigation);

        char[] valueChar = seed.ToCharArray();

        for (int i = 0; i < valueChar.Length; i++)
        {
            buttons[i].sprite = buttonsSource[int.Parse(valueChar[i].ToString())];
        }
    }

    public void OnTrickEnd()
    {
        buttonsHolder.SetActive(false);
    }
}
