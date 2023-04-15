using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerReset : MonoBehaviour
{
    public int Seconds;
    public int XIterations;
    public Timer WaistTimer;

    private void Awake()
    {
        StartCoroutine(PlayTimerXTimes());
    }

    public void RestartTimerForXIterations()
    {
        StartCoroutine(PlayTimerXTimes());
    }

    public IEnumerator PlayTimerXTimes()
    {
        for (int i = 0; i < XIterations; i++)
        {
            WaistTimer.StartTimer();
            yield return new WaitForSeconds(Seconds);
        }
    }
}
