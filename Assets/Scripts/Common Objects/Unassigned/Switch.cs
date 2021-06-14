using UnityEngine;

public class Switch : GenerationsObject
{
    public float EventOFF = 0f;
    public float EventON = 6f;
    public bool IsMoveCollision = false;
    public bool IsPrimitiveCollision = true;
    public float OffTimer = 5f;
    public float TimerOFF = 0f;
    public float TimerON = 0f;
    public float Type = 0f;
    public AudioClip audio1, audio2;
    public bool keepOn;
    private Material material;
    private SkinnedMeshRenderer meshRenderer;

    public MonoBehaviour[] generationsObjects;
    private Animator animator;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        meshRenderer = GetComponentInChildren<SkinnedMeshRenderer>();
        animator = GetComponentInChildren<Animator>();
        animator.SetTrigger("Switch Off");
    }

    public override void OnValidate()
    {

    }

    private void OnTriggerStay(Collider other)
    {
        if (!active)
        {
            active = true;

            audioSource.PlayOneShot(audio1);

            meshRenderer.materials[2].color = Color.cyan;

            animator.SetTrigger("Switch On");

            SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (!keepOn && active)
        {
            active = false;

            audioSource.PlayOneShot(audio2);

            meshRenderer.materials[2].color = Color.yellow;

            animator.SetTrigger("Switch Off");

            SetActive(false);
        }
    }

    void SetActive(bool active)
    {
        foreach (GenerationsObject g in generationsObjects)
        {
            g.active = active;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;

        foreach (GenerationsObject generationsObject in generationsObjects)
        {
            if (generationsObject != null)
            {
                Gizmos.DrawLine(transform.position, generationsObject.transform.position);
            }
        }
    }
}