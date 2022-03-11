using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 1f;

    public void LoadIndexLevel(int levelIndex)
    {
        StartCoroutine(LoadLevel(levelIndex));
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        Debug.Log(levelIndex);
        // play animation
        transition.SetTrigger("Start");

        // wait while animate
        yield return new WaitForSeconds(transitionTime);

        // load new scene
        SceneManager.LoadScene(levelIndex);

    }
}
