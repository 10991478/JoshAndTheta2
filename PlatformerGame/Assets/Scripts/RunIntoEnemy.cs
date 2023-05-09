using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RunIntoEnemy : MonoBehaviour
{
    public UnityEvent collisionEvent, jumpOnEnemyEvent;
    private ID enemyID;
    public ID enemy, enemyTop;

    void OnCollisionEnter(Collision other)
    {
        enemyID = other.gameObject.GetComponent<IDContainer>().id;
        if (enemyID == enemy)
        {
            gameObject.SetActive(false);
            collisionEvent.Invoke();
        }
        else if (enemyID == enemyTop)
        {
            Destroy(other.gameObject);
            jumpOnEnemyEvent.Invoke();
        }
    }
}
