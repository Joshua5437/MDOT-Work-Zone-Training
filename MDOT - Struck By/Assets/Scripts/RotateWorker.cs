using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RotateWorker : MonoBehaviour
{
    private bool toggle = true, toggle2 = true;
    public GameObject ConstructionWorker, ConstructionWorker2;

    void Start()
    {
        StartCoroutine(RotateConstructionWorker());
        StartCoroutine(RotateConstructionWorker2());
    }

    private IEnumerator RotateConstructionWorker()
    {
        yield return new WaitForSeconds(toggle ? 5 : 3);
        ConstructionWorker.transform.eulerAngles = new Vector3(0, (ConstructionWorker.transform.eulerAngles.y - 90), 0);
        toggle = !toggle;
        StartCoroutine(RotateConstructionWorker());
    }

    private IEnumerator RotateConstructionWorker2()
    {
        yield return new WaitForSeconds(toggle ? 3 : 2);
        ConstructionWorker2.transform.eulerAngles = new Vector3(0, (ConstructionWorker2.transform.eulerAngles.y - 90), 0);
        toggle2 = !toggle2;
        StartCoroutine(RotateConstructionWorker2());
    }
}
