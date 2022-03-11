using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ItemPicker : MonoBehaviour
{
    public int countItem;
    private ItemCount itemUI;
    public int pickToEnergy = 5;
    private EnergySystem energyNew;


    [Header("Save/Load variables")]
    private string itemCocoaPrefsName = "itemCocoa";

    private void Awake()
    {
        itemUI = GameObject.FindObjectOfType<ItemCount>();
        energyNew = GameObject.FindObjectOfType<EnergySystem>();



        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            PlayerPrefs.DeleteKey(itemCocoaPrefsName);
        }

        LoadCocoaData();

        itemUI.UpdateCocoa(countItem);
    }


    private void OnTriggerEnter(Collider collision)
    {
        if (collision.transform.tag == "Cacao")
        {
            countItem++;
            //Debug.Log(countItem);
            Destroy(collision.gameObject);
            AudioManager.instance.PlayCacaoPick();
            itemUI.UpdateCocoa(countItem);
            if(countItem % pickToEnergy == 0)
            {
                energyNew.UpdateEnergyUI(true);
            }
        }
    }
    public void SaveCocoaData()
    {
        PlayerPrefs.SetInt(itemCocoaPrefsName, countItem);
        Debug.Log("item data saved" + countItem);
    }

    public void LoadCocoaData()
    {
        countItem = PlayerPrefs.GetInt(itemCocoaPrefsName, 0);
    }
}
