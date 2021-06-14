using UnityEngine;

public class StateMachine
{
    public delegate void State();
    private State state;

    public bool canTransitToSameState;

    private const string errorMessage = "State Machine not initialized, please initialize State Machine on the Awake or Start method.";
    private float LastStateTime;
    private string LastStateName;
    private string CurrentStateName;
    private string NextStateName;
    private bool paused;

    public string lastStateName
    {
        get
        {
            return LastStateName;
        }
    }
    public string currentStateName
    {
        get
        {
            return CurrentStateName;
        }
    }
    public string nextStateName
    {
        get
        {
            return NextStateName;
        }
    }
    public float lastStateTime
    {
        get
        {
            return LastStateTime;
        }
    }

    private GameObject gameObject;

    public void Initialize(GameObject gameObject, State startState)
    {
        this.gameObject = gameObject;

        LastStateTime = Time.time;

        state = startState;

        LastStateName = state.Method.Name;

        CurrentStateName = state.Method.Name;

        NextStateName = string.Empty;
    }

    public void Update()
    {
        if (!paused)
        {
            state();
        }
    }

    public void ChangeState(State nextState)
    {
        if (state.Method.Name == nextState.Method.Name)
            return;

        LastStateName = state.Method.Name;

        NextStateName = nextState.Method.Name;

        SendMessageAtEnd(gameObject, LastStateName);

        LastStateTime = Time.time;

        state = nextState;

        CurrentStateName = state.Method.Name;

        SendMessageAtStart(gameObject, CurrentStateName);
    }

    public void ChangeState(State nextState, float delay)
    {
        if (Time.time < lastStateTime + delay)
            return;

        ChangeState(nextState);
    }

    public void ChangeState(State nextState, GameObject listener)
    {
        if (state.Method.Name == nextState.Method.Name)
            return;

        LastStateName = state.Method.Name;

        NextStateName = nextState.Method.Name;

        SendMessageAtEnd(gameObject, LastStateName);
        SendMessageAtEnd(listener, LastStateName);

        LastStateTime = Time.time;

        state = nextState;

        CurrentStateName = state.Method.Name;

        SendMessageAtStart(gameObject, CurrentStateName);
        SendMessageAtStart(listener, CurrentStateName);
    }

    public void ChangeState(State nextState, GameObject listener, float delay)
    {
        if (Time.time < lastStateTime + delay)
            return;

        ChangeState(nextState, listener);
    }

    public void ChangeState(State nextState, GameObject[] listeners)
    {
        if (state.Method.Name == nextState.Method.Name)
            return;

        LastStateName = state.Method.Name;

        NextStateName = nextState.Method.Name;

        foreach (GameObject listener in listeners)
        {
            SendMessageAtEnd(listener, LastStateName);
        }

        LastStateTime = Time.time;

        state = nextState;

        CurrentStateName = state.Method.Name;

        foreach (GameObject listener in listeners)
        {
            SendMessageAtStart(listener, CurrentStateName);
        }
    }

    public void ChangeState(State nextState, GameObject[] listeners, float delay)
    {
        if (Time.time < lastStateTime + delay)
            return;

        ChangeState(nextState, listeners);
    }

    private void SendMessageAtStart(GameObject sender, string stateName)
    {
        sender.SendMessage(stateName + "Start", SendMessageOptions.DontRequireReceiver);
    }

    private void SendMessageAtEnd(GameObject sender, string stateName)
    {
        sender.SendMessage(stateName + "End", SendMessageOptions.DontRequireReceiver);
    }

    public void Zero()
    {

    }

    public void Play()
    {
        paused = false;
    }

    public void Pause()
    {
        paused = true;
    }
}