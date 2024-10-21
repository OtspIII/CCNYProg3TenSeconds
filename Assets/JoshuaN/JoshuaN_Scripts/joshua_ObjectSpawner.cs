using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class joshua_ObjectSpawner : MonoBehaviour
{
    [Header("Spawn Settings")]
    public GameObject[] objectsToSpawn; 
    public float spawnInterval;

    private float spawnTimer;

    void Start()
    {
        spawnTimer = spawnInterval; 
    }

    void Update()
    {
        spawnTimer -= Time.deltaTime;

        if (spawnTimer <= 0)
        {
            SpawnRandomObject();
            spawnTimer = spawnInterval; 
        }
    }

    void SpawnRandomObject()
    {
        //null check
        if (objectsToSpawn.Length == 0)
        {
            Debug.LogWarning("array empty.");
            return;
        }

        //choose object from array list
        GameObject objectToSpawn = objectsToSpawn[Random.Range(0, objectsToSpawn.Length)];

        //spawns object at spawners position.
        Vector3 spawnPosition = transform.position;

        //spawns object
        Instantiate(objectToSpawn, spawnPosition, Quaternion.identity);
    }
}
