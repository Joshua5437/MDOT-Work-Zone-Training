using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class ControllerTutorial : MonoBehaviour
{
    private int ToggleCounter = 0, ActiveCounter = 0, NowPlayVid = -1, BeginWaistScene = -1;
    public Image Image;
    public Button ActivateWaistScene;
    public Sprite SelectImage, MenuImage;
    public UnityEngine.Video.VideoPlayer VideoPlayer;
    public AudioSource MenuEnter, MenuExit, SelectClip, PracticeSuccess;
    public GameObject Text1, Text2, NextButton, MenuCanvas, Interactable;
    public InputActionReference activeReference = null, toggleReference = null;

    private void Update()
    {
        if (!PracticeSuccess.isPlaying && NowPlayVid == 0)
        {
            VideoPlayer.Play();
            NowPlayVid = -1;
            BeginWaistScene = 0;
        }

        if (!VideoPlayer.isPlaying && BeginWaistScene == 0)
        {
            ActivateWaistScene.onClick.Invoke();
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
        NowPlayVid = 0;
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