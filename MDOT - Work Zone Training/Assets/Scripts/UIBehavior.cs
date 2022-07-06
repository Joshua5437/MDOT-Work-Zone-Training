using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class UIBehavior : MonoBehaviour
{
    public InputActionReference toggleReference = null;
    private GameObject menu;

    void Start() {
        menu = GameObject.Find("Menu Canvas");
        menu.SetActive(false);
    }

    private void Awake() {toggleReference.action.started += Toggle;}
    private void OnDestroy() {toggleReference.action.started -= Toggle;}

    private void Toggle(InputAction.CallbackContext context) {
        bool isActive = !gameObject.activeSelf;
        gameObject.SetActive(isActive);
    }

    public void Exit() {Application.Quit();}
    public void ResetTask1() {SceneManager.LoadScene("Task1");}
    public void ResetTask2() {SceneManager.LoadScene("Task2");}
    public void ReloadCurrentScene() {SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);}
}