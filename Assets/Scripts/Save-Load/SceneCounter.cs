using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneCounter : MonoBehaviour
{
    public int sceneCount;


    [Header("Save/Load variables")]
    private string scenePrefsName = "scene";

    private void Awake()
    {
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            PlayerPrefs.DeleteKey(scenePrefsName);
        }

        LoadSceneData();
    }
    public void SaveSceneData()
    {
        PlayerPrefs.SetInt(scenePrefsName, sceneCount);
        Debug.Log("item data saved" + sceneCount);
    }

    public void LoadSceneData()
    {
        sceneCount = PlayerPrefs.GetInt(scenePrefsName, 1);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "ChangeScene")
        {
            sceneCount++;
            Debug.Log("Scene " + sceneCount);
        }
    }
}
