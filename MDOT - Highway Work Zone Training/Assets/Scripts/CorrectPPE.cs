using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class CorrectPPE : MonoBehaviour
{
    private int counter = 0;

    [Header("Correct PPE (GameObject)")] // Assign correct PPE through the inspector
    public Transform[] CorrectPPE;

    public GameObject NextScenario;

    private void Update()
    {
        for(int i = 0; i < CorrectPPE.Length; i++)
        {
            if(!CorrectPPE[i].activeSelf) { counter = counter + 1; }
        }

        if(counter == CorrectPPE.Length) { NextScenario.active = true; }
        
    }
}
