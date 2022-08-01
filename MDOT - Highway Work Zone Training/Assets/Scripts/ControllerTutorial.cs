using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class ControllerTutorial : MonoBehaviour
{
    private int ToggleCounter = 0, ActiveCounter = 0, NowPlayVid = -1, CallTeleportUser = -1;
    public Image Image;
    public TeleportUser ScreenFade;
    public Button ActivateWaistScene;
    public Sprite SelectImage, MenuImage;
    public UnityEngine.Video.VideoPlayer VideoPlayer, PracticeSuccess;
    public AudioSource MenuEnter, MenuExit, SelectClip, TransitionAudio;
    public GameObject Text1, Text2, NextButton, MenuCanvas, Interactable;
    public InputActionReference activeReference = null, toggleReference = null;

    private void Update()
    {
        if (!VideoPlayer.isPlaying && CallTeleportUser == 0)
        {
            ScreenFade.TransitionNotification();
            CallTeleportUser = -1;
        }
    }

    private void Awake() {
        toggleReference.action.started += Toggle;
    }

    private void OnDestroy() {
        toggleReference.action.started -= Toggle;
    }

    public void NowPlayVideo()
    {
        CallTeleportUser = 0;
    }

    private void Toggle(InputAction.CallbackContext context) { // Triggered by pressing 'Menu'. Introduces the select button to user. 
        if (ToggleCounter == 1) { 
            SelectClip.Play();
            MenuExit.Stop();
            Interactable.SetActive(true);
        }
        if (ToggleCounter == 0) { 
            MenuExit.Play();
            MenuEnter.Stop();
        }
        Image.sprite = SelectImage;
        Text1.GetComponent<TextMeshProUGUI>().text = "Use grip your right controller to grab the sphere.";
        Text2.GetComponent<TextMeshProUGUI>().text = "You can use the 'Select' button to grab objects.";
        ToggleCounter++;
    }
}