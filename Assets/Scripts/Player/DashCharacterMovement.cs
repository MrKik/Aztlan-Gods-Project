using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DashCharacterMovement : MonoBehaviour
{
    // variables for player input
    PlayerInput input;

    // variables to dash with characther controller
    private CharacterController ccontroller;
    public float dashSpeed;
    private float dashTime;
    public float startDashTime;
    private bool direction;
    Vector2 aimDash;
    private bool groundedPlayer;

    // variables to store player input values
    bool dashPressed;
    bool dashAimed;

    // variables to control amount of dashes
    public int registerKeyPress;
    public int dashAllowed = 2;
    private bool dashNotPressed;
    private bool dashPressedClick;

    // variable for dash particle
    public GameObject dashEffect;

    // place inputs before start
    private void Awake()
    {
        input = new PlayerInput();

        // set the player input values using listeners
        input.CharacterController.Aiming.performed += ctx =>
        {
            aimDash = ctx.ReadValue<Vector2>();
            dashAimed = aimDash.x != 0 || aimDash.y != 0;
        };
    }

    void Start()
    {
        // set CharacterController
        ccontroller = gameObject.GetComponent<CharacterController>();
        dashTime = startDashTime;
        registerKeyPress = 0;
    }

    //Update is called once per frame
    void Update()
    {
        // direction is a boolean that help to know when the player can dash and when not
            //if player is in ground reset registerKeyPress
            groundedPlayer = ccontroller.isGrounded;
            if (groundedPlayer)
            {
                registerKeyPress = 0;
            }

            if (direction == false)
            {
                if (dashAimed && dashPressed && !groundedPlayer && registerKeyPress < dashAllowed)
                {
                    Instantiate(dashEffect, transform.position, Quaternion.identity);
                    direction = true;
                    registerKeyPress++;
                }
            }
            else
            {
                if (dashTime <= 0)
                {
                    direction = false;
                    dashTime = startDashTime;
                }
                else
                {
                    dashTime -= Time.deltaTime;
                    handleDash();
                }
            
        }

        //if (dashPressed)
        //{
        //    Debug.Log("Hold");
        //    dashPressedClick = false;
        //}
    }

    private void OnDash(InputAction.CallbackContext obj)
    {
        dashPressed = true;
        Debug.Log("Dashing");
    }

    void handleDash()
    {
        Vector3 move = new Vector3(aimDash.x, aimDash.y, 0);
        ccontroller.Move(move * dashSpeed * Time.deltaTime);
        AudioManager.instance.PlayDashCualli();
    }

    private void OnEnable()
    {
        // enable character controls
        input.CharacterController.Dash.started += OnDash;
        input.CharacterController.Dash.performed += ExitDash;
        input.CharacterController.Dash.Enable();
        input.CharacterController.Aiming.Enable();
    }

    private void ExitDash(InputAction.CallbackContext obj)
    {
        dashPressed = false;
        Debug.Log("Not");
    }

    private void OnDisable()
    {
        // disable character controls
        input.CharacterController.Dash.Disable();
        input.CharacterController.Aiming.Disable();
    }
}
