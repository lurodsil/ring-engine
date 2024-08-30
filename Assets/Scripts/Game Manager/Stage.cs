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
        stageNameUI.text = stageName;
        actUI.text = act;
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
    }

    void Update()
    {
        if (GameManager.instance.underwaterManager.underwaterAlertState == 4)
        {
            audioSource.Stop();
            audioSourceFast.Stop();
            audioSourceBoost.Stop();
        }
        else if (playMusicOnStart && !audioSource.isPlaying)
        {
            if (GameManager.instance.tornadoGameplay)
            {
                SetupAudioSource(audioSource, start, tornadoTheme);
            }
            else
            {
                SetupAudioSource(audioSource, start, loop);
                SetupAudioSource(audioSourceFast, startFast, loopFast);
                SetupAudioSource(audioSourceBoost, startBoost, loopBoost);
            }
            
        }

        if (player.isBoosting == true)
        {
            musicVelocityModes = MusicVelocityModes.Boost;
        }
        else if (player.absoluteVelocity > 30)
        {
            musicVelocityModes = MusicVelocityModes.Fast;
        }
        else
        {
            musicVelocityModes = MusicVelocityModes.Normal;
        }


            switch (musicVelocityModes)
            {
                case MusicVelocityModes.Normal:
                    if (GameManager.instance.underwaterManager.underwater)
                    {
                        audioSource.volume = musicVolumeUnderwater;
                    }
                    else
                    {
                        audioSource.volume = musicVolume;

                    }
                    audioSourceFast.volume = 0;
                    audioSourceBoost.volume = 0;
                    break;
                case MusicVelocityModes.Fast:
                    if (loopFast)
                    {
                        audioSource.volume = 0;
                        audioSourceFast.volume = musicVolume;
                        audioSourceBoost.volume = 0;
                    }
                    break;
                case MusicVelocityModes.Boost:
                    if (loopBoost)
                    {
                        audioSource.volume = 0;
                        audioSourceFast.volume = 0;
                        audioSourceBoost.volume = musicVolume;
                    }
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
        GameManager.instance.rings = 0;

        for (int i = 0; i < checkpoints.Length; i++)
        {
            if (GameManager.instance.activeCheckpoints.Contains(checkpoints[i].PointMarkerID))
            {
                checkpoints[i].active = false;
            }

            if (checkpoints[i].PointMarkerID == GameManager.instance.lastCheckpoint)
            {
                spawnPoint = checkpoints[i].transform;
            }
        }

        player = Instantiate(GameManager.instance.player, spawnPoint.transform.position, spawnPoint.transform.rotation).GetComponentInChildren<Player>();

        for (int i = 0; i < redMedals.Length; i++)
        {
            if (GameManager.instance.foundRedMedals.Contains(redMedals[i].MedalID))
            {
                redMedals[i].gameObject.SetActive(false);
            }

        }
    }

    public void StartTornado()
    {
        audioSource.Stop();
    }
}
