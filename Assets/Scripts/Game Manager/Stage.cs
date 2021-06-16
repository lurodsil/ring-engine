using UnityEngine;
using UnityEngine.UI;

public class Stage : MonoBehaviour
{
    public string stageName = "test stage";
    public string act = "act 1";


    public PointMarker[] checkpoints;
    public Transform spawnPoint;

    public MusicVelocityModes musicVelocityModes;

    public bool playMusicOnStart;

    public AudioClip
        start,
        loop,
        startFast,
        loopFast,
        startBoost,
        loopBoost;

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
        if (GameManager.instance.firstTimeLoad)
        {
            Load();
            GameManager.instance.firstTimeLoad = false;
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

        GameManager.instance.activeCheckpoints = new bool[checkpoints.Length];

        for (int i = 0; i < checkpoints.Length; i++)
        {
            GameManager.instance.activeCheckpoints[i] = checkpoints[i].active;
        }
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

        if (playMusicOnStart)
        {
            SetupAudioSource(audioSource, start, loop);
            SetupAudioSource(audioSourceFast, startFast, loopFast);
            SetupAudioSource(audioSourceBoost, startBoost, loopBoost);
        }
    }

    // Update is called once per frame
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
            SetupAudioSource(audioSource, start, loop);
            SetupAudioSource(audioSourceFast, startFast, loopFast);
            SetupAudioSource(audioSourceBoost, startBoost, loopBoost);
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
                audioSource.volume = 1;
                audioSourceFast.volume = 0;
                audioSourceBoost.volume = 0;
                break;
            case MusicVelocityModes.Fast:
                if (loopFast)
                {
                    audioSource.volume = 0;
                    audioSourceFast.volume = 1;
                    audioSourceBoost.volume = 0;
                }
                break;
            case MusicVelocityModes.Boost:
                if (loopBoost)
                {
                    audioSource.volume = 0;
                    audioSourceFast.volume = 0;
                    audioSourceBoost.volume = 1;
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
            audioSource.PlayDelayed(start.length);
        }
        else
        {
            audioSource.Play();
        }
    }

    private void Load()
    {
        //player = Instantiate(GameManager.instance.player, spawnPoint).GetComponentInChildren<Player>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    private void Reload()
    {
        for (int i = 0; i < checkpoints.Length; i++)
        {
            if (GameManager.instance.activeCheckpoints[i])
            {
                checkpoints[i].Activate();
            }

            if (checkpoints[i].PointMarkerID == GameManager.instance.lastCheckpoint)
            {
                spawnPoint = checkpoints[i].transform;
            }

        }

        player = Instantiate(GameManager.instance.player, spawnPoint).GetComponentInChildren<Player>();
    }
}
