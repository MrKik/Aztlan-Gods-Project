using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPicker : MonoBehaviour
{
    public int countItem;
    private ItemCount itemUI;
    public int pickToEnergy = 5;
    private EnergySystem energyNew;

    private void Awake()
    {
        itemUI = GameObject.FindObjectOfType<ItemCount>();
        energyNew = GameObject.FindObjectOfType<EnergySystem>();
    }
    void Start()
    {
        countItem = 0;
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
            //countItem = countItem + 1;
        }
    }
}
