using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class characterMovement : MonoBehaviour
{
    // character animator component
    Animator animator;

    // variables for parameter IDs
    int isWalkingHash;
    int isRunningHash;
    int isAttackOnHash;
    int isHurtOnHash;
    int isDeadOnHash;

    // variable for PlayerInput
    PlayerInput input;

    // variables to store player input values
    bool movementPressed;
    bool runPressed;
    bool jumpPressed;
    bool attackOn;
    //bool attackRelease;

    // variable direction must equal 0 when joystick doesn't move
    float direction = 0;

    // variables for movement with CharacterController
    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    private float playerSpeed = 2.0f;
    private float originalSpeed = 2.0f;
    private float runningSpeed = 4.0f;
    private float jumpHeight = 1.0f;
    private float gravityValue = -9.81f;

    private float tmpSpeed;

    [Header("Attack Settings")]
    public Transform attackPointPlayer;
    public float attackPointRangePlayer = 0.5f;
    public LayerMask enemyLayers;
    public int attackDamagePlayer = 1;
    private float nextAttackTime = 0f;
    private float attackRate = 0.8f;

    [Header("Damage Settings")]
    public int maxHealthPlayer = 5;
    public int currentHealthPlayer;
    private HealthSystem healthUI;

    [Header("Change Color When Hit")]
    public GameObject myTexture;


    // called when being loaded
    private void Awake()
    {
        input = new PlayerInput();

        // set the player input values using listeners
        input.CharacterController.Movement.performed += ctx =>
        {
            direction = ctx.ReadValue<float>();
            movementPressed = direction != 0;
        };
        input.CharacterController.Run.performed += ctx => runPressed = ctx.ReadValueAsButton();

        input.CharacterController.Jump.performed += ctx => jumpPressed = ctx.ReadValueAsButton();

        input.CharacterController.Attack.performed += ctx => attackOn = ctx.ReadValueAsButton();

        //input.CharacterController.Attack.canceled += ctx => attackRelease = ctx.ReadValueAsButton();

        healthUI = GameObject.FindObjectOfType<HealthSystem>();
    }

    // Start is called before the first frame update
    void Start()
    {
        // set animator
        animator = GetComponent<Animator>();

        // set IDs
        isWalkingHash = Animator.StringToHash("IsWalking");
        isRunningHash = Animator.StringToHash("IsRunning");
        isAttackOnHash = Animator.StringToHash("AttackOn");
        isHurtOnHash = Animator.StringToHash("Hurt");
        isDeadOnHash = Animator.StringToHash("IsDead");

        // set CharacterController
        controller = gameObject.GetComponent<CharacterController>();

        currentHealthPlayer = maxHealthPlayer;
        healthUI.UpdateHealth(maxHealthPlayer, currentHealthPlayer);
    }

    // Update is called once per frame
    void Update()
    {
        if (PauseManager.paused || animator.GetCurrentAnimatorStateInfo(0).IsName("Healing"))
            return;  // added to block movement when paused
        handleMovement();
        handleRotation();
    }

    void handleMovement()
    {
        // MOVEMENT

        // check if is grounded
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        // conversion of direction into a vector 3 to move the character
        Vector3 move = new Vector3(direction, 0, 0);
        controller.Move(move * Time.deltaTime * playerSpeed);

        if (move != Vector3.zero)
        {
            gameObject.transform.forward = move;
        }

        // Changes the height position of the player..
        if (jumpPressed && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);

        // ANIMATION

        // get parameter values from animator
        bool isRunning = animator.GetBool(isRunningHash);
        bool isWalking = animator.GetBool(isWalkingHash);
        bool isAttacking = animator.GetBool(isAttackOnHash);

        // start walking if movementPressed is true and not already walking
        if(movementPressed && !isWalking)
        {
            animator.SetBool(isWalkingHash, true);
            playerSpeed = originalSpeed;
            tmpSpeed = playerSpeed;
        }

        // stop walking if movementPressed is false and is already walking
        if(!movementPressed && isWalking)
        {
            animator.SetBool(isWalkingHash, false);
            playerSpeed = originalSpeed;
            tmpSpeed = playerSpeed;
        }

        // start running if movementPressed and runPressed are true and not already running
        if((movementPressed && runPressed) && !isRunning)
        {
            animator.SetBool(isRunningHash, true);
            playerSpeed = runningSpeed;
            tmpSpeed = playerSpeed;
        }

        // stop running if movementPressed or runPressed are false and is already running
        if((!movementPressed || !runPressed) && isRunning)
        {
            animator.SetBool(isRunningHash, false);
            playerSpeed = originalSpeed;
            tmpSpeed = playerSpeed;
        }

        if (Time.time >= nextAttackTime)
        {
            //tmpSpeed = playerSpeed;
            // check if is attacking
            if (attackOn && !isAttacking)
            {
               // Debug.Log("Attack " + attackOn);
                animator.SetTrigger(isAttackOnHash);
                
                nextAttackTime = Time.time + 1f / attackRate;
                //ExecuteAttack();
                if (groundedPlayer)
                    playerSpeed = 0;
                Debug.Log("GroundAttack");
            }
            else
            {
                //Debug.Log(playerSpeed);
                playerSpeed = tmpSpeed;  //Put back playerSpeed here but it will be froze

            }
                        //Put back playerSpeed here and it will slip

            //if (!attackOn && isAttacking)
            //{
            //    Debug.Log("Attack " + isAttackOnHash);
            //    animator.SetBool(isAttackOnHash, false);
            //}
        }
    }

    void handleRotation()
    {
        // current position of character
        Vector3 currentPosition = transform.position;

        // the change in position the character should point to
        Vector3 newPosition = new Vector3(direction, 0, 0);

        // combine the positions to give a position to look at
        Vector3 positionToLookAt = currentPosition + newPosition;

        //rotate the character to face the positionToLookAt
        transform.LookAt(positionToLookAt);
    }

    private void OnEnable()
    {
        // enable character controls
        input.CharacterController.Enable();
    }

    private void OnDisable()
    {
        // disable character controls
        input.CharacterController.Disable();
    }


    // Attacking and damage functions


    private void ExecuteAttack()
    {
        // launching audio of the attack
        AudioManager.instance.PlayAttackCualli();
        // Detect enemies in range
        Collider[] hitPlayer = Physics.OverlapSphere(attackPointPlayer.position, attackPointRangePlayer, enemyLayers);

        // Damage enemies
        foreach (Collider enemy in hitPlayer)
        {
            Debug.Log("Enemy " + enemy.name);
            enemy.GetComponent<SoldierController>().TakeDamageEnemy(attackDamagePlayer);
            //transform.LookAt(player.transform);
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPointPlayer == null)
            return;
        Gizmos.DrawWireSphere(attackPointPlayer.position, attackPointRangePlayer);
    }


    public void TakeDamagePlayer(int damage)
    {
        currentHealthPlayer -= damage;
        // call function to update UI health
        healthUI.UpdateHealth(maxHealthPlayer, currentHealthPlayer);
        //healthUI.health = currentHealthPlayer;

        AudioManager.instance.PlayDamageCualli();

        // if is dead
        if (currentHealthPlayer <= 0)
        {
            DiePlayer();
        }
        else //if not yet dead
        {

            animator.SetTrigger(isHurtOnHash);

            //Flash damage
            myTexture.GetComponent<FlashDamage>().Flash();
        }

    }
    void DiePlayer()
    {
        Debug.Log("Player died");

        animator.SetBool(isDeadOnHash, true);

        GetComponent<Collider>().enabled = false;
        this.enabled = false;
        AudioManager.instance.PlayDeathCualli();
    }


    public void UpdateHealthWhenHeal()
    {
        currentHealthPlayer += 1;

        healthUI.UpdateHealth(maxHealthPlayer, currentHealthPlayer);
    }

    public void StopWhenHealing()
    {
        playerSpeed = 0;
    }
}
