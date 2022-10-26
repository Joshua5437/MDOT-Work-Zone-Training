using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ReturnObject : MonoBehaviour
{
    private float PositionX, PositionY, PositionZ;
    private float RotationX, RotationY, RotationZ;

    private void Start()
    {
        // Collects the starting position of the object. 
        PositionX = transform.localPosition.x;
        PositionY = transform.localPosition.y;
        PositionZ = transform.localPosition.z;

        // Collects the starting rotation of the object.
        RotationX = transform.localRotation.x;
        RotationY = transform.localRotation.y;
        RotationZ = transform.localRotation.z;
    }

    public void ReturnObjectToTable()
    {
        transform.localPosition = new Vector3(PositionX, PositionY, PositionZ);
        transform.localRotation = Quaternion.Euler(RotationX, RotationY, RotationZ);
    }
}
