using UnityEngine;

public class MultiSpawner : MonoBehaviour
{
    public GameObject[] obstacles;
    public Transform[] spawnPoints;  // Múltiples puntos de disparo
    public float spawnRate = 2f;

    private float timer = 0f;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnRate)
        {
            SpawnObstacle();
            timer = 0f;
        }
    }

    void SpawnObstacle()
    {
        int spawnIndex = Random.Range(0, spawnPoints.Length);
        int obstacleIndex = Random.Range(0, obstacles.Length);

        Vector3 spawnPos = spawnPoints[spawnIndex].position;
        Instantiate(obstacles[obstacleIndex], spawnPos, Quaternion.identity);
    }


}
