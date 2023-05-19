using UnityEngine;
using UnityEngine.Events;

public class ParentCollisionScript : MonoBehaviour
{

    RespawnPoint respawnPoint;
    [SerializeField] GameObject player;
    public UnityEvent bounceCollisionEvent, enemyCollisionEvent, spawnPointCollisionEvent, deathPlaneCollisionEvent;
    public ID enemyKillbox, bouncePad, spawnPoint, deathPlane;
    void Awake()
    {
        respawnPoint = player.gameObject.GetComponent<RespawnPoint>();
    }

    public void CollisionDetected(ChildCollisionScript childScript, Collider2D clldr)
    {
        if (clldr.gameObject.GetComponent<IDContainer>().id == enemyKillbox)
        {
            clldr.transform.parent.GetComponent<EnemyColiisionEvents>().InvokePlayerCollisionEvent();
            enemyCollisionEvent.Invoke();
        }
        if (clldr.gameObject.GetComponent<IDContainer>().id == bouncePad)
        {
            bounceCollisionEvent.Invoke();
        }
        if (clldr.gameObject.GetComponent<IDContainer>().id == spawnPoint)
        {
            //need to find a better way to access the script
            //respawnPoint = player.gameObject.GetComponent<RespawnPoint>();
            respawnPoint.NewSpawnPoint(clldr);

        }
        if (clldr.gameObject.GetComponent<IDContainer>().id == deathPlane)
        {
            //need to find a better way to access the script
            //respawnPoint = player.gameObject.GetComponent<RespawnPoint>();
            Debug.Log("hitbox detecteds");
            deathPlaneCollisionEvent.Invoke();
            //respawnPoint.Respawn();

        }
    }
    public void CollisionDetected(ChildCollisionScript childScript, Collision2D clldr)
    {
        if (clldr.gameObject.GetComponent<IDContainer>().id == enemyKillbox)
        {
            clldr.transform.parent.GetComponent<EnemyColiisionEvents>().InvokePlayerCollisionEvent();
            enemyCollisionEvent.Invoke();
        }
        if (clldr.gameObject.GetComponent<IDContainer>().id == bouncePad)
        {
            bounceCollisionEvent.Invoke();
        }
        if (clldr.gameObject.GetComponent<IDContainer>().id == spawnPoint)
        {
            spawnPointCollisionEvent.Invoke();
        }
        
    }
}
