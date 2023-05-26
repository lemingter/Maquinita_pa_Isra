using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeedState : State
{
    public float minFeedTime;
    public float maxFeedTime;

    protected bool flipAfterFeed;

    protected float feedTime;
    
    public FeedState(Entity entity, FiniteStateMachine stateMachine) : base(entity, stateMachine)
    {
        minFeedTime = 3f;
        maxFeedTime = 6f;
        SetRamdomFeedTime();
    }

    public override void Enter()
    {
        base.Enter();
        
        entity.SetVelocity(0f);
        entity.spriteRenderer.color = Color.green;
    }

    public override void Exit()
    {
        base.Exit();

        if (flipAfterFeed)
        {
            entity.Flip();
        }
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (Time.time >= startTime + feedTime)
        {
            stateMachine.ChangeState(entity.moveState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
    
    public void SetFlipAfterFeed(bool flip)
    {
        flipAfterFeed = flip;
    }

    public void SetRamdomFeedTime()
    {
        feedTime = Random.Range(minFeedTime, maxFeedTime);
    }
}
