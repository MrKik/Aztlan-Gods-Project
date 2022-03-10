using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundCharacterMovement : MonoBehaviour
{
    // animator for checking current state
    Animator animator;
    private CharacterController controller;
    bool alreadyPlayed = false;
    bool isGroundedd = true;
    float distToGround = .83f;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        controller = gameObject.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        GroundCheckk();
        Debug.Log(controller.isGrounded);
        Debug.Log(isGroundedd);
        if (isGroundedd)
        {
            if (!alreadyPlayed)
            {
                if (animator.GetCurrentAnimatorStateInfo(0).IsName("Walk"))
                {
                    AudioManager.instance.PlayWalkCualli();
                    alreadyPlayed = true;
                }


            }
            else if (animator.GetCurrentAnimatorStateInfo(0).IsName("Run"))
            {
                AudioManager.instance.PlayRunCualli();
                alreadyPlayed = false;
            }
        } 
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Idle") || !controller.isGrounded)
        {
                AudioManager.instance.StopWalkCualli();
                alreadyPlayed = false;
        }

        //if (!controller.isGrounded && animator.GetCurrentAnimatorStateInfo(0).IsName("Run"))
        //{
        //    AudioManager.instance.StopWalkCualli();
        //    alreadyPlayed = true;
        //}
    }

    void GroundCheckk()
    {
        Debug.DrawRay(transform.position, Vector3.down);

        if (Physics.Raycast(transform.position, Vector3.down, distToGround + 0.1f))
        {
            isGroundedd = true;
        }
        else
        {
            isGroundedd = false;
        }
    }
}
