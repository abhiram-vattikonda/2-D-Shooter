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
        /*float[] xyPosition = {Random.Range(-0.1f, 0f), Random.Range(1.0f, 1.1f)};
        Vector3[] possibleSpawnPositions = { new Vector3(Camera.main.ViewportToWorldPoint(new Vector3(xyPosition[Random.Range(0, 2)], 0, -1)).x, Camera.main.ViewportToWorldPoint(new Vector3(0, Random.Range(0f, 1f), 0)).y, -1),
                                             new Vector3(Camera.main.ViewportToWorldPoint(new Vector3(0, Random.Range(0f, 1f), -1)).y, Camera.main.ViewportToWorldPoint(new Vector3(xyPosition[Random.Range(0, 2)], 0, 0)).x, -1)};
            // these two are just the x and y coordinates interchanged
        Vector3 spawnPosition = possibleSpawnPositions[Random.Range(0, possibleSpawnPositions.Length)];*/

        float yPosition = Random.value;
        float verticalSide = Random.Range(0, 100) % 2;
        float xPosition = Random.value;
        float horizontalSides = Random.Range(0, 100) % 2;

        Vector3[] possibleSpawnPosition =
        {
            Camera.main.ViewportToWorldPoint(new Vector3(verticalSide, yPosition, -1)),
            Camera.main.ViewportToWorldPoint(new Vector3(xPosition, horizontalSides, -1))
        };

        Vector3 spawnPosition = possibleSpawnPosition[Random.Range(0, possibleSpawnPosition.Length - 1)];

        return new Vector3(spawnPosition.x, spawnPosition.y, -1);
    }
}
