using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class RunIntoEnemy : MonoBehaviour
{
    public ID enemy;
    RespawnPoint respawnPoint;
    [SerializeField] GameObject player;


    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.GetComponent<IDContainer>().id == enemy) 
        {
            Die();
        }
    }
    public void KillEnemy(Collider2D enemy)
    {
        Destroy(enemy.gameObject);
    }
    public void KillEnemy(Collision2D enemy)
    {
        Destroy(enemy.gameObject);
    }
    public void Die()
    {
        //gameObject.SetActive(false);
        //respawnPoint = Player.gameObject.GetComponent<RespawnPoint>();
        player.GetComponent<RespawnPoint>().Respawn();
    }
}
