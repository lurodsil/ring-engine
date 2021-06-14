using UnityEngine;
using UnityEngine.UI;

public class RingEngineDebug : MonoBehaviour
{

    new public bool enabled;
    public Canvas canvas;
    Player player;
    PlayerAnimation playerAnimation;

    public Text
        rigidbodyVelocity,
        absoluteVelocity,
        verticalVelocity,
        horizontalVelocity,
        appliedVelocity,
        isGrounded,
        groundDistance,
        groundPhysicMaterial,
        useGravity,
        gravity,
        isKinematic
    ;

    public Text currentState;

    public Text currentAnimation;

    public Text fpsText;

    public Text groundState;

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        playerAnimation = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerAnimation>();
    }

    private void Update()
    {
        if (enabled)
        {
            fpsText.text = GameManager.fps.ToString("f0");

            rigidbodyVelocity.text = player.rigidbody.velocity.ToString("f2");
            absoluteVelocity.text = player.rigidbody.velocity.magnitude.ToString("f2");
            horizontalVelocity.text = new Vector3(player.rigidbody.velocity.x, 0, player.rigidbody.velocity.z).magnitude.ToString("f2");
            verticalVelocity.text = player.rigidbody.velocity.y.ToString("f2");
            appliedVelocity.text = player.velocity.ToString("f2");
            isGrounded.text = player.groundInfo.grounded.ToString();
            groundDistance.text = (player.groundInfo.groundHit.distance - 0.5f).ToString("f2");
            if (player.groundInfo.GetComponent<Collider>() && player.groundInfo.GetComponent<Collider>().sharedMaterial != null)
            {
                groundPhysicMaterial.text = player.groundInfo.GetComponent<Collider>().sharedMaterial.name;
            }

            useGravity.text = player.rigidbody.useGravity.ToString();
            gravity.text = Physics.gravity.y.ToString();
            isKinematic.text = player.rigidbody.isKinematic.ToString();

            currentState.text = player.stateMachine.currentStateName.Replace("State", "");
            currentAnimation.text = playerAnimation.animator.GetCurrentAnimatorStateInfo(0).tagHash.ToString();

            groundState.text = player.groundInfo.groundState.ToString();
        }
    }

    // Update is called once per frame
    private void LateUpdate()
    {
        canvas.enabled = enabled;
    }
}
