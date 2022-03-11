using UnityEngine;

public class QuetzalcoatlFollowCualli: MonoBehaviour
{
    //A simple smooth follow camera,
    // that follows the targets forward direction

    public Transform target;
    float smooth = 0.3f;
    float distance = 1.0f;
    float yVelocity = 0.0f;

    private void Start()
    {
        //transform.rotation = new Quaternion(-90, 0, -90, 1);
    }
    void Update()
    {
        // Damp angle from current y-angle towards target y-angle
        float yAngle = Mathf.SmoothDampAngle(transform.eulerAngles.y, target.eulerAngles.y, ref yVelocity, smooth);
        // Position at the target
        Vector3 position = target.position;
        // Then offset by distance behind the new angle
        position += Quaternion.Euler(0, yAngle, 0) * new Vector3(0, 0, -distance);
        // Apply the position
        transform.position = position;

        // Look at the target
        transform.LookAt(target);

        transform.rotation = new Quaternion(-90, 0, -90, 1);
        //transform.Rotate(-90,0,-90, Space.World);
    }
}
