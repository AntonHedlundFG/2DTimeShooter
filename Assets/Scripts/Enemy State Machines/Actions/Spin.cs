using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TimeMultiplier;


public class Spin : Action
{
    public float SpinSpeed = 90f;
    public bool Clockwise = true;
    public Transform SpinningObject;

    private TMSystemHandler _tmSystemHandler;
    private TMBrain _brain;
    public override void OnExit()
    {

    }

    public override void OnEnter()
    {
        _brain = _tmSystemHandler.GetBrain();
    }

    public override void OnUpdate()
    {
        float rotateSpeed = SpinSpeed * Time.deltaTime * _brain.GetMultiplier();
        if(!Clockwise)
        {
            rotateSpeed = -rotateSpeed;
        }
        SpinningObject.eulerAngles += new Vector3(0, 0, rotateSpeed);
    }
}
