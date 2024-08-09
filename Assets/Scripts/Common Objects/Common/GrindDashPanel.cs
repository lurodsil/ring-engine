using UnityEngine;

public class GrindDashPanel : CommonObject
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
        OnPlayerTriggerEnter.AddListener(GrindDash);
    }

    public void GrindDash()
    {
        audio.PlayOneShot(dash);
        player.transform.forward = transform.forward;
        player.rigidbody.AddForce(player.rigidbody.velocity.normalized * Speed, ForceMode.Impulse);
    }
}