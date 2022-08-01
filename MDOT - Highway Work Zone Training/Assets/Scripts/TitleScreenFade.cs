using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TitleScreenFade : MonoBehaviour
{
    public float Duration = 1.0f;
    public AudioSource TriggerClip;
    public RawImage WorldBlockImage;

    private void Awake()
    {
        var canvGroup = WorldBlockImage.GetComponent<CanvasGroup>();
        StartCoroutine(DoFade(canvGroup, 1, 0));
    }

    private IEnumerator DoFade(CanvasGroup canvGroup, float start, float end)
    {
        float counter = 0f;
        yield return new WaitForSeconds(18);
        while (counter < Duration)
        {
            counter += Time.deltaTime;
            canvGroup.alpha = Mathf.Lerp(start, end, (counter / Duration));
            yield return null;
        }
        Destroy(WorldBlockImage);
        TriggerClip.Play();
    }
}
