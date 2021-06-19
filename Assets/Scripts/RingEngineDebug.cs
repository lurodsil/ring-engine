using UnityEngine;
using UnityEngine.UI;

public class RingEngineDebug : MonoBehaviour
{
    public Text physicsContent;
    public Text playerContent;
    public Text statemachineContent;
    public Text animationContent;
    public Text miscContent;

    private Player player;
    private Animator playerAnimator;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        playerAnimator = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
    }

    private void Update()
    {
        physicsContent.text =
            "Rigidbody velocity: " + player.rigidbody.velocity.ToString("f2") + "\r\n" +
            "Absolute velocity: " + player.rigidbody.velocity.magnitude.ToString("f2") + "\r\n" +
            "Horizontal velocity: " + new Vector3(player.rigidbody.velocity.x, 0, player.rigidbody.velocity.z).magnitude.ToString("f2") + "\r\n" +
            "Vertical velocity: " + player.rigidbody.velocity.y.ToString("f2") + "\r\n" +
            "Applied velocity: " + player.velocity.ToString("f2") + "\r\n" +
            "Ground distance: " + (player.groundInfo.groundHit.distance - 0.5f).ToString("f2") + "\r\n" +
            "Is Kinematic: " + player.rigidbody.isKinematic + "\r\n" +
            "Use gravity: " + player.rigidbody.useGravity + "\r\n" +
            "Gravity: " + Physics.gravity;

        playerContent.text =
            "Is grounded: " + player.groundInfo.grounded + "\r\n" +
            "Ground state: " + player.groundInfo.groundState + "\r\n" +
            "Is grind grounded: " + player.groundInfo.grindGrounded + "\n\r" +
            "Can homming: " + player.canHomming + "\n\r" +
            "Is attacking: " + player.isAttacking + "\n\r" +
            "Ignore damage: " + player.ignoreDamage;

        statemachineContent.text =
            "Last state: " + player.stateMachine.lastStateName.Replace("State", "") + "\n\r" +
            "Current state: " + player.stateMachine.currentStateName.Replace("State", "");

        animationContent.text =
            "Current animation: " + playerAnimator.GetCurrentAnimatorClipInfo(0)[0].clip.name;

        miscContent.text =
            "FPS: " + GameManager.fps.ToString("f0");
    }
}
