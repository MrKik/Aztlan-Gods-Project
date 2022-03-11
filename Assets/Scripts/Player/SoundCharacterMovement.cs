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
        //Debug.Log(controller.isGrounded);
        //Debug.Log(isGroundedd);
        //if (isGroundedd)
        //{
        //    if (!alreadyPlayed)
        //    {
        //        AudioManager.instance.PlayWalkCualli();
        //        alreadyPlayed = true;
        //if (animator.GetCurrentAnimatorStateInfo(0).IsName("Walk"))
        //{
        //    AudioManager.instance.PlayWalkCualli();
        //    alreadyPlayed = true;
        //}


        //}
        //else if (animator.GetCurrentAnimatorStateInfo(0).IsName("Run"))
        //{
        //    AudioManager.instance.PlayRunCualli();
        //    alreadyPlayed = false;
        //}
        //} // the comments are failed attemps to change the pith of an audio depending of the animation, at the end it just play an average pitch between run pitch and walk pitch
        if (!alreadyPlayed)
        {
            if (isGroundedd && (animator.GetCurrentAnimatorStateInfo(0).IsName("Walk") || animator.GetCurrentAnimatorStateInfo(0).IsName("Run")))
            {
                AudioManager.instance.PlayWalkCualli();
                alreadyPlayed = true;
            }
        }
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Idle") || !isGroundedd)
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
