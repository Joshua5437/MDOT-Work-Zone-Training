using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.XR.Interaction.Toolkit;

public class PPESystem : MonoBehaviour
{
    private GameObject SelectedPPE;
    private AudioSource Correct, Incorrect;
    private float PositionX = 0, PositionY = 0, PositionZ = 0;
    private float RotationX = 0, RotationY = 0, RotationZ = 0;

    private void Start() {
        SelectedPPE = this.gameObject;          // Gets object the script is attached to.
        AudioSource Correct = GameObject.Find("Correct").GetComponent<AudioSource>();
        AudioSource Incorrect = GameObject.Find("Incorrect").GetComponent<AudioSource>();

        // Collects the starting position of the object. 
        PositionX = transform.localPosition.x;
        PositionY = transform.localPosition.y;
        PositionZ = transform.localPosition.z;

        // Collects the starting rotation of the object.
        RotationX = transform.localRotation.x;
        RotationY = transform.localRotation.y;
        RotationZ = transform.localRotation.z;
    }

    protected virtual void OnSelectEntered(SelectEnterEventArgs args) {
        if (SelectedPPE.tag == "CorrectPPE") {   // Disables correct PPE.
            Correct.Play();
            SelectedPPE.active = false;
        } else if (SelectedPPE.tag == "IncorrectPPE") {  // Plays incorrect audio.
            Incorrect.Play();
        }
    }

    protected virtual void OnSelectExited(SelectExitEventArgs args) {
        if(SelectedPPE.tag == "IncorrectPPE") {   // Returns incorrect PPE to table. 
            transform.localPosition = new Vector3(PositionX, PositionY, PositionZ);
            transform.localRotation = Quaternion.Euler(RotationX, RotationY, RotationZ);
        }
    }
}
