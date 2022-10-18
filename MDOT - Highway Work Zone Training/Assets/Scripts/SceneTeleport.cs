using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class SceneTeleport : MonoBehaviour
{
    private bool wait = false;
    public float Duration = 2.0f;
    public Image TransitionImage;
    public GameObject TeleportPoint;
    public AudioSource TransitionAudio;
    public TextMeshProUGUI TransitionText;

    public void TeleportUser()
    {
        // Show & tell the user the section they are about to go to.
        var canvGroup = TransitionText.GetComponent<CanvasGroup>();
        StartCoroutine(DoFade(canvGroup, 1, 0));   // Visual
        TransitionAudio.Play();                    // Verbal    
        wait = true;        

        // Show transition screen.
        canvGroup = TransitionImage.GetComponent<CanvasGroup>();
        StartCoroutine(DoFade(canvGroup, 1, 0));

        //Teleport user.
        GameObject User = GameObject.Find("XR Origin");
        User.transform.position = new Vector3(TeleportPoint.transform.position.x, TeleportPoint.transform.position.y, TeleportPoint.transform.position.z);
    }

    private IEnumerator DoFade(CanvasGroup canvGroup, float start, float end)
    {
        float counter = 0f;
        if(wait) { yield return new WaitWhile(() => TransitionAudio.isPlaying); }
        while (counter < Duration)
        {
            counter += Time.deltaTime;
            canvGroup.alpha = Mathf.Lerp(start, end, (counter / Duration));
            yield return null;
        }
    }
}
