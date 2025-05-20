using UnityEngine;

public class DifficultyManager : MonoBehaviour
{
    public static DifficultyManager Instance;

    [Header("Disparo")]
    public float baseSpeed = 5f;
    public float speedIncreaseRate = 0.1f; // más suave

    [Header("Spawn")]
    public float baseSpawnRate = 2f;
    public float spawnRateDecrease = 0.01f; // más gradual
    public float minSpawnRate = 0.4f;

    [Header("Background Scroll")]
    public float baseScrollSpeed = 2f;
    public float scrollSpeedIncrease = 0.05f;

    private float startTime;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            startTime = Time.time;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public float GetCurrentSpeed()
    {
        float elapsed = Time.time - startTime;
        return baseSpeed + elapsed * speedIncreaseRate;
    }

    public float GetCurrentSpawnRate()
    {
        float elapsed = Time.time - startTime;
        return Mathf.Max(minSpawnRate, baseSpawnRate - (elapsed * spawnRateDecrease));
    }

    public float GetCurrentScrollSpeed()
    {
        float elapsed = Time.time - startTime;
        return baseScrollSpeed + elapsed * scrollSpeedIncrease;
    }
    public void ResetDifficulty()
    {
        startTime = Time.time;
    }

}
