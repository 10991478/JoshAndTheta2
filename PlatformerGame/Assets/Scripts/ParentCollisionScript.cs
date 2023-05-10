using UnityEngine;
using UnityEngine.Events;

public class ParentCollisionScript : MonoBehaviour
{
    public UnityEvent bounceCollisionEvent, enemyCollisionEvent;
    public ID enemy, bouncePad;
    public void CollisionDetected(ChildCollisionScript childScript, Collider collider)
    {
        if (collider.gameObject.GetComponent<IDContainer>().id == enemy)
        {
            gameObject.GetComponent<RunIntoEnemy>().KillEnemy(collider);
            enemyCollisionEvent.Invoke();
        }
        if (collider.gameObject.GetComponent<IDContainer>().id == bouncePad)
        {
            bounceCollisionEvent.Invoke();
        }
    }
    public void CollisionDetected(ChildCollisionScript childScript, Collision collider)
    {
        if (collider.gameObject.GetComponent<IDContainer>().id == enemy)
        {
            gameObject.GetComponent<RunIntoEnemy>().KillEnemy(collider);
            enemyCollisionEvent.Invoke();
            Debug.Log("Child collided with enemy");
        }
        if (collider.gameObject.GetComponent<IDContainer>().id == bouncePad)
        {
            bounceCollisionEvent.Invoke();
        }
    }
}
