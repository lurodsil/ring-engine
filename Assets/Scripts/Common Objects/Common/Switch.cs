using UnityEngine;

public class Switch : CommonActivableStatelessObject
{
    public bool keepOn;

    public AudioClip switchOn;
    public AudioClip switchOff;

    private Animator animator;
    private AudioSource audioSource;
    private SkinnedMeshRenderer meshRenderer;

    GameObject activator;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        meshRenderer = GetComponentInChildren<SkinnedMeshRenderer>();
        animator = GetComponentInChildren<Animator>();

        //OnPlayerTriggerEnter.AddListener(PowerOn);
        //OnPlayerTriggerExit.AddListener(PowerOff);
    }

    public void PowerOn()
    {
        if (!active)
        {
            TriggerSwitch(switchOn, Color.cyan, "Switch On");
            Activate();
        }
    }

    public void PowerOff()
    {
        if (!keepOn && active)
        {
            TriggerSwitch(switchOff, Color.yellow, "Switch Off");
            Deactivate();
        }
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

    public new void OnTriggerEnter(Collider other)
    {
        if (!active)
        {
            if (other.CompareTag("MovingPlatform") || other.CompareTag("Player"))
            {
                activator = other.gameObject;

                TriggerSwitch(switchOn, Color.cyan, "Switch On");
                Activate();
            }
            
        }
    }

    public new void OnTriggerExit(Collider other)
    {

        if (!keepOn && active)
        {
            if (other.gameObject == activator)
            {
                TriggerSwitch(switchOff, Color.yellow, "Switch Off");
                Deactivate();
            }
        }

    }
}