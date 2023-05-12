using UnityEngine;

public class InitialConditions : MonoBehaviour
{
    public Vector3 position;
    public RigidbodyType2D rigidbodyType;
    public Color color;
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void RestoreToInitialConditions()
    {
        transform.position = position;
        if (rb != null) rb.bodyType = rigidbodyType;
        spriteRenderer.color = color;
    }
}
