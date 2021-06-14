using UnityEngine;

public class Ganigani : Enemy
{

    private AudioSource audioSource
    {
        get
        {
            return GetComponent<AudioSource>();
        }
    }
    public AudioClip footstep;
    public AudioClip excite;
    public AudioClip perform1;
    public AudioClip perform2;
    public AudioClip seek;

    new void Start()
    {

    }

    new void Update()
    {

    }

    //new void OnDrawGizmosSelected()
    //{
    //    base.OnDrawGizmosSelected();
    //}

    void Footstep()
    {
        audioSource.PlayOneShot(footstep);
    }
    void Excite()
    {
        audioSource.PlayOneShot(excite);
    }
    void Seek()
    {
        audioSource.PlayOneShot(seek);
    }

    void Perform()
    {
        audioSource.PlayOneShot(perform1);
    }
}
