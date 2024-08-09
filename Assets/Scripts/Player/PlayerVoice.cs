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

    public AudioClip[] generationsStumble;
    public AudioClip[] unleashedStumble;

    public AudioClip[] generationsTrick;
    public AudioClip[] unleashedTrick;

    [SerializeField] private AudioSource audioSource;

    void Awake()
    {
       
    }

    private void PlayRandomSound(AudioClip[] audioClips)
    {
        audioSource.PlayOneShot(audioClips[Random.Range(0, audioClips.Length)]);
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

    private void StateStumbleStart()
    {
        switch (voiceType)
        {
            case VoiceType.Generations:
                PlayRandomSound(generationsStumble);
                break;
            case VoiceType.Unleashed:
                PlayRandomSound(unleashedStumble);
                break;
        }
    }
}
