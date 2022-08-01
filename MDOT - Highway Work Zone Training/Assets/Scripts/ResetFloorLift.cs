using UnityEngine;
using UnityEngine.UI;

public class ResetFloorLift : MonoBehaviour
{
    public Image CorrectPostureImage;
    public Sprite StartingSprite;
    public GameObject FloorInstructionBoard;

    public GameObject UserScene, RoadCone;

    // [Header("RoadCone Position (Transform)")]
    private double PositionX = -0.047, PositionY = 0, PositionZ = 0.528;

    // [Header("RoadCone Rotation (Transform)")]
    private float RotationX = 0, RotationY = 0, RotationZ = 0;

    public void ResetFloorLiftScenario()
    {
        ResetRoadCone();
        ResetUserInstructionBoard();
    }

    private void ResetRoadCone()
    {
        RoadCone.transform.localRotation = Quaternion.Euler(RotationX, RotationY, RotationZ);
        RoadCone.transform.localPosition = new Vector3((float)PositionX, (float)PositionY, (float)PositionZ);
    }

    private void ResetUserInstructionBoard()
    {
        CorrectPostureImage.sprite = StartingSprite;
        FloorInstructionBoard.GetComponent<FloorLiftVerification>().enabled = false;
        FloorInstructionBoard.GetComponent<FloorLiftVerification>().enabled = true;
    }
}
