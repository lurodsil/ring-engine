using UnityEngine;

public class PlayParticleOnAnimationEvent : MonoBehaviour
{
    public new ParticleSystem particleSystem;

    public void PlayParticle()
    {
        particleSystem.Play();
    }
}
