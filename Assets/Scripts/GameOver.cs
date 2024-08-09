using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip audioClip;

    private bool continueGame = false;
    private bool fade = false;

    void Update()
    {
        if (!fade)
        {
            GameManager.instance.AudioFadeIn();
            GameManager.instance.ScreenFadeIn();
        }
        else
        {
            GameManager.instance.AudioFadeOut();
            if (GameManager.instance.ScreenFadeOut())
            {
                GameManager.instance.firstTimeLoad = true;
                GameManager.instance.activeCheckpoints.Clear();
                GameManager.instance.lastCheckpoint = -1;
                Timer.reset = true;
                GameManager.instance.lives = 3;
                GameManager.instance.LoadSceneWithLoading(GameManager.instance.sceneLoading);
            }
        }

        if (!continueGame && Input.GetButton(XboxButton.A))
        {
            animator.SetTrigger("Continue");
            audioSource.PlayOneShot(audioClip);
            StartCoroutine("Wait");
            continueGame = true;
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(2);
        fade = true;
    }
}
