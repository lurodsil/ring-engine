using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PlayRandomSoundOnAwake : MonoBehaviour
{
    public AudioClip[] sounds;

    void Awake()
    {
        GetComponent<AudioSource>().PlayOneShot(sounds[Random.Range(0, sounds.Length - 1)]);
    }
}
