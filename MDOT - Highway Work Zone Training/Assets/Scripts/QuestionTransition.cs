using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class QuestionTransition : MonoBehaviour
{
    private int counter = 0;
    public GameObject WaistQuestion1, FloorQuestion1;
    public float Duration = 1.0f;
    public AudioSource TransitionAudio1;
    public TextMeshProUGUI TransitionText1;

    public void TransitionNotification()
    {
        var canvGroup = TransitionText1.GetComponent<CanvasGroup>();
        StartCoroutine(DoFade(canvGroup, 1, 0));
        StartCoroutine(WaitWhileAudioPlays(TransitionAudio1));
    }
    private IEnumerator DoFade(CanvasGroup canvGroup, float start, float end)
    {
        float counter = 0f;
        while (counter < Duration)
        {
            counter += Time.deltaTime;
            canvGroup.alpha = Mathf.Lerp(start, end, (counter / Duration));
            yield return null;
        }
    }

    private IEnumerator WaitWhileAudioPlays(AudioSource currentAudio)
    {
        currentAudio.Play();
        yield return new WaitWhile(() => currentAudio.isPlaying);

        if (counter == 0) { WaistQuestion1.SetActive(true); }
        else if (counter == 1) { FloorQuestion1.SetActive(true); }
    }
}
