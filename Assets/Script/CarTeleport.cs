using UnityEngine;

public class CarTeleport : MonoBehaviour
{
    public Transform carTransform; // Reference to the car's transform
    public Vector3 teleportZoneCenter; // Center position of the teleportation zone
    public float teleportZoneRadius = 15f; // Radius of the teleportation zone

    public Vector3 targetPosition; // The target position to teleport the car

    public float teleportDelay = 2f; // Delay in seconds after teleportation

    private Vector3 initialPosition; // Initial position of the car
    private Quaternion initialRotation; // Initial rotation of the car

    private bool isTeleporting = false; // Flag to track if the car is currently being teleported

    private void Start()
    {
        initialPosition = carTransform.position;
        initialRotation = carTransform.rotation;
    }

    private void Update()
    {
        // Calculate the distance between the car and the teleportation zone center
        float distanceToZone = Vector3.Distance(carTransform.position, teleportZoneCenter);

        // Check if the car is within the teleportation zone
        if (distanceToZone <= teleportZoneRadius)
        {
            // Check if the "E" key is pressed and the car is not currently being teleported
            if (Input.GetKeyDown(KeyCode.E) && !isTeleporting)
            {
                // Start the teleportation coroutine
                StartCoroutine(TeleportCoroutine());
            }
        }
    }

    // Coroutine for the teleportation process
    private System.Collections.IEnumerator TeleportCoroutine()
    {
        isTeleporting = true;

        // Teleport the car to the target position
        carTransform.position = targetPosition;
        carTransform.rotation = Quaternion.LookRotation(Vector3.forward);

        // Freeze the car in the air for the specified delay
        carTransform.GetComponent<Rigidbody>().isKinematic = true;
        yield return new WaitForSeconds(teleportDelay);
        carTransform.GetComponent<Rigidbody>().isKinematic = false;

        isTeleporting = false;
    }

    // Reset the car's position and rotation to the initial state
    public void ResetCarPosition()
    {
        carTransform.position = initialPosition;
        carTransform.rotation = initialRotation;
    }
}
