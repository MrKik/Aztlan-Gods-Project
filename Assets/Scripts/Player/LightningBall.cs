using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class LightningBall : MonoBehaviour
{
    // variables for player input
    PlayerInput input;

    // variables for ball throw
    public GameObject electricityBall;
    public float speedBall;
    private float timeBtwThrow;
    public float startTimeBtwThrow;
    Vector2 aimBall;
    private bool isShooting;
    private GameObject tmpBall;

    // bools to detect when an input is acting
    private bool ballAimed;
    private bool ballPressed;
    private bool justOnce;

    // to get reference about the energy
    EnergySystem classEnergy;

    // to animate the characther
    public Animator cualliAnim;

    private void Awake()
    {
        input = new PlayerInput();
        classEnergy = GameObject.FindObjectOfType<EnergySystem>();
        // set the aim input values with listeners this keep enabled because I need to check if it's aimed
        input.CharacterController.AimBall.performed += ctx =>
        {
            aimBall = ctx.ReadValue<Vector2>();
            ballAimed = aimBall.x != 0 || aimBall.y != 0;
        };
    }
    // Start is called before the first frame update
    void Start()
    {
        timeBtwThrow = startTimeBtwThrow;
        justOnce = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isShooting)
        {
            if (ballAimed && ballPressed && classEnergy.currentEnergy > 0)
            {
                isShooting = true;
            }
        }
        else
        {
            if (timeBtwThrow <= 0)
            {
                isShooting = false;
                timeBtwThrow = startTimeBtwThrow;
                justOnce = true;
            }
            else
            {
                timeBtwThrow -= Time.deltaTime;
                handleShoot();
            }
        }
    }

    void handleShoot()
    {
        Debug.Log("ball");
        /*tmpBall = */Instantiate(electricityBall, transform.position, Quaternion.identity);
        //aimBall.x = Mathf.Clamp(aimBall.x, -1.0f, 1.0f);
        //aimBall.y = Mathf.Clamp(aimBall.y, -1.0f, 1.0f);
        //Vector3 targetBall = new Vector3(aimBall.x, aimBall.y, 0);
        //tmpBall.transform.position = Vector3.MoveTowards(transform.position, targetBall, speedBall * Time.deltaTime);

        // all the aiming is in the bullet script, inside the prefab of BallGO

        //update energy calling the function
        if (justOnce)
        {
            classEnergy.UpdateEnergyUI(false);
            justOnce = false;
        }

        //animation and effects
        cualliAnim.SetTrigger("IsLightning");
        AudioManager.instance.PlayLightningAttack();
    }


    private void OnShoot(InputAction.CallbackContext obj)
    {
        ballPressed = true;
        
    }

    private void OnEnable()
    {
        // enable character controls
        input.CharacterController.Shoot.started += OnShoot;
        input.CharacterController.Shoot.performed += ExitShoot;
        input.CharacterController.Shoot.Enable();
        input.CharacterController.AimBall.Enable();
    }

    private void ExitShoot(InputAction.CallbackContext obj)
    {
        ballPressed = false;
    }

    private void OnDisable()
    {
        // disable character controls
        input.CharacterController.Shoot.Disable();
        input.CharacterController.AimBall.Disable();
    }
}
