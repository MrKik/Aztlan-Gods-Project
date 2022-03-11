using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public int level;
    public int health;
    public int energy;
    public int cacao;

    public PlayerData(Player player)
    {
        level = player.level;
        health = player.health;
        energy = player.energy;
        cacao = player.cacao;
    }
}
