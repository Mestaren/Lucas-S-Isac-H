using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 12f;
    public float gravity = -60f;
    public float jumpHeight = 3f;

    public float runBoost = 24f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    public Transform wallCheck;
    public float wallDistance = 0.4f;
    public LayerMask wallMask;

    bool isWalled;

    Vector3 velocity;
    bool isGrounded;

    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        
        isWalled = Physics.CheckSphere(wallCheck.position, wallDistance, wallMask);

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
   
        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = 24f;
        }
        else
        {
            speed = 12f;
        }

        
        if (isWalled && !isGrounded)
        {
            gravity = -4f;
        }
        else
        {
            gravity = -60f;
        }

        //gravity = -60f + (56f * System.Convert.ToSingle(isWalled && !isGrounded));
        //speed = 12f + (runBoost * System.Convert.ToSingle(Input.GetKey(KeyCode.LeftShift)))
    }


}

