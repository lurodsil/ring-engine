using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Audio;
//using UnityEngine.PostProcessing;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class GameManager : MonoBehaviour
{
    public delegate void PauseAction();
    public static event PauseAction OnPause;
    public static event PauseAction OnResume;

    public UnderwaterManager underwaterManager;
    public PauseMenu pauseMenu;

    public bool firstTimeLoad = true;

    public bool[] activeCheckpoints;
    public int lastCheckpoint = -1;

    public string sceneLoading;
    public AudioClip loadingStart;
    public AudioClip loadingEnd;

    public GameObject player;

    //public PostProcessingProfile postProcessingProfile;

    public static GameManager instance;

    //Debug
    private RingEngineDebug ringEngineDebug;

    //Settings
    public string settingsFile = "Settings.ring";
    public string settingsPath
    {
        get
        {
            return Application.dataPath + "\\" + settingsFile;
        }
    }
    public Settings settings = new Settings();

    //Save
    public string saveDataFile = "SaveData.ring";
    public string saveDataPath
    {
        get
        {
            return Application.dataPath + "\\" + saveDataFile;
        }
    }
    public SaveData saveData = new SaveData();

    //UI
    public Image blackscreen;
    public Slider musicVolume;
    public AchievementUI achievementUI;

    //Audio
    public AudioSource audioSource;
    public AudioMixer mixer;
    private float masterVolume = -10;

    public GameState gameState;

    public float screenFadeSpeed;
    public float audioFadeSpeed;

    public int lives;
    public int rings;
    public int redStars;

    public float ringDecrease;

    public List<GameObject> cameras = new List<GameObject>();

    //FPS
    public static float fps = 0.0f;
    public static float deltaStep = 0.0f;
    public static float deltaTime = 0.0f;
    float deltatime = 0.0f;

    void OnEnable()
    {
        instance = GetComponent<GameManager>();

        OnResume += Resume;
        OnPause += Pause;
    }

    void OnDisable()
    {
        OnResume -= Resume;
        OnPause -= Pause;
    }


    void Awake()
    {
        Application.targetFrameRate = 60;

        instance = GetComponent<GameManager>();

        audioSource = GetComponent<AudioSource>();

        ringEngineDebug = GetComponent<RingEngineDebug>();

        DontDestroyOnLoad(gameObject);

        //Load Settings
        if (File.Exists(settingsPath))
        {
            settings = FileManager.Load(settings, settingsPath);
        }
        else
        {
            settings = Settings.DefaultSettings();

            FileManager.Save(settings, settingsPath);
        }

        //Load Save Data
        if (File.Exists(saveDataFile))
        {
            saveData = FileManager.Load(saveData, saveDataPath);
        }
        else
        {
            FileManager.Save(saveData, saveDataPath);
        }
    }

    void Start()
    {

    }

    private void LateUpdate()
    {
        //if(player.GetComponentInChildren<Player>().stateMachine.currentStateName != "StateFallDead")
        //{
        //    try
        //    {
        //        if (cameras.Count == 0)
        //        {
        //            MainCamera.instance.enabled = true;
        //        }
        //        else
        //        {
        //            MainCamera.instance.enabled = false;
        //        }
        //    }
        //    catch
        //    {

        //    }
        //}
        //else
        //{
        //    MainCamera.instance.enabled = false;
        //}



        //if(Input.GetKey(KeyCode.LeftControl) && Input.GetKey(KeyCode.LeftAlt) && Input.GetKeyDown(KeyCode.D))
        //{
        //    if (ringEngineDebug.enabled)
        //    {
        //        ringEngineDebug.enabled = false;
        //    }
        //    else
        //    {
        //        ringEngineDebug.enabled = true;
        //    }
        //}
    }




    void Update()
    {

        //if(rings > 0)
        //{
        //    if (Time.time > ringDecrease + 1)
        //    {
        //        rings--;
        //        ringDecrease = Time.time;
        //    }
        //}





        switch (gameState)
        {
            case GameState.Loading:
                blackscreen.color = Color.clear;
                mixer.SetFloat("MasterVolume", -10);
                break;
            case GameState.MainMenu:

                mixer.SetFloat("EffectsVolume", settings.effectsVolume - 100);
                mixer.SetFloat("MusicVolume", settings.musicVolume - 100);
                mixer.SetFloat("VoiceVolume", settings.voiceVolume - 100);

                //postProcessingProfile.ambientOcclusion.enabled = settings.ambientOcclusion;
                //postProcessingProfile.motionBlur.enabled = settings.motionBlur;
                //postProcessingProfile.bloom.enabled = settings.bloom;
                //postProcessingProfile.colorGrading.enabled = settings.colorGrading;
                break;
            case GameState.Playing:
                if (Input.GetButtonDown(XboxButton.Start))
                {
                    OnPause();
                }
                break;
            case GameState.Paused:
                if (Input.GetButtonDown(XboxButton.Start))
                {
                    OnResume();
                }

                if (Input.GetButtonDown(XboxButton.A))
                {
                    switch (pauseMenu.index)
                    {
                        case 0:
                            OnResume();
                            break;
                        case 1:
                            OnResume();
                            string levelName = SceneManager.GetActiveScene().name;
                            LoadSceneWithLoading(levelName);
                            break;
                    }


                }
                break;
        }

        //Calculate FPS
        deltatime += (Time.deltaTime - deltatime) * 0.1f;
        fps = 1.0f / deltatime;
        deltaStep = Application.targetFrameRate / fps;
        deltaTime = deltaStep * Time.deltaTime;

        ////Music
        //if (!audioSource.isPlaying)
        //{
        //    audioSource.clip = musicLoop;
        //    audioSource.loop = true;
        //    audioSource.Play();
        //}

        //Screen Fade
        //if (fadeScreen)
        //{
        //    ScreenFadeOut();
        //}
        //else
        //{
        //    ScreenFadeIn();
        //}

        ////Audio Fade
        //if (fadeAudio)
        //{
        //    AudioFadeOut();
        //}
        //else
        //{
        //    AudioFadeIn();
        //}

        saveData.totalRings = rings;

        if (!saveData.achievements.Contains(Achievements.collected100Rings.ToString()))
        {
            if (saveData.totalRings >= 100)
            {
                achievementUI.Show(Achievements.achievements[Achievements.collected100Rings], settings.languageType);
                saveData.achievements += Achievements.collected100Rings + ",";
            }
        }
    }

    public bool ScreenFadeIn()
    {
        blackscreen.color = Color.Lerp(blackscreen.color, Color.clear, Time.deltaTime * screenFadeSpeed);

        return blackscreen.color == Color.clear;
    }

    public bool ScreenFadeOut()
    {
        blackscreen.color = Color.Lerp(blackscreen.color, Color.black, Time.deltaTime * screenFadeSpeed);

        return blackscreen.color == Color.black;
    }

    public void AudioFadeIn()
    {
        masterVolume = Mathf.Lerp(masterVolume, -10, audioFadeSpeed * Time.deltaTime);
        mixer.SetFloat("MasterVolume", masterVolume);
    }

    public void AudioFadeOut()
    {
        masterVolume = Mathf.Lerp(masterVolume, -80, audioFadeSpeed * Time.deltaTime);
        mixer.SetFloat("MasterVolume", masterVolume);
    }

    void SetTags()
    {

    }

    public void Pause()
    {
        Time.timeScale = 0;
        pauseMenu.gameObject.SetActive(true);
        gameState = GameState.Paused;
    }

    public void Resume()
    {
        Time.timeScale = 1;
        pauseMenu.gameObject.SetActive(false);
        gameState = GameState.Playing;
    }

    public void LoadSceneWithLoading(string sceneName)
    {
        sceneLoading = sceneName;
        gameState = GameState.Loading;
        SceneManager.LoadScene("Loading");
    }

    public void OnLoadingStart()
    {
        audioSource.PlayOneShot(loadingStart);
    }
    public void OnLoadingEnd()
    {
        audioSource.PlayOneShot(loadingEnd);
    }
}
