using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    public Vector2 moveDirection = Vector2.left;
    public float lifeTime = 4f;

    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    void Update()
    {
        float currentSpeed = DifficultyManager.Instance.GetCurrentSpeed();
        transform.Translate(moveDirection * currentSpeed * Time.deltaTime);
    }
}
