using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class buttonPress : MonoBehaviour
{
    private Button BackUpOne, BackUpTwo, BackUpThree;
    private int counter = 0;
    public int iterations = 0;
    public int WaitTime = 0;
    public Button One, Two, Three;
    
    private void Awake()
    {
        BackUpOne = One;
        BackUpTwo = Two;
        BackUpThree = Three;

        One.onClick.Invoke();
        One = Two;
        Two = Three;
        StartCoroutine(WaitXSeconds(WaitTime));
    }

    public void CaptionReadReset() {
        One = BackUpOne; Two = BackUpTwo; Three = BackUpThree;

        One.onClick.Invoke();
        One = Two;
        Two = Three;
        StartCoroutine(WaitXSeconds(WaitTime));
    }

    private void buttonInvoke()
    {
        One.onClick.Invoke();
        One = Two;
        Two = Three;
        if(counter < (iterations - 1)) { 
            StartCoroutine(WaitXSeconds(WaitTime));
            counter = counter + 1;
        }
    }
    
    public IEnumerator WaitXSeconds(int WaitTime)
    {
        
        yield return new WaitForSeconds(WaitTime);
        buttonInvoke();
    }
}
