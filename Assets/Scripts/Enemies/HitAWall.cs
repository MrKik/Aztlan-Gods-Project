using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitAWall : MonoBehaviour
{
    SoldierController callSoldier;
    private void Awake()
    {
        // with this I can link the call with the parent script of each object
        callSoldier = this.GetComponentInParent<SoldierController>();
    }
    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log(other.name);
        if (other.tag == "Ground")
        {
            //Debug.Log("Invisiblewall");
            callSoldier.Wall();

        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.tag == "Ground")
        {
            Debug.Log("Physical wall");
            //callSoldier.Wall();
        }


    }
}
