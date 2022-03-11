using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class NewLevel : MonoBehaviour
{
    PlayerInput input;
    public GameObject levelLoader;
    private void Awake()
    {
        this.enabled = false;
    }

    private void ChangeLevel(InputAction.CallbackContext obj)
    {
        levelLoader.GetComponent<LevelLoader>().LoadIndexLevel(2);
    }

    private void OnEnable()
    {
        input.CharacterController.Textok.Enable();
        input.CharacterController.Textok.performed += ChangeLevel;
    }

    private void OnDisable()
    {
        input.CharacterController.Textok.Disable();
    }
}
