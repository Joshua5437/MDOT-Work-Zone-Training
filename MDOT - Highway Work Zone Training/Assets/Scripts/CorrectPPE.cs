using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class CorrectPPE : MonoBehaviour
{
    private bool failSafe = true;
    public GameObject LBoot, RBoot, Hat, Class2Vest, T_Point, StartHazardButton, CrossingBoard;

    private void Update()
    {
        if(!LBoot.activeSelf && !Hat.activeSelf && !Class2Vest.activeSelf && !RBoot.activeSelf && failSafe)
        {
            failSafe = false;
            GameObject User = GameObject.Find("XR Origin");
            User.transform.position = new Vector3(T_Point.transform.position.x, T_Point.transform.position.y, T_Point.transform.position.z);
            CrossingBoard.active = true;
        }
    }
}
