using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // using SerializeField for best practice, so that the variables are private but can be accessed in the inspector
    [field: Header("Component Variables")] // accessing player character components
    [SerializeField] private Rigidbody2D rb; // accessing Rigidbody2D component
    [SerializeField] private CapsuleCollider2D playerCollider; // CapusleCollider2D for the player
    [SerializeField] private Transform groundCheck; // checks if the players is touching the ground layer (can apply to tileset)
    [SerializeField] private LayerMask groundLayer; // layermask for the ground layer
    

    [field: Header("Movement Variables")] // movement variables
    [SerializeField] private float speed = 8f; // speed of the player
    [SerializeField] private float jumpForce = 8f; // force of the jump
    private float horizontal; // horizontal input

    [field: Header("Animation Stuff")] // random animation variables (commented out, currently)
    //public SpriteRenderer sR; // for dealing with sprites later
    // public Animator animator; // for dealing with animations later
    // private bool isFacingRight = true; // checks if the player is facing right
    // Still have to add a lot of code for animations but will do so later as to not clog up the script


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        GetInput(); // getting input
        Jump(); // jumping function
        Crouch(); // crouching function
    }
    
    // FixedUpdate is called once per fixed frame; has the same framerate as the physics system, so it is framerate independent
    void FixedUpdate()
    {
        Move(); // movement function for the player
    }

    private void GetInput()
    {
        horizontal = Input.GetAxisRaw("Horizontal"); // getting horizontal input
    }

    private void Move()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y); // moving the player
    }

    private bool isGrounded() // groundcheck bool
    {
        // Debug.Log("Grounded");
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer); // ground check using child object
    }

    private void Jump()
    {
        if (isGrounded() && Input.GetButton("Jump")) // if the player is grounded and the jump button is pressed, the player can jump
        {
            Debug.Log("Jumping");
            rb.velocity = new Vector2(rb.velocity.x, jumpForce); // jump force applied to rigidbody
        }
    }

    private void Crouch() // is a little scuffed, will fix later
    {
        if (Input.GetKeyDown(KeyCode.LeftControl)) // if the left control key is pressed, the player can crouch
        {
            Debug.Log("Crouching");
            playerCollider.size = new Vector2(playerCollider.size.x, 0.5f); // changing the size of the collider
            playerCollider.offset = new Vector2(playerCollider.offset.x, -0.25f); // changing the offset of the collider
        }
        else if (Input.GetKeyUp(KeyCode.LeftControl)) // if the left control key is released, the player can stand up
        {
            Debug.Log("Not crouching");
            playerCollider.size = new Vector2(playerCollider.size.x, 1f); // changing the size of the collider
            playerCollider.offset = new Vector2(playerCollider.offset.x, 0f); // changing the offset of the collider
        }
    }

}
