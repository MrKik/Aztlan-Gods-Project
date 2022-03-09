using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierController : MonoBehaviour
{
    [Header("State Manager")]
    private string currentState = "WalkingState";
    private Transform target;
    public float chaseRange = 5;
    public Animator enemyAnim;
    public float speed = 3;
    public float attackRange = 2;
    public float speedWalk = 1.5f;

    [Header("Walking Settings")]
    public Transform[] moveSpots;
    private int randomSpot;

    [Header("Attack Settings")]
    public Transform attackPointEnemy;
    public float attackPointRangeEnemy = 0.5f;
    public LayerMask playerLayers;
    public int attackDamageEnemy = 1;
    private float nextAttackTimeEnemy = 0f;
    private float attackRateEnemy = 0.5f;

    [Header("Damage Settings")]
    public int maxHealth = 2;
    public int currentHealth;
    public HealthBar healthBar;
    public GameObject uiBar;

    [Header("Change Color When Hit")]
    public GameObject myTextureEnemy;

    //[Header("Access to the soundEnemy")]

    //public SoundEnemySoldier

    private void Awake()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;

    }
    // Start is called before the first frame update
    void Start()
    {
        randomSpot = 0;
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(transform.position, target.position);

        // idle state (patrolling state)
        if (currentState == "WalkingState")
        {
            enemyAnim.SetTrigger("IsGone");
            //Debug.Log(currentState);
            //Debug.Log(distance);
            //AudioManager.instance.PlayWalkSoldier();
            transform.position = Vector3.MoveTowards(transform.position, moveSpots[randomSpot].position, speedWalk * Time.deltaTime);
            transform.LookAt(moveSpots[randomSpot]);

            if (Vector3.Distance(transform.position, moveSpots[randomSpot].position) < 0.2f)
            {
                randomSpot = Random.Range(0, moveSpots.Length);
            }

            if (distance < chaseRange)
                currentState = "ChaseState";
        } 
        
        // chasing the player state
        else if(currentState == "ChaseState")
        {
            // play run animation
            enemyAnim.SetTrigger("Chase");
            enemyAnim.SetBool("IsAttacking", false);
            //AudioManager.instance.PlayRunSoldier();

            if(distance < attackRange)
            {
                currentState = "AttackState";
            }

            if(distance > 3*attackRange)
            {
                currentState = "WalkingState";
            }
            
            if(target.position.x > transform.position.x)
            {
                // move left
                transform.Translate(-transform.right * speed * Time.deltaTime);
                transform.rotation = Quaternion.Euler(0, 90, 0);
            }
            else
            {
                // move right
                transform.Translate(transform.right * speed * Time.deltaTime);
                transform.rotation = Quaternion.Euler(0, -90, 0);
            }
        }
        else if(currentState == "AttackState")
        {
            if (Time.time >= nextAttackTimeEnemy)
            {
                enemyAnim.SetBool("IsAttacking", true);
                nextAttackTimeEnemy = Time.time + 1f / attackRateEnemy;
                //ExecuteAttack();
            }
                if (distance > attackRange)
            {
                currentState = "ChaseState";
            }
        }
        else if (currentState == "DamageState") // the soldier stays in place if its hurt
        {
            transform.position = Vector3.MoveTowards(transform.position, transform.position, 0.0f * Time.deltaTime);
        }
    }

    private void ExecuteAttack() // to attach at the middle of the AttackSoldier animation
    {
        // launching audio of the attack
        AudioManager.instance.PlayAttackSoldier();
        // Detect enemies in range
        Collider[] hitPlayer = Physics.OverlapSphere(attackPointEnemy.position, attackPointRangeEnemy, playerLayers);

        // Damage enemies
        foreach (Collider player in hitPlayer)
        {
            Debug.Log("Enemy " + player.name);
            player.GetComponent<characterMovement>().TakeDamagePlayer(attackDamageEnemy);
        }
    }


    private void OnDrawGizmosSelected()
    {
        if (attackPointEnemy == null)
            return;
        Gizmos.DrawWireSphere(attackPointEnemy.position, attackPointRangeEnemy);
    }

    private void ChasingAfterHurt() // to attach at the end of reaction animation
    {
        currentState = "ChaseState";
    }

    public void TakeDamageEnemy(int damage)
    {
        currentHealth -= damage;

        healthBar.SetHealth(currentHealth);

        AudioManager.instance.PlayDamageSoldier();

        enemyAnim.SetBool("IsAttacking", false);

        enemyAnim.SetTrigger("Hurt");

        currentState = "DamageState";

        //Flash damage
        myTextureEnemy.GetComponent<FlashDamage>().Flash();

        // Die animation

        if (currentHealth <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        Debug.Log("Enemy died");

        enemyAnim.SetBool("IsDead", true);

        GetComponent<Collider>().enabled = false;

        Destroy(uiBar);

        this.enabled = false;
        //if (gameObject != null)
        //{
        //    Destroy(gameObject, 3f);
        //}
        //Destroy(this.gameObject, 3);
    }
}
