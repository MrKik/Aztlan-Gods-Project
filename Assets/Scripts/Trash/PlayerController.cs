using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{

    public Animator playerAnimator;
    public CapsuleCollider capsuleCollider;
    public Rigidbody playerRB;

    private bool setColliderY = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Run();
        if (Input.GetButtonDown("Jump"))
        {
             Jump();
        }

        if (setColliderY)
        {
            GetComponent<CapsuleCollider>().center = new Vector3(0,
                playerAnimator.GetFloat("yCollider"), 0);
                //capsuleCollider.center.y = playerAnimator.GetFloat("HeightCollider");

        }
    }

    void Run()
    {
        playerAnimator.SetFloat("speed",
                        Input.GetAxis("Horizontal"));
    }

    void Jump()
    {
        playerAnimator.SetTrigger("Jump");
    }

    public void EnableColliderY()
    {
        setColliderY = true;
        /*originalGravity = Physics.gravity;*/
        /*playerRB.useGravity = false;*/
        playerRB.isKinematic = true;

    }
    public void DisableColliderY()
    {
        setColliderY = false;
        /*Physics.gravity = originalGravity;*/
        /*playerRB.useGravity = true;*/
        playerRB.isKinematic = false;
    }
}
