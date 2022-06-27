using UnityEngine;
using UnityEngine.AI;

public class CarPatrol : MonoBehaviour {

    [Header("Car Wheels (Transform)")] // Assign wheels through the inspector
    public Transform WheelBL;
    public Transform WheelBR;
    public Transform WheelFL;
    public Transform WheelFR;

    public Transform[] PathNodes;

    private NavMeshAgent Agent;
    private int DestinationPoint = 0;

    private void Start() {
        Agent = GetComponent<NavMeshAgent>();
        GotoNextPoint();
    }

    private void Update() {
        if (!Agent.pathPending && Agent.remainingDistance < 0.5f)
            GotoNextPoint();
        RotateWheels();
    }

    private void GotoNextPoint() {
        if (PathNodes.Length == 0) // No nodes in list.
            return; 

        Agent.destination = PathNodes[DestinationPoint].position; // Sets next node to move to. 
        DestinationPoint = (DestinationPoint + 1) % PathNodes.Length; // Gets next node in iteration.
    }

    private void RotateWheels() { 
        WheelBL.transform.Rotate(10f, 0f, 0f, Space.Self);
        WheelBR.transform.Rotate(10f, 0f, 0f, Space.Self);
        WheelFL.transform.Rotate(10f, 0f, 0f, Space.Self);
        WheelFR.transform.Rotate(10f, 0f, 0f, Space.Self);
    }
    
    private void OnTriggerEnter(Collider other) {Agent.speed = 5;}    
    private void OnTriggerExit(Collider other) {Agent.speed = 15;}   
}