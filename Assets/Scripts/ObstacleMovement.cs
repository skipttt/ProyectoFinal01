using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    public float speed = 5f;
    public Vector2 moveDirection = Vector2.left; // Dirección por defecto a la izquierda
    public float lifeTime = 4f;

    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    void Update()
    {
        transform.Translate(moveDirection * speed * Time.deltaTime);
    }
}
