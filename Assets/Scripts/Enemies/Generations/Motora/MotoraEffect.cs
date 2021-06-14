using UnityEngine;

public class MotoraEffect : MonoBehaviour
{
    public ParticleSystem store;
    public ParticleSystem rush;

    void StateStoreStart()
    {
        store.Play(true);
    }

    void StateStoreEnd()
    {
        store.Stop(true);
    }

    void StateRushStart()
    {
        rush.Play();
    }

    void StateRushEnd()
    {
        rush.Stop();
    }
}
