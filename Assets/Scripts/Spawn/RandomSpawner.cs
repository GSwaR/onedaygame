using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class RandomSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] objectsToSpawn;
    [SerializeField] private Transform spawnPosition;

    [SerializeField] private bool spawnOnStart;
    [SerializeField] private Transform spawned;
    [SerializeField] private int emptyObjectsAmount;
    
    private void Start()
    {
        if (spawnOnStart)
        {
            Spawn();
        }
    }

    public void Spawn()
    {
        int inArrayPosition = Random.Range(0, objectsToSpawn.Length + emptyObjectsAmount);
        Debug.Log(gameObject.name + " " + inArrayPosition);
        if (inArrayPosition < objectsToSpawn.Length)
        {
            spawned = Instantiate(objectsToSpawn[inArrayPosition], spawnPosition).transform; 
            SetParent();
        }

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
