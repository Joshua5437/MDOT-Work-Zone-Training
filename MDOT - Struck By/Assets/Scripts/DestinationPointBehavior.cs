using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DestinationPointBehavior : MonoBehaviour
{
    private int Triggered = 0;
    private GameObject DestinationButton, DestroyButton;
    public float speed = 2;
    public GameObject DestinationPoint;

    private void Start() {
        DestroyButton = GameObject.Find("Destroy Button");
        DestinationButton = GameObject.Find("Destination Button");
    }

    private void Update() { // Moves destination collider out of range of headset collider. Needed to trigger other colliders.
        if (Triggered != 0) {
            DestinationPoint.transform.Translate(speed * Time.deltaTime * Vector3.up); 
        } 
    }
    private void OnTriggerEnter(Collider other) { // Invokes destination button and begins moving destination point to trigger OnTriggerExit command.
        DestinationPoint.SetActive(false);
        DestinationButton.GetComponent<Button>().onClick.Invoke();
        Triggered++;
        StartCoroutine(WaitForDestroy());
    }

    public IEnumerator WaitForDestroy()
    {
        yield return new WaitForSeconds(3);
        DestroyButton.GetComponent<Button>().onClick.Invoke();
    }

    public void DestroyScene(GameObject context) { Destroy(context); } // Destroys a gameObject.
}
