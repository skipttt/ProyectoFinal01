using UnityEngine;


public class BackgroundScroll : MonoBehaviour
{
    public float scrollSpeed = 2f;
    private Vector3 startPos;

    void Start() => startPos = transform.position;

    void Update()
    {
        transform.Translate(Vector3.left * scrollSpeed * Time.deltaTime);

        if (transform.position.x < -20) // Ajusta según tu fondo
            transform.position = startPos;
    }
}
