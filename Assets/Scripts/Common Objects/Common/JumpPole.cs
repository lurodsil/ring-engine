using UnityEngine;

public class JumpPole : GenerationsObject
{
    public float AddMaxVelocity = 0f;
    public float AddMinVelocity = 0f;
    public AudioClip jumpPoleSound;

    private AudioSource audioSource;
    private Animator animator;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
    }

    #region State Jump Pole
    private void StateJumpPoleStart()
    {
        player.transform.forward = transform.forward;

        player.rigidbody.velocity = Vector3.up * AddMaxVelocity;
    }
    private void StateJumpPole()
    {
        if(player.rigidbody.velocity.y < 10)
        {
            player.stateMachine.ChangeState(player.StateFall, gameObject);
        }
             
    }
    private void StateJumpPoleEnd()
    {
    }
    #endregion

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(GameTags.playerTag))
        {
            player = other.GetComponent<Player>();

            if(player.rigidbody.velocity.y < 0)
            {
                player.stateMachine.ChangeState(StateJumpPole, gameObject);
                audioSource.PlayOneShot(jumpPoleSound);
                animator.SetTrigger("Spring Pole");
            }
        }
    }
}