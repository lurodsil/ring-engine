using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Rendering.HighDefinition;
using UnityEngine.SceneManagement;

public class UnderwaterManager : MonoBehaviour
{
    public bool underwater { get; set; }
    public AudioClip underwaterAlert1;
    public AudioClip underwaterAlert2;
    public AudioClip underwaterCountdown;
    public AudioClip drown;
    public int underwaterAlertState { get; set; }
    private float underwaterTimer;

    public AudioSource audioSource;
    public AudioMixer mixer;

    public CustomPassVolume underwaterPassVolume;    

    public void UnderwaterStart()
    {

        SceneManager.sceneLoaded += SceneManager_sceneLoaded;

        mixer.SetFloat("Lowpass", 600);
        underwater = true;
        //Here we change the injection point to render the underwater distortion properly
        underwaterPassVolume.injectionPoint = CustomPassInjectionPoint.BeforePostProcess;
    }

    private void SceneManager_sceneLoaded(Scene arg0, LoadSceneMode arg1)
    {
        UnderwaterReset();
        UnderwaterEnd();
    }

    public void UnderwaterEnd()
    {
        mixer.SetFloat("Lowpass", 22000);
        underwater = false;
        //Here we change the injection point to render the boost wave propperly
        underwaterPassVolume.injectionPoint = CustomPassInjectionPoint.BeforeTransparent;
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
            if (Player.instance.isUnderwater)
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
                        case 4:
                        if (Time.time > underwaterTimer + 11)
                        {
                            Player.instance.drown = true;
                            Player.instance.stateMachine.ChangeState(Player.instance.StateDie);
                            audioSource.PlayOneShot(drown);
                            underwaterAlertState++;
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
