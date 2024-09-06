using UnityEngine;
using UnityEngine.Events;


public abstract class CommonStatefulObject : CommonObject
{
    public UnityEvent OnStateStart;
    public UnityEvent OnStateEnd;
    public StateMachine.State objectState { get; set; }
    public StateMachine.State objectPhysicsState { get; set; }

    public bool canTransitionToSameState { get; set; }

    public void Awake()
    {
        OnPlayerTriggerEnter.AddListener(ChangeState);
    }

    public void ChangeState()
    {
        if (objectState != null && objectPhysicsState != null)
        {
            player.stateMachine.ChangeState(objectState, objectPhysicsState, gameObject);
        }
        else if (objectState != null)
        {
            player.stateMachine.ChangeState(objectState, gameObject, canTransitionToSameState);
        }
        else
        {
            Debug.Log("Object state isn't defined");
            return;
        }
    }
}
