using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Tunnelman : MonoBehaviour
{
    //Private
    Vector2 moveInput;
    Rigidbody2D rb;

    // Public
    public float walkSpeed;
    public float runSpeed;
    public float jumpHeight;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        

        if (Input.GetKey(KeyCode.LeftShift)) {
            Run();
        } 
        else
        {
            Walk();
        }
    }


    // Input System Functions

    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    void OnJump (InputValue value)
    {
        if (value.isPressed)
        {
            rb.velocity += new Vector2(rb.velocity.x, jumpHeight);
        }
    }

    // User-defined Functions

    void Walk()
    {
        Vector2 playerWalkVelocity = new Vector2 (moveInput.x * walkSpeed, rb.velocity.y);
        rb.velocity = playerWalkVelocity;
    }
    
    void Run()
    {
        Vector2 playerRunVelocity = new Vector2(moveInput.x * runSpeed, rb.velocity.y);
        rb.velocity = playerRunVelocity;
    }


}
