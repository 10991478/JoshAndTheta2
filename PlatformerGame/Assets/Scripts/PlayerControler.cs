using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    private Rigidbody2D rb;
    private float horizontalInput, lastFrameGrounded;
    public float speed = 5f;
    public float jumpHeight, jumpSensitivity, coyoteFrames;
    private bool grounded, doubleJump = true;
    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        lastFrameGrounded = Time.frameCount;
    }

    // Update is called once per frame
    void Update()
    {
//Movement controls 
        horizontalInput = Input.GetAxis("Horizontal");
        if (horizontalInput != 0)
        {
            rb.velocity = new Vector2(horizontalInput * speed, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }


//Jump controls
        if (Input.GetButtonDown("Jump")&& (grounded == true || doubleJump == true))
        {
            Jump(jumpHeight);
            if (doubleJump && !grounded) doubleJump = false;
            if (grounded) Debug.Log("Using grounded jump");
            else Debug.Log("Using double jump");
        }
        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, Mathf.Lerp(rb.velocity.y, 0, jumpSensitivity));
        }
        if (rb.velocity.y != 0 && grounded == true && Time.frameCount - lastFrameGrounded >= coyoteFrames)
        {
            grounded = false;
            Debug.Log("Set grounded to false");
        }
        if (rb.velocity.y == 0 && grounded)
        {
            Debug.Log("Updated frames");
            lastFrameGrounded = Time.frameCount;
        }
    }

    public void Jump(float height)
    {
        rb.velocity = new Vector2(rb.velocity.x, height);
    }

    public void BecomeGrounded()
    {
        Debug.Log("BecomeGrounded works :P");
        grounded = true;
        doubleJump = true;
        lastFrameGrounded = Time.frameCount;
    }
}
