using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    PlayerInput input;

    public static bool paused = false;

    public GameObject menu;

    private SoundEnemySoldier soundEnemy;

    public GameObject levelLoader;

    private void Awake()
    {
        input = new PlayerInput();

        soundEnemy = GameObject.FindObjectOfType<SoundEnemySoldier>();
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
        AudioManager.instance.StopWalkCualli();
        AudioManager.instance.PlayPauseButton();
    }

    public void ResumeGame()
    {
        StartCoroutine(WaitTime());
    }
    
    IEnumerator WaitTime()
    {
        yield return new WaitForSecondsRealtime(0.3f);
        Time.timeScale = 1;
        AudioListener.pause = false;
        paused = false;
        menu.SetActive(false);
        soundEnemy.afterPause();
    }

    public void QuitToMainMenu()
    {
        StartCoroutine(WaitTimeExit());
    }

    IEnumerator WaitTimeExit()
    {
        yield return new WaitForSecondsRealtime(0.3f);
        Time.timeScale = 1;
        AudioListener.pause = false;
        paused = false;
        levelLoader.GetComponent<LevelLoader>().LoadIndexLevel(0);
    }
}
