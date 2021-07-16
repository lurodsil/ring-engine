using UnityEngine;

public class AdlibTrickJump : RingEngineObject
{
    public float ImpulseSpeedOnBoost = 41f;
    public float ImpulseSpeedOnNormal = 41f;
    public bool IsTo3D = true;
    public float OutOfControl = 3.5f;
    private AudioSource audioSource;
    public Transform startPoint;
    public AudioClip sound;
    float duration;
    float outOfControl;
    string seed = "";
    char[] seedArray;
    char[] buttonArray;
    int index = -1;
    public AudioClip success;
    public AudioClip fail;


    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    #region State Jump Board
    void StateAdlibTrickJumpStart()
    {


        seed = "";

        for (int i = 0; i < 4; i++)
        {
            seed += Random.Range(0, 4);
        }

        EventManager.TrickPanelRainbowStart(seed);

        print(seed);

        seedArray = seed.ToCharArray();
        buttonArray = new char[4] { ' ',' ',' ',' '};
        index = -1;

        Time.timeScale = 0.2f;

        player.transform.position = startPoint.position;

        player.transform.forward = startPoint.forward;

        if (player.isBoosting)
        {
            player.rigidbody.velocity = startPoint.forward * ImpulseSpeedOnBoost;
        }
        else
        {
            player.rigidbody.velocity = startPoint.forward * ImpulseSpeedOnNormal;
        }

        outOfControl = player.stateMachine.lastStateTime + OutOfControl;
    }
    void StateAdlibTrickJump()
    {
        if (Input.GetButtonDown(XboxButton.A))
        {
            index++;
            buttonArray[index] = '0';
            print(buttonArray[0] +" "+ buttonArray[1] + " " + buttonArray[2] + " " + buttonArray[3]);
        }
        if (Input.GetButtonDown(XboxButton.B))
        {
            index++;
            buttonArray[index] = '1';
            print(buttonArray[0] + " " + buttonArray[1] + " " + buttonArray[2] + " " + buttonArray[3]);
        }
        if (Input.GetButtonDown(XboxButton.X))
        {
            index++;
            buttonArray[index] = '2';
            print(buttonArray[0] + " " + buttonArray[1] + " " + buttonArray[2] + " " + buttonArray[3]);
        }
        if (Input.GetButtonDown(XboxButton.Y))
        {
            index++;
            buttonArray[index] = '3';
            print(buttonArray[0] + " " + buttonArray[1] + " " + buttonArray[2] + " " + buttonArray[3]);
        }

        if(index >= 0)
        {
            if (buttonArray[index] != seedArray[index])
            {
                print("fail");
                audioSource.PlayOneShot(fail);

                player.stateMachine.ChangeState(player.StateTransition, gameObject);
            }
            else
            {
                if (index == 3)
                {
                    print("success");
                    audioSource.PlayOneShot(success);

                    player.SendMessage("TrickJumpSuccess");
                    player.rigidbody.AddForce(transform.up * 20, ForceMode.Impulse);
                    player.stateMachine.ChangeState(player.StateTransition, gameObject);
                }
            }
        }
        

        

        if (Time.time > player.stateMachine.lastStateTime  + 0.6f)
        {
            player.stateMachine.ChangeState(player.StateTransition, gameObject);
        }
    }
    void StateAdlibTrickJumpEnd()
    {
        Time.timeScale = 1f;

        EventManager.TrickPanelRainbowEnd();
    }
    #endregion

    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        GizmosExtension.DrawTrajectory(startPoint.position, startPoint.forward, ImpulseSpeedOnNormal, 2);
        Gizmos.color = Color.blue;
        GizmosExtension.DrawTrajectory(startPoint.position, startPoint.forward, ImpulseSpeedOnBoost, 2);

        Gizmos.color = Color.red;
        GizmosExtension.DrawTrajectory(startPoint.position, startPoint.forward, ImpulseSpeedOnNormal, OutOfControl);
        GizmosExtension.DrawTrajectory(startPoint.position, startPoint.forward, ImpulseSpeedOnBoost, OutOfControl);
    }

    public override void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(GameTags.playerTag))
        {
            audioSource.PlayOneShot(sound);

            player = other.GetComponent<Player>();

            player.stateMachine.ChangeState(StateAdlibTrickJump, gameObject);
        }
    }
}