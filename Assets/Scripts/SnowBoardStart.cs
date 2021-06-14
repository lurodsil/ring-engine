using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SnowBoardStart : GenerationsObject
{
    public bool canCancelState = false;
    public GameObject snowboard;
    public AudioClip boardGet;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (!snowboard.activeSelf && !player.isSnowboarding)
        {
            snowboard.SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(GameTags.playerTag))
        {
            player = other.GetComponent<Player>();

            if (!player.isSnowboarding)
            {
                audioSource.PlayOneShot(boardGet);
                snowboard.SetActive(false);
                player.canCancelState = canCancelState;
                player.stateMachine.ChangeState(player.StateSnowBoard);
            }
        }
    }
}
