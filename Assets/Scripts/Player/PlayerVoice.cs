using UnityEngine;
using UnityEngine.Audio;

public class PlayerVoice : MonoBehaviour
{
    public VoiceType voiceType;
    public AudioMixerGroup audioMixerGroup;

    public AudioClip[] generationsJump;
    public AudioClip[] unleashedJump;

    public AudioClip[] generationsBoost;
    public AudioClip[] unleashedBoost;

    private AudioSource audioSource;

    public AudioClip trick;

    void Awake()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.loop = false;
        audioSource.outputAudioMixerGroup = audioMixerGroup;
        audioSource.dopplerLevel = 0;
        audioSource.maxDistance = 100;
        audioSource.minDistance = 2;
        audioSource.volume = 0.5f;
        audioSource.priority = 256;
    }

    private void PlayRandomSound(AudioClip[] audioClips)
    {
        audioSource.PlayOneShot(audioClips[Random.Range(0, audioClips.Length - 1)]);
    }

    private void StateBoostStart()
    {
        switch (voiceType)
        {
            case VoiceType.Generations:
                PlayRandomSound(generationsBoost);
                break;
            case VoiceType.Unleashed:
                PlayRandomSound(unleashedBoost);
                break;
        }
    }

    void StateJumpCollisionStart()
    {
        if (Player.instance.isSnowboarding)
        {
            //audioSource.PlayOneShot(trick);
            PlayRandomSound(generationsJump);
        }
    }

    private void StateJumpStart()
    {
        switch (voiceType)
        {
            case VoiceType.Generations:
                PlayRandomSound(generationsJump);
                break;
            case VoiceType.Unleashed:
                PlayRandomSound(generationsJump);
                break;
        }
    }

    private void StateGrindJumpStart()
    {
        StateJumpStart();
    }

    private void StateGrindSwitchLeftStart()
    {
        StateJumpStart();
    }

    private void StateGrindSwitchRightStart()
    {
        StateJumpStart();
    }
}
