using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamSwitch : MonoBehaviour
{

    public GameObject Camera1;
    public GameObject Camera2;

    void Update() {
        if  (Input.GetButtonDown("9Key")) 
       {
           Camera1.SetActive(true);
           Camera2.SetActive(false);
       }
        if  (Input.GetButtonDown("0Key")) 
       {
           Camera1.SetActive(false);
           Camera2.SetActive(true);
       }
    }
}