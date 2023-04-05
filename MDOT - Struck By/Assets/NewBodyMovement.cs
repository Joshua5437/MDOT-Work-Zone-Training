using UnityEngine;
using System.Collections;
using System.Globalization;
using System.Collections.Generic;

public class NewBodyMovement : MonoBehaviour
{
    public GameObject Tracker;

    void Start() {
        GetRotation();
        StartCoroutine(Wait5Seconds());
    }

    private float Upper_Margin_Calculator(float Start_Position) {
        return (float)(Start_Position + (Start_Position * .05));
    }

    private float Lower_Margin_Calculator(float Start_Position)
    {
        return (float)(Start_Position - (Start_Position * .05));
    }

    public void GetRotation() {
        // (21.86, 145.45, 351.13) <---- What Vector3 looks like.
        Vector3 OriginalTrackerRotation = Tracker.transform.localEulerAngles;
        Debug.Log(OriginalTrackerRotation);
    }

    public IEnumerator Wait5Seconds()
    {
        yield return new WaitForSeconds(5);
        GetRotation();
    }
}
