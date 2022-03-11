using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    // little note: in characterMovement is the maxhealth and current health (Player)
    // in itempicker is the count of cocoas (UI)
    // in EnergySystem is the current energy (UI)
    // and in superCacaoPickerhere is the count of supercocoas (superCacaoPicker) (Player)
    public int level;

    public int health; /*= GameObject.FindObjectOfType<characterMovement>().currentHealthPlayer;*/
    public int healthMax; /*= GameObject.FindObjectOfType<characterMovement>().maxHealthPlayer;*/
    public int itemCacao; /*= GameObject.FindObjectOfType<ItemPicker>().countItem;*/
    public int energy; /*= GameObject.FindObjectOfType<EnergySystem>().currentEnergy;*/
    public int superCacao; /*= GameObject.FindObjectOfType<SuperCacaoPicker>().countSuperCacao;*/

    // first call all the different classes that contain a variable that I want to keep
    //characterMovement classCharacter;
    //ItemPicker classItem;
    //EnergySystem classEnergy;
    //SuperCacaoPicker classSuperCacao;

    // in the awake I assign correctly every class
    private void Awake()
    {
        level = SceneManager.GetActiveScene().buildIndex + 1;
            /*public int */health = GameObject.FindObjectOfType<characterMovement>().currentHealthPlayer;
    /*public int */healthMax = GameObject.FindObjectOfType<characterMovement>().maxHealthPlayer;
    /*public int */itemCacao = GameObject.FindObjectOfType<ItemPicker>().countItem;
    /*public int */energy = GameObject.FindObjectOfType<EnergySystem>().currentEnergy;
    /*public int */superCacao = GameObject.FindObjectOfType<SuperCacaoPicker>().countSuperCacao;
    //    classCharacter = GameObject.FindObjectOfType<characterMovement>();
    //    classItem = GameObject.FindObjectOfType<ItemPicker>();
    //    classEnergy = GameObject.FindObjectOfType<EnergySystem>();
    //    classSuperCacao = GameObject.FindObjectOfType<SuperCacaoPicker>();
}

    // now with everything assigned, let's declarate the variables that will receive all the data


    // Start is called before the first frame update
    //void Start()
    //{
    //    public int energy = classEnergy.currentEnergy;
    //}

    public void SavePlayer()
    {
        SaveSystem.SavePlayer(this);
        Debug.Log("Data saved");
    }

    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer();

        level = data.level;
        health = data.health;
        healthMax = data.maxHealth;
        energy = data.energy;
        itemCacao = data.itemCount;
        superCacao = data.superCacao;
        Debug.Log("Data loaded");
    }

}
