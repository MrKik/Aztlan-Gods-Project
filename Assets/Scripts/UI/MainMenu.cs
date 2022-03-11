using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject levelLoader;
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
