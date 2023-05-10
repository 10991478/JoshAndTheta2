using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    private Rigidbody rb;
    private float horizontalInput;
    public float speed = 5f;
    public float jumpHeight;
    public bool slow;
    public bool grounded = true;
    public bool doubleJump = true;
    

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
        if (Input.GetKeyUp(KeyCode.LeftArrow) && Input.GetKeyUp(KeyCode.RightArrow))
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }


        
        if (Input.GetButtonDown("Jump")&& (grounded == true || doubleJump == true))
        {
            Jump(jumpHeight);
            if (grounded == false)
            {
                doubleJump = false;
            }
        }
        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, -3);
            
        }
        if (rb.velocity.y < 0 || rb.velocity.y > 0)
            {
                grounded = false;
            }
        else
            {
                grounded = true;
                doubleJump = true;
            }


    }

    public void Jump(float height)
    {
        rb.velocity = new Vector2(rb.velocity.x, height);
    }
}
