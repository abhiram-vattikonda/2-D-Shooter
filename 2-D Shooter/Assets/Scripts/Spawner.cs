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
        float yPosition = Random.value;
        float verticalSide = Random.Range(0, 10) % 2;
        float xPosition = Random.value;
        float horizontalSides = Random.Range(0, 10) % 2;

        Vector3[] possibleSpawnPosition =
        {
            Camera.main.ViewportToWorldPoint(new Vector3(verticalSide, yPosition, -1)),
            Camera.main.ViewportToWorldPoint(new Vector3(xPosition, horizontalSides, -1))
        };

        Vector3 spawnPosition = possibleSpawnPosition[Random.Range(0, possibleSpawnPosition.Length)];

        return new Vector3(spawnPosition.x, spawnPosition.y, -1);
    }
}
