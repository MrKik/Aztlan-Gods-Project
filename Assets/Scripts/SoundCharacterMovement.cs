using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundCharacterMovement : MonoBehaviour
{
    // animator for checking current state
    Animator animator;
    private CharacterController controller;
    bool alreadyPlayed = false;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        controller = gameObject.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (controller.isGrounded && !alreadyPlayed)
        {
            if (animator.GetCurrentAnimatorStateInfo(0).IsName("Walk"))
            {
                AudioManager.instance.PlayWalkCualli();
                alreadyPlayed = true;
            }

            if (animator.GetCurrentAnimatorStateInfo(0).IsName("Run"))
            {
                AudioManager.instance.PlayRunCualli();
                alreadyPlayed = true;
            }
        }
        else if(animator.GetCurrentAnimatorStateInfo(0).IsName("Idle") || !controller.isGrounded)
        {
                AudioManager.instance.StopWalkCualli();
                alreadyPlayed = false;
        }
    }
}
