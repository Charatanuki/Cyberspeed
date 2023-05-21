using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;

public class LapManager : MonoBehaviour
{
    public Text timerText;
    public Text topLapsText;
    public GameObject playerCar; // Reference to the player car GameObject

    private float lapTimer = 0f;
    private bool colliderActive = true;

    private List<float> lapTimes = new List<float>();
    private const int maxTopLaps = 3;

    private void Update()
    {
        if (colliderActive)
        {
            lapTimer += Time.deltaTime;
            UpdateTimerText();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == playerCar && colliderActive)
        {
            RegisterLapTime();
            ResetTimer();
        }
    }

    private void RegisterLapTime()
    {
        lapTimes.Add(lapTimer);
        lapTimes.Sort();
        if (lapTimes.Count > maxTopLaps)
            lapTimes.RemoveAt(lapTimes.Count - 1);

        UpdateTopLapsText();
    }

    private void ResetTimer()
    {
        lapTimer = 0f;
    }

    private void UpdateTimerText()
    {
        int minutes = (int)(lapTimer / 60);
        int seconds = (int)(lapTimer % 60);
        string lapTime = $"{minutes:00}:{seconds:00}";
        timerText.text = $"Lap Time: {lapTime}";
    }

    private void UpdateTopLapsText()
    {
        topLapsText.text = "Top Lap Times:\n";
        for (int i = 0; i < lapTimes.Count; i++)
        {
            int minutes = (int)(lapTimes[i] / 60);
            int seconds = (int)(lapTimes[i] % 60);
            string lapTime = $"{minutes:00}:{seconds:00}";
            topLapsText.text += $"Lap {i + 1}: {lapTime}\n";
        }
    }
}
