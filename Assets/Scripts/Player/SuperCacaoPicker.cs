using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SuperCacaoPicker : MonoBehaviour
{
    // little note: in characterMovement is the maxhealth and current health
    // in itempicker is the count of cocoas
    // in EnergySystem is the current energy
    // and here is the count of supercocoas

    // counter
    public int countSuperCacao;

    // track health
    private characterMovement classCharacter;

    [Header("Save/Load variables")]
    private string superCacaoPrefsName = "superCacao";

    private void Awake()
    {
        classCharacter = GameObject.FindObjectOfType<characterMovement>();

        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            PlayerPrefs.DeleteKey(superCacaoPrefsName);
        }

        LoadSuperCacaoData();
    }
    //void Start()
    //{
    //    countSuperCacao = 0;
    //}
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.transform.tag == "SuperCacao")
        {
            countSuperCacao++;
            //Debug.Log(countItem);
            Destroy(collision.gameObject);
            AudioManager.instance.PlaySuperCacaoPick();
            classCharacter.UpdateAmountOfHearts();
        }
    }

    public void SaveSuperCacaoData()
    {
        PlayerPrefs.SetInt(superCacaoPrefsName,countSuperCacao);
    }

    public void LoadSuperCacaoData()
    {
        countSuperCacao = PlayerPrefs.GetInt(superCacaoPrefsName, 0);
    }
}
