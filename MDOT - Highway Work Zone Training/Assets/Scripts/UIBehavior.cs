using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class UIBehavior : MonoBehaviour
{
    public Transform Menu, MenuElements;
    public InputActionReference toggleReference = null;

    private void Awake() {toggleReference.action.started += Toggle;}
    private void OnDestroy() {toggleReference.action.started -= Toggle;}

    private void Toggle(InputAction.CallbackContext context) {
        bool isActive = !gameObject.activeSelf;
        if (isActive == true) { Menu.parent = null; }
        else Menu.parent = MenuElements;
        gameObject.SetActive(isActive);
    }

    public void Exit() {Application.Quit();}
    public void ReloadCurrentScene() {SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);}
}