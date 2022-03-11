using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class MainMenu : MonoBehaviour
{
    public GameObject levelLoader;
    public GameObject sceneCounter;
    public GameObject alternativeMainMenu;
    public GameObject alternativeStart;

    private void Start()
    {
        if(sceneCounter.GetComponent<SceneCounter>().sceneCount > 1)
        {
            alternativeMainMenu.SetActive(true);
            var eventSystem = EventSystem.current;
            eventSystem.SetSelectedGameObject(alternativeStart, new BaseEventData(eventSystem));
            this.enabled = false;
        }
        else
        {
            alternativeMainMenu.SetActive(false);
            this.enabled = true;
        }
    }
    public void ContinueGame()
    {
        Debug.Log("Continue");
        levelLoader.GetComponent<LevelLoader>().LoadIndexLevel(sceneCounter.GetComponent<SceneCounter>().sceneCount);
    }
    public void PlayGame()
    {
        Debug.Log("Play");
        levelLoader.GetComponent<LevelLoader>().LoadIndexLevel(SceneManager.GetActiveScene().buildIndex +1);
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
