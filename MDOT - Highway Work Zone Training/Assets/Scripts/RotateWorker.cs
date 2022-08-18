using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RotateWorker : MonoBehaviour
{
    public GameObject ConstructionWorker;

    void Start()
    {
        StartCoroutine(RotateConstructionWorker());
    }

    private IEnumerator RotateConstructionWorker()
    {
        yield return new WaitForSeconds(5);
        ConstructionWorker.transform.rotation = new Quaternion(0, (ConstructionWorker.transform.rotation.y - 90), 0, 1);
        StartCoroutine(RotateConstructionWorker());
    }
}
