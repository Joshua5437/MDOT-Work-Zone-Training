using UnityEngine;

public class AnimatorPositionReset : MonoBehaviour
{
    
    public GameObject AnimatedObject;

    [Header("Object Position (Transform)")]
    public float PositionX;
    public float PositionY;
    public float PositionZ;

    [Header("Object Rotation (Transform)")]
    public float RotationX;
    public float RotationY;
    public float RotationZ;

    public void PositionReset() {
        AnimatedObject.transform.localPosition = new Vector3(PositionX, PositionY, PositionZ);
        AnimatedObject.transform.localRotation = Quaternion.Euler(RotationX, RotationY, RotationZ);
    }
}
