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

    public Transform wallChackLeft;
    public float walldistanceLeft = 0.4f;

   // public float z;
   // public GameObject FPplayer;

    bool isWalled;
    bool isWalledLeft;

    Vector3 velocity;
    bool isGrounded;

    

    void Update()
    {

        
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        
        isWalled = Physics.CheckSphere(wallCheck.position, wallDistance, wallMask);

        isWalledLeft = Physics.CheckSphere(wallChackLeft.position, walldistanceLeft, wallMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        if (isWalled && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        if (isWalledLeft && velocity.y < 0)
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
            gravity = -55f;

           
            //GetComponent<Transform>().rotation = Quaternion.Euler(0, 0,-25);
        }
        else
        {
            gravity = -60f;
          //GetComponent<Transform>().rotation = Quaternion.Euler(0, 0, 0);
        }

        if (isWalledLeft && !isGrounded)
        {
            gravity = -55f;
        }
        else
        {
            gravity = -60f;
        }

        //gravity = -60f + (56f * System.Convert.ToSingle(isWalled && !isGrounded));
        //speed = 12f + (runBoost * System.Convert.ToSingle(Input.GetKey(KeyCode.LeftShift)))
    }


}

