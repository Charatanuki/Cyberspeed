using UnityEngine;

public class SpeedDetecto3r1 : MonoBehaviour
{
    public Camera camera3; // Reference to the Camera component
    public float fovSpeed = 5f; // Speed of FOV change
    private Rigidbody rb;
    private float targetFov;
    private float currentFov;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        currentFov = camera3.fieldOfView;
    }

    void Update()
    {
        float speed = rb.velocity.magnitude * 3.6f; // Convert speed to km/h

        if (speed <= 20f)           // Gear1
        {
            targetFov = 60f;
        }
        else if (speed <= 40f)      // Gear2
        {
            targetFov = 62.5f;
        }
        else if (speed <= 74f)      // Gear3
        {
            targetFov = 65f;
        }
        else if (speed <= 106f)     // Gear4
        {
            targetFov = 67.5f;
        }
        else if (speed <= 149f)     // Gear5
        {
            targetFov = 70f;
        }
        else if (speed <= 178f)     // Gear6
        {
            targetFov = 72.5f;
        }

        currentFov = Mathf.Lerp(currentFov, targetFov, fovSpeed * Time.deltaTime); // Smoothly interpolate between current and target FOV
        camera3.fieldOfView = currentFov;
    }
}
