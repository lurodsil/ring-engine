using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.GraphicsBuffer;

public class RingEngineDebug : MonoBehaviour
{
    public Text physicsContent;
    public Text playerContent;
    public Text statemachineContent;
    public Text animationContent;
    public Text miscContent;

    public Text pathInformation;

    private Player player;
    private Animator playerAnimator;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        playerAnimator = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
    }

    private void Update()
    {
        if (player != null)
        {
            physicsContent.text =
           "Rigidbody velocity: " + player.rigidbody.velocity.ToString("f2") + "\r\n" +
           "Absolute velocity: " + player.rigidbody.velocity.magnitude.ToString("f2") + "\r\n" +
           "Horizontal velocity: " + new Vector3(player.rigidbody.velocity.x, 0, player.rigidbody.velocity.z).magnitude.ToString("f2") + "\r\n" +
           "Vertical velocity: " + player.rigidbody.velocity.y.ToString("f2") + "\r\n" +
           "Is Kinematic: " + player.rigidbody.isKinematic + "\r\n" +
           "Use gravity: " + player.rigidbody.useGravity + "\r\n" +
           "Is sleeping: " + player.rigidbody.IsSleeping() + "\r\n" +
           "Gravity: " + Physics.gravity;

            playerContent.text =
                "Is grounded: " + player.IsGrounded() + "\r\n" +
                "Ground state: " + player.transform.GetGroundState() + "\r\n" +
                "Is grind grounded: " + player.isGrindGrounded + "\n\r" +
                "Is grinding: " + player.isGrinding + "\n\r" +
                "Can homming: " + player.canHomming + "\n\r" +
                "Is attacking: " + player.isAttacking + "\n\r" +
                "Is braking: " + player.isBraking + "\n\r" +
                 "Is boosting: " + player.isBoosting + "\n\r" +
                "Ignore damage: " + player.ignoreDamage;

            statemachineContent.text =
                "Last state: " + player.stateMachine.lastStateName.Replace("State", "") + "\n\r" +
                "Current state: " + player.stateMachine.currentStateName.Replace("State", "") + "\n\r" +
                "Physics state: " + player.stateMachine.currentPhysicsStateName.Replace("State", "");

            animationContent.text =
                "Current animation: " + (playerAnimator.GetCurrentAnimatorClipInfo(0).Length != 0 ? playerAnimator.GetCurrentAnimatorClipInfo(0)[0].clip.name : "");

            miscContent.text =
                "FPS: " + GameManager.fps.ToString("f0");

   //         if (player.sideViewPath != null)
   //         {
   //             pathInformation.text =
   //"Side view path: " + player.sideViewPath + "\r\n" +
   //"Tangent: " + player.tangent + "\r\n" +
   //"Tangent multiplier: " + player.tangentMultiplier;
   //         }


            Debug.DrawRay(player.collider.bounds.center, player.tangent, Color.blue);
            Vector3 nTan = player.tangent;
            nTan.y = 0;
            Debug.DrawRay(player.collider.bounds.center, nTan, Color.yellow);

            RaycastHit hit = player.GetGroundInformation();

            Debug.DrawRay(hit.point, hit.normal, Color.cyan);
        }





    }
}
