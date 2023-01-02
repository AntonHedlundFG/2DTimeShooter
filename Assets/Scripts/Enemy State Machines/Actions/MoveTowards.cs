using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TimeMultiplier;

public class MoveTowards : Action
{
    public Rigidbody2D rb;
    public float Speed;

    public bool TargetIsPlayer;
    public GameObject Target;

    [SerializeField] private PlayerFinder _playerFinder;
    [SerializeField] private TMSystemHandler _tmSystemHandler;
    TMBrain brain;

    public override void OnEnter()
    {
        brain = _tmSystemHandler.GetBrain();
        if (TargetIsPlayer)
        {
            Target = _playerFinder.GetPlayer();
        }
    }

    public override void OnExit()
    {
        rb.velocity = Vector2.zero;
    }

    public override void OnUpdate()
    {
        float speed = Speed * brain.GetMultiplier();

        Vector3 dir = Target.transform.position - rb.transform.position;
        rb.velocity = dir.normalized * speed;
    }
}
