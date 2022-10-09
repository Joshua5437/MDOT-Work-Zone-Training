using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using System.Collections;
using System.Globalization;

public class VidFinish : MonoBehaviour
{
    private bool startUpdate = false;
    public GameObject Next, Replay;
    public UnityEngine.Video.VideoPlayer VideoPlayer;

    private void Awake()
    {
        StartCoroutine(Wait3Seconds());
    }

    private void Update()
    {
        if (!VideoPlayer.isPlaying && startUpdate)
        {
            Next.SetActive(true);
            Replay.SetActive(true);
        }
    }

    private void StartUpdateFunction()
    {
        startUpdate = true;
    }

    public IEnumerator Wait3Seconds()
    {
        yield return new WaitForSeconds(3);
        StartUpdateFunction();
    }
}
