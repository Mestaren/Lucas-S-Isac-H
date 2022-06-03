using UnityEngine;

public class playerMovement : MonoBehaviour
    //gjord av isac och Lucas
{

    public CharacterController controller;

    public float speed = 12f;
    public float gravity = -60f;
    public float jumpHeight = 3f;

    public float wallJumpHeight = 6f;

    public float runBoost = 24f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;


    //Wall Run
    public Transform wallCheck;
    public float wallDistance = 0.4f;
    public LayerMask wallMask;

    public Transform wallChackLeft;
    public float walldistanceLeft = 0.4f;

    bool isWalled;
    bool isWalledLeft;


    //jetpack


    Vector3 velocity;
    bool isGrounded;
    /* public float XtraJump=1;*/


    public ParticleSystem ps;

    [Header("Camera")]

    [SerializeField] private Camera cam;
    [SerializeField] private float fov;
    [SerializeField] private float wallRunfov;
    [SerializeField] private float wallRunfovTime;
    [SerializeField] private float camTilt;
    [SerializeField] private float camTiltTime;

    public float tilt { get; private set; }

    public float TimeSpeed = 1f;
    public float NormSpeed = 1f;
    public float SlowSpeed = 0.01f;

    private bool time = true;

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

        if (Input.GetButtonDown("Jump") && !isGrounded && isWalled)
        {
            velocity.y = Mathf.Sqrt(wallJumpHeight * -2f * gravity);
        }

        if (Input.GetButtonDown("Jump") && !isGrounded && !isWalled && isWalledLeft)
        {
            velocity.y = Mathf.Sqrt(wallJumpHeight * -2f * gravity);

        }

        /* if (Input.GetButtonDown("Jump"))
         {
             if (isGrounded == false)

             {
                 velocity.y = Mathf.Sqrt(wallJumpHeight * -100f * gravity);
                 XtraJump- 1;

             }
         }
             if (isGrounded)
             {
                 XtraJump = 0;


             }
         else
         {
             XtraJump = 1;
         }
             */


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

            //kamera tilt
            cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, wallRunfov, wallRunfovTime * Time.deltaTime);

            tilt = Mathf.Lerp(tilt, camTilt, camTiltTime * Time.deltaTime);
            //GetComponent<Transform>().rotation = Quaternion.Euler(0, 0,-25);
        }
        else
        {
            gravity = -60f;

            //kamera tilt reset
            cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, fov, wallRunfovTime * Time.deltaTime);

            tilt = Mathf.Lerp(tilt, 0, camTiltTime * Time.deltaTime);
            //GetComponent<Transform>().rotation = Quaternion.Euler(0, 0, 0);
        }

        if (isWalledLeft && !isGrounded)
        {
            gravity = -55f;

            //kamera tilt
            cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, wallRunfov, wallRunfovTime * Time.deltaTime);

            tilt = Mathf.Lerp(tilt, -camTilt, camTiltTime * Time.deltaTime);
        }
        else
        {
            gravity = -60f;

            //kamera tlit reset
            cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, fov, wallRunfovTime * Time.deltaTime);

            tilt = Mathf.Lerp(tilt, 0, camTiltTime * Time.deltaTime);
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            if (time)
            {
                Time.timeScale = 0.1f;
                time = false;
            }
            else
            {
                Time.timeScale = 1f;
                time = true;
            }


            //gravity = -60f + (56f * System.Convert.ToSingle(isWalled && !isGrounded));
            //speed = 12f + (runBoost * System.Convert.ToSingle(Input.GetKey(KeyCode.LeftShift)))

            //jetpack

            /*  if (!isGrounded && Input.GetKey(KeyCode.Space) && !isWalled && !isWalledLeft)
              {
                  velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);

                  ps.Play();
              }
              else
              {
                  ps.Stop();
              }*/
        }

        //Lucas:
        //Jag har gjort Hopp funktionen och wall run funktionerna. och basically det jag gjorde var att jag anv�nde Booleans f�r att checka om jag r�rde marken f�r at hoppa eller r�rde v�g f�r att springa p� v�gen
        // Det jag senare l�rde mig �r att det �r mycket l�ttare att anv�nda sig av raycast och �nd� om det �r mer komplicerat att f�rst� s� hade det nog kunnat underl�tta antal rader kod som man beh�ver skriva
        
        //Isac:
        //
    }
}

