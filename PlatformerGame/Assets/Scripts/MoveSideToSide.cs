using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSideToSide : MonoBehaviour
{
    private int currentDirection = 1;
    public float speed = 3f;
    private float timeOfLastFlip;
    public float flipFrequency = 3f;
    private Rigidbody2D rb;

    void Start()
    {
        timeOfLastFlip = Time.time;
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Time.time - timeOfLastFlip >= flipFrequency)
        {
            currentDirection *= -1;
            timeOfLastFlip = Time.time;
        }
        rb.velocity = new Vector2(speed * currentDirection, rb.velocity.y);
    }
}
