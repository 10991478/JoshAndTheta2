using UnityEngine;
using UnityEngine.Events;

public class PlatformCollisions : MonoBehaviour
{
    public UnityEvent collisionEvent;

    private void OnCollisionEnter2D(Collision2D other) {
        collisionEvent.Invoke();
    }
}
