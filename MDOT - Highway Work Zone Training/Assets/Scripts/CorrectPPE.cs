using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class CorrectPPE : MonoBehaviour
{
    private bool failSafe = false;
    public AudioSource BeginHazard;
    public GameObject LBoot, RBoot, Hat, Class2Vest, T_Point, StartHazardButton;

    private void Update()
    {
        if(!LBoot.activeSelf && !Hat.activeSelf && !Class2Vest.activeSelf && !RBoot.activeSelf )
        {
            
            GameObject User = GameObject.Find("XR Origin");
            User.transform.position = new Vector3(T_Point.transform.position.x, T_Point.transform.position.y, T_Point.transform.position.z);
            BeginHazard.Play();
            StartCoroutine(WaitForInvoke());
        }
    }

    private IEnumerator WaitForInvoke()
    {
        yield return new WaitForSeconds(3);
        failSafe = true;
        InvokeHazardButton();
    }

    private void InvokeHazardButton()
    {
        if(!BeginHazard.isPlaying && failSafe) { StartHazardButton.GetComponent<Button>().onClick.Invoke(); }
    }
}
