using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ChangeMaterialOnSight : MonoBehaviour, iGazeReceiver
{
    private bool isGazingUpon;

    public Material highlight;
    public Material[] material;
    public GameObject[] ObjectParts;

    private void Start()
    {
        for(int i = 0; i < ObjectParts.Length; i++)
        {
            material[i] = ObjectParts[i].GetComponent<Renderer>().sharedMaterial;
        }
    }

    private void Update()
    {
        for(int i = 0; i < ObjectParts.Length; i++)
        {
            ObjectParts[i].GetComponent<Renderer>().sharedMaterial = isGazingUpon ? highlight : material[i]; 
        }
    }

    // string GetWeatherDisplay(double tempInCelsius) => tempInCelsius < 20.0 ? "Cold." : "Perfect!";
    // public void ChangeColor(bool isGazingUpon) => RoadRoller.sharedMaterial = isGazingUpon ? material[0] : material[1];       <~~~~~~~  COULD BE USED LATER !!!

    public void GazingUpon() { isGazingUpon = true; }

    public void NotGazingUpon() { isGazingUpon = false; }
}
