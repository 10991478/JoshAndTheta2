using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RunIntoEnemy : MonoBehaviour
{
    public UnityEvent collisionEvent;
    private ID enemyID;
    public ID enemy;

    void OnCollisionEnter(Collision other)
    {
        enemyID = other.gameObject.GetComponent<IDContainer>().id;
        if (enemyID == enemy)
        {
            Destroy(gameObject);
            collisionEvent.Invoke();
        }
    }
}
