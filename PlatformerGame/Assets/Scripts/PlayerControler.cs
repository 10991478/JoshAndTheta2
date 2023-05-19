using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    private Rigidbody2D rb;
    private Collider2D coll;
    RespawnPoint respawnPoint;
    [SerializeField] GameObject player;
    [SerializeField] private LayerMask jumpableGround;
    [SerializeField] private Transform wallCheck;
    [SerializeField] private LayerMask wallLayer;

    private float horizontalInput;
    public float speed = 5f;
    public float jumpHeight, jumpSensitivity;
    private float wallSlidingSpeed = 2f;
    //private float wallJumpingDirection;
    private float wallJumpingTime = 0.2f;
    private float wallJumpingDuration = 0.4f;
    private float wallJumpingCounter;
    private Vector2 wallJumpingPower = new Vector2(8f, 16f);

    private bool isWallSliding;
    private bool doubleJump = true;
    private bool isWallJumping;
    private int buffer = 0;
    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<Collider2D>();
        respawnPoint = player.gameObject.GetComponent<RespawnPoint>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Debug.Log("pog");
            respawnPoint.Respawn();
        }
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
        WallSlide();


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
        if (!doubleJump && IsGrounded()) doubleJump = true;

//wall grab logic
        
    }

    public void Jump(float height)
    {
        rb.velocity = new Vector2(rb.velocity.x, height);
    }
    
    private bool IsGrounded()
    {
        bool isGrounded = Physics2D.BoxCast(coll.bounds.center, new Vector2(coll.bounds.size.x*.9f, coll.bounds.size.y*.7f), 0f, Vector2.down, .2f, jumpableGround);
        if (isGrounded) doubleJump = true;
        return isGrounded;
    }

    private bool IsWalled()
    //method to check if player is touching a wall
    {
        //bool isWalled = Physics2D.OverLapCircle(wallCheck.position);
        bool isWalled = Physics2D.BoxCast(wallCheck.gameObject.GetComponent<Collider2D>().bounds.center, new Vector2(coll.bounds.size.x*.9f, coll.bounds.size.y*.7f), 0f, Vector2.down, .2f, jumpableGround);
        //return isWalled;
        return isWalled;
    }

    private void WallSlide()
    //makes it so that if you are grabbing onto the wall, you will slide down it
    //might want to make it so that there is a delay before that happens though
    {
        if (IsWalled() && !IsGrounded() && horizontalInput != 0f)
        {
            isWallSliding = true;
            rb.velocity = new Vector2(rb.velocity.x, Mathf.Clamp(rb.velocity.y, -wallSlidingSpeed, float.MaxValue));
            if(IsWalled() && !Input.GetKeyDown(KeyCode.LeftArrow)&& !Input.GetKeyDown(KeyCode.RightArrow))
            {
                horizontalInput = 0;
            }
                //probably better to 
            doubleJump = true;

            //CancelInvoke(nameof(StopWallJumping));
        }
        else
        {
            isWallSliding = false;
        }
    }

    /*private void WallJump()
    {
        if (isWallSliding)
        {
            isWallJumping = false;
            wallJumpingDirection = -transform.localScale.x;
            wallJumpingCounter = wallJumpingTime;
        }
        else
        {
            wallJumpingCounter -= Time.deltaTime;
        }
        if (Input.GetButtonDown("Jump") && wallJumpingCounter > 0f)
        {
            isWallJumping = true;
            rb.velocity = new Vector2(wallJumpingDirection * wallJumpingPower.x, wallJumpingPower.y);
            wallJumpingCounter = 0f;
            Invoke(nameof(StopWallJumping), wallJumpingDuration);
        }
    }
    private void StopWallJumping()
    {
        isWallJumping = false;
    }*/
}