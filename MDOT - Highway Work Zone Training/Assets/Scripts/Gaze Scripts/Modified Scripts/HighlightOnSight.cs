using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HighlightOnSight : MonoBehaviour
{
    private Renderer rend;
    private int count = 0;
    private bool isGazingUpon;
    private bool waitFlag = false, updateFlag = true, turnOffMoveRoadRollerFlag = true;   // updateFlag is used to make sure the update function counts one time per rend being enabled.

    public GameObject MoveRoadRollerScriptObject;

    private void Awake()
    {
        StartCoroutine(WaitFor16Seconds());
    }
    
    private void Start()
    {
        rend = GetComponent<Renderer>();
    }
    
    private void Update()
    {
        if (isGazingUpon) {
            rend.enabled = true;
            if(waitFlag && updateFlag) { // Keeps track of how many times the user looked at this object since it stopped.
                count = count + 1;
                updateFlag = false;

                if(turnOffMoveRoadRollerFlag) { 
                    MoveRoadRollerScriptObject.GetComponent<MoveRoadRoller>().enabled = false; 
                    turnOffMoveRoadRollerFlag = false;
                }
            }    
        }

        else {
            rend.enabled = false;
            updateFlag = true;
        }
    }

    public int setCount() {
        return count;
    }

    public IEnumerator WaitFor16Seconds()
    {
        yield return new WaitForSeconds(16);
        setWaitFlag();
    }

    private void setWaitFlag()
    {
        waitFlag = true;
    }

    public void GazingUpon() { isGazingUpon = true; }
    public void NotGazingUpon() { isGazingUpon = false; }
}
