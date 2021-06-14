using UnityEngine;

public class StateMachineUsage : MonoBehaviour
{
    StateMachine stateMachine = new StateMachine();

    string testString;

    public GameObject receiver;

    void Start()
    {
        stateMachine.Initialize(gameObject, StateIdle);
    }

    void Update()
    {
        stateMachine.Update();
    }

    #region State Idle
    void StateIdleStart()
    {
        testString = "I'm starting idle state";

        Debug.Log(testString);
    }
    void StateIdle()
    {
        testString = "I'm inside idle state";

        if (Input.GetButtonDown("Jump"))
        {
            //stateMachine.ChangeState(Senders(gameObject, receiver), StateMove);

            testString = "I'll never see this in debug";
            return;
        }

        Debug.Log(testString);
    }
    void StateIdleEnd()
    {
        testString = "I'm ending idle state";

        Debug.Log(testString);
    }
    #endregion

    #region State Move
    void StateMoveStart()
    {
        testString = "I'm starting move state";

        Debug.Log(testString);
    }
    void StateMove()
    {
        testString = "I'm inside move state";

        if (Input.GetButtonDown("Jump"))
        {
            stateMachine.ChangeState(StateIdle);

            testString = "I'll never see this in debug";
            return;
        }

        if (Input.GetButtonDown("Fire1"))
        {
            stateMachine.ChangeState(StateMove);

            testString = "I'll never see this in debug";
            return;
        }

        Debug.Log(testString);
    }
    void StateMoveEnd()
    {
        testString = "I'm ending move state";

        Debug.Log(testString);
    }
    #endregion

    public GameObject[] Senders(GameObject a, GameObject b)
    {
        GameObject[] senders = new GameObject[2];

        senders[0] = a;
        senders[1] = b;

        return senders;
    }
}
