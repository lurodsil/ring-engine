using UnityEngine;

public class MotoraAudio : MonoBehaviour
{

    public AudioSource audioSource, audioSourceLoop;

    public AudioClip brake;
    public AudioClip excite;
    public AudioClip clash;
    public AudioClip move;
    public AudioClip rush;
    public AudioClip rushLoop;
    public AudioClip seek;
    public AudioClip store;
    public AudioClip storeLoop;
    public AudioClip[] damages;
    public AudioClip[] explosions;


    void Brake()
    {
        audioSourceLoop.Stop();
        audioSource.PlayOneShot(brake);
    }

    void Clash()
    {
        audioSourceLoop.Stop();
        audioSource.PlayOneShot(clash);
    }

    void Seek()
    {
        audioSource.PlayOneShot(seek);
    }
    void Rush()
    {
        audioSourceLoop.Stop();
        audioSourceLoop.clip = rushLoop;
        audioSource.PlayOneShot(rush);
        audioSourceLoop.Play();
    }
    void Store()
    {
        audioSource.PlayOneShot(store);
        audioSourceLoop.clip = storeLoop;
        audioSourceLoop.PlayDelayed(store.length);
    }

    void Excite()
    {
        audioSourceLoop.Stop();
        audioSource.PlayOneShot(excite);
    }

    void IdleMove()
    {
        if (!audioSourceLoop.isPlaying)
        {
            audioSourceLoop.clip = move;
            audioSourceLoop.Play();
        }
    }

    void StateDamageStart()
    {
        audioSourceLoop.Stop();
        audioSource.Stop();
        audioSource.PlayOneShot(damages[Random.Range(0, damages.Length - 1)]);
    }

    void StateDestroyStart()
    {

    }
}
