using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class WallCheck : MonoBehaviour
{
    public Entity entity;

    public bool isWallCheck;
    private void Start()
    {
        entity = GetComponentInParent<Entity>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Ground") && isWallCheck)
        {
            ChageToRandomState();
        }
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Ground") && !isWallCheck)
        {
            ChageToRandomState();
        }
    }

    private void ChageToRandomState()
    {
        if (Random.Range(0, 2) == 0)
        {
            entity.idleState.SetFlipAfterIdle(true);
            entity.idleState.SetRamdomIdleTime();
            entity.stateMachine.ChangeState(entity.idleState);
        }
        else
        {
            entity.feedState.SetFlipAfterFeed(true);
            entity.feedState.SetRamdomFeedTime();
            entity.stateMachine.ChangeState(entity.feedState);
        }
    }
}
