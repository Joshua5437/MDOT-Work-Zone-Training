using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class turnOffButtons : MonoBehaviour
{
    public GameObject Next, Replay;

    public void Awake()
    {
        Next.SetActive(false);
        Replay.SetActive(false);
    }

    
}
