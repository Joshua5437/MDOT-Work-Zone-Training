using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class InstructionBoardBehavior : MonoBehaviour {
    public GameObject CinderBlockSnapZone, CinderBlock;
    public GameObject SlideButton, BendButton, LiftButton;
    public Image Image;
    public Sprite BendDown, LiftWithLegs, Done;

    private void Awake() {
        StartCoroutine(SetupWait());
        StartCoroutine(MyUpdate());
    }

    public void MyUpdateTrigger() {
        StartCoroutine(SetupWait());
        StartCoroutine(MyUpdate());
    }

    public void SetupTrigger() {StartCoroutine(AnalyzeMovementWait());}

    public void SpriteUpdater() {
        Image.sprite = BendDown;
        BendDown = LiftWithLegs;
        LiftWithLegs = Done;
    }

    private IEnumerator SetupWait() {
        yield return new WaitForSeconds(2);
        Debug.Log("Setup Complete! ");
        SlideButton.GetComponent<Button>().onClick.Invoke();
    }

    private IEnumerator AnalyzeMovementWait() {
        yield return new WaitForSeconds(15);
        BendButton.GetComponent<Button>().onClick.Invoke();
        yield return new WaitForSeconds(15);
        LiftButton.GetComponent<Button>().onClick.Invoke();
    }

    IEnumerator MyUpdate()
    {
        float timer = 0f;
        float time = 15f;
        while (timer < time)
        {
            timer += Time.deltaTime;
            yield return null;
        }
        // Here do anything that needs be done after 5s
        if (CinderBlock.transform.localPosition.z <= 0.3850001)
        {
            SpriteUpdater();
            SetupTrigger();
            CinderBlockSnapZone.SetActive(false);
        }
    }

}