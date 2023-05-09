using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowCharacter : MonoBehaviour
{
    private GameObject target;
    private Rigidbody rb;
    public float xRange = 15;
    public float yRange = 8;
    public float cameraSpeed = 1;
    private float differencex, differencey;
    private Vector3 newPosition;

    private void Awake()
    {
        target = GameObject.Find("Player");
        rb = GetComponent<Rigidbody>();
    }


    void Update()
    {
        differencex = Mathf.Abs(transform.position.x - target.transform.position.x);
        differencey = Mathf.Abs(transform.position.y - target.transform.position.y);
        if (differencex >= xRange || differencey >= yRange)
        {
            newPosition = Vector3.Lerp(transform.position, target.transform.position, cameraSpeed * Time.deltaTime);
            transform.position = new Vector3(newPosition.x, newPosition.y, -10);
        }
    }
}