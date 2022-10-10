using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CorrectPPE : MonoBehaviour
{
    public AudioSource BeginHazard;
    public GameObject Boots, Hat, Class2Vest, T_Point;

    private void Update()
    {
        if(!Boots.activeSelf && !Hat.activeSelf && !Class2Vest.activeSelf)
        {
            GameObject User = GameObject.Find("XR Origin");
            User.transform.position = new Vector3(T_Point.transform.position.x, T_Point.transform.position.y, T_Point.transform.position.z);
            BeginHazard.Play();
        }
    }
}
