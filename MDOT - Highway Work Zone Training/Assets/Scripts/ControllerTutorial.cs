using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class ControllerTutorial : MonoBehaviour
{
    private int ToggleCounter = 0, ActiveCounter = 0;
    public Image Image;
    public Sprite SelectImage, MenuImage;
    public AudioSource MenuEnter, MenuExit, SelectClip;
    public GameObject Text1, Text2, NextButton, MenuCanvas, DestinationPoint;
    public InputActionReference activeReference = null, toggleReference = null;

    private void Awake() {
        activeReference.action.started += Active;
    }

    private void OnDestroy() {
        activeReference.action.started -= Active;
        toggleReference.action.started -= Toggle;
    }

    private void Active(InputAction.CallbackContext context) { // Triggered by pressing 'Trigger'. Introduces the menu button to user. 
        if (ActiveCounter == 0) { MenuEnter.Play(); }
        Destroy(NextButton);
        Image.sprite = MenuImage;
        toggleReference.action.started += Toggle;
        Text1.GetComponent<TextMeshProUGUI>().text = "\n\n Press 'Menu' to continue";
        Text2.GetComponent<TextMeshProUGUI>().text = "\n You can use the 'Menu' button to look at your progress.";
        ActiveCounter++;
    }

    private void Toggle(InputAction.CallbackContext context) { // Triggered by pressing 'Menu'. Introduces the select button to user. 
        if (!MenuCanvas.activeSelf) { 
            SelectClip.Play();
            DestinationPoint.SetActive(true);
        }
        if (ToggleCounter == 0) { MenuExit.Play(); }
        Image.sprite = SelectImage;
        Text1.GetComponent<TextMeshProUGUI>().text = "\n\n Aim at the teleportation point and press 'Select' to continue";
        Text2.GetComponent<TextMeshProUGUI>().text = "\n You can use the 'Select' button to grab objects and teleport.";
        ToggleCounter++;
    }
}