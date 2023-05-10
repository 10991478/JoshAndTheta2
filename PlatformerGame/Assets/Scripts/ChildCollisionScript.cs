using UnityEngine;

public class ChildCollisionScript : MonoBehaviour
{
    private void Awake()
    {
        Debug.Log("Child awoken");
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Child collided");
        transform.parent.GetComponent<ParentCollisionScript>().CollisionDetected(this, other);
    }
}