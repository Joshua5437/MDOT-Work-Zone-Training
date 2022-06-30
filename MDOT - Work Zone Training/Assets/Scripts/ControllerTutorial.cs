using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class ControllerTutorial : MonoBehaviour
{
    public Image Image;
    public Sprite SelectImage, MenuImage;
    public GameObject InstructionBoard1, InstructionBoard2, PracticeScene;
    public InputActionReference activeReference = null;
    public InputActionReference selectReference = null;
    public InputActionReference toggleReference = null;

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
        InstructionBoard1 = GameObject.Find("Text (TMP)");
        InstructionBoard1.GetComponent<TextMesh>().text = "\n\n Press 'Select' to continue";
        InstructionBoard1 = GameObject.Find("HTC Vive Controller Image");
        Image.sprite = SelectImage;
        InstructionBoard2 = GameObject.Find("Text (TMP)");
        InstructionBoard2.GetComponent<TextMesh>().text = "\n\n You can use the 'Select' button to grab objects and teleport.";
    }

    private void Select(InputAction.CallbackContext context) {
        InstructionBoard1 = GameObject.Find("Text (TMP)");
        InstructionBoard1.GetComponent<TextMesh>().text = "\n\n Press 'Menu' to continue";
        Image.sprite = MenuImage;
        InstructionBoard2 = GameObject.Find("Text (TMP)");
        InstructionBoard2.GetComponent<TextMesh>().text = "\n\n You can use the 'Menu' button to look at your progress.";
    }

    private void Toggle(InputAction.CallbackContext context) {
        bool isActive = !PracticeScene.activeSelf;
        PracticeScene.SetActive(isActive);
    }
}