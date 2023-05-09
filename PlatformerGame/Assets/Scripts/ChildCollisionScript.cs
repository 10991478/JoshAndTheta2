using UnityEngine;

public class ChildCollisionScript : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        transform.parent.GetComponent<ParentCollisionScript>().CollisionDetected(this, other);
    }
}
