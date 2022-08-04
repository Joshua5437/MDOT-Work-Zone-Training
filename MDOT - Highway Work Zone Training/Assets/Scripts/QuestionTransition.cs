using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class QuestionTransition : MonoBehaviour
{
    public float Duration = 1.0f;
    public GameObject FloorQuestion1;
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
        FloorQuestion1.SetActive(true);
    }
}
