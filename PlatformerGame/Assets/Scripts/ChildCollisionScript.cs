using UnityEngine;

public class ChildCollisionScript : MonoBehaviour
{
    private void Awake()
    {
        Debug.Log("Child awoken");
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Child collided");
        transform.parent.GetComponent<ParentCollisionScript>().CollisionDetected(this, other);
    }
}