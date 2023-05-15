using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class RunIntoEnemy : MonoBehaviour
{
    public ID enemy;
    RespawnPoint respawnPoint;
    [SerializeField] GameObject player;

    void Awake()
    {
        respawnPoint = player.gameObject.GetComponent<RespawnPoint>();
    }

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
        gameObject.SetActive(false);
        Debug.Log(gameObject.name);
        Debug.Log($"x value {respawnPoint.x}");
        //respawnPoint = Player.gameObject.GetComponent<RespawnPoint>();
        respawnPoint.Respawn();
    }
}
