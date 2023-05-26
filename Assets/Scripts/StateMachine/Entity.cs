using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Update = UnityEngine.PlayerLoop.Update;

public class Entity : MonoBehaviour
{
    public FiniteStateMachine stateMachine;
    public int facingDirection { get; private set; }
    public Rigidbody2D rb { get; private set; }

    private Vector2 velocityWorkspace;

    public SpriteRenderer spriteRenderer { get; private set; }
    public IdleState idleState { get; private set; }
    public MoveState moveState { get; private set; }
    public FeedState feedState { get; private set; }
    public AttackState attackState { get; private set; }

    public virtual void Start()
    {
        facingDirection = 1;

        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        stateMachine = new FiniteStateMachine();

        idleState = new IdleState(this, stateMachine);
        moveState = new MoveState(this, stateMachine);
        feedState = new FeedState(this, stateMachine);
        attackState = new AttackState(this, stateMachine);
        
        stateMachine.Initialize(moveState);
    }
    
    public virtual void Update()
    {
        stateMachine.currentState.LogicUpdate();
    }

    public virtual void FixedUpdate()
    {
        stateMachine.currentState.PhysicsUpdate();
    }
    
    public virtual void SetVelocity(float velocity)
    {
        velocityWorkspace.Set(facingDirection * velocity, rb.velocity.y);
        rb.velocity = velocityWorkspace;
    }
    
    public virtual void Flip()
    {
        facingDirection *= -1;
        transform.Rotate(0f,180f,0f);
    }

}
