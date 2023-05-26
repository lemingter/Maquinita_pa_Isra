using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    public GameObject player;

    private float timeToSpawn = 15f;

    private int timesSpawned = 0;

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= timeToSpawn * timesSpawned)
        {
            timesSpawned++;
            Instantiate(player, transform);
        }
    }
}
