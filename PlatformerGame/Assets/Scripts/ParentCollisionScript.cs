using UnityEngine;
using UnityEngine.Events;

public class ParentCollisionScript : MonoBehaviour
{

    [SerializeField] GameObject player;
    public UnityEvent bounceCollisionEvent, enemyCollisionEvent, spawnPointCollisionEvent, deathPlaneCollisionEvent;
    public ID enemyKillbox, bouncePad, spawnPoint, deathPlane, stage;


    public void CollisionDetected(ChildCollisionScript childScript, Collider2D clldr)
    {
        /*switch(clldr.gameObject.GetComponent<IDContainer>().id)
        {
            case enemyKillbox:
                clldr.transform.parent.GetComponent<EnemyColiisionEvents>().InvokePlayerCollisionEvent();
                enemyCollisionEvent.Invoke();
                break;

            case bouncePad:
                bounceCollisionEvent.Invoke();
                break;

            case spawnPoint:
                player.GetComponent<RespawnPoint>().NewSpawnPoint(clldr);
                break;

            case deathPlane:
                deathPlaneCollisionEvent.Invoke();
                break;

            /*case stage:
                if (childScript.gameObject.GetComponent<IDContainer>().id == wallCheck)
                {
                    player.GetComponent<PlayerControler>().
                }*/

        
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
            player.GetComponent<RespawnPoint>().NewSpawnPoint(clldr);
            //respawnPoint.NewSpawnPoint(clldr);

        }
        if (clldr.gameObject.GetComponent<IDContainer>().id == deathPlane)
        {
            //respawnPoint.Respawn();
            deathPlaneCollisionEvent.Invoke();
        }
    }
    
    /*public void CollisionDetected(ChildCollisionScript childScript, Collision2D clldr)
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
    }*/
}

