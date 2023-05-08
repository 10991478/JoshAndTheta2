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
        rb.velocity = Vector3.right * horizontalInput * speed;

        if (horizontalInput != 0)
        {
            Debug.Log($"Horizontal movement:{horizontalInput} velocity:{rb.velocity} speed: {speed} time: {Time.deltaTime}");
        }


        
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Jump();
        }

    }

    public void Jump()
    {
        rb.velocity = Vector3.up * jumpHeight;
    }
}
