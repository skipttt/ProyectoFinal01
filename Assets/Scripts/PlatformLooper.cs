
using UnityEngine;

public class PlatformLooper : MonoBehaviour
{
    public float speed = 5f;
    public float resetX = 20f;
    public float destroyX = -20f;

    void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;

        if (transform.position.x < destroyX)
        {
            transform.position = new Vector3(resetX, transform.position.y, transform.position.z);
        }
    }
}
