using UnityEngine;
using System.Collections;

public class AudFinish : MonoBehaviour
{
    private bool startUpdate = false;
    public GameObject obj;
    public AudioSource currentAudio;

    private void Awake()
    {
        StartCoroutine(Wait2Seconds());
    }

    private void Update()
    {
        if (!currentAudio.isPlaying && startUpdate)
        {
            obj.SetActive(true);
        }
    }

    private void StartUpdateFunction()
    {
        startUpdate = true;
    }

    public IEnumerator Wait2Seconds()
    {
        yield return new WaitForSeconds(2);
        StartUpdateFunction();
    }
}
