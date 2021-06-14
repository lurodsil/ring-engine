using UnityEngine;

[RequireComponent(typeof(Animator))]
public class MotoraAnimation : MonoBehaviour
{
    private Animator animator;
    private float tireSpeed;
    private float tireRotationSpeed;

    public Transform tire;

    private int velocityNameHash
    {
        get
        {
            return Animator.StringToHash("Velocity");
        }
    }
    private int exciteNameHash
    {
        get
        {
            return Animator.StringToHash("Excite");
        }
    }
    private int rushNameHash
    {
        get
        {
            return Animator.StringToHash("Rush");
        }
    }
    private int brakeNameHash
    {
        get
        {
            return Animator.StringToHash("Brake");
        }
    }
    private int clashNameHash
    {
        get
        {
            return Animator.StringToHash("Clash");
        }
    }

    void Awake()
    {
        animator = gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        animator.SetFloat("Velocity", 10);
        tireRotationSpeed += tireSpeed % 360;
    }
    void StateIdleStart()
    {
        tireSpeed = 0;
    }

    void StateMoveStart()
    {
        tireSpeed = 6;
    }

    void StateStoreStart()
    {
        animator.SetTrigger("Excite");
        tireSpeed = 20;
    }

    void StateRushStart()
    {
        animator.SetTrigger("Rush");
    }

    void StateBrakeStart()
    {
        animator.SetTrigger("Brake");
        tireSpeed = 0;
    }

    void StateClashStart()
    {
        animator.SetTrigger("Clash");
        tireSpeed = 0;
    }

    void LateUpdate()
    {
        tire.localRotation = Quaternion.Euler(tireRotationSpeed, 0, 0);
    }
}
