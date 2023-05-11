using UnityEngine;
using UnityEngine.Events;

public class EnemyColiisionEvents : MonoBehaviour
{
    public UnityEvent playerCollisionEvent;

    public void InvokePlayerCollisionEvent()
    {
        playerCollisionEvent.Invoke();
    }

    public void Deactivate()
    {
        gameObject.SetActive(false);
    }
}
