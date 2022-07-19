using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.XR.Interaction.Toolkit;

public class InstructionBoardBehavior : MonoBehaviour {
    private int count = 0;
    private GameObject CinderBlockSnapZone;
    private GameObject SlideButton, BendButton, LiftButton;
    public Image Image;
    public Sprite BendDown, LiftWithLegs, Done;

    private void Awake() {
        SlideButton = GameObject.Find("Slide Button");
        BendButton = GameObject.Find("Bend Button");
        LiftButton = GameObject.Find("Lift Button");
        CinderBlockSnapZone = GameObject.Find("Cinder Block Snap Zone");
        SlideButton.SetActive(false);
        BendButton.SetActive(false);
        LiftButton.SetActive(false);
        StartCoroutine(SetupWait());
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
        yield return new WaitForSeconds(10);
        BendButton.GetComponent<Button>().onClick.Invoke();
        yield return new WaitForSeconds(10);
        LiftButton.GetComponent<Button>().onClick.Invoke();
    }
}