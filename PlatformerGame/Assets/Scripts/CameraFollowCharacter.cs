using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowCharacter : MonoBehaviour
{
    public GameObject target;
    public float xRange = 15;
    public float yRange = 8;
    public float speed = 5;
    private float distance;
    private float difference;

    // Update is called once per frame
    void Update()
    {
        distance = transform.position.x - target.transform.position.x;
        difference = Mathf.Abs(distance);
        if (difference >= xRange)
        {
            if (distance < 0)
            {
                transform.Translate(Vector3.right * speed * Time.deltaTime);
            }
            else
            {
                transform.Translate(Vector3.left * speed * Time.deltaTime);
            }
        }

        distance = transform.position.y - target.transform.position.y;
        difference = Mathf.Abs(distance);
        if (difference >= yRange)
        {
            if (distance < 0)
            {
                transform.Translate(Vector3.up * speed * Time.deltaTime);
            }
            else
            {
                transform.Translate(Vector3.down * speed * Time.deltaTime);
            }
        }
    }
}