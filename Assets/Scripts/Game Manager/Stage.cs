using UnityEngine;
using UnityEngine.UI;

public class Stage : MonoBehaviour
{
    public string stageName = "test stage";
    public string act = "act 1";

    public PointMarker[] checkpoints;
    public RedMedal[] redMedals;
    public Transform spawnPoint;

    public MusicVelocityModes musicVelocityModes;

    public bool playMusicOnStart;
    [SerializeField] float musicVolume = 0.8f;
    [SerializeField] float musicVolumeUnderwater = 0.2f;

    public float loopDelayCorrection = 0;
    public AudioClip
        start,
        loop,
        startFast,
        loopFast,
        startBoost,
        loopBoost,
        tornadoTheme;

    private AudioSource
        audioSource,
        audioSourceFast,
        audioSourceBoost;

    public AudioClip bossBattle;

    public GameObject goalring;

    public static Player player;

    public Text stageNameUI;
    public Text actUI;

    public void StartBossBattle()
    {
        audioSource.Stop();
        audioSourceFast.Stop();
        audioSourceBoost.Stop();

        audioSource.clip = bossBattle;
        audioSource.Play();
    }

    private void Awake()
    {
        GameManager.instance.currentStage = this;

        if (GameManager.instance.firstTimeLoad)
        {
            Load();


        }
        else
        {
            Reload();
        }
    }

    private void OnValidate()
    {
        if(stageNameUI)
        {
            stageNameUI.text = stageName;
            actUI.text = act;
        }
        
    }

    private void OnDisable()
    {
        GameManager.OnPause -= audioSource.Pause;
        GameManager.OnPause -= audioSourceFast.Pause;
        GameManager.OnPause -= audioSourceBoost.Pause;
        GameManager.OnResume -= audioSource.UnPause;
        GameManager.OnResume -= audioSourceFast.UnPause;
        GameManager.OnResume -= audioSourceBoost.UnPause;
    }

    public void BossDied()
    {
        audioSource.Stop();
        Start();
        goalring.SetActive(true);
    }

    private void OnEnable()
    {
        //GameManager.OnPause += audioSource.Pause;
        //GameManager.OnPause += audioSourceFast.Pause;
        //GameManager.OnPause += audioSourceBoost.Pause;
        //GameManager.OnResume += audioSource.UnPause;
        //GameManager.OnResume += audioSourceFast.UnPause;
        //GameManager.OnResume += audioSourceBoost.UnPause;
    }

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSourceFast = gameObject.AddComponent<AudioSource>();
        audioSourceBoost = gameObject.AddComponent<AudioSource>();

        GameManager.instance.OnLoadingEnd();

        InitAudio();

        currentMode = MusicVelocityModes.Normal;
        lastMode = currentMode;
    }

    MusicVelocityModes currentMode;
    MusicVelocityModes lastMode;

    [SerializeField] float modeChangeDelay = 1f;
    [SerializeField] float fadeSpeed = 2.5f;

    MusicVelocityModes detectedMode;
    MusicVelocityModes pendingMode;


    float modeTimer;


    void DetectMusicMode()
    {
        if (player.isBoosting)
            detectedMode = MusicVelocityModes.Boost;
        else if (player.absoluteVelocity > 30)
            detectedMode = MusicVelocityModes.Fast;
        else
            detectedMode = MusicVelocityModes.Normal;
    }

    void UpdateMusicState()
    {
        if (detectedMode != pendingMode)
        {
            pendingMode = detectedMode;
            modeTimer = 0f;
        }
        else
        {
            modeTimer += Time.deltaTime;

            if (modeTimer >= modeChangeDelay && currentMode != pendingMode)
            {
                currentMode = pendingMode;
            }
        }
    }

    void UpdateMusicBlend()
    {
        float baseVolume = GameManager.instance.underwaterManager.underwater
            ? musicVolumeUnderwater
            : musicVolume;

        Fade(audioSource, currentMode == MusicVelocityModes.Normal ? baseVolume : 0);
        Fade(audioSourceFast, currentMode == MusicVelocityModes.Fast ? musicVolume : 0);
        Fade(audioSourceBoost, currentMode == MusicVelocityModes.Boost ? musicVolume : 0);
    }

    void Fade(AudioSource source, float target)
    {
        source.volume = Mathf.MoveTowards(
            source.volume,
            target,
            fadeSpeed * Time.deltaTime
        );
    }


    void InitAudio()
    {
        if (GameManager.instance.tornadoGameplay)
        {
            SetupAudioSource(audioSource, start, tornadoTheme);
            return;
        }

        SetupAudioSource(audioSource, start, loop);
        SetupAudioSource(audioSourceFast, startFast, loopFast);
        SetupAudioSource(audioSourceBoost, startBoost, loopBoost);
    }


    void Update()
    {
        if (GameManager.instance.underwaterManager.underwaterAlertState == 4)
        {
            StopAllMusic();
            return;
        }

        DetectMusicMode();
        UpdateMusicState();
        UpdateMusicBlend();
    }



    void StopAllMusic()
    {
        audioSource.Stop();
        audioSourceFast.Stop();
        audioSourceBoost.Stop();
    }


    void ApplyMusicMix()
    {
        float baseVolume = GameManager.instance.underwaterManager.underwater
            ? musicVolumeUnderwater
            : musicVolume;

        audioSource.volume = 0;
        audioSourceFast.volume = 0;
        audioSourceBoost.volume = 0;

        switch (currentMode)
        {
            case MusicVelocityModes.Normal:
                audioSource.volume = baseVolume;
                break;

            case MusicVelocityModes.Fast:
                if (loopFast)
                    audioSourceFast.volume = musicVolume;
                break;

            case MusicVelocityModes.Boost:
                if (loopBoost)
                    audioSourceBoost.volume = musicVolume;
                break;
        }
    }


    private void SetupAudioSource(AudioSource audioSource, AudioClip start, AudioClip loop)
    {
        audioSource.clip = loop;
        audioSource.outputAudioMixerGroup = GameManager.instance.mixer.FindMatchingGroups("Music")[0];
        audioSource.playOnAwake = false;
        audioSource.loop = true;
        audioSource.volume = 0;
        audioSource.dopplerLevel = 0;
        if (start)
        {
            audioSource.PlayOneShot(start);
            audioSource.PlayDelayed(start.length + loopDelayCorrection);
        }
        else
        {
            audioSource.Play();
        }
    }

    private void Load()
    {
        player = Instantiate(GameManager.instance.player, spawnPoint.transform.position, spawnPoint.transform.rotation).GetComponentInChildren<Player>();
        GameManager.instance.foundRedMedals.Clear();
        GameManager.instance.redStars = 0;
        GameManager.instance.rings = 0;
        Timer.ResetTimer();
        Timer.PauseTimer();
    }

    private void Reload()
    {
        //GameManager.instance.rings = 0;

        //for (int i = 0; i < checkpoints.Length; i++)
        //{
        //    if (GameManager.instance.activeCheckpoints.Contains(checkpoints[i].PointMarkerID))
        //    {
        //        checkpoints[i].active = false;
        //    }

        //    if (checkpoints[i].PointMarkerID == GameManager.instance.lastCheckpoint)
        //    {
        //        spawnPoint = checkpoints[i].transform;
        //    }
        //}

        //player = Instantiate(GameManager.instance.player, spawnPoint.transform.position, spawnPoint.transform.rotation).GetComponentInChildren<Player>();

        //for (int i = 0; i < redMedals.Length; i++)
        //{
        //    if (GameManager.instance.foundRedMedals.Contains(redMedals[i].MedalID))
        //    {
        //        redMedals[i].gameObject.SetActive(false);
        //    }

        //}
    }

    public void StartTornado()
    {
        audioSource.Stop();
    }
}
