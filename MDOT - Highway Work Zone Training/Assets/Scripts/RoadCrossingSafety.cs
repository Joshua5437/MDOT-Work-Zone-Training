using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RoadCrossingSafety : MonoBehaviour
{
    public GameObject XROrigin;
    public AudioSource Correct, Incorrect;

    public int count = 0;
    private bool left = false, right = true;

    private void Update()
    {
        StartCoroutine(RightLook());
    }

    private IEnumerator RightLook()
    {
        if(right && XROrigin.transform.eulerAngles.y <= -30)
        {
            Correct.Play();
            right = false;
            left = true;
            count++;
            StartCoroutine(LeftLook());
            yield return null;
        }
        else { StartCoroutine(RightLook()); }
    }

    private IEnumerator LeftLook()
    {
        if(right && XROrigin.transform.eulerAngles.y <= -150)
        {
            Correct.Play();
            right = true;
            left = false;
            count++;
            StartCoroutine(RightLook());
            yield return null;
        }
        else { StartCoroutine(LeftLook()); }
    }
}
