using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Transform enemyPrefab;

    private float spawnRate = 1f;
    private float spawnTimer;

    private void Update()
    {
        if (spawnTimer <= 0)
        {
            Transform enemyInstance = Instantiate(enemyPrefab, SpawnPosition(), enemyPrefab.rotation);
            spawnTimer = spawnRate;
        }
        else 
        {
            spawnTimer -= Time.deltaTime;
        }

    }

    private Vector3 SpawnPosition()
    {
        float[] xyPosition = {Random.Range(-0.1f, 0f), Random.Range(1.0f, 1.1f)};
        Vector3[] possibleSpawnPositions = { new Vector3(Camera.main.ViewportToWorldPoint(new Vector3(xyPosition[Random.Range(0, 2)], 0, 0)).x, Camera.main.ViewportToWorldPoint(new Vector3(0, Random.Range(0f, 1f), 0)).y, 0),
                                             new Vector3(Camera.main.ViewportToWorldPoint(new Vector3(0, Random.Range(0f, 1f), 0)).y, Camera.main.ViewportToWorldPoint(new Vector3(xyPosition[Random.Range(0, 2)], 0, 0)).x, 0)};
            // these two are just the x and y coordinates interchanged
        Vector3 spawnPosition = possibleSpawnPositions[Random.Range(0, possibleSpawnPositions.Length)]; 

        return spawnPosition;
    }
}
