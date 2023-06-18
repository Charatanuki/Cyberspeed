using UnityEngine;
using UnityEngine.UI;

public class EnableUIOnKeyPress : MonoBehaviour
{
    public GameObject timerText;
    public GameObject topLapsText;
    public GameObject Lap1Text;
    public GameObject Lap2Text;
    public GameObject Lap3Text;
    public GameObject Car2;

    private bool spawnCar2;
    private float spawnTimer;

    private void Start()
    {
        timerText.SetActive(false);
        topLapsText.SetActive(false);
        Lap1Text.SetActive(false);
        Lap2Text.SetActive(false);
        Lap3Text.SetActive(false);
        Car2.SetActive(false);
        
        spawnCar2 = false;
        spawnTimer = 0f;
    }
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            timerText.SetActive(true);
            topLapsText.SetActive(true);
            Lap1Text.SetActive(true);
            Lap2Text.SetActive(true);
            Lap3Text.SetActive(true);
            
            spawnCar2 = true;
            spawnTimer = 0f;
        }
        
        if (spawnCar2)
        {
            spawnTimer += Time.deltaTime;
            
            if (spawnTimer >= 2f)
            {
                Car2.SetActive(true);
                spawnCar2 = false;
            }
        }
    }
}
