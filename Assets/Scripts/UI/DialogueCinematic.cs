using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.InputSystem;

public class DialogueCinematic : MonoBehaviour
{
    public PlayableDirector dialogueDirector;
    public GameObject Cualli;
    public GameObject canvasWorld;
    PlayerInput input;
    //DashCharacterMovement dashChanged;

    public void PlayCinematic(InputAction.CallbackContext obj)
    {
        dialogueDirector.Play();
        Cualli.GetComponent<characterMovement>().enabled = true;
        canvasWorld.SetActive(true);
        this.enabled = false;
    }

    public void PauseCinematic()
    {
        dialogueDirector.Pause();
        Debug.Log("Pause");
    }

    // prevent the player to move before the cinematic ends
    public void StopMotion()
    {
        Cualli.GetComponent<characterMovement>().enabled = false;
    }

    private void Awake()
    {
        input = new PlayerInput();
    }

    private void OnEnable()
    {
        input.CharacterController.Jump.Enable();
        input.CharacterController.Jump.performed += PlayCinematic;
    }

    private void OnDisable()
    {
        input.CharacterController.Jump.Disable();
    }

}
