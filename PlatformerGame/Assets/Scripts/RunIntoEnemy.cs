using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RunIntoEnemy : MonoBehaviour
{
    public UnityEvent collisionEvent, jumpOnEnemyEvent;
    private ID otherID;
    public ID enemy;
    public ID enemyTop;

    void OnCollisionEnter(Collision other)
    {
        otherID = other.gameObject.GetComponent<IDContainer>().id;
        if (otherID == enemy)
        {
            gameObject.SetActive(false);
            collisionEvent.Invoke();
        }
        else if (otherID == enemyTop)
        {
            Destroy(other.gameObject);
            Debug.Log("Jumped On Enemy");
            jumpOnEnemyEvent.Invoke();
        }
    }
}
