using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class ControllerTutorial : MonoBehaviour
{
    public Image Image;
    public Sprite SelectImage, MenuImage;
    public AudioSource MenuEnter, SelectClip, PracticeSuccess;
    public GameObject Text1, Text2, PracticeScene, NextButton, MenuCanvas, IntroductionScene, DestinationPoint;
    public InputActionReference activeReference = null, selectReference = null, toggleReference = null;

    private void Awake() {
        activeReference.action.started += Active;
    }

    private void OnDestroy() {
        activeReference.action.started -= Active;
        selectReference.action.started -= Select;
        toggleReference.action.started -= Toggle;
    }

    public void DestroyScene(GameObject context)
    {
        Destroy(context);
    }

    private void Active(InputAction.CallbackContext context) {
        MenuEnter.Play();
        Destroy(NextButton);
        Image.sprite = MenuImage;
        toggleReference.action.started += Toggle;
        Text1.GetComponent<TextMeshProUGUI>().text = "\n\n Press 'Menu' to continue";
        Text2.GetComponent<TextMeshProUGUI>().text = "\n You can use the 'Menu' button to look at your progress.";
    }

    private void Select(InputAction.CallbackContext context)
    {
        /*
        PracticeSuccess.Play();
        MenuCanvas.GetComponent<AudioSource>().enabled = false;
        IntroductionScene.GetComponent<IntroductionScript>().enabled = true;
        Destroy(PracticeScene);
        */
    }
    private void Toggle(InputAction.CallbackContext context) {
        if (!MenuCanvas.activeSelf) { 
            SelectClip.Play();
            DestinationPoint.SetActive(true);
        }
        Image.sprite = SelectImage;
        selectReference.action.started += Select;
        Text1.GetComponent<TextMeshProUGUI>().text = "\n\n Press 'Select' to continue";
        Text2.GetComponent<TextMeshProUGUI>().text = "\n You can use the 'Select' button to grab objects and teleport.";
    }
}