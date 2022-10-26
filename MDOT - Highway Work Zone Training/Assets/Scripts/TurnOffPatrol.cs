using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TurnOffPatrol : MonoBehaviour
{
    public GameObject[] Cars;

    private void Awake() {
        for (int i = 0; i < Cars.Length; i++) { Cars[i].GetComponent<CarPatrol>().enabled = false; } // Turns off car patrol scripts on cars. 
    }
}
