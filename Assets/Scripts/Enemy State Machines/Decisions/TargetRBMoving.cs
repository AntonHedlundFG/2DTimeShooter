using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetRBMoving : Decision
{
    public Rigidbody2D _targetRB;
    public bool Moving;
    
    public override bool CheckDecision()
    {
        bool moving = _targetRB.velocity.sqrMagnitude > 0.01;
        return (moving == Moving);
    }
}
