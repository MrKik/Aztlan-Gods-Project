using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitAWall : MonoBehaviour
{
    SoldierController callSoldier;
    //private void OnTriggerEnter(Collider other)
    //{
    //    if(other.tag == "Ground")
    //    {
    //        callSoldier.mustTurn();
    //    }
    //}

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag =="Ground")
        {
            callSoldier.Wall();
        }


    }
}
