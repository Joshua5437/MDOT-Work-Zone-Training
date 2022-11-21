using TMPro;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ReportMaker : MonoBehaviour
{
    public GameObject HazardScenario;
    public GameObject Next, Restart;
    public TextMeshProUGUI ReportText, ReportText2;
    private int RoadRollerCount = 0, DumptruckCount = 0;

    public void MakeReport()
    {
        DumptruckCount = HazardScenario.GetComponent<MySightManager>().getDPCount();
        RoadRollerCount = HazardScenario.GetComponent<MySightManager>().getRRCount();

        if(DumptruckCount >= 6) {
            Next.SetActive(true);
            Restart.SetActive(false);
            ReportText.GetComponent<TextMeshProUGUI>().color = new Color32(0, 0, 0, 255);       // Black
            ReportText.GetComponent<TextMeshProUGUI>().text = "You looked at the Dumptruck: " + DumptruckCount + " times.";
        } else {
            Restart.SetActive(true);
            Next.SetActive(false);
            ReportText.GetComponent<TextMeshProUGUI>().color = new Color32(255, 0, 0, 255);     // Red
            ReportText.GetComponent<TextMeshProUGUI>().text = "You looked at the Dumptruck: " + DumptruckCount + " times.";
        }
        
        if(RoadRollerCount >= 6) {
            Next.SetActive(true);
            Restart.SetActive(false);
            ReportText2.GetComponent<TextMeshProUGUI>().color = new Color32(0, 0, 0, 255);      // Black
            ReportText2.GetComponent<TextMeshProUGUI>().text = "You looked at the Road Roller: " + RoadRollerCount + " times.";
        } else {
            Restart.SetActive(true);
            Next.SetActive(false);
            ReportText2.GetComponent<TextMeshProUGUI>().color = new Color32(255, 0, 0, 255);     // Red
            ReportText2.GetComponent<TextMeshProUGUI>().text = "You looked at the Road Roller: " + RoadRollerCount + " times.";
        }
    }
}
