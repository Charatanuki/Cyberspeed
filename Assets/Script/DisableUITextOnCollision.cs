using UnityEngine;
using UnityEngine.UI;

public class DisableUITextOnCollision : MonoBehaviour
{
    public Text timerText;
    public Text topLapsText;
    public GameObject startingCube;
    public GameObject car;
    private int hitCount = 0;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == startingCube)
        {
            hitCount++;
            if (hitCount >= 4)
            {
                timerText.gameObject.SetActive(false);
                topLapsText.gameObject.SetActive(false);
            }
        }
    }
}
