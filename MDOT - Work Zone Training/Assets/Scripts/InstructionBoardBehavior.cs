using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.XR.Interaction.Toolkit;

public class InstructionBoardBehavior : MonoBehaviour {
    private int count = 0;
    private GameObject CinderBlockSnapZone;
    private GameObject SlideButton, BendButton, LiftButton;
    private GameObject CurrentAudioClip, AudioClip1, AudioClip2, AudioClip3;
    public Image Image;
    public Sprite BendDown, LiftWithLegs, Done;

    private void Start() {
        SlideButton = GameObject.Find("Slide Button");
        BendButton = GameObject.Find("Bend Button");
        LiftButton = GameObject.Find("Lift Button");
        CurrentAudioClip = GameObject.Find("Voice Clip 3");
        AudioClip1 = GameObject.Find("Voice Clip 4");
        AudioClip2 = GameObject.Find("Voice Clip 5");
        AudioClip3 = GameObject.Find("Voice Clip 6");
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

    private void AudioChange() {
        CurrentAudioClip.GetComponent<AudioSource>().Stop();
        AudioClip1.GetComponent<AudioSource>().Play();
        CurrentAudioClip = AudioClip1;
        AudioClip1 = AudioClip2;
        AudioClip2 = AudioClip3;
    }

    private IEnumerator SetupWait() {
        yield return new WaitForSeconds(2);
        Debug.Log("Setup Complete! ");
        SlideButton.GetComponent<Button>().onClick.Invoke();
        CinderBlockSnapZone.GetComponent<XRSocketInteractor>().selectEntered.AddListener(raycastHit => AudioChange());
    }

    private IEnumerator AnalyzeMovementWait() {
        yield return new WaitForSeconds(10);
        BendButton.GetComponent<Button>().onClick.AddListener(AudioChange);
        BendButton.GetComponent<Button>().onClick.Invoke();
        yield return new WaitForSeconds(10);
        LiftButton.GetComponent<Button>().onClick.AddListener(AudioChange);
        LiftButton.GetComponent<Button>().onClick.Invoke();
    }
}