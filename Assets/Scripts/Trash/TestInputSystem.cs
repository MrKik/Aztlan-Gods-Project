using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TestInputSystem : MonoBehaviour
{

    private Rigidbody sphere;

    private void Awake()
    {
        sphere = GetComponent<Rigidbody>();
    }

    public void JumpTest(InputAction.CallbackContext context)
    {
        Debug.Log("Jump " + context.phase);
        sphere.AddForce(Vector3.up * 5f, ForceMode.Impulse);
    }
}
