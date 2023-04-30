using UnityEngine;

public class SpeedDetector : MonoBehaviour
{
    public Camera camera1; // Reference to the Camera component
    public float fovSpeed = 5f; // Speed of FOV change
    private Rigidbody rb;
    private float targetFov;
    private float currentFov;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        currentFov = camera1.fieldOfView;
    }

    void Update()
    {
        float speed = rb.velocity.magnitude * 3.6f; // Convert speed to km/h
        if (speed <= 0f )
        {
            targetFov = 60f;
        }
        else if (speed <= 42f)
        {
            targetFov = 70f;
        }
        else if (speed <= 75.8f)
        {
            targetFov = 80f;
        }
        else if (speed <= 107.1f)
        {
            targetFov = 90f;
        }
        else if (speed <= 149.8f)
        {
            targetFov = 95f;
        }
        else if (speed <= 179f)
        {
            targetFov = 100f;
        }

        currentFov = Mathf.Lerp(currentFov, targetFov, fovSpeed * Time.deltaTime); // Smoothly interpolate between current and target FOV
        camera1.fieldOfView = currentFov;
    }
}
