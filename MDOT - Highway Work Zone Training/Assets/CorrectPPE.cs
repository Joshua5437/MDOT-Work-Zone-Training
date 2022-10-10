using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class CorrectPPE : MonoBehaviour
{
    public AudioSource BeginHazard;
    public GameObject Boots, Hat, Class2Vest, T_Point, StartHazardButton;

    private void Update()
    {
        if(!Boots.activeSelf && !Hat.activeSelf && !Class2Vest.activeSelf)
        {
            GameObject User = GameObject.Find("XR Origin");
            User.transform.position = new Vector3(T_Point.transform.position.x, T_Point.transform.position.y, T_Point.transform.position.z);
            StartHazardButton.GetComponent<Button>().onClick.Invoke();
            BeginHazard.Play();
        }
    }
}
