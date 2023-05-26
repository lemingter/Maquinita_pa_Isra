using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveState : State
{
    private float moveSpeed;

    // Start is called before the first frame update
    public MoveState(Entity entity, FiniteStateMachine stateMachine) : base(entity, stateMachine)
    {
        moveSpeed = 3.0f;
    }

    public override void Enter()
    {
        base.Enter();
        entity.SetVelocity(moveSpeed);
        entity.spriteRenderer.color = Color.blue;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
