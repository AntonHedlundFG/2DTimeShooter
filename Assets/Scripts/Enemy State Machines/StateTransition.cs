using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class StateTransition
{
    public List<Decision> Decisions;
    public State TargetState;

    public bool CheckDecisions()
    {
        foreach (Decision decision in Decisions)
        {
            if (!decision.CheckDecision())
            {
                return false;
            }
        }
        return true;
    }
}
