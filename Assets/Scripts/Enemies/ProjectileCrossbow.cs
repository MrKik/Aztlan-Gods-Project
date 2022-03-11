using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileCrossbow : MonoBehaviour
{
    public float speed;

    // variables to locate the player
    private Transform player;
    private Vector3 target;

    // call to the damage function on Cualli and damage amount
    public characterMovement classCharacter;
    public int damageCrossbow = 2;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        // target will be the position of the player in the moment that the arrow was instantiated
        target = new Vector3(player.position.x, player.position.y, player.position.z);
        
        classCharacter = GameObject.FindObjectOfType<characterMovement>();

    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);

        if(transform.position.x == target.x && transform.position.y == target.y && transform.position.z == target.z)
        {
            DestroyProjectile();
        }
    }

    // to damage
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("ChangeScene")) // I'm reusing the trigger of the level ending
        {
            classCharacter.TakeDamagePlayer(damageCrossbow);
            DestroyProjectile();
        }
    }

    void DestroyProjectile()
    {
        Destroy(gameObject);
    }
}
