using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossbowmanController : MonoBehaviour
{
    // variables to control the time between shots and not shooting 60 times per second
    private float timeBtwShots;
    public float startTimeBtwShots;

    // variables to control when does the arrow will be spawn
    private Transform player;
    private float distance;
    private string currentState = "IdleState";
    public Animator cBMAnim;
    public float shootRange = 16;

    // arrow to instantiate
    public GameObject projectile;

    // variable to flash when damage
    public GameObject myTextureCrossbowman;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        timeBtwShots = startTimeBtwShots;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPosition = new Vector3(player.transform.position.x,
                                             transform.position.y,
                                             player.transform.position.z);
        transform.LookAt(targetPosition);
        distance = Vector3.Distance(transform.position, player.position);

        // idle state
        if (currentState == "IdleState")
        {
            cBMAnim.SetTrigger("IsGone");
            if (distance < shootRange)
                currentState = "ShootState";
        }
        else if (currentState == "ShootState")
        {
            if (timeBtwShots <= 0)
            {
                // shoot animation
                cBMAnim.SetTrigger("Shoot");
                Instantiate(projectile, transform.position, Quaternion.identity); // spawn arrow
                AudioManager.instance.PlayArrowFly();
                timeBtwShots = startTimeBtwShots; // reset timing
            }
            else // wait time to "reload" the weapon
            {
                timeBtwShots -= Time.deltaTime;
            }
            if (distance > shootRange)
                currentState = "IdleState";
        }
    } // projectiles movement will be programed into the arrow prefab


    public void Die()
    {
        AudioManager.instance.PlayDamageSoldier();

        Debug.Log("CrossbowMan died");

        cBMAnim.SetBool("IsDead", true);

        //Flash damage
        myTextureCrossbowman.GetComponent<FlashDamage>().Flash();

        GetComponent<Collider>().enabled = false;

        this.enabled = false;
    }
}
