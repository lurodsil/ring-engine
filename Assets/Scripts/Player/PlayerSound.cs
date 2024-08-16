using UnityEngine;
using UnityEngine.Audio;

[AddComponentMenu("Ring Engine/Player/Player Sound")]
[RequireComponent(typeof(Player))]
public class PlayerSound : MonoBehaviour
{

    //Components
    public AudioSource audioSource;
    public AudioSource footstepAaudioSource;
    public AudioSource boardAudioSource;
    public AudioSource boostAudioSource;
    public AudioSource skydiveAudioSource;
    public AudioMixerGroup audioMixerGroup;
    private Player player;

    public GroundMaterial defaultMaterial;

    public GroundMaterial[] groundMaterials;

    public AudioClip allRight;
    public AudioClip jumpSound;
    public AudioClip ballSound;
    public AudioClip landSound;
    public AudioClip grindStart;
    public AudioClip grindSound;
    public AudioClip homingStart;
    public AudioClip lostRing;
    public AudioClip stompStart;
    public AudioClip stompLand;
    public AudioClip jumpVoice;
    public AudioClip hurt;
    public AudioClip boostStart1;
    public AudioClip boostStart2;
    public AudioClip boostStart3;
    public AudioClip boostLoop;
    public AudioClip boostStartSuper1;
    public AudioClip boostStartSuper2;
    public AudioClip boostStartSuper3;
    public AudioClip boostLoopSuper;
    public AudioClip die;
    public AudioClip bubbleBreath;
    public AudioClip drift;
    public AudioClip slidingStart;
    public AudioClip sliding;
    public AudioClip quickStep;
    public AudioClip powerBrake;
    public AudioClip fallDead;
    public AudioClip spinDash;
    public AudioClip spinDashRelease;
    public AudioClip diveWind;
    public AudioClip rollStart;
    public AudioClip wallStick;
    public AudioClip changeStart;

    public AudioClip boardNormal;
    public AudioClip boardDrift;
    public AudioClip boardTrick;
    public AudioClip boardJump;
    public AudioClip boardLand;

    float lastTimePlayed;

    //GroundInfo groundInfo;
    new string tag;

    void StateSnowBoardJumpStart()
    {
        boardAudioSource.Stop();
        audioSource.PlayOneShot(boardJump);
    }
    void StateSnowBoardFallStart()
    {
        boardAudioSource.Stop();
    }

    void StateSnowBoardFallEnd()
    {
        audioSource.PlayOneShot(boardLand);
        boardAudioSource.clip = boardNormal;
        boardAudioSource.Play();
    }

    void StateSnowBoardDriftStart()
    {
        boardAudioSource.clip = boardDrift;
        boardAudioSource.Play();
    }

    void StateSnowBoardDriftEnd()
    {
        boardAudioSource.clip = boardNormal;
        boardAudioSource.Play();
    }

    void StateSnowBoardStart()
    {
        boardAudioSource.clip = boardNormal;
        boardAudioSource.Play();
    }
    void StateSnowBoardEnd()
    {
        if (player.isSnowboarding == false)
        {
            boardAudioSource.Stop();
        }
    }

    void StateSnowBoardGrindStart()
    {
        StateGrindStart();
    }

    
    private void StateSkydiveStart()
    {
        skydiveAudioSource.Play();
    }
 
    private void StateSkydiveEnd()
    {
        skydiveAudioSource.Stop();

    }

    void StateSnowBoardGrindEnd()
    {
        StateGrindEnd();
    }

    void StateJumpTriggerStart()
    {
        if (player.isSnowboarding)
        {
            boardAudioSource.PlayOneShot(boardTrick);
        }         
    }

    private void OnEnable()
    {
        GameManager.OnPause += audioSource.Pause;
        GameManager.OnPause += boostAudioSource.Pause;
        GameManager.OnResume += audioSource.UnPause;
        GameManager.OnResume += boostAudioSource.UnPause;
    }

    private void OnDisable()
    {
        GameManager.OnPause -= audioSource.Pause;
        GameManager.OnPause -= boostAudioSource.Pause;
        GameManager.OnResume -= audioSource.UnPause;
        GameManager.OnResume -= boostAudioSource.UnPause;
    }
    void Awake()
    {
        //audioSource = gameObject.GetComponent<AudioSource>();
        //audioSource.loop = false;
        //audioSource.outputAudioMixerGroup = audioMixerGroup;
        //audioSource.dopplerLevel = 0;
        //audioSource.maxDistance = 100;
        //audioSource.minDistance = 2;
        //audioSource.spatialBlend = 1;
        //audioSource.priority = 128;

        //groundInfo = GetComponent<GroundInfo>();
        player = GetComponent<Player>();
    }

    void StateChangeToSuperSonicStart()
    {
        audioSource.PlayOneShot(changeStart);
    }

    public void StateBoostStart()
    {
        boostAudioSource.volume = 0.3f;
        boostAudioSource.Stop();
        if (!player.isSuper)
        {
            boostAudioSource.PlayOneShot(boostStart1);
            boostAudioSource.PlayOneShot(boostStart2);
            boostAudioSource.PlayOneShot(boostStart3);
            boostAudioSource.clip = boostLoop;
        }
        else
        {
            boostAudioSource.PlayOneShot(boostStartSuper1);
            boostAudioSource.PlayOneShot(boostStartSuper2);
            boostAudioSource.PlayOneShot(boostStartSuper3);
            boostAudioSource.clip = boostLoopSuper;
        }        
        boostAudioSource.loop = true;        
        boostAudioSource.Play();
    }


    void Update()
    {
        if (player.stateMachine.currentStateName == "StateGrind")
        {
            audioSource.pitch = 0.3f + player.rigidbody.velocity.magnitude / 50;
        }

        if (!player.isBoosting)
        {
            boostAudioSource.volume = Mathf.Lerp(boostAudioSource.volume, 0, 10 * Time.deltaTime);
            if (boostAudioSource.volume < 0.01f)
            {
                boostAudioSource.Stop();
            }
        }

        if (player.stateMachine.currentStateName == "StateSpindash")
        {
            if (Input.GetButtonDown(XboxButton.Y))
            {
                audioSource.Stop();
                audioSource.PlayOneShot(spinDash);
                audioSource.pitch = 1 + ((player.velocity - 30) / 90);
            }
        }
    }

    void StateFallDeadStart()
    {
        if (!player.drown)
        {
            audioSource.PlayOneShot(fallDead);
        }
    }

    void StateSpindashStart()
    {
        audioSource.PlayOneShot(spinDash);
    }

    void StateSpindashEnd()
    {
        audioSource.Stop();
        audioSource.pitch = 1;
        audioSource.PlayOneShot(spinDashRelease);
    }

    void StateRollStart()
    {
        if (player.stateMachine.lastStateName != "StateSpindash")
        {
            audioSource.PlayOneShot(rollStart);
        }
    }

    void StateBrakeStart()
    {
        if (player.absoluteVelocity < 50 && player.absoluteVelocity > 21)
        {
            if (player.IsGrounded() && player.GetGroundInformation().collider.sharedMaterial)
            {
                foreach (GroundMaterial gm in groundMaterials)
                {
                    if (player.GetGroundInformation().collider.sharedMaterial.name.Contains(gm.physicMaterial.name))
                    {
                        audioSource.PlayOneShot(gm.brake);
                    }
                }
            }
            else
            {
                audioSource.PlayOneShot(defaultMaterial.brake);
            }
        }
        else if (player.absoluteVelocity > 50)
        {
            audioSource.PlayOneShot(powerBrake);
        }
    }

    void StateDriftStart()
    {
        audioSource.clip = drift;
        audioSource.loop = true;
        audioSource.Play();
    }

    void StateDriftEnd()
    {
        audioSource.clip = null;
        audioSource.loop = false;
        audioSource.Stop();
    }

    void StateSlidingStart()
    {
        audioSource.clip = sliding;
        audioSource.loop = true;
        audioSource.PlayDelayed(slidingStart.length);
        audioSource.PlayOneShot(slidingStart);
    }

    void StateSlidingEnd()
    {
        audioSource.clip = null;
        audioSource.loop = false;
        
    }

    void StateWallJumpEnd()
    {
        if (player.stateMachine.nextStateName == "StateFall")
        {
            StateJumpStart();
        }


    }

    void StateDoubleJumpEnd()
    {
        audioSource.PlayOneShot(jumpSound);
    }

    void StateWallJumpStart()
    {
        audioSource.PlayOneShot(wallStick);
    }

    void StateQuickstepLeftStart()
    {
        audioSource.PlayOneShot(quickStep);
    }

    void StateQuickstepRightStart()
    {
        audioSource.PlayOneShot(quickStep);
    }

    void StateJumpStart()
    {
        audioSource.PlayOneShot(jumpSound);
    }

    void StateBallStart()
    {
        audioSource.PlayOneShot(ballSound);
    }

    void StateAirboostStart()
    {
        audioSource.PlayOneShot(boostStart1);
    }

    void Land()
    {
        if (player.IsGrounded() && player.GetGroundInformation().collider.sharedMaterial)
        {
            foreach (GroundMaterial gm in groundMaterials)
            {
                if (!footstepAaudioSource.isPlaying && player.GetGroundInformation().collider.sharedMaterial.name.Contains(gm.physicMaterial.name))
                {
                    footstepAaudioSource.PlayOneShot(gm.land);
                }
            }
        }
        else
        {
            footstepAaudioSource.PlayOneShot(defaultMaterial.land);
        }
    }

    void Footstep()
    {
        if(Time.time > lastTimePlayed + 0.01f)
        {
            if (player.IsGrounded() && player.GetGroundInformation().collider.sharedMaterial)
            {
                foreach (GroundMaterial gm in groundMaterials)
                {
                    if (player.GetGroundInformation().collider.sharedMaterial.name.Contains(gm.physicMaterial.name))
                    {
                        lastTimePlayed = Time.time;
                        footstepAaudioSource.PlayOneShot(gm.footstep[Random.Range(0, gm.footstep.Length - 1)]);
                    }
                }
            }
            else
            {
                lastTimePlayed = Time.time;
                footstepAaudioSource.PlayOneShot(defaultMaterial.footstep[Random.Range(0, defaultMaterial.footstep.Length - 1)]);
            }
        }

        
    }

   

    void StateGrindJumpStart()
    {
        StateJumpStart();
    }

    void StateGrindSwitchLeftStart()
    {
        audioSource.PlayOneShot(jumpSound);
    }

    void StateGrindSwitchRightStart()
    {
        audioSource.PlayOneShot(jumpSound);
    }


    void StateGrindStart()
    {
        audioSource.PlayOneShot(grindStart);

        audioSource.clip = grindSound;

        audioSource.Play();

        audioSource.loop = true;
    }

    void StateBubbleBreathStart()
    {
        audioSource.PlayOneShot(bubbleBreath);
    }

    void StateGrindEnd()
    {
        audioSource.loop = false;

        audioSource.pitch = 1;

        audioSource.Stop();
    }

    void StateHomingStart()
    {
        audioSource.PlayOneShot(homingStart);
    }

    void StateHurtStart()
    {
        audioSource.PlayOneShot(lostRing);
        audioSource.PlayOneShot(hurt);
    }

    private void GrindDamage()
    {
        StateHurtStart();
    }

    void StateStompStart()
    {
        audioSource.PlayOneShot(stompStart);
    }

    void StateStompEnd()
    {
        audioSource.PlayOneShot(stompLand);
    }

    void StateDieStart()
    {
        audioSource.PlayOneShot(die);
    }

    void StatePulleyStart()
    {
        //audioSource.PlayOneShot(allRight);
    }

    void StateHurdleStart()
    {
        audioSource.PlayOneShot(jumpSound);
    }
}
