using UnityEngine;
using UnityEngine.Tilemaps;

public class ChildCollisionScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other != null)
        {
            transform.parent.GetComponent<ParentCollisionScript>().CollisionDetected(this, other);
        }
    }
}