using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
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

    Vector3 velocity;
    bool isGrounded;

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
                speedVar += 6f;
            }
            speedVar -= speedSlideDecrease * Time.deltaTime;
            if(speedVar < 0)
            {
                speedVar = 0;
            }

            playerBody.transform.localScale = new Vector3(1f, 1f * scaleChange, 1f);
        }
        else
        {
            startSlide = true;
            speedVar = speed;
            playerBody.transform.localScale = new Vector3(1f, 1f, 1f);
        }

        if (Input.GetKey("left shift"))
        {
            controller.Move(move * speedVar * sprintModifier * Time.deltaTime);
        }
        else
        {
            controller.Move(move * speedVar * Time.deltaTime);
        }

        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }


        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }
}
