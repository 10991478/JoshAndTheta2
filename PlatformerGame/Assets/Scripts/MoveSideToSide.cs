using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSideToSide : MonoBehaviour
{
    private int currentDirection = 1;
    public float speed = 3f;
    private float timeOfLastFlip;
    public float flipFrequency = 3f;

    void Start()
    {
        timeOfLastFlip = Time.time;
    }

    void Update()
    {
        if (Time.time - timeOfLastFlip >= flipFrequency)
        {
            currentDirection *= -1;
            timeOfLastFlip = Time.time;
        }
        transform.Translate(Vector3.right * currentDirection * speed * Time.deltaTime);
    }
}
