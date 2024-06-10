using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Base class for characters with a generic state machine
public class Character<T> : MonoBehaviour
{
    private Dictionary<T, State<T>> states = new Dictionary<T, State<T>>();
    private State<T> currentState;
    private readonly bool isDebug = true;

    public virtual void Update()
    {
        currentState?.Update(Time.deltaTime);
    }

    public virtual void FixedUpdate()
    {
        currentState?.FixedUpdate(Time.deltaTime);
    }

    // Method for adding a new state to the state machine
    public void AddState(T stateKey, State<T> stateValue)
    {
        if (!states.ContainsKey(stateKey))
        {
            stateValue.Start(this);
            states.Add(stateKey, stateValue);
            if (isDebug) Debug.Log($"State {stateKey} added.");
        }
        else
        {
            if (isDebug) Debug.LogWarning($"State {stateKey} already exists.");
        }
    }

    public void RemoveState(T stateKey)
    {
        if (states.ContainsKey(stateKey))
        {
            states.Remove(stateKey);
            if (isDebug) Debug.Log($"State {stateKey} removed.");
        }
        else
        {
            if (isDebug) Debug.LogWarning($"State {stateKey} does not exist.");
        }
    }

    // Method for setting the current state of the state machine
    public void SetState(T stateKey)
    {
        if (states.TryGetValue(stateKey, out State<T> newState))
        {
            if (currentState != null && newState == currentState) return;

            currentState?.Exit();
            newState.Enter();
            currentState = newState;
            if (isDebug) Debug.Log($"Transitioned to state {stateKey}.");
        }
        else
        {
            if (isDebug) Debug.LogError($"State {stateKey} not found in the state machine.");
        }
    }

    public virtual void OnCollisionEnter2D(Collision2D coll)
    {
        currentState?.OnCollisionEnter2D(coll);
    }
}
