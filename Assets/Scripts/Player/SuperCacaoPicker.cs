using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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


    private void Awake()
    {
        classCharacter = GameObject.FindObjectOfType<characterMovement>();
    }
    void Start()
    {
        countSuperCacao = 0;
    }
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
}
