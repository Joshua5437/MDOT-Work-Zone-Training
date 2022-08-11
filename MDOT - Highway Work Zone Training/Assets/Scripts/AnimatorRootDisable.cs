using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorRootDisable : MonoBehaviour
{
    public GameObject CinderBlock;

    void Awake()
    {
        StartCoroutine(AnimatorDisableWait());
    }

    public IEnumerator AnimatorDisableWait()
    {
        yield return new WaitForSeconds(7);
        AnimatorDisable();
    }

    private void AnimatorDisable()
    {
        CinderBlock.GetComponent<Animator>().enabled = false;
    }

    public void ResetAnimator()
    {
        CinderBlock.GetComponent<Animator>().enabled = true;
        StartCoroutine(AnimatorDisableWait());
    }
}