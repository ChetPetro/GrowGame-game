using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Imports other c# scripts
    public CharacterController controller;
    public PlayerGrow playerGrow;
    public Transform playerBody;
    public Timer timerText;
    public Leaderboard leaderboard;

    // Initilize important variable for player movement (set values != real values)
    public float scaleChange = 0.75f;
    private float sprintModifier = 1.5f;
    public float speed = 12f;
    public float speedSlideDecrease = 0.2f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;
    private float speedVar = 0f;
    private bool startSlide = true;
    Vector3 velocity;
    private bool isGrounded;

    // Import groundCheck objects and initilize variables
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    // Import badGroundCheck (death) objects and initilize variables
    public LayerMask badGroundMask;
    public bool isBadGrounded;
    public bool badGrouded = false;
    public Transform spawnPoint;

    // Import finishLine objects and initilize variables
    public LayerMask finshLineMask;
    private bool isFinished;
    public bool finished;

    // Import LeaderboardCanvas
    public Canvas leaderboardCanvas;

    // Import startLine object and initilize variables
    public LayerMask startLineMask;
    private bool isStarted;
    public bool started;


    // Start is called before the first frame update
    void Start()
    {
        speedVar = speed;
        finished = false;
        started = false;
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the player has crossed the start line
        isStarted = Physics.CheckSphere(groundCheck.position, groundDistance, startLineMask);
        if (isStarted)
        {
            badGrouded = false; 
            started = true;
        } 

        // Check if the player is touching the ground
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        // Push the player into the groud if they are touching the ground
        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        // Get WASD key horizontal and vertical inputs (WS->x, AD->z)
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        // Create a vector for movement
        Vector3 move = transform.right * x + transform.forward * z;

        // If slide
        if (Input.GetKey("c"))
        {
            // If the player can slide allow them too
            if (startSlide && (speedVar <= speed))
            {
                startSlide = false;
                speedVar += 1.5f;
            }
            // Decrease the speed of the slide every frame 
            speedVar -= speedSlideDecrease * Time.deltaTime;

            if (speedVar < 0)
            {
                speedVar = 0;
            }

            // change the y scale of the player to be smaller when sliding 
            playerBody.transform.localScale = new Vector3(playerGrow.scale, playerGrow.scale * scaleChange, playerGrow.scale);
        }

        // If not sliding
        else
        {
            startSlide = true;
            speedVar = speed;
            playerBody.transform.localScale = new Vector3(playerGrow.scale, playerGrow.scale, playerGrow.scale);
        }

        // If sprinting change the speed
        if (Input.GetKey("left shift"))
        {
            speedVar = speed * sprintModifier;
        }
        else
        {
            speedVar = speed;
        }
        
         // move the player every frame based on the move vector/speed/scale
         controller.Move(move * speedVar * playerGrow.scale * Time.deltaTime);

        // If jumping and on ground then jump
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * playerGrow.scale * -2f * gravity);
        }

        // Apply a grabity to the player
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        // Check if the player is touching the ground
        isBadGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, badGroundMask);

        // If the player is touching the ground then reset them 
        if (isBadGrounded)
        {
            badGrouded = true; 
            playerGrow.scale = 1f;
            started = false;
            speedVar = speed;
            velocity.y = -2f;
            playerBody.position = spawnPoint.position;
            playerBody.rotation = Quaternion.Euler(0f, 0f, 0f);
        }

        // Check if the player is touching the fnish line
        isFinished = Physics.CheckSphere(groundCheck.position, groundDistance, finshLineMask);

        // Show the leaderboard when finished
        if (isFinished)
        {
            Cursor.lockState = CursorLockMode.Confined;
            leaderboardCanvas.enabled = true;
            leaderboard.ShowInfo();
            finished = true;
        }
    }
}
