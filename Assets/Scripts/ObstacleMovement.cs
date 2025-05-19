using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    public float speed = 5f;

    void Start()
    {
        Destroy(gameObject, 4f); // Se destruye después de 4 segundos
    }

    void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);

        if (transform.position.x < -15) 
            Destroy(gameObject);
    }
}
