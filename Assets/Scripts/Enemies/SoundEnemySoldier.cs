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
        // at first the sound played is walking and change the bool to wait for the running state
        if (!alreadyPlayed)
        {
            if (animator.GetCurrentAnimatorStateInfo(0).IsName("WalkingSoldier"))
            {
                AudioManager.instance.PlayWalkSoldier();
                alreadyPlayed = true;
            }
        }
        else
        {
            // if running state, it will play the audio and change the bool in case it goes back to walk
            if (animator.GetCurrentAnimatorStateInfo(0).IsName("RunningSoldier"))
            {
                AudioManager.instance.PlayRunSoldier();
                alreadyPlayed = false;
            }
        }
    }

    public void afterPause()
    {
        alreadyPlayed = false;
    }
}
