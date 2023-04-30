using UnityEngine;
using UnityEngine.UI;

public class DriftUI : MonoBehaviour
{
    public GameObject car; // Reference to the car game object
    public float pointsPerDrift = 100f; // Points earned per drift
    public float driftThreshold = 0.5f; // Minimum drift angle for a drift to count
    public Text driftPointText; // Reference to the UI Text component

    private float currentPoints; // Current drift points
    private bool isDrifting; // Flag to indicate whether the car is drifting

    private void Start()
    {
        currentPoints = 0f;
        UpdateDriftUI();
    }

    private void Update()
    {
        // Check if the car is drifting
        isDrifting = Mathf.Abs(car.GetComponent<Rigidbody>().angularVelocity.y) > driftThreshold;

        // Add points if the car is drifting
        if (isDrifting)
        {
            currentPoints += pointsPerDrift * Time.deltaTime;
        }

        // Check if currentPoints exceeds max drift points
        if (currentPoints >= 100000f)
        {
            currentPoints = 100000f;
        }

        UpdateDriftUI();

        if (currentPoints < 0f) currentPoints = 0f; // Prevent negative points
    }

    private void UpdateDriftUI()
    {
        // Limit the maximum number of points to 100k
        currentPoints = Mathf.Clamp(currentPoints, 0f, 100000f);

        // Format the points with a comma separator and display them in the UI
        driftPointText.text = $"Drift Points: {currentPoints:#,###0}";
    }
}
