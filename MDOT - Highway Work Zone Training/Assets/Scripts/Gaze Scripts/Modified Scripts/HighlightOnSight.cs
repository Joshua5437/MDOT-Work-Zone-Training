using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HighlightOnSight : MonoBehaviour
{
    private bool waitFlag = false;
    private int counter = 0;
    private Renderer rend;
    private bool isGazingUpon;

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
            if(waitFlag) { counter = counter + 1; }   // Keeps track of how many times the user looked at this object since it stopped. 
        }

        else {
            rend.enabled = false;
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
