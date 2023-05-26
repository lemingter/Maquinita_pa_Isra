using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCheck : MonoBehaviour
{
    public Entity entity;
    private void Start()
    {
        entity = GetComponentInParent<Entity>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            Destroy(col.gameObject);
            entity.stateMachine.ChangeState(entity.attackState);
        }
    }
}
