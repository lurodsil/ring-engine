using UnityEngine;
using UnityEngine.Events;


public abstract class CommonActivableStatefulObject : CommonActivableStatelessObject
{
    public UnityEvent OnStateStart;
    public UnityEvent OnStateEnd;
    public StateMachine.State objectState { get; set; }
    public StateMachine.State objectPhysicsState { get; set; }

    public bool changeStateWhenDeactivated = true;

    public void Awake()
    {
        OnPlayerTriggerEnter.AddListener(CheckAtivationThenChangestate);
    }

    private void CheckAtivationThenChangestate()
    {
        if (changeStateWhenDeactivated)
        {
            ChangeState();
        }
        else if (active)
        {
            ChangeState();
        }        
    }

    public void ChangeState()
    {
        if (objectState != null && objectPhysicsState != null)
        {
            player.stateMachine.ChangeState(objectState, objectPhysicsState, gameObject);
        }
        else if (objectState != null)
        {
            player.stateMachine.ChangeState(objectState, gameObject);
        }
        else
        {
            Debug.Log("Object state isn't defined");
            return;
        }
    }
}
