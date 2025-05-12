using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    public float speed = 5f;

    void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;

        if (transform.position.x < -15f) // Puedes ajustar el límite
        {
            Destroy(gameObject); // o resetea su posición si es parte de un sistema infinito
        }
    }
}
