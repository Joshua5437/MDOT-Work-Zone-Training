using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FixedJointScript : MonoBehaviour
{
    public float TimeToWait = 0;
    public GameObject RoadCone;
    public Rigidbody ConstructionWorker;
    private float PositionX = 0, PositionY = 0, PositionZ = 0;
    private float RotationX = 0, RotationY = 0, RotationZ = 0;

    private void Awake()
    {
        // Collects the starting position of the RoadCone. 
        PositionX = RoadCone.transform.localPosition.x;
        PositionY = RoadCone.transform.localPosition.y;
        PositionZ = RoadCone.transform.localPosition.z;

        // Collects the starting rotation of the RoadCone
        RotationX = RoadCone.transform.localRotation.x;
        RotationY = RoadCone.transform.localRotation.y;
        RotationZ = RoadCone.transform.localRotation.z;

        StartCoroutine(CreateFixedJoint());
    }

    private IEnumerator CreateFixedJoint()
    {
        yield return new WaitForSeconds(TimeToWait); // Gives construction worker X seconds before attaching object as fixed joint.
        RoadCone.GetComponent<FixedJoint>().connectedBody = ConstructionWorker;
    }

    public void ObjectReset() // Detaches and resets road cone to original position if replayed. 
    {
        RoadCone.transform.localPosition = new Vector3(PositionX, PositionY, PositionZ);
        RoadCone.transform.localRotation = Quaternion.Euler(RotationX, RotationY, RotationZ);
        StartCoroutine(CreateFixedJoint()); // Starts coroutine again. (Assuming that the user press 'replay')
    }

    public void DisconnectRigidbody()
    {
        RoadCone.GetComponent<FixedJoint>().connectedBody = null;
        ObjectReset();
    }
}