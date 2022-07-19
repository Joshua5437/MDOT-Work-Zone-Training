using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TeleportUser : MonoBehaviour
{
    public Image BlackScreen;
    public float Duration = 1.0f;
    public GameObject TeleportPoint1, TeleportPoint2;

    public void FadeScreenNow()
    {
        var canvGroup = BlackScreen.GetComponent<CanvasGroup>();
        StartCoroutine(DoFade(canvGroup, 1, 0));
        TeleportNow(TeleportPoint1);
        TeleportPoint1 = TeleportPoint2;
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
}
