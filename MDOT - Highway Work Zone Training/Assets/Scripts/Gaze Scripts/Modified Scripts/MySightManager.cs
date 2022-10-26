using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MySightManager : MonoBehaviour
{
    public GameObject RoadRollerCube, DumptruckCube;
    private int RoadRollerCount = 0, DumptruckCount = 0;

    private void getCount() {
        DumptruckCount = DumptruckCube.GetComponent<HighlightOnSight>().setCount();
        RoadRollerCount = RoadRollerCube.GetComponent<HighlightOnSight>().setCount();
    }
}
