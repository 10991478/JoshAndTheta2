using UnityEngine;
using UnityEngine.Tilemaps;

public class ChildCollisionScript : MonoBehaviour
{
    [SerializeField] private GameObject parent;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other != null)
        {
            parent.GetComponent<ParentCollisionScript>().CollisionDetected(this, other);
        }
    }
}