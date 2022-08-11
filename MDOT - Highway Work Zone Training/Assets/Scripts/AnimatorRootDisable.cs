using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorRootDisable : MonoBehaviour
{
    public GameObject CinderBlock;

    void Awake()
    {
        StartCoroutine(rootDisableWait());
    }

    public IEnumerator rootDisableWait()
    {
        yield return new WaitForSeconds(7);
        rootDisable();
    }

    private void rootDisable()
    {
        CinderBlock.GetComponent<Animator>().enabled = false;
    }
}
