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
        if (other.gameObject.name != currentSpawn)
        {
            currentSpawn = other.gameObject.name;
            //respawnPoint.GetComponent = other.gameObject;
            x = other.gameObject.GetComponent<Transform>().position.x;
            y = other.gameObject.GetComponent<Transform>().position.y;
            Debug.Log($"{x}, {y}, {currentSpawn}");
            
        }
        
    }
    public void Respawn()
    {
        player.transform.position = new Vector2(x,y);
        player.SetActive(true);
    }
}
