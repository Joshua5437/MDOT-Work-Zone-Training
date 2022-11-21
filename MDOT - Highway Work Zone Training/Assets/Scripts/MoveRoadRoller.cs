using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class MoveRoadRoller : MonoBehaviour
{
    public int turn = 0;
    private bool rendFlag = true;
    private bool isGazingUpon;
    private GameObject Wh1, Wh2, Wh3, Wh4, Wh5, Wh6;
    private GameObject LB_Wheel, RB_Wheel, Front_Wheel;

    public GameObject Dumptruck, RRCube, DPCube;
    public float Duration = 1.0f;
    public AudioSource BackingUpAudio;

    private void Start()
    {
        Front_Wheel = GameObject.Find("Front_Wheel");
        LB_Wheel = GameObject.Find("Wheel_Left_Back.001");
        RB_Wheel = GameObject.Find("Wheel_Right_Back.001");

        Wh1 = GameObject.Find("Wh1");
        Wh2 = GameObject.Find("Wh2");
        Wh3 = GameObject.Find("Wh3");
        Wh4 = GameObject.Find("Wh4");
        Wh5 = GameObject.Find("Wh5");
        Wh6 = GameObject.Find("Wh6");

        
        // StartCoroutine(ForwardAndReverseRoadRoller(15, 0));
    }

    public void StartHazard()
    {
        StartCoroutine(HazardScenario2(25, 0));
    }

	private void Update () {

        if (turn == 0) // Turns wheels forward. 
        { 
            Front_Wheel.transform.Rotate(0f, 1f, 0f, Space.Self);
            LB_Wheel.transform.Rotate(0f, 1f, 0f, Space.Self);
            RB_Wheel.transform.Rotate(0f, 1f, 0f, Space.Self); 
        }

        else if (turn == 1)           // Turns wheels backward.
        {
            Front_Wheel.transform.Rotate(0f, -1f, 0f, Space.Self); // Front wheel does not turn backwards.
            LB_Wheel.transform.Rotate(0f, -1f, 0f, Space.Self); 
            RB_Wheel.transform.Rotate(0f, -1f, 0f, Space.Self); 
        }

        else if (turn == 2)
        {
            Front_Wheel.transform.Rotate(0f, -1f, 0f, Space.Self); // Front wheel does not turn backwards.
            LB_Wheel.transform.Rotate(0f, -1f, 0f, Space.Self); 
            RB_Wheel.transform.Rotate(0f, -1f, 0f, Space.Self); 

            Wh1.transform.Rotate(1f, 0f, 0f, Space.Self); 
            Wh2.transform.Rotate(1f, 0f, 0f, Space.Self); 
            Wh3.transform.Rotate(1f, 0f, 0f, Space.Self); 
            Wh4.transform.Rotate(1f, 0f, 0f, Space.Self); 
            Wh5.transform.Rotate(1f, 0f, 0f, Space.Self); 
            Wh6.transform.Rotate(1f, 0f, 0f, Space.Self); 
        }
        
        if (isGazingUpon) {
            StopAllCoroutines();
        }
        
        else {
        }
    }

    public IEnumerator HazardScenario2(float start, float end)
    {
        
        float counter = 0f;   
        counter = 0f;                   // Logic to reverse road roller.
        BackingUpAudio.Play();
        while(counter < Duration)
        {
            turn = 2;
            counter += Time.deltaTime;
            transform.position = new Vector3(transform.position.x, transform.position.y, Mathf.Lerp(10, 15, (counter / Duration)));
            Dumptruck.transform.position = new Vector3(Dumptruck.transform.position.x, Dumptruck.transform.position.y, Mathf.Lerp(40, 35, (counter / Duration)));
            yield return null;
        }
        DPCube.GetComponent<TestObject>().enabled = true;
        RRCube.GetComponent<TestObject>().enabled = true;
        turn = -1;
        // StartCoroutine(ForwardAndReverseRoadRoller(15, 0)); // Recalls itself
    }

    public void GazingUpon() { isGazingUpon = true; }
    public void NotGazingUpon() { isGazingUpon = false; }

    /*
    public IEnumerator ForwardAndReverseRoadRoller(float start, float end)
    {
        float counter = 0f;             // Logic to move road roller forward. 
        BackingUpAudio.Stop();
        while(counter < Duration)
        {
            counter += Time.deltaTime;
            transform.position = new Vector3(transform.position.x, transform.position.y, Mathf.Lerp(start, end, (counter / Duration)));
            yield return null;
        }
        turn = 1;

        counter = 0f;                   // Logic to reverse road roller.
        BackingUpAudio.Play();
        while(counter < Duration)
        {
            counter += Time.deltaTime;
            transform.position = new Vector3(transform.position.x, transform.position.y, Mathf.Lerp(end, start, (counter / Duration)));
            yield return null;
        }
        turn = 0;
        StartCoroutine(ForwardAndReverseRoadRoller(15, 0)); // Recalls itself
    }
    */
}
