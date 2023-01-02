using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class State : MonoBehaviour
{
    public string StateName = "New State";
    public List<Action> Actions;
    public List<StateTransition> Transitions;

    public void OnEnter()
    {
        foreach (Action a in Actions)
        {
            a.OnEnter();
        }
    }
    public void OnExit()
    {
        foreach (Action a in Actions)
        {
            a.OnExit();
        }
    }

    public void OnUpdate()
    {
        foreach (Action a in Actions)
        {
            a.OnUpdate();
        }
    }
}
