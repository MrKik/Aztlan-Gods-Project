using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class HealCharacter : MonoBehaviour
{
    // variables for player input
    PlayerInput input;

    // track energy and health
    private EnergySystem classEnergy;
    private characterMovement classCharacter;

    // animator and effects
    public Animator cualliAnim;
    public GameObject healEffect;

    // for stopping character
    private CharacterController controller;

    private void Awake()
    {
        input = new PlayerInput();
        classEnergy = GameObject.FindObjectOfType<EnergySystem>();
        classCharacter = GameObject.FindObjectOfType<characterMovement>();
        // set CharacterController
        controller = gameObject.GetComponent<CharacterController>();
    }

    private void OnHeal(InputAction.CallbackContext obj)
    {
        if(classEnergy.currentEnergy > 0 && classCharacter.currentHealthPlayer < classCharacter.maxHealthPlayer)
        {
            // update energy calling the function
            classEnergy.UpdateEnergyUI(false);

            // update health calling the function
            classCharacter.UpdateHealthWhenHeal();

            // animation and effects
            cualliAnim.SetTrigger("IsHealing");
            AudioManager.instance.PlayHealCualli();
            Instantiate(healEffect, transform.position, new Quaternion(-transform.rotation.y, transform.rotation.x, transform.rotation.z, transform.rotation.w));
        }

    }

    private void OnAnimHeal(InputAction.CallbackContext obj)
    {
        if (classEnergy.currentEnergy > 0 && classCharacter.currentHealthPlayer < classCharacter.maxHealthPlayer)
        {
            cualliAnim.SetTrigger("IsHealing");
            AudioManager.instance.PlayHealCualli();
            Instantiate(healEffect, transform.position, new Quaternion (-transform.rotation.y, transform.rotation.x, transform.rotation.z, transform.rotation.w));
            //classCharacter.StopWhenHealing();
        }

    }

    private void OnEnable()
    {
        // enable heal button

        // when the button is pressed first run the animation and sound
        //input.CharacterController.Heal.started += OnAnimHeal;
        // after the hold time it performed the heal
        input.CharacterController.Heal.performed += OnHeal;
        input.CharacterController.Heal.Enable();
    }

    private void OnDisable()
    {
        // disable heal button
        input.CharacterController.Heal.Disable();
    }
}
