using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class ControllerTutorial : MonoBehaviour
{
    public Image Image;
    public Sprite SelectImage, MenuImage;
    public GameObject Text1, Text2, PracticeScene, NextButton;
    public InputActionReference activeReference = null, selectReference = null, toggleReference = null;

    private void Awake() {
        activeReference.action.started += Active;
        selectReference.action.started += Select;
        toggleReference.action.started += Toggle;
    }

    private void OnDestroy() {
        activeReference.action.started -= Active;
        selectReference.action.started -= Select;
        toggleReference.action.started -= Toggle;
    }

    private void Active(InputAction.CallbackContext context) {
        bool isActive = !NextButton.activeSelf;
        NextButton.SetActive(isActive);
        Text1.GetComponent<TextMeshProUGUI>().text = "\n\n Press 'Menu' to continue";
        Image.sprite = MenuImage;
        Text2.GetComponent<TextMeshProUGUI>().text = "\n You can use the 'Menu' button to look at your progress.";
    }

    private void Select(InputAction.CallbackContext context) {
        bool isActive = !PracticeScene.activeSelf;
        PracticeScene.SetActive(isActive);
    }

    private void Toggle(InputAction.CallbackContext context) {
        Text1.GetComponent<TextMeshProUGUI>().text = "\n\n Press 'Select' to continue";
        Image.sprite = SelectImage;
        Text2.GetComponent<TextMeshProUGUI>().text = "\n You can use the 'Select' button to grab objects and teleport.";
    }
}