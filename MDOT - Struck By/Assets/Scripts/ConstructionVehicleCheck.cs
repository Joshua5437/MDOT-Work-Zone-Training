using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstructionVehicleCheck : MonoBehaviour
{
    private bool OneStart = true;
    private bool DP_Rend = false, RR_Rend = false;
    public GameObject DPCube, RRCube;
    public AudioSource BeginCrossing, Correct;
    
    void Update()
    {
        if(DPCube.GetComponent<Renderer>().enabled) 
        {
            DP_Rend = true;
        }

        if(RRCube.GetComponent<Renderer>().enabled) 
        {
            RR_Rend = true;
        }

        if(DP_Rend && RR_Rend && OneStart)
        {
            OneStart = false;
            BeginCrossing.Play();
            Correct.Play();
        }
    }
}
