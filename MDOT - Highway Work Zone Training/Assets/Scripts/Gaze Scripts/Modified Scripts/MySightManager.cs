using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MySightManager : MonoBehaviour
{
    public GameObject RoadRollerCube, DumptruckCube;
    private int RoadRollerCount = 0, DumptruckCount = 0;

    public int getDPCount() {
        DumptruckCount = DumptruckCube.GetComponent<HighlightOnSight>().setCount();
        return DumptruckCount;
    }

    public int getRRCount() {
        RoadRollerCount = RoadRollerCube.GetComponent<HighlightOnSight>().setCount();
        return RoadRollerCount;
    }
}
