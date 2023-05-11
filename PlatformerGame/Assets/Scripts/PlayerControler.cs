using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    private Rigidbody2D rb;
    private Collider2D coll;
    [SerializeField] private LayerMask jumpableGround;
    private float horizontalInput;
    public float speed = 5f;
    public float jumpHeight, jumpSensitivity;
    private bool doubleJump = true;
    private int buffer = 0;
    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (buffer > 0) buffer--;
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
        if (Input.GetButtonDown("Jump")&& (IsGrounded() || doubleJump == true))
        {
            Jump(jumpHeight);
            if (doubleJump && !IsGrounded()) doubleJump = false;
        }
        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, Mathf.Lerp(rb.velocity.y, 0, jumpSensitivity));
        }
    }

    public void Jump(float height)
    {
        rb.velocity = new Vector2(rb.velocity.x, height);
    }
    
    private bool IsGrounded()
    {
        bool isGrounded = Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
        if (isGrounded) doubleJump = true;
        return isGrounded;
    }
}
