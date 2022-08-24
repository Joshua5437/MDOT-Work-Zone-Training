using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class MoveRoadRoller : MonoBehaviour
{
    private int turn = 0;
    private GameObject LB_Wheel, RB_Wheel, Front_Wheel;

    public float Duration = 1.0f;
    public AudioSource BackingUpAudio;

    private void Start()
    {
        Front_Wheel = GameObject.Find("Front_Wheel");
        LB_Wheel = GameObject.Find("Wheel_Left_Back.001");
        RB_Wheel = GameObject.Find("Wheel_Right_Back.001");
        StartCoroutine(ForwardAndReverseRoadRoller(15, 0));
    }

	private void Update () {

        if (turn == 0) // Turns wheels forward. 
        { 
            Front_Wheel.transform.Rotate(0f, 1f, 0f, Space.Self);
            LB_Wheel.transform.Rotate(0f, 1f, 0f, Space.Self);
            RB_Wheel.transform.Rotate(0f, 1f, 0f, Space.Self); 
        }

        else           // Turns wheels backward.
        {
            Front_Wheel.transform.Rotate(0f, -1f, 0f, Space.Self); // Front wheel does not turn backwards.
            LB_Wheel.transform.Rotate(0f, -1f, 0f, Space.Self); 
            RB_Wheel.transform.Rotate(0f, -1f, 0f, Space.Self); 
        }

    }

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
        turn--;

        counter = 0f;                   // Logic to reverse road roller.
        BackingUpAudio.Play();
        while(counter < Duration)
        {
            counter += Time.deltaTime;
            transform.position = new Vector3(transform.position.x, transform.position.y, Mathf.Lerp(end, start, (counter / Duration)));
            yield return null;
        }
        turn++;
        StartCoroutine(ForwardAndReverseRoadRoller(15, 0)); // Recalls itself
    }
}
