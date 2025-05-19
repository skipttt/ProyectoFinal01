using UnityEngine;

public class BackgroundScroll : MonoBehaviour
{
    public float scrollSpeed = 2f;
    private Transform[] backgrounds;
    private float backgroundWidth;

    void Start()
    {
        // Obtén todos los hijos (fondos) en un arreglo
        int childCount = transform.childCount;
        backgrounds = new Transform[childCount];

        for (int i = 0; i < childCount; i++)
        {
            backgrounds[i] = transform.GetChild(i);
        }

        // Suponemos que todos los fondos tienen el mismo ancho
        SpriteRenderer sr = backgrounds[0].GetComponent<SpriteRenderer>();
        if (sr != null)
            backgroundWidth = sr.bounds.size.x;
    }

    void Update()
    {
        // Mueve cada fondo
        foreach (Transform bg in backgrounds)
        {
            bg.Translate(Vector3.left * scrollSpeed * Time.deltaTime);

            // Si ya salió completamente de la vista, lo mandamos al final
            if (bg.position.x <= -backgroundWidth)
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
