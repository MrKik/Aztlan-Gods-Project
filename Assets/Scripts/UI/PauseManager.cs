using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PauseManager : MonoBehaviour
{
    PlayerInput input;

    public static bool paused = false;

    public GameObject menu;

    private void Awake()
    {
        input = new PlayerInput();
    }

    private void OnEnable()
    {
        input.CharacterController.PauseGame.Enable();
        input.CharacterController.PauseGame.performed += CheckPause;
    }

    private void OnDisable()
    {
        input.CharacterController.PauseGame.Disable();
    }

    private void CheckPause(InputAction.CallbackContext obj)
    {
        if (paused)
            ResumeGame();
        else
            PauseGame();
    }
    public void PauseGame()
    {
        Time.timeScale = 0;
        //AudioListener.pause = true;
        paused = true;
        menu.SetActive(true);
        AudioManager.instance.StopWalkSoldier();
        AudioManager.instance.PlayPauseButton();
    }

    public void ResumeGame()
    {
        StartCoroutine(WaitTime());
        //Time.timeScale = 1;
        //AudioListener.pause = false;
        //paused = false;
        //menu.SetActive(false);
    }

    IEnumerator WaitTimeFrame()
    {
        //print(Time.time);
        ////yield return new WaitForSecondsRealtime(0.1f);
        
        //print(Time.time);
        
        yield return new WaitForEndOfFrame();
        Time.timeScale = 1;
        AudioListener.pause = false;
        paused = false;
        menu.SetActive(false);
    }
        

    IEnumerator WaitTime()
    {
        yield return new WaitForSecondsRealtime(0.3f);
        Time.timeScale = 1;
        AudioListener.pause = false;
        paused = false;
        menu.SetActive(false);
    }
}
