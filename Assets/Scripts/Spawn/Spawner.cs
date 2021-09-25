using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject objectToSpawn;
    [SerializeField] private Transform spawnPosition;

    [SerializeField] private Transform spawned;
    
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

    public void Spawn()
    {
        spawned = Instantiate(objectToSpawn, spawnPosition).transform;
    }

    public void SetParent()
    {
        spawned.parent = transform;
    }

    public void Despawn(GameObject objectToDespawn)
    {
        Spawn();
        SetParent();
        Destroy(objectToDespawn);
    }
}
