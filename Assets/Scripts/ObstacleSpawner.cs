using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject[] obstacles;
    public float spawnRate = 2f;
    public Transform spawnPoint;

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
        int index = Random.Range(0, obstacles.Length);
        Instantiate(obstacles[index], spawnPoint.position, Quaternion.identity);
    }
}
