using UnityEngine;

public class EnemyEFighterAudio : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip footstep;
    public AudioClip land;
    public AudioClip punch;
    public AudioClip beep01;
    public AudioClip beep02;
    public AudioClip down;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void StateSeekStart()
    {
        audioSource?.PlayOneShot(beep01);
    }

    public void TakeDamage()
    {
        audioSource.PlayOneShot(down);
    }

    void StateLookStart()
    {
        audioSource.PlayOneShot(beep02);
    }

    void Footstep()
    {
        audioSource.PlayOneShot(footstep);
    }

    public void Land()
    {
        audioSource.PlayOneShot(land);
    }

    public void Punch()
    {
        audioSource.PlayOneShot(punch);
    }
}
