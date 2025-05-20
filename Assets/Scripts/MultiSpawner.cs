using UnityEngine;

public class MultiSpawner : MonoBehaviour
{
    public GameObject[] obstacles;
    public Transform[] spawnPoints;

    private float timer = 0f;

    void Update()
    {
        timer += Time.deltaTime;

        // Obtener spawn rate dinámico desde el DifficultyManager
        float currentSpawnRate = DifficultyManager.Instance.GetCurrentSpawnRate();

        if (timer >= currentSpawnRate)
        {
            SpawnObstacle();
            timer = 0f;
        }
    }

    void SpawnObstacle()
    {
        if (obstacles.Length == 0 || spawnPoints.Length == 0)
            return;

        int spawnIndex = Random.Range(0, spawnPoints.Length);
        int obstacleIndex = Random.Range(0, obstacles.Length);

        Vector3 spawnPos = spawnPoints[spawnIndex].position;
        Instantiate(obstacles[obstacleIndex], spawnPos, Quaternion.identity);
    }
}
