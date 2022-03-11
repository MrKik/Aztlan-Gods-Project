using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public void QuitToMainMenu()
    {
        StartCoroutine(WaitTimeExit());
    }
    IEnumerator WaitTimeExit()
    {
        yield return new WaitForSecondsRealtime(0.3f);
        SceneManager.LoadScene("MainMenu");
    }
}