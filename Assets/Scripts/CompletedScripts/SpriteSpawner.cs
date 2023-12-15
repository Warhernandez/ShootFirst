using System.Collections;
using UnityEngine;

public class SpriteSpawner : MonoBehaviour
{
    public GameObject civilianPrefab;
    public GameObject wantedPrefab;

    public float minSpawnTime = 1f;
    public float maxSpawnTime = 5f;
    public float wantedSpawnProbability = 0.1f; // Adjust this probability as needed for civilians

    public float spawnXMin = -15f; // Minimum x-coordinate for spawning
    public float spawnXMax = -5f;  // Maximum x-coordinate for spawning

    public int maxCivilianCount = 5; // Maximum number of civilians allowed
    private int currentCivilianCount = 0; // Current number of active civilians

    private bool wantedSpawned = false; // Track if the wanted sprite has been spawned

    private void Start()
    {
        // Start the spawning coroutine
        InvokeRepeating("Spawn", 0f, Random.Range(minSpawnTime, maxSpawnTime));
    }

    private void Spawn()
    {
        // Check if the maximum number of civilians is reached
        if (currentCivilianCount < maxCivilianCount)
        {
            // Decide whether to spawn a civilian or a wanted character
            float randomValue = Random.value;
            GameObject prefabToSpawn = randomValue < wantedSpawnProbability && !wantedSpawned ? wantedPrefab : civilianPrefab;

            // Instantiate the selected prefab with x-coordinate within the specified range
            float spawnX = Random.Range(spawnXMin, spawnXMax);
            GameObject spawnedObject = Instantiate(prefabToSpawn, new Vector2(spawnX, Random.Range(-10f, 5f)), Quaternion.identity);

            // If a "wanted" sprite is spawned, mark it as spawned to prevent further spawns
            if (prefabToSpawn == wantedPrefab)
            {
                wantedSpawned = true;
            }
            else
            {
                // Increment the current civilian count
                currentCivilianCount++;
            }
        }

        // Check if the maximum time for wanted spawn is reached
        if (Time.time >= 7f && !wantedSpawned)
        {
            // If the wanted sprite hasn't spawned by the end of 7 seconds, spawn it
            GameObject spawnedObject = Instantiate(wantedPrefab, new Vector2(Random.Range(spawnXMin, spawnXMax), Random.Range(-10f, 5f)), Quaternion.identity);
            wantedSpawned = true;
        }
    }

    // Add a method to decrease the civilian count when a civilian is destroyed
    public void DecreaseCivilianCount()
    {
        currentCivilianCount = Mathf.Max(0, currentCivilianCount - 1);
    }
}

