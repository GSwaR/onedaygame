using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Spawner : MonoBehaviour
{
    [SerializeField] protected GameObject objectToSpawn;
    [SerializeField] protected Transform spawnPosition;
    [SerializeField] protected Transform spawned;
    
    protected void Spawn()
    {
        spawned = Instantiate(objectToSpawn, spawnPosition).transform;
    }

    protected void SetParent()
    {
        spawned.parent = transform;
    }

    protected virtual void DespawnLogic(GameObject objectToDespawn)
    {
        
    }
    
    public void Despawn(GameObject objectToDespawn)
    {
        Debug.Log("Despawn called");
        DespawnLogic(objectToDespawn);
    }
}
