using TMPro;
using UnityEngine;

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

        if(DumptruckCount < 6 || RoadRollerCount < 6) {
            Restart.SetActive(true);
            Next.SetActive(false);
            ReportText.GetComponent<TextMeshProUGUI>().text = "You looked at the Dumptruck: " + DumptruckCount + " times.";
            ReportText2.GetComponent<TextMeshProUGUI>().text = "You looked at the Road Roller: " + RoadRollerCount + " times.";
        } else {
            Next.SetActive(true);
            Restart.SetActive(false);
            ReportText.GetComponent<TextMeshProUGUI>().text = "You looked at the Dumptruck: " + DumptruckCount + " times.";      // Black
            ReportText2.GetComponent<TextMeshProUGUI>().text = "You looked at the Road Roller: " + RoadRollerCount + " times.";
        }
    }
}
