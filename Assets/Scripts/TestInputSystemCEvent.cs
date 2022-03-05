using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class TestInputSystemCEvent : MonoBehaviour
{
    private PlayerInput input;
    //private InputAction movement;

    private void Awake()
    {
        input = new PlayerInput();
    }

    private void OnEnable()
    {
        //movement = input.CharacterController.Movement;
        //movement.Enable();

        input.CharacterController.Dash.started += OnDash;
        input.CharacterController.Dash.performed += WhileDash;
        input.CharacterController.Dash.canceled += ExitDash;
        input.CharacterController.Dash.Enable();
    }

    private void ExitDash(InputAction.CallbackContext obj)
    {
        Debug.Log("Exit");
    }

    private void WhileDash(InputAction.CallbackContext obj)
    {
        Debug.Log("While");
    }

    private void OnDash(InputAction.CallbackContext obj)
    {
        Debug.Log("Start");
    }

    private void OnDisable()
    {
        //movement.Disable();
        input.CharacterController.Dash.Disable();
    }
}
