using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleSpawner : Spawner
{
    [Header("Conditional functional")]
    [Tooltip("Set 'true' to spawn object on Start")]
    [SerializeField] private bool spawnOnStart = false;

    private void Start()
    {
        if (spawnOnStart)
        {
            Spawn();
            SetParent();
        }
    }

    protected override void DespawnLogic(GameObject objectToDespawn)
    {
        Spawn();
        SetParent();
        
        Destroy(objectToDespawn);
        Debug.Log("Despawned");
    }

}
