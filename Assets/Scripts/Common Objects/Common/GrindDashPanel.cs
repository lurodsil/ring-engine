using UnityEngine;

public class GrindDashPanel : RingEngineObject
{
    public bool IsFront = true;
    public bool IsStartVelocityConstant = true;
    public float OutOfControl = 2.5f;

    public float Speed = 60f;

    public AudioClip dash;
    new private AudioSource audio;

    private void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    public override void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(GameTags.playerTag))
        {
            player = other.GetComponent<Player>();

            audio.PlayOneShot(dash);

            player.transform.forward = transform.forward;

            player.velocity = Speed;
        }
    }
}