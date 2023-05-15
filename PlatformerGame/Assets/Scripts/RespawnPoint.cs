using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnPoint : MonoBehaviour
{
    [SerializeField] private GameObject respawnPoint;
    [SerializeField] private GameObject player;
    public string currentSpawn;
    public float x;
    public float y;



    public void NewSpawnPoint(Collider2D other)
    {
        Debug.Log($"made it to NewSpawnPoint function {other.gameObject.name} ");
        Debug.Log(currentSpawn);
        if (other.gameObject.name != currentSpawn)
        {
            currentSpawn = other.gameObject.name;
            //respawnPoint.GetComponent = other.gameObject;
            Debug.Log($"current spawnPoint: {respawnPoint.name}");
            Debug.Log($"name: {player.name}");
            Debug.Log($"player x position: {player.GetComponent<Transform>().position.x}");
            x = other.gameObject.GetComponent<Transform>().position.x;
            y = other.gameObject.GetComponent<Transform>().position.y;
            Debug.Log($"{x}, {y}, {currentSpawn}");
            
        }
        
    }
    public void Respawn()
    {
        Debug.Log("I revived!");
        player.transform.position = new Vector2(x,y);
        player.SetActive(true);
    }
}
