using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamSwitch : MonoBehaviour
{

    public GameObject Camera1;
    public GameObject Camera2;
    public GameObject Camera3;
    public GameObject Camera4;
    public GameObject Camera5;
    public GameObject Camera6;
    public GameObject Person;

    void Update() {
        if  (Input.GetButtonDown("1Key")) 
       {
           Camera1.SetActive(true);
           Camera2.SetActive(false);
           Camera3.SetActive(false);
           Camera4.SetActive(false);
           Camera5.SetActive(false);
           Camera6.SetActive(false);
           Person.SetActive(true);
       }
        if  (Input.GetButtonDown("RKey")) 
       {
           Camera1.SetActive(false);
           Camera2.SetActive(true);
           Camera3.SetActive(false);
           Camera4.SetActive(false);
           Camera5.SetActive(false);
           Camera6.SetActive(false);
           Person.SetActive(true);
       }
       if  (Input.GetButtonDown("9Key")) 
       {
           Camera1.SetActive(false);
           Camera2.SetActive(false);
           Camera3.SetActive(true);
           Camera4.SetActive(false);
           Camera5.SetActive(false);
           Camera6.SetActive(false);
           Person.SetActive(true);
       }
       if  (Input.GetButtonDown("0Key")) 
       {
           Camera1.SetActive(false);
           Camera2.SetActive(false);
           Camera3.SetActive(false);
           Camera4.SetActive(true);
           Camera5.SetActive(false);
           Camera6.SetActive(false);
           Person.SetActive(true);
       }
       if  (Input.GetButtonDown("-Key")) 
       {
           Camera1.SetActive(false);
           Camera2.SetActive(false);
           Camera3.SetActive(false);
           Camera4.SetActive(false);
           Camera5.SetActive(true);
           Camera6.SetActive(false);
           Person.SetActive(true);
       }
       if  (Input.GetButtonDown("=Key")) 
       {
           Camera1.SetActive(false);
           Camera2.SetActive(false);
           Camera3.SetActive(false);
           Camera4.SetActive(false);
           Camera5.SetActive(false);
           Camera6.SetActive(true);
           Person.SetActive(true);
       }
    }
}