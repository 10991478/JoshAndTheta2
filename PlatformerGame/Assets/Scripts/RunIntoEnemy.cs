using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RunIntoEnemy : MonoBehaviour
{
    public ID enemy;

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.GetComponent<IDContainer>().id == enemy) Die();
    }
    public void KillEnemy(Collider enemy)
    {
        Destroy(enemy.gameObject);
    }
    public void KillEnemy(Collision enemy)
    {
        Destroy(enemy.gameObject);
    }
    public void Die()
    {
        gameObject.SetActive(false);
    }
}
