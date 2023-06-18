using UnityEngine;
using UnityEngine.UI;

public class TougeRaceStart : MonoBehaviour
{
    public GameObject car;
    public GameObject startCollider;
    public Text timerText;

    private bool raceStarted = false;
    private float raceTime = 0f;

    void OnCollisionEnter(Collision collision)
    {
        if (!raceStarted && collision.gameObject == car)
        {
            raceStarted = true;
        }
    }

    void Update()
    {
        if (raceStarted)
        {
            raceTime += Time.deltaTime;
            int minutes = Mathf.FloorToInt(raceTime / 60f);
            int seconds = Mathf.FloorToInt(raceTime % 60f);
            string timerString = string.Format("{0:00}:{1:00}", minutes, seconds);
            timerText.text = timerString;
        }
    }
}
