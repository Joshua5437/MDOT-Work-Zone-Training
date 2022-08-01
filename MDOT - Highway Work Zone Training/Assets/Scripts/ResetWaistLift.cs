using UnityEngine;
using UnityEngine.UI;

public class ResetWaistLift : MonoBehaviour
{
    public Image CorrectPostureImage;
    public Sprite StartingSprite, BendDown, LiftWithLegs, Done;
    public GameObject WaistInstructionBoard;

    public GameObject UserScene, CinderBlock, CinderBlockSnapZone;

    // [Header("RoadCone Position (Transform)")]
    private double PositionX = -0.000734307, PositionY = 0.9877658, PositionZ = 0.594;

    // [Header("RoadCone Rotation (Transform)")]
    private float RotationX = 0, RotationY = 0, RotationZ = 0;

    public void ResetWaistLiftScenario()
    {
        ResetCinderBlocks();
        ResetBoardSprites();
        ResetUserInstructionBoard();
    }

    private void ResetCinderBlocks()
    {
        CinderBlock.transform.localRotation = Quaternion.Euler(RotationX, RotationY, RotationZ);
        CinderBlock.transform.localPosition = new Vector3((float)PositionX, (float)PositionY, (float)PositionZ);
        CinderBlockSnapZone.SetActive(true);
    }

    private void ResetBoardSprites()
    {
        CorrectPostureImage.sprite = StartingSprite;
        WaistInstructionBoard.GetComponent<InstructionBoardBehavior>().BendDown = BendDown;
        WaistInstructionBoard.GetComponent<InstructionBoardBehavior>().LiftWithLegs = LiftWithLegs;
        WaistInstructionBoard.GetComponent<InstructionBoardBehavior>().Done = Done;
    }

    private void ResetUserInstructionBoard()
    {
        CorrectPostureImage.sprite = StartingSprite;
        WaistInstructionBoard.GetComponent<InstructionBoardBehavior>().enabled = false;
        WaistInstructionBoard.GetComponent<InstructionBoardBehavior>().enabled = true;
    }
}
