using UnityEngine;

public class UICross2Check : MonoBehaviour
{
    public GameObject[] activeObjects;
    public GameObject[] deactiveObjects;

    public void taskComplete() {
        foreach (GameObject obj in activeObjects) { obj.SetActive(false); }
        foreach (GameObject obj in deactiveObjects) { obj.SetActive(true); }
    } 
}
