using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEnemySoldier : MonoBehaviour
{
    // animator for checking current state
    Animator animator;
    bool alreadyPlayed = false;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!alreadyPlayed)
        {
            if (animator.GetCurrentAnimatorStateInfo(0).IsName("WalkingSoldier"))
            {
                AudioManager.instance.PlayWalkSoldier();
                alreadyPlayed = true;
            }

            if (animator.GetCurrentAnimatorStateInfo(0).IsName("RunningSoldier"))
            {
                AudioManager.instance.PlayRunSoldier();
                alreadyPlayed = true;
            }

            if (animator.GetCurrentAnimatorStateInfo(0).IsName("AttackSoldier"))
            {
                AudioManager.instance.StopWalkSoldier();
                alreadyPlayed = false;
            }
        }
        else
        {

        }
    }
}
