using UnityEngine;
using UnityEngine.UI;

public class LapTimer : MonoBehaviour
{
    public Text timerText;
    public Text previousTimesText;
    public GameObject startingCube;
    public GameObject car;
    public float detectionRadius = 15f;

    private const int MaxLaps = 3;
    private int lapCount = 0;
    private float lapTimer = 0f;
    private bool lapInProgress = false;

    private void Update()
    {
        if (lapInProgress)
        {
            lapTimer += Time.deltaTime;
            UpdateTimerText();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == car) 
        {
            if (lapInProgress)
            {
                StopLapTimer();
                CompleteLap();
            }
            StartLapTimer();
        }
    }

    private void StartLapTimer()
    {
        lapInProgress = true;
        lapTimer = 0f;
    }

    private void StopLapTimer()
    {
        lapInProgress = false;
    }

    private void UpdateTimerText()
    {
        string lapTime = GetFormattedLapTime();
        timerText.text = $"Lap Time: {lapTime}";
    }

    private void CompleteLap()
    {
        lapCount++;
        if (lapCount <= MaxLaps)
        {
            string lapTime = GetFormattedLapTime();
            previousTimesText.text += $"Lap {lapCount}: {lapTime}\n";

            if (lapCount == MaxLaps)
            {
                timerText.text = "Lap Time: ---";
            }
        }
    }

    private string GetFormattedLapTime()
    {
        int minutes = (int)(lapTimer / 60);
        int seconds = (int)(lapTimer % 60);
        return $"{minutes:00}:{seconds:00}";
    }
}