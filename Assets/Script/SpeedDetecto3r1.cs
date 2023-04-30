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

        if (speed <= 20f)
        {
            targetFov = 60f;
        }
        else if (speed <= 40f)
        {
            targetFov = 62.5f;
        }
        else if (speed <= 74f)
        {
            targetFov = 65f;
        }
        else if (speed <= 106f)
        {
            targetFov = 67.5f;
        }
        else if (speed <= 149f)
        {
            targetFov = 70f;
        }
        else if (speed <= 178f)
        {
            targetFov = 72.5f;
        }

        currentFov = Mathf.Lerp(currentFov, targetFov, fovSpeed * Time.deltaTime); // Smoothly interpolate between current and target FOV
        camera3.fieldOfView = currentFov;
    }
}
