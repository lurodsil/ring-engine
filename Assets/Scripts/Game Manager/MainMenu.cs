using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Transform mainMenuCamera, optionsCamera, stageSelectCamera, creditsCamera;
    public float cameraTransitionTime = 2;

    public delegate void MenuState();
    public MenuState menuState;

    private int menuIndex;
    private int maxMenuIndex;
    new private Camera camera;

    public Text[] mainMenuTexts;
    public Canvas mainMenuCanvas;

    public AudioClip navigateSound;
    public AudioClip acceptSound;
    public AudioClip returnSound;

    [Header("Stage Select")]
    public Canvas stageSelectCanvas;
    public GameObject[] stages;

    [Header("Options Settings")]
    public Canvas optionsCanvas;
    public Text[] optionsTexts;

    public Text voiceTypeText;
    public Text hudTypeText;

    public Text ambientOcclusion;
    public Text motionBlur;
    public Text bloom;
    public Text colorGrading;

    public Text vibrationText;
    public Text invertFlightControlsText;

    public Slider effectsVolume;
    public Slider musicVolume;
    public Slider voiceVolume;

    public AudioSource effectsAudioSource;
    public AudioSource musicAudioSource;
    public AudioSource voiceAudioSource;

    public AudioClip effectVolumeTestClip;
    public AudioClip[] voiceVolumeTestAudioClipsGenerations;
    public AudioClip[] voiceVolumeTestAudioClipsUnleashed;

    [Header("Credits Settings")]
    public Canvas creditsCanvas;
    public GameObject[] credits;

    // Use this for initialization
    void Awake()
    {
        camera = Camera.main;
        menuState = StateFadeIn;
        menuIndex = 0;
        maxMenuIndex = 3;
    }

    private void Update()
    {
        menuState();

        effectsVolume.value = (GameManager.instance.settings.effectsVolume - 50) * 2;
        musicVolume.value = (GameManager.instance.settings.musicVolume - 50) * 2;
        voiceVolume.value = (GameManager.instance.settings.voiceVolume - 50) * 2;

        voiceTypeText.text = GameManager.instance.settings.voiceType.ToString().ToLower();
        hudTypeText.text = GameManager.instance.settings.hudType.ToString().ToLower();

        ambientOcclusion.text = GameManager.instance.settings.ambientOcclusion == true ? "on" : "off";
        motionBlur.text = GameManager.instance.settings.motionBlur == true ? "on" : "off";
        bloom.text = GameManager.instance.settings.bloom == true ? "on" : "off";
        colorGrading.text = GameManager.instance.settings.colorGrading == true ? "on" : "off";

        vibrationText.text = GameManager.instance.settings.vibration == true ? "on" : "off";
        invertFlightControlsText.text = GameManager.instance.settings.invertFlightControl == true ? "yes" : "no";
    }

    public void StateMainMenu()
    {
        MoveCamera(mainMenuCamera);

        switch (menuIndex)
        {
            case 0:
                if (Input.GetButtonDown(XboxButton.A))
                {
                    PlayAcceptSound();
                    menuIndex = 0;
                    menuState = StateStageSelect;
                    mainMenuCanvas.enabled = false;
                    stageSelectCanvas.enabled = true;
                }
                break;
            case 1:
                if (Input.GetButtonDown(XboxButton.A))
                {
                    PlayAcceptSound();
                    menuIndex = 0;
                    maxMenuIndex = optionsTexts.Length;
                    menuState = StateOptions;
                    mainMenuCanvas.enabled = false;
                    optionsCanvas.enabled = true;
                }
                break;
            case 2:
                if (Input.GetButtonDown(XboxButton.A))
                {
                    PlayAcceptSound();
                    menuState = StateFadeOutAndQuit;
                    mainMenuCanvas.enabled = false;
                }
                break;
        }

        Navigate(mainMenuTexts);
    }

    public void StateOptions()
    {
        MoveCamera(optionsCamera);

        switch (menuIndex)
        {
            case 0:
                if (Input.GetButtonDown(XboxButton.DPadRight))
                {
                    if (GameManager.instance.settings.effectsVolume < 100)
                    {
                        GameManager.instance.settings.effectsVolume += 5;
                    }
                    effectsAudioSource.PlayOneShot(effectVolumeTestClip);
                }
                else if (Input.GetButtonDown(XboxButton.DPadLeft))
                {
                    if (GameManager.instance.settings.effectsVolume > 50)
                    {
                        GameManager.instance.settings.effectsVolume -= 5;
                    }
                    effectsAudioSource.PlayOneShot(effectVolumeTestClip);
                }
                break;
            case 1:
                if (Input.GetButtonDown(XboxButton.DPadRight))
                {
                    if (GameManager.instance.settings.musicVolume < 100)
                    {
                        GameManager.instance.settings.musicVolume += 5;
                    }

                }
                else if (Input.GetButtonDown(XboxButton.DPadLeft))
                {
                    if (GameManager.instance.settings.musicVolume > 50)
                    {
                        GameManager.instance.settings.musicVolume -= 5;
                    }
                }
                break;
            case 2:
                if (Input.GetButtonDown(XboxButton.DPadRight))
                {
                    if (GameManager.instance.settings.voiceVolume < 100)
                    {
                        GameManager.instance.settings.voiceVolume += 5;
                    }
                    PlayTestVoice();
                }
                else if (Input.GetButtonDown(XboxButton.DPadLeft))
                {
                    if (GameManager.instance.settings.voiceVolume > 50)
                    {
                        GameManager.instance.settings.voiceVolume -= 5;
                    }
                    PlayTestVoice();
                }
                break;
            case 3:
                if (Input.GetButtonDown(XboxButton.DPadRight) || Input.GetButtonDown(XboxButton.DPadLeft))
                {
                    switch (GameManager.instance.settings.voiceType)
                    {
                        case VoiceType.Generations:
                            GameManager.instance.settings.voiceType = VoiceType.Unleashed;
                            break;
                        case VoiceType.Unleashed:
                            GameManager.instance.settings.voiceType = VoiceType.Generations;
                            break;
                    }
                    PlayTestVoice();
                }
                break;
            case 4:
                if (Input.GetButtonDown(XboxButton.DPadRight))
                {
                    switch (GameManager.instance.settings.hudType)
                    {
                        case HudType.Generations:
                            GameManager.instance.settings.hudType = HudType.LostWorld;
                            break;
                        case HudType.LostWorld:
                            GameManager.instance.settings.hudType = HudType.Unleashed;
                            break;
                        case HudType.Unleashed:
                            GameManager.instance.settings.hudType = HudType.Generations;
                            break;

                    }
                    PlayNavigateSound();
                }
                else if (Input.GetButtonDown(XboxButton.DPadLeft))
                {
                    switch (GameManager.instance.settings.hudType)
                    {
                        case HudType.Generations:
                            GameManager.instance.settings.hudType = HudType.Unleashed;
                            break;
                        case HudType.LostWorld:
                            GameManager.instance.settings.hudType = HudType.Generations;
                            break;
                        case HudType.Unleashed:
                            GameManager.instance.settings.hudType = HudType.LostWorld;
                            break;
                    }
                    PlayNavigateSound();
                }
                break;
            case 5:
                if (Input.GetButtonDown(XboxButton.DPadRight) || Input.GetButtonDown(XboxButton.DPadLeft))
                {
                    if (GameManager.instance.settings.ambientOcclusion)
                    {
                        GameManager.instance.settings.ambientOcclusion = false;
                    }
                    else
                    {
                        GameManager.instance.settings.ambientOcclusion = true;
                    }
                    PlayNavigateSound();
                }
                break;
            case 6:
                if (Input.GetButtonDown(XboxButton.DPadRight) || Input.GetButtonDown(XboxButton.DPadLeft))
                {
                    if (GameManager.instance.settings.motionBlur)
                    {
                        GameManager.instance.settings.motionBlur = false;
                    }
                    else
                    {
                        GameManager.instance.settings.motionBlur = true;
                    }
                    PlayNavigateSound();
                }
                break;
            case 7:
                if (Input.GetButtonDown(XboxButton.DPadRight) || Input.GetButtonDown(XboxButton.DPadLeft))
                {
                    if (GameManager.instance.settings.bloom)
                    {
                        GameManager.instance.settings.bloom = false;
                    }
                    else
                    {
                        GameManager.instance.settings.bloom = true;
                    }
                    PlayNavigateSound();
                }
                break;
            case 8:
                if (Input.GetButtonDown(XboxButton.DPadRight) || Input.GetButtonDown(XboxButton.DPadLeft))
                {
                    if (GameManager.instance.settings.colorGrading)
                    {
                        GameManager.instance.settings.colorGrading = false;
                    }
                    else
                    {
                        GameManager.instance.settings.colorGrading = true;
                    }
                    PlayNavigateSound();
                }
                break;
            case 9:
                if (Input.GetButtonDown(XboxButton.DPadRight) || Input.GetButtonDown(XboxButton.DPadLeft))
                {
                    if (GameManager.instance.settings.vibration)
                    {
                        GameManager.instance.settings.vibration = false;
                    }
                    else
                    {
                        GameManager.instance.settings.vibration = true;
                        Input.SetVibration(1, 1, 0.5f);
                    }
                    PlayNavigateSound();
                }
                break;
            case 10:
                if (Input.GetButtonDown(XboxButton.DPadRight) || Input.GetButtonDown(XboxButton.DPadLeft))
                {
                    if (GameManager.instance.settings.invertFlightControl)
                    {
                        GameManager.instance.settings.invertFlightControl = false;
                    }
                    else
                    {
                        GameManager.instance.settings.invertFlightControl = true;
                    }
                    PlayNavigateSound();
                }
                break;
            case 11:
                if (Input.GetButtonDown(XboxButton.A))
                {
                    PlayAcceptSound();
                    optionsCanvas.enabled = false;
                    menuState = StateCredits;
                    menuIndex = 0;
                    creditsCanvas.enabled = true;
                }
                break;
        }

        if (Input.GetButtonDown(XboxButton.B))
        {
            PlayReturnSound();
            menuIndex = 1;
            maxMenuIndex = mainMenuTexts.Length;
            mainMenuCanvas.enabled = true;
            optionsCanvas.enabled = false;
            menuState = StateMainMenu;
            FileManager.Save(GameManager.instance.settings, GameManager.instance.settingsPath);
        }

        Navigate(optionsTexts);
    }

    public void StateStageSelect()
    {
        MoveCamera(stageSelectCamera);

        if (Input.GetButtonDown(XboxButton.B))
        {
            PlayReturnSound();
            menuIndex = 0;
            maxMenuIndex = mainMenuTexts.Length;
            mainMenuCanvas.enabled = true;
            stageSelectCanvas.enabled = false;
            menuState = StateMainMenu;
        }

        Navigate(stages);

        if (Input.GetButtonDown(XboxButton.A))
        {
            switch (menuIndex)
            {
                case 0:
                    menuState = StateFadeOutAndLoad;
                    break;
            }
        }
    }

    void StateCredits()
    {
        MoveCamera(creditsCamera);

        if (Input.GetButtonDown(XboxButton.B))
        {
            PlayReturnSound();
            menuIndex = optionsTexts.Length - 1;
            maxMenuIndex = optionsTexts.Length;
            menuState = StateOptions;
            creditsCanvas.enabled = false;
            optionsCanvas.enabled = true;
        }

        Navigate(credits);
    }

    void StateFadeOutAndLoad()
    {
        GameManager.instance.AudioFadeOut();

        if (GameManager.instance.ScreenFadeOut())
        {
            GameManager.instance.LoadSceneWithLoading("Test Stage");
        }
    }

    void StateFadeOutAndQuit()
    {
        GameManager.instance.AudioFadeOut();

        if (GameManager.instance.ScreenFadeOut())
        {
            Application.Quit();
        }
    }

    void StateFadeIn()
    {
        //GameManager.instance.AudioFadeIn();
        if (GameManager.instance.ScreenFadeIn())
        {
            menuState = StateMainMenu;
        }
    }

    void Navigate(Text[] texts)
    {
        if (Input.GetButtonDown(XboxButton.DPadDown))
        {
            PlayNavigateSound();
            if (menuIndex == texts.Length - 1)
            {
                menuIndex = 0;
            }
            else
            {
                menuIndex++;
            }
        }
        else if (Input.GetButtonDown(XboxButton.DPadUp))
        {
            PlayNavigateSound();
            if (menuIndex == 0)
            {
                menuIndex = texts.Length - 1;
            }
            else
            {
                menuIndex--;
            }
        }

        for (int i = 0; i < texts.Length; i++)
        {
            if (i == menuIndex)
            {
                texts[i].color = Color.yellow;
            }
            else
            {
                texts[i].color = Color.white;
            }
        }
    }

    void Navigate(GameObject[] gameObjects)
    {
        if (Input.GetButtonDown(XboxButton.DPadRight))
        {
            if (menuIndex == gameObjects.Length - 1)
            {
                menuIndex = 0;
            }
            else
            {
                menuIndex++;
            }

            PlayNavigateSound();
        }
        else if (Input.GetButtonDown(XboxButton.DPadLeft))
        {
            if (menuIndex == 0)
            {
                menuIndex = gameObjects.Length - 1;
            }
            else
            {
                menuIndex--;
            }

            PlayNavigateSound();
        }

        for (int i = 0; i < gameObjects.Length; i++)
        {
            if (i == menuIndex)
            {
                gameObjects[i].SetActive(true);
            }
            else
            {
                gameObjects[i].SetActive(false);
            }
        }
    }

    void MoveCamera(Transform target)
    {
        camera.transform.position = Vector3.Lerp(camera.transform.position, target.position, Time.deltaTime * cameraTransitionTime);
        camera.transform.rotation = Quaternion.Lerp(camera.transform.rotation, target.rotation, Time.deltaTime * cameraTransitionTime);
    }

    void PlayNavigateSound()
    {
        effectsAudioSource.PlayOneShot(navigateSound);
    }

    void PlayAcceptSound()
    {
        effectsAudioSource.PlayOneShot(acceptSound);
    }

    void PlayReturnSound()
    {
        effectsAudioSource.PlayOneShot(returnSound);
    }

    void PlayTestVoice()
    {
        switch (GameManager.instance.settings.voiceType)
        {
            case VoiceType.Generations:
                voiceAudioSource.Stop();
                voiceAudioSource.PlayOneShot(voiceVolumeTestAudioClipsGenerations[Random.Range(0, voiceVolumeTestAudioClipsGenerations.Length - 1)]);
                break;
            case VoiceType.Unleashed:
                voiceAudioSource.Stop();
                voiceAudioSource.PlayOneShot(voiceVolumeTestAudioClipsUnleashed[Random.Range(0, voiceVolumeTestAudioClipsUnleashed.Length - 1)]);
                break;
        }
    }

    void Zero()
    {

    }
}
