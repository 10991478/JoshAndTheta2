using UnityEngine;
using UnityEngine.Events;

public class ParentCollisionScript : MonoBehaviour
{
    public UnityEvent bounceCollisionEvent, enemyCollisionEvent, groundedEvent;
    public ID enemy, bouncePad;
    public void CollisionDetected(ChildCollisionScript childScript, Collider2D clldr)
    {
        if (clldr.gameObject.GetComponent<IDContainer>().id == enemy)
        {
            gameObject.GetComponent<RunIntoEnemy>().KillEnemy(clldr);
            enemyCollisionEvent.Invoke();
        }
        if (clldr.gameObject.GetComponent<IDContainer>().id == bouncePad)
        {
            bounceCollisionEvent.Invoke();
        }
    }
    public void CollisionDetected(ChildCollisionScript childScript, Collision2D clldr)
    {
        if (clldr.gameObject.GetComponent<IDContainer>().id == enemy)
        {
            gameObject.GetComponent<RunIntoEnemy>().KillEnemy(clldr);
            enemyCollisionEvent.Invoke();
            Debug.Log("Child collided with enemy");
        }
        if (clldr.gameObject.GetComponent<IDContainer>().id == bouncePad)
        {
            bounceCollisionEvent.Invoke();
        }
    }
}
