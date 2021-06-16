using UnityEngine;

public class Switch : RingEngineObject
{
    public bool keepOn;

    public AudioClip switchOn;
    public AudioClip switchOff;    

    private Animator animator;
    private AudioSource audioSource;
    private SkinnedMeshRenderer meshRenderer;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        meshRenderer = GetComponentInChildren<SkinnedMeshRenderer>();
        animator = GetComponentInChildren<Animator>();
    }

    public override void OnTriggerEnter(Collider other)
    {
        if (!active)
        {
            Activate();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (!keepOn && active)
        {
            Deactivate();
        }
    }    

    public override void Activate()
    {
        base.Activate();

        TriggerSwitch(switchOn, Color.cyan, "Switch On");
    }

    public override void Deactivate()
    {
        base.Deactivate();

        TriggerSwitch(switchOff, Color.yellow, "Switch Off");
    }

    private void TriggerSwitch(AudioClip sound, Color color, string animatorTrigger)
    {
        audioSource.PlayOneShot(sound);
        meshRenderer.materials[2].color = color;
        animator.SetTrigger(animatorTrigger);
    }

    private void OnDrawGizmosSelected()
    {
        DrawEventLines(OnBecomeActive, Color.green);
        DrawEventLines(OnBecomeInactive, Color.red);
    }
}