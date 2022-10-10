using Tobii.XR;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FocusedObject : MonoBehaviour
{
    public AudioSource Walk;
    public GameObject DP, RR;
    private int dumptruck = 0, roadRoller = 0;

    private void Update()
    {
        if(TobiiXR.FocusedObjects.Count > 0)
        {
            GameObject focusedGameObject = TobiiXR.FocusedObjects[0].GameObject;
            Debug.Log("Hello: " + focusedGameObject.name);
            
            if(focusedGameObject.name == "Dumptruck")
            {
                dumptruck = dumptruck + 1;
            }
            else if (focusedGameObject.name == "Road Roller")
            {
                roadRoller = roadRoller + 1;
            }
        }

        if(dumptruck >= 2 && roadRoller >= 2 && DP.transform.rotation.y == 30 && RR.transform.rotation.y == 15)
        {
            Walk.Play();
        }
    }
}
