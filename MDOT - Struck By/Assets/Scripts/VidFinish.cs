using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using System.Collections;
using System.Globalization;

public class VidFinish : MonoBehaviour
{
    public GameObject Next, Replay;
    public UnityEngine.Video.VideoPlayer VideoPlayer;

    void Update()
    {
        if (!VideoPlayer.isPlaying)
        {
            Next.SetActive(true);
            Replay.SetActive(true);
        }
        else {
            Next.SetActive(false);
            Replay.SetActive(false);
        }
    }
}
