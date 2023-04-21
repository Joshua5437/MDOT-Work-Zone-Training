using UnityEngine;

public class PPEManager : MonoBehaviour
{
    private int counter = 0;
    public GameObject[] CorrectPPE;

    public UICross2Check UIFix;
    public GameObject CurrentScene, NextScene;

    private void Update() {
        for (int i = 0; i < CorrectPPE.Length; i++) {
            if(CorrectPPE[i].activeSelf == false) { counter = counter + 1; }
        }

        if(counter == CorrectPPE.Length) {  // Switches user to next scene. 
            NextScene.SetActive(true);
            CurrentScene.SetActive(false);

            if(NextScene.name == "Hazard Scenario 1") {
                UIFix.taskComplete();
                NextScene.GetComponent<SceneTeleport>().TeleportUser();
            } else {
                CurrentScene.GetComponent<SceneTeleport>().TeleportUser();
            }
        }
        else { counter = 0; }
    }
}
