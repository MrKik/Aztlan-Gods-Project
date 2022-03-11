using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public class PlayerData
{    // little note: in characterMovement is the maxhealth and current health (Player)
    // in itempicker is the count of cocoas (UI)
    // in EnergySystem is the current energy (UI)
    // and in superCacaoPickerhere is the count of supercocoas (superCacaoPicker) (Player)


    // here are the variables that I want to save after finishing a level
    public int health;
    public int maxHealth;
    public int itemCount;
    public int energy;
    public int superCacao;

    // the level is the easiest because I always want to begin in the next level after saving the data
    public int level;

    // now here are all the player data functions that will keep track of the original place where are the variables
    //public PlayerData (characterMovement player)
    //{
    //    health = player.currentHealthPlayer;
    //    maxHealth = player.maxHealthPlayer;

    //}
    //public PlayerData (ItemPicker player)
    //{
    //    itemCount = player.countItem;
    //}

    //public PlayerData(EnergySystem player)
    //{
    //    energy = player.currentEnergy;
    //}

    //public PlayerData(SuperCacaoPicker player)
    //{
    //    superCacao = player.countSuperCacao;
    //}

    public PlayerData (Player player)
    {
        health = player.health;
        maxHealth = player.healthMax;
        itemCount = player.itemCacao;
        energy = player.energy;
        superCacao = player.superCacao;
        level = player.level;
    }
}
