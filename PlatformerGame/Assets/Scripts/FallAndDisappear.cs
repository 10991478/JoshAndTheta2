using System.Collections;
using UnityEngine;

public class FallAndDisappear : MonoBehaviour
{
    private WaitForFixedUpdate wffu;
    private WaitForSeconds wfsUntilFall, wfsUntilRespawn;
    public float secondsUntilFall, secondsUntilRespawn, fadeOutRate, fadeInRate;
    public ID playerBottom;
    private SpriteRenderer spriteRenderer;
    private Color color;
    private Vector2 startingPosition;
    private Rigidbody2D rb;
    private Collider2D thisCollider;

    private void Awake() {
        startingPosition = transform.position;
        wfsUntilFall = new WaitForSeconds(secondsUntilFall);
        wfsUntilRespawn = new WaitForSeconds(secondsUntilRespawn);
        spriteRenderer = GetComponent<SpriteRenderer>();
        color = spriteRenderer.color;
        rb = GetComponent<Rigidbody2D>();
        thisCollider = GetComponent<Collider2D>();
    }

    private IEnumerator OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.GetComponent<IDContainer>().id == playerBottom)
        {
            yield return wfsUntilFall;
            rb.bodyType = RigidbodyType2D.Dynamic;
            thisCollider.enabled = false;
            while (color.a >= 0.01f)
            {
                yield return wffu;
                color.a = Mathf.Lerp(color.a, 0, fadeOutRate);
                spriteRenderer.color = color;
            }
            color.a = 0;
            spriteRenderer.color = color;
            Debug.Log("Done fading");
            rb.bodyType = RigidbodyType2D.Static;
            transform.position = startingPosition;
            yield return wfsUntilRespawn;
            while (color.a <= 0.99f)
            {
                yield return wffu;
                color.a = Mathf.Lerp(color.a, 1f, fadeInRate);
                spriteRenderer.color = color;
            }
            thisCollider.enabled = true;
            rb.bodyType = RigidbodyType2D.Static;
            color.a = 1;
            spriteRenderer.color = color;
        }
    }
}
