using UnityEngine;
using UnityEngine.UI;

public class TougeRaceEnd : MonoBehaviour
{
    public GameObject car;
    public GameObject raceEndCollider;
    public Text timerText;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == car && raceEndCollider.GetComponent<Collider>() == collision.collider)
        {
            timerText.gameObject.SetActive(false);
        }
    }
}
