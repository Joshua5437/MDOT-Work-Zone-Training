using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FocusedObject : MonoBehaviour
{
    public AudioSource Walk;
    public GameObject DP, RR, MainCamera;
    private int dumptruck = 0, roadRoller = 0;

    private void Start()
    {
        LookBack();
    }

    private void LookBack()
    {
        if(DP.transform.rotation.y == 30 && RR.transform.rotation.y == 15)
        {
            if(MainCamera.transform.rotation.y <= -110) 
            {
                roadRoller = roadRoller + 1;
            }

            if(MainCamera.transform.rotation.y >= -80)
            {
                dumptruck = dumptruck + 1;
            }

            if(dumptruck >= 2 && roadRoller >= 2 && DP.transform.rotation.y == 30 && RR.transform.rotation.y == 15)
            {
                Walk.Play();
            }
            else
            {
                LookBack();
            }
        }
    }
}
