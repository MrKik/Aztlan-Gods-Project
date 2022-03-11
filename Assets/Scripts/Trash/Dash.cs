using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour
{
    // variables for player input
    PlayerInput input;

    // variables to dash with rb
    private Rigidbody rb;
    public float dashSpeed;
    private float dashTime;
    public float startDashTime;
    private int direction;
    private Animator playerAnim;
    Vector2 aimDash;

    // variables to store player input values
    bool dashPressed;

    public int registerKeyPress;
    public int dashAllowed = 2;
    public bool isGrounded = true;
    private float disToGround = .83f;

    // place inputs before start
    //private void Awake()
    //{
    //    input = new PlayerInput();

    //    // set the player input values using listeners
    //    input.CharacterController.Movement.performed += ctx =>
    //    {
    //        aimDash = ctx.ReadValue<Vector2>();
    //        //movementPressed = direction != 0;
    //    };
    //    input.CharacterController.Dash.performed += ctx => dashPressed = ctx.ReadValueAsButton();

    //    //input.CharacterController.Attack.canceled += ctx => attackRelease = ctx.ReadValueAsButton();
    //}

    void Start()
    {
        // set CharacterController
        rb = gameObject.GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        dashTime = startDashTime;
        registerKeyPress = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(isGrounded);
        GroundCheck();
            if (direction == 0)
            {
                if (Input.GetKey(KeyCode.LeftArrow) && Input.GetKeyDown(KeyCode.Q) && registerKeyPress < dashAllowed)
                {
                    direction = 1;
                registerKeyPress++;
                }
                else if (Input.GetKey(KeyCode.RightArrow) && Input.GetKeyDown(KeyCode.Q) && registerKeyPress < dashAllowed)
                {
                    direction = 2;
                registerKeyPress++;
                }
                else if (Input.GetKey(KeyCode.UpArrow) && Input.GetKeyDown(KeyCode.Q) && registerKeyPress < dashAllowed)
                {
                    direction = 3;
                registerKeyPress++;
            }
                else if (Input.GetKey(KeyCode.DownArrow) && Input.GetKeyDown(KeyCode.Q) && registerKeyPress < dashAllowed)
                {
                    direction = 4;
                registerKeyPress++;
                }
            }
            else
            {
                if (dashTime <= 0)
                {
                    direction = 0;
                    dashTime = startDashTime;
                    rb.velocity = Vector3.zero;
                    playerAnim.GetComponent<Animator>().enabled = true;
            }
                else
                {
                    dashTime -= Time.deltaTime;

                    if (direction == 1)
                    {
                    playerAnim.GetComponent<Animator>().enabled = false;
                        rb.velocity = Vector3.left * dashSpeed;
                    }
                    if (direction == 2)
                    {
                    playerAnim.GetComponent<Animator>().enabled = false;
                    rb.velocity = Vector3.right* dashSpeed;
                    }
                    if (direction == 3)
                    {
                    playerAnim.GetComponent<Animator>().enabled = false;
                    rb.velocity = Vector3.up * dashSpeed;
                    }
                    if (direction == 4)
                    {
                    playerAnim.GetComponent<Animator>().enabled = false;
                    rb.velocity = Vector3.down * dashSpeed;
                    }
                }
            }
        }
        
    void GroundCheck()
    {
        Debug.DrawRay(transform.position, Vector3.down);

        if(Physics.Raycast(transform.position, Vector3.down, disToGround + 0.1f))
        {
            isGrounded = true;
            registerKeyPress = 0;
        } else
        {
            isGrounded = false;
        }
    }
    private void OnEnable()
    {
        // enable character controls
        input.CharacterController.Enable();
    }

    private void OnDisable()
    {
        // disable character controls
        input.CharacterController.Disable();
    }
}
