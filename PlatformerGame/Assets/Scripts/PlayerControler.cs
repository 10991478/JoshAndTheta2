using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    private Rigidbody rb;
    private float horizontalInput;
    public float speed = 5;
    public float jumpHeight;
    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
        horizontalInput = Input.GetAxis("Horizontal");
        if (horizontalInput != 0)
        {
            rb.velocity = new Vector2(horizontalInput * speed, rb.velocity.y);
        }


        
        if (Input.GetButtonDown("Jump"))
        {
            Jump(jumpHeight);
        }

    }

    public void Jump(float height)
    {
        rb.velocity = new Vector2(rb.velocity.x, height);
    }
}
