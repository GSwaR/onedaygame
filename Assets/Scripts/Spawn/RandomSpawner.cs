using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class RandomSpawner : Spawner
{
    [SerializeField] private GameObject[] objectsToSpawn;
    
    [Header("Conditional functional")]
    [Tooltip("Set 'true' to spawn object on Start")]
    [SerializeField] private bool spawnOnStart;
    [Tooltip("Amount of empty objects")]
    [SerializeField] private int emptyObjectsAmount;

    private void Start()
    {
        if (spawnOnStart)
        {
            Spawn();
        }
    }

    private new void Spawn()
    {
        int inArrayPosition = Random.Range(0, objectsToSpawn.Length + emptyObjectsAmount);
 
        if (inArrayPosition < objectsToSpawn.Length)
        {
            spawned = Instantiate(objectsToSpawn[inArrayPosition], spawnPosition).transform;
            SetParent();
        }
    }
    
    protected override void DespawnLogic(GameObject objectToDespawn)
    {
        Spawn();
        Destroy(objectToDespawn);
    }
    
}
