
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSideToSide : MonoBehaviour
{
    private int currentDirection = 1;
    public float speed = 3f;
    private float timeOfLastFlip;
    public float flipFrequency = 3f;
    private float turn = .1f;
    private Rigidbody2D rb;
    private Collider2D coll;
    [SerializeField] private GameObject enemy;
    [SerializeField] private LayerMask platformEdge;

    void Start()
    {
        timeOfLastFlip = Time.time;
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<Collider2D>();
    }

    void Update()
    {
        if (Time.time - timeOfLastFlip >= flipFrequency || OnEdge())
        {
            if (Time.time - timeOfLastFlip >= turn)
            {
                currentDirection *= -1;
                timeOfLastFlip = Time.time;
            }    
        }
        rb.velocity = new Vector2(speed * currentDirection, rb.velocity.y);
    }

    private bool OnEdge()
    {
        bool onEdge = Physics2D.BoxCast(coll.bounds.center, new Vector2(coll.bounds.size.x*.9f, coll.bounds.size.y*.7f), 0f, Vector2.down, .2f, platformEdge);
        return onEdge;
    }
}
