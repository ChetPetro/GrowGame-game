using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public PlayerGrow playerGrow;
    public Transform playerBody;
    public float scaleChange = 0.75f;

    public float sprintModifier = 2f;
    public float speed = 12f;
    public float speedSlideDecrease = 0.2f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;
    private float speedVar = 0f;
    private bool startSlide = true;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    public LayerMask badGroundMask;
    private bool isBadGrounded;
    public Transform spawnPoint;

    public LayerMask finshLineMask;
    private bool isFinished;

    Vector3 velocity;
    private bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        speedVar = speed;
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        
        Vector3 move = transform.right * x + transform.forward * z;

 
        if (Input.GetKey("c"))
        {
            if (startSlide && (speedVar <= speed))
            {
                startSlide = false;
                speedVar += 1.5f;
            }
            speedVar -= speedSlideDecrease * Time.deltaTime;

            if (speedVar < 0)
            {
                speedVar = 0;
            }

            playerBody.transform.localScale = new Vector3(playerGrow.scale, playerGrow.scale * scaleChange, playerGrow.scale);
        }
        else
        {
            startSlide = true;
            speedVar = speed;
            playerBody.transform.localScale = new Vector3(playerGrow.scale, playerGrow.scale, playerGrow.scale);
        }

        if (Input.GetKey("left shift"))
        {
            sprintModifier = 2f;
        }
        else
        {
            sprintModifier = 1f;
        }
        
       
         controller.Move(move * speedVar * sprintModifier * playerGrow.scale * Time.deltaTime);


        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * playerGrow.scale * -2f * gravity);
        }


        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

        isBadGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, badGroundMask);

        if (isBadGrounded)
        {
            playerBody.position = spawnPoint.position;
        }

        isFinished = Physics.CheckSphere(playerBody.position, playerGrow.scale, finshLineMask);

        if (isFinished)
        {
            Debug.Log("Finshed");
        }
    }
}
