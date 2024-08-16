using UnityEngine;

public class GoalRing : GenerationsObject
{
    public bool IsMessageOn = false;
    public float Radius = 4f;
    public Vector3 ResultPosition;
    public float SENumber = 6f;
    public float AddRange = 0f;
    public float BossKeyType = 3f;
    public bool IsMessageON = false;
    public Transform goalRingMesh;
    public AudioClip sound;
    public bool get;
    private AudioSource audioSource;

    private void Awake()
    {
        OnPlayerTriggerEnter!.AddListener(GoalRingStart);
    }

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();

    }

    private void Update()
    {
        if (get)
        {
            transform.localScale = Vector3.Lerp(transform.localScale, Vector3.zero, 3 * Time.deltaTime);

            if (transform.localScale.magnitude < 0.01f)
            {
                if (GameManager.instance.ScreenFadeOut())
                {
                    GameManager.instance.LoadSceneWithLoading("Test Stage");
                }
            }
        }

        goalRingMesh.Rotate(0, -90 * Time.deltaTime, 0);
    }

    private void GoalRingStart()
    {
        audioSource.Stop();
        audioSource.PlayOneShot(sound);
        get = true;
        player.stateMachine.ChangeState(State, gameObject);
        player.rigidbody.velocity = Vector3.zero;
        GameManager.instance.firstTimeLoad = true;
        GameManager.instance.lastCheckpoint = -1;
        Timer.PauseTimer();
    }

    #region State
    void StateStart()
    {

    }
    void State()
    {

    }
    void StateEnd()
    {

    }
    #endregion 

}