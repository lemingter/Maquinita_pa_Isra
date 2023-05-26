using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : State
{
    private float attackTime;
    public AttackState(Entity entity, FiniteStateMachine stateMachine) : base(entity, stateMachine)
    {
        attackTime = 3;
    }

    public override void Enter()
    {
        base.Enter();
        entity.SetVelocity(0f);
        entity.spriteRenderer.color = Color.red;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (Time.time >= startTime + attackTime)
        {
            entity.idleState.SetRamdomIdleTime();
            stateMachine.ChangeState(entity.idleState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
