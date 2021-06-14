using UnityEngine;

public class StateMachineReceiver : MonoBehaviour
{
    void StateIdleStart()
    {
        Debug.Log("I hear your message! I'll do something on state idle start.");
    }

    void StateIdleEnd()
    {
        Debug.Log("I hear your message! I'll do something on state idle end.");
    }

    void StateMoveStart()
    {
        Debug.Log("I hear your message! I'll do something on state move start.");
    }

    void StateMoveEnd()
    {
        Debug.Log("I hear your message! I'll do something on state move end.");
    }
}
