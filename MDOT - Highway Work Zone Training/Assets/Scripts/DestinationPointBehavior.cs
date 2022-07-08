using UnityEngine;
using UnityEngine.UI;

public class DestinationPointBehavior : MonoBehaviour
{
    private GameObject DestinationButton;

    private void Start() { DestinationButton = GameObject.Find("Destination Button"); }
    private void OnTriggerEnter(Collider other) { DestinationButton.GetComponent<Button>().onClick.Invoke(); }
}
