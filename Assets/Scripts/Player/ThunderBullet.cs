using System.Collections;

using System.Collections.Generic;

using UnityEngine;
public class ThunderBullet : MonoBehaviour
{
    // variables for player input
    PlayerInput input;

    // variables for ball throw
    Vector2 aimBall;

    // variables for the ball
    public float ballSpeed = 20;
    public int ballDamage = 1;

    private void Awake()
    {
        input = new PlayerInput();

        // set the player input values with listeners
        input.CharacterController.AimBall.performed += ctx =>
        {
            aimBall = ctx.ReadValue<Vector2>();
        };
    }
    void Update()
    {
        aimBall.x = Mathf.Clamp(aimBall.x, -1.0f, 1.0f);
        aimBall.y = Mathf.Clamp(aimBall.y, -1.0f, 1.0f);
        Vector3 targetBall = new Vector3(aimBall.x, aimBall.y, 0);
        transform.Translate(targetBall * ballSpeed * Time.deltaTime);
        StartCoroutine(WaitToDestroy());
    }


    private void OnEnable()
    {
        // enable character controls
        input.CharacterController.AimBall.Enable();
    }

    private void OnDisable()
    {
        // disable character controls
        input.CharacterController.AimBall.Disable();
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name);
        if (other.tag == "Enemy")
        {
            Debug.Log("hit enemy");
            other.GetComponent<SoldierController>().TakeDamageEnemy(ballDamage);
            Destroy(this.gameObject);
        }

        if (other.tag == "EnemyCrossbow")
        {
            Debug.Log("hit enemy");
            other.GetComponent<CrossbowmanController>().Die();
            Destroy(this.gameObject);
        }
    }

    IEnumerator WaitToDestroy()
    {
        yield return new WaitForSeconds(5);
        Destroy(this.gameObject);
    }
}