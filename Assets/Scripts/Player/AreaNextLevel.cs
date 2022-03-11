using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class AreaNextLevel : MonoBehaviour
{
    
    PlayerInput input;
    public PlayableDirector dialogueDirector;
    public GameObject levelLoader;
    public bool isEnding = false;
    private int enter = 1;
    public Animator cualliAnim;

    private void Awake()
    {
        input = new PlayerInput();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "ChangeScene")
        {
            isEnding = false;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        
        Debug.Log(other.name);
        if (other.tag == "ChangeScene")
        {
            cualliAnim.SetBool("IsWalking", false);
            cualliAnim.SetBool("IsRunning", false);

            if (enter == 1)
                {
                dialogueDirector.Play();
                    enter++;
                }
            if (isEnding)
                levelLoader.GetComponent<LevelLoader>().LoadIndexLevel(2);
        }
    }

    public void PlayCinematicAgain()
    {
        dialogueDirector.Play();
        if(isEnding)
           levelLoader.GetComponent<LevelLoader>().LoadIndexLevel(2);
    }

    private void ChangeLevel(InputAction.CallbackContext obj)
    {
        isEnding = true;
        
    }

    private void OnEnable()
    {
        input.CharacterController.Jump.Enable();
        input.CharacterController.Jump.performed += ChangeLevel;
    }

    private void OnDisable()
    {
        input.CharacterController.Jump.Disable();
    }

}
