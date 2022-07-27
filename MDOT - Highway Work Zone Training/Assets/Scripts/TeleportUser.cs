using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TeleportUser : MonoBehaviour
{
    private int counter = 0;
    public TextMeshProUGUI TransitionText1, TransitionText2;
    public Image BlackScreen;
    public float Duration = 1.0f;
    public GameObject TeleportPoint1, TeleportPoint2;
    public AudioSource TransitionAudio1, TransitionAudio2;
    public Button button1, button2;

    public void FadeScreenNow()
    {
        var canvGroup = BlackScreen.GetComponent<CanvasGroup>();
        StartCoroutine(DoFade(canvGroup, 1, 0));
        TeleportNow(TeleportPoint1);
        TeleportPoint1 = TeleportPoint2;
    }

    public void TransitionNotification()
    {
        var canvGroup = TransitionText1.GetComponent<CanvasGroup>();
        StartCoroutine(DoFade(canvGroup, 1, 0));
        TransitionText1 = TransitionText2;
        if (counter == 0)
        {
            StartCoroutine(WaitWhileAudioPlays(TransitionAudio1, button1));
        }
        else if (counter == 1)
        {
            StartCoroutine(WaitWhileAudioPlays(TransitionAudio2, button2));
        }
        counter++;
    }

    private void TeleportNow(GameObject T_Point)
    {
        GameObject User = GameObject.Find("XR Origin");
        User.transform.position = new Vector3(T_Point.transform.position.x, T_Point.transform.position.y, T_Point.transform.position.z);
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

    private IEnumerator WaitWhileAudioPlays(AudioSource currentAudio, Button button)
    {
        currentAudio.Play();
        yield return new WaitWhile(() => currentAudio.isPlaying);
        button.onClick.Invoke();
        FadeScreenNow();
    }
}
