using UnityEngine;

public class BackgroundScroll : MonoBehaviour
{
    public float scrollSpeed = 2f;
    private Transform[] backgrounds;
    private float backgroundWidth;
    private const float overlapOffset = 0.2f; // Aumentamos la superposición a 0.2 unidades

    void Start()
    {
        int childCount = transform.childCount;
        backgrounds = new Transform[childCount];

        for (int i = 0; i < childCount; i++)
        {
            backgrounds[i] = transform.GetChild(i);
        }

        SpriteRenderer sr = backgrounds[0].GetComponent<SpriteRenderer>();
        if (sr != null)
        {
            backgroundWidth = sr.bounds.size.x - overlapOffset; // Se fuerza la superposición
            Debug.Log("Background Width (Adjusted): " + backgroundWidth);
        }

        // Alinear con solapamiento fuerte
        for (int i = 1; i < backgrounds.Length; i++)
        {
            backgrounds[i].position = new Vector3(
                backgrounds[i - 1].position.x + backgroundWidth,
                backgrounds[i].position.y,
                backgrounds[i].position.z
            );
        }
    }

    void Update()
    {
        foreach (Transform bg in backgrounds)
        {
            bg.Translate(Vector3.left * scrollSpeed * Time.deltaTime);

            // Mantener posición redondeada
            bg.position = new Vector3(
                Mathf.Round(bg.position.x * 100f) / 100f,
                bg.position.y,
                bg.position.z
            );

            // Usar un margen de seguridad amplio
            if (bg.position.x <= -backgroundWidth - 0.5f) // Aumento del margen
            {
                float rightMostX = GetRightMostX();
                bg.position = new Vector3(rightMostX + backgroundWidth, bg.position.y, bg.position.z);
            }
        }
    }

    float GetRightMostX()
    {
        float maxX = backgrounds[0].position.x;
        foreach (Transform bg in backgrounds)
        {
            if (bg.position.x > maxX)
                maxX = bg.position.x;
        }
        return maxX;
    }
}
