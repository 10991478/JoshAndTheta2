using UnityEngine;
using UnityEngine.Events;

public class ParentCollisionScript : MonoBehaviour
{
    public UnityEvent collisionEvent, enemyCollisionEvent;
    public ID enemy;
    public void CollisionDetected(ChildCollisionScript childScript, Collider collider)
    {
        if (collider.gameObject.GetComponent<IDContainer>().id == enemy)
        {
            gameObject.GetComponent<RunIntoEnemy>().KillEnemy(collider);
            enemyCollisionEvent.Invoke();
            Debug.Log("Child collided with enemy");
        }
        collisionEvent.Invoke();
    }
    public void CollisionDetected(ChildCollisionScript childScript, Collision collider)
    {
        if (collider.gameObject.GetComponent<IDContainer>().id == enemy)
        {
            gameObject.GetComponent<RunIntoEnemy>().KillEnemy(collider);
            enemyCollisionEvent.Invoke();
            Debug.Log("Child collided with enemy");
        }
        collisionEvent.Invoke();
    }
}
