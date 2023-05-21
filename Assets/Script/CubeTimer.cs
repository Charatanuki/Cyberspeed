using UnityEngine;
using UnityEngine.UI;

public class CubeTimer : MonoBehaviour
{
    public Text timerText;
    public GameObject playerCar; // Reference to the player car GameObject

    private bool timerStarted = false;
    private float lapTimer = 0f;
    private bool colliderActive = true;

    private void Update()
    {
        if (timerStarted)
        {
            lapTimer += Time.deltaTime;
            UpdateTimerText();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == playerCar && colliderActive)
        {
            StartTimer();
            StartCoroutine(DeactivateColliderForSeconds(0.1f));
            StartCoroutine(ReactivateColliderAfterSeconds(3f));
        }
    }

    private void StartTimer()
    {
        timerStarted = true;
        lapTimer = 0f;
    }

    private void UpdateTimerText()
    {
        int minutes = (int)(lapTimer / 60);
        int seconds = (int)(lapTimer % 60);
        string lapTime = $"{minutes:00}:{seconds:00}";
        timerText.text = $"Lap Time: {lapTime}";
    }

    private System.Collections.IEnumerator DeactivateColliderForSeconds(float seconds)
    {
        colliderActive = false;
        gameObject.GetComponent<Collider>().enabled = false;
        yield return new WaitForSeconds(seconds);
    }

    private System.Collections.IEnumerator ReactivateColliderAfterSeconds(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        colliderActive = true;
        gameObject.GetComponent<Collider>().enabled = true;
    }
}
