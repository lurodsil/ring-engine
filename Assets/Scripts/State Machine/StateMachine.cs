using System;
using UnityEngine;

public class StateMachine
{
    public delegate void State();
    private event State updateState;
    private event State fixedUpdateState;
    private Component owner;
    public bool canTransitToSameState { get; set; }
    public bool initiated { get; private set; }
    public string lastStateName { get; private set; }
    public string currentStateName { get; private set; }
    public string currentPhysicsStateName { get; private set; }
    public string nextStateName { get; private set; }
    public float lastStateTime { get; private set; } 
    public bool paused { get; private set; }

    public void Initialize(Component initializer, State startState)
    {
        owner = initializer;

        lastStateTime = Time.time;

        updateState = startState;

        lastStateName = updateState.Method.Name;

        currentStateName = updateState.Method.Name;

        nextStateName = string.Empty;

        fixedUpdateState = GetPhysicsState(initializer, nextStateName);

        currentPhysicsStateName = fixedUpdateState.Method.Name;

        initiated = true;
    }
    public void OnUpdate()
    {
        if (!paused)
        {
            updateState?.Invoke();
        }        
    }
    public void OnFixedUpdate()
    {
        if (!paused)
        {
            fixedUpdateState?.Invoke();
        }
    }
    public void EmptyState()
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

    public void ChangeState(State nextState, State physicsState, GameObject[] listeners, float delay)
    {
        if (Time.time < lastStateTime + delay)
            return;

        if (updateState.Method.Name == nextState.Method.Name)
            return;

        lastStateName = updateState.Method.Name;
        nextStateName = nextState.Method.Name;

        foreach (GameObject listener in listeners)
        {
            SendMessageAtEnd(listener, lastStateName);
        }

        lastStateTime = Time.time;

        updateState = nextState;

        fixedUpdateState = physicsState;

        currentStateName = updateState.Method.Name;

        currentPhysicsStateName = fixedUpdateState.Method.Name;

        foreach (GameObject listener in listeners)
        {
            SendMessageAtStart(listener, currentStateName);
        }
    }
    public void ChangeState(State nextState, State physicsState, GameObject[] listeners)
    {
        ChangeState(nextState, physicsState, listeners, 0);
    }
    public void ChangeState(State nextState, State physicsState, GameObject listener, float delay)
    {
        ChangeState(nextState, physicsState, new GameObject[2] { owner.gameObject, listener }, delay);
    }
    public void ChangeState(State nextState, State physicsState, GameObject listener)
    {
        ChangeState(nextState, physicsState, new GameObject[2] { owner.gameObject, listener }, 0);
    }
    public void ChangeState(State nextState, GameObject listener, float delay)
    {
        ChangeState(nextState, GetPhysicsState(owner, nextState.Method.Name), new GameObject[2] { owner.gameObject, listener }, delay);
    }
    public void ChangeState(State nextState, GameObject listener)
    {
        ChangeState(nextState, GetPhysicsState(owner, nextState.Method.Name), new GameObject[2] { owner.gameObject, listener }, 0);
    }
    public void ChangeState(State nextState, State physicsState, float delay)
    {
        ChangeState(nextState, physicsState, new GameObject[1] { owner.gameObject }, delay);
    }
    public void ChangeState(State nextState, State physicsState)
    {
        ChangeState(nextState, physicsState, new GameObject[1] { owner.gameObject }, 0);
    }
    public void ChangeState(State nextState, float delay)
    {
        ChangeState(nextState, GetPhysicsState(owner, nextState.Method.Name), new GameObject[1] { owner.gameObject }, delay);
    }
    public void ChangeState(State nextState)
    {
        ChangeState(nextState, GetPhysicsState(owner, nextState.Method.Name), new GameObject[1] { owner.gameObject }, 0);
    }

    private void SendMessageAtStart(GameObject sender, string stateName)
    {
        sender.SendMessage(stateName + "Start", SendMessageOptions.DontRequireReceiver);
    }
    private void SendMessageAtEnd(GameObject sender, string stateName)
    {
        sender.SendMessage(stateName + "End", SendMessageOptions.DontRequireReceiver);
    }
    private State GetPhysicsState(Component owner, string stateName)
    {
        var method = owner.GetType().GetMethod(stateName + "Physics");
        if (method == null)
        {
            return EmptyState;
        }
        else
        {
            return Delegate.CreateDelegate(typeof(State), owner, method) as State;
        }    
    }
}