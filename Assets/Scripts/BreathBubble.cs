using UnityEngine;

public class BreathBubble : MonoBehaviour
{
    public AudioClip particleStart, particleEnd;
    public ParticleSystem waterSplash;
    new private ParticleSystem particleSystem;
    private AudioSource audioSource;
    private Vector3 particlePosition;

    private void Start()
    {
        particleSystem = GetComponent<ParticleSystem>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (particleSystem.particleCount >= 1)
        {
            ParticleSystem.Particle[] particles = new ParticleSystem.Particle[particleSystem.particleCount];

            particleSystem.GetParticles(particles);

            particlePosition = particles[0].position;

            if (particleSystem.time > particleSystem.main.duration - 0.01f)
            {
                audioSource.PlayOneShot(particleEnd);
            }
        }

        if (particleSystem.time > 1.0f && particleSystem.time < 1.02f)
        {
            audioSource.PlayOneShot(particleStart);
        }
    }

    void OnParticleCollision(GameObject other)
    {
        audioSource.PlayOneShot(particleEnd);

        if (other.CompareTag(GameTags.playerTag))
        {
            GameObject splash = Instantiate(waterSplash, particlePosition, Quaternion.identity).gameObject;

            splash.transform.LookAt(Camera.main.transform);

            Destroy(splash, waterSplash.main.duration);

            other.SendMessage("BubbleBreath");
        }
    }
}
