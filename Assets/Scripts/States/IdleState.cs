using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : State
{
    public float minIdleTime;
    public float maxIdleTime;

    protected bool flipAfterIdle;

    protected float idleTime;
    
    public IdleState(Entity entity, FiniteStateMachine stateMachine) : base(entity, stateMachine)
    {
        minIdleTime = 1f;
        maxIdleTime = 3f;
        SetRamdomIdleTime();
    }

    public override void Enter()
    {
        base.Enter();
        
        entity.SetVelocity(0f);
        entity.spriteRenderer.color = Color.cyan;
    }

    public override void Exit()
    {
        base.Exit();

        if (flipAfterIdle)
        {
            entity.Flip();
        }
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (Time.time >= startTime + idleTime)
        {
            stateMachine.ChangeState(entity.moveState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
    
    public void SetFlipAfterIdle(bool flip)
    {
        flipAfterIdle = flip;
    }

    public void SetRamdomIdleTime()
    {
        idleTime = Random.Range(minIdleTime, maxIdleTime);
    }
}
