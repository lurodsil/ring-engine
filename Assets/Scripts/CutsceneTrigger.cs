using UnityEngine;
using UnityEngine.Playables;

public class CutsceneTrigger : MonoBehaviour
{
    public PlayableDirector playableDirector;

    public Transform playerPositionAfterAnimationIsFinished;

    public bool lockPlayerControls = true;

    private Player player;


    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Player>())
        {
            playableDirector.Play();
            player = other.GetComponent<Player>();
            player.velocity = 0;
            player.rigidbody.velocity = Vector3.zero;
            if (lockPlayerControls)
            {
                player.stateMachine.Pause();
            }
        }
    }

    public void AnimationFinished()
    {
        if (playerPositionAfterAnimationIsFinished)
        {
            player.transform.position = playerPositionAfterAnimationIsFinished.position;
            player.transform.rotation = playerPositionAfterAnimationIsFinished.rotation;
        }

        if (lockPlayerControls)
        {
            player.stateMachine.Play();
        }
    }
}
