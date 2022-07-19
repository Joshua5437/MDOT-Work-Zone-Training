using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class UIBehavior : MonoBehaviour
{
    public GameObject Menu, RightController, CameraOffset;
    public InputActionReference toggleReference = null;
    private void Awake()
    {
        toggleReference.action.started += Toggle;
        gameObject.SetActive(false);
    }
    private void OnDestroy() {toggleReference.action.started -= Toggle;}

    private void Toggle(InputAction.CallbackContext context) {
        bool isActive = !gameObject.activeSelf;
        gameObject.SetActive(isActive);
        if (isActive == true) { Menu.transform.parent = CameraOffset.transform; }
        else { Menu.transform.parent = RightController.transform; }
    }
    public void Exit() {Application.Quit();}
    public void ReloadCurrentScene() {SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);}
}