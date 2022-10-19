using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class CorrectPPE : MonoBehaviour
{
    private int counter = 0;

    // [Header("Correct PPE (GameObject)")] // Assign correct PPE through the inspector
    public GameObject[] CorrectPPEList;

    public GameObject CurrentScenario, NextScenario;

    private void Update()
    {
        for(int i = 0; i < CorrectPPEList.Length; i++)
        {
            if(!CorrectPPEList[i].activeSelf) { counter = counter + 1; }
        }

        if(counter == CorrectPPEList.Length) {
            NextScenario.active = true;
            CurrentScenario.active = false;
        }
        else{ counter = 0; }
    }
}
