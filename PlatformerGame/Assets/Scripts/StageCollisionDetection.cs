using UnityEngine;
using UnityEngine.Events;

public class StageCollisionDetection : MonoBehaviour
{
    public ID playerBottom;
    public UnityEvent playerGroundedEvent;
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log($"Collided with {other.gameObject.GetComponent<IDContainer>().id}");
        if (other.gameObject.GetComponent<IDContainer>().id == playerBottom)
        {
            Debug.Log("Collided with PlayerBottom");
            //other.transform.parent.GetComponent<PlayerControler>().BecomeGrounded();
            playerGroundedEvent.Invoke();
        }
    }
}
