using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class MoveRoadRoller : MonoBehaviour
{
    public float Duration = 1.0f;
    public AudioSource BackingUpAudio;

    private void Start()
    {
        StartCoroutine(DoFade(15, 0));
    }

    public IEnumerator DoFade(float start, float end)
    {
        float counter = 0f;
        while(counter < Duration)
        {
            counter += Time.deltaTime;
            transform.position = new Vector3(transform.position.x, transform.position.y, Mathf.Lerp(start, end, (counter / Duration)));
            yield return null;
        }

        counter = 0f;
        BackingUpAudio.Play();
        while(counter < Duration)
        {
            counter += Time.deltaTime;
            transform.position = new Vector3(transform.position.x, transform.position.y, Mathf.Lerp(end, start, (counter / Duration)));
            yield return null;
        }
        StartCoroutine(DoFade(15, 0));
    }
}
