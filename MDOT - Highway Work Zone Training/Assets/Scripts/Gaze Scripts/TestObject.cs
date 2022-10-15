using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestObject : MonoBehaviour, iGazeReceiver
{
    private Renderer rend;
    private bool isGazingUpon;
    
    private void Start()
    {
        rend = GetComponent<Renderer>();
    }
    
    private void Update()
    {
        if (isGazingUpon) {
        // Do anything you want here, we'll rotate for this demo
        // transform.Rotate(0, 3, 0);
        rend.enabled = true;
        }

        else {
            rend.enabled = false;
        }
    }

    public void GazingUpon() { isGazingUpon = true; }
    public void NotGazingUpon() { isGazingUpon = false; }
}
