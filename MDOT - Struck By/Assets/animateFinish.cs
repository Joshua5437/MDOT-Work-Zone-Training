using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class animateFinish : MonoBehaviour
{
    public Button AudPlay;
    public int WaitTime = 0;
    
    private void Awake()
    {
        StartCoroutine(WaitXSeconds(WaitTime));
    }

    public void RestartAnimateFinishCoroutine() {
        StartCoroutine(WaitXSeconds(WaitTime));
    }

    private void buttonInvoke()
    {
        AudPlay.onClick.Invoke();
    }
    
    public IEnumerator WaitXSeconds(int WaitTime)
    {
        yield return new WaitForSeconds(WaitTime);
        buttonInvoke();
    }
}
