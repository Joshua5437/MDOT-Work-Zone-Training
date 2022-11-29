using UnityEngine;

public class AnimatorPositionReset : MonoBehaviour
{

    public GameObject AnimatedObject;
    private Vector3 ObjectPosition, ObjectRotation;

    private void Start()
    {
        ObjectPosition = AnimatedObject.transform.localPosition;
        ObjectRotation = AnimatedObject.transform.localEulerAngles;
    }

    public void PositionReset() {
        AnimatedObject.transform.localPosition = ObjectPosition;
        AnimatedObject.transform.localRotation = Quaternion.Euler(ObjectRotation.x, ObjectRotation.y, ObjectRotation.z);
    }
}
