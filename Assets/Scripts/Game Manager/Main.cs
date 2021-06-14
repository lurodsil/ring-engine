using UnityEngine;
using UnityEngine.Audio;

//Project Settings
//Time/Fixed Timestep = 0.01
//Script Execution Order: XInput = -2; GroundInfo = -1;

[AddComponentMenu("Ring Engine/Main")]
public class Main : MonoBehaviour
{

    public static bool canControl;
    public bool debug;
    public static bool debugger;
    public static int lives = 3;
    public static bool getLife;

    public static Transform ringOrientation;

    public float gravity = -35;
    public static int rings { get; set; }
    public AudioClip startNormal;
    public AudioClip loopNormal;
    public AudioClip startFast;
    public AudioClip loopFast;
    public AudioClip startFastFX;
    public AudioClip loopFastFX;
    public float delay = 0.02f;
    public float normalToFastSpeed = 28;
    public float musicVolume = 0.8f;
    public Vector3 spawnPoint;
    public static Transform currentCamera;
    public static int specialRings;

    public AudioMixer mixer;

    AudioSource normal;
    AudioSource fast;
    AudioSource fastFX;

    float playerSpeed;

    void Awake()
    {
        // Player.transform.position = spawnPoint;
        DontDestroyOnLoad(gameObject);
    }

    // Use this for initialization
    void Start()
    {

        //ringOrientation = transform.GetChild(0);
        //     normal = gameObject.AddComponent<AudioSource> ();
        //fast = gameObject.AddComponent<AudioSource> ();
        //fastFX = gameObject.AddComponent<AudioSource> ();


        //if (startNormal) {
        //	normal.playOnAwake = false;
        //	normal.clip = loopNormal;
        //	normal.loop = true;
        //	normal.PlayOneShot (startNormal);
        //	normal.PlayDelayed (startNormal.length - delay);
        //}

        //if (startFast) {
        //	fast.playOnAwake = false;
        //	fast.clip = loopFast;
        //	fast.loop = true;
        //	fast.PlayOneShot (startFast);
        //	fast.PlayDelayed (startFast.length - delay);
        //}

        //if (startFastFX) {
        //	fastFX.playOnAwake = false;
        //	fastFX.clip = loopFastFX;
        //	fastFX.loop = true;
        //	fastFX.PlayOneShot (startFastFX);
        //	fastFX.PlayDelayed (startFastFX.length - delay);
        //	fastFX.volume = 0;
        //}

        //Cursor.visible = false;	
        Physics.gravity = new Vector3(0, gravity, 0);
        Application.targetFrameRate = 60;

        canControl = false;


    }

    // Update is called once per frame
    void Update()
    {
        debugger = debug;


        //if (Player.boost) {
        //	normal.volume = 0;
        //	fast.volume = 0;
        //	fastFX.volume = musicVolume;
        //} else if (Player.absoluteVelocity > 35) {
        //	normal.volume = 0;
        //	fast.volume = musicVolume;
        //	fastFX.volume = 0;
        //} else if (Player.absoluteVelocity < 25){
        //	normal.volume = musicVolume;
        //	fast.volume = 0;
        //	fastFX.volume = 0;
        //}

        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Application.LoadLevel(0);
        }

    }

    void LateUpdate()
    {
        //ringOrientation.Rotate(0, -90 * Time.deltaTime, 0);
    }

    void Reset()
    {
        Physics.gravity = new Vector3(0, gravity, 0);
    }

    public void EnablePlayerMovement()
    {
        canControl = true;
    }

    public void SetTags()
    {

    }
}
