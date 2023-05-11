using UnityEngine;
using UnityEngine.Tilemaps;

public class ChildCollisionScript : MonoBehaviour
{
    private void Awake()
    {
        Debug.Log("Child awoken");
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other != null)
        {
            //Debug.Log($"Child collided with {other.gameObject.GetComponent<IDContainer>().id}");
            transform.parent.GetComponent<ParentCollisionScript>().CollisionDetected(this, other);
        }
    }
}