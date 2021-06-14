using UnityEngine;
using UnityEngine.Audio;

public class UnderwaterManager : MonoBehaviour
{
    public bool underwater { get; set; }
    public AudioClip underwaterAlert1;
    public AudioClip underwaterAlert2;
    public AudioClip underwaterCountdown;
    public int underwaterAlertState { get; set; }
    private float underwaterTimer;

    public AudioSource audioSource;
    public AudioMixer mixer;

    void Start()
    {

    }

    void UnderwaterStart()
    {
        mixer.SetFloat("Lowpass", 800);
        underwater = true;
    }

    void UnderwaterEnd()
    {
        mixer.SetFloat("Lowpass", 22000);
        underwater = false;
    }

    void UnderwaterReset()
    {
        underwaterAlertState = 0;
        underwaterTimer = Time.time;
        audioSource.Stop();
    }

    void Update()
    {
        if (GameManager.instance.gameState == GameState.Playing && Player.instance)
        {
            if (Player.instance.underwater)
            {
                switch (underwaterAlertState)
                {
                    case 0:
                        if (Time.time > underwaterTimer + 10)
                        {
                            audioSource.PlayOneShot(underwaterAlert1);
                            underwaterAlertState++;
                            underwaterTimer = Time.time;
                        }
                        break;
                    case 1:
                        if (Time.time > underwaterTimer + 10)
                        {
                            audioSource.PlayOneShot(underwaterAlert1);
                            underwaterAlertState++;
                            underwaterTimer = Time.time;
                        }
                        break;
                    case 2:
                        if (Time.time > underwaterTimer + 10)
                        {
                            audioSource.PlayOneShot(underwaterAlert2);
                            underwaterAlertState++;
                            underwaterTimer = Time.time;
                        }
                        break;
                    case 3:
                        if (Time.time > underwaterTimer + 10)
                        {
                            audioSource.PlayOneShot(underwaterCountdown);
                            underwaterAlertState++;
                            underwaterTimer = Time.time;
                        }
                        break;
                }
            }
            else
            {
                underwaterTimer = Time.time;
            }
        }
    }
}
