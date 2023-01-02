using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    public State StartingState;

    private State _currentState;

    private void OnEnable()
    {
        _currentState = StartingState;
        _currentState.OnEnter();
    }
    private void Update()
    {
        foreach(StateTransition st in _currentState.Transitions)
        {
            if(st.CheckDecisions())
            {
                _currentState.OnExit();
                _currentState = st.TargetState;
                _currentState.OnEnter();
                break;
            }
        }

        _currentState.OnUpdate();
    }

    private void OnDisable()
    {
        _currentState.OnExit();
    }
}
