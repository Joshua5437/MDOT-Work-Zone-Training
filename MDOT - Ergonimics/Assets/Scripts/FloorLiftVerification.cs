using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FloorLiftVerification : MonoBehaviour
{
    public TextMeshProUGUI percentError;
    public Image Check, Cross, InstructionBoardImage;
    public GameObject reportCheck, reportCross, reportObjects;
    public float Duration = 1.0f;
    public GameObject WaistTracker;
    public AudioSource Correct, Incorrect;
    private float num1, num2;
    private float W_Start_Pos_X = 0, W_Start_Pos_Y = 0, W_Start_Pos_Z = 0;
    private float W_Start_Rot_X = 0, W_Start_Rot_Y = 0, W_Start_Rot_Z = 0;

    [Header("Instruction Board Sprite (Sprite)")] // Assign sprites to be displayed to the instruction board.
    public Sprite LiftUp;

    [Header("Instruction Board Buttons (Button)")] // Assign buttons from instruction board.
    public Button BendDownButton;
    public Button LiftUpButton;

    private void OnEnable()
    {
        Set_Start_Pos(WaistTracker, 'y', 'w'); Set_Start_Rot(WaistTracker, 'x', 'w');
        Debug.Log("Setup Complete! ");
        StartCoroutine(AnalyzeMovementWait());
    }

    private float Upper_Margin_Calculator(float Start_Position)
    {
        return (float)(Start_Position * (18)); // 5% of 360 degrees = 18 degrees
    }

    private float Lower_Margin_Calculator(float Start_Position)
    {
        return (float)(Start_Position * (18)); // 5% of 360 degrees = 18 degrees
    }

    public void SpriteUpdater()
    {
        InstructionBoardImage.sprite = LiftUp;
    }

    private void Set_Start_Pos(GameObject Tracker, char axis, char trackerName)
    {
        Vector3 TrackerPosition = Tracker.transform.localPosition;
        W_Start_Pos_X = TrackerPosition.x;
        W_Start_Pos_Y = TrackerPosition.y;
        W_Start_Pos_Z = TrackerPosition.z;
    }

    private void Set_Start_Rot(GameObject Tracker, char axis, char trackerName) {
        Vector3 TrackerRotation = Tracker.transform.localEulerAngles;
        W_Start_Rot_X = TrackerRotation.x;
        W_Start_Rot_Y = TrackerRotation.y;
        W_Start_Rot_Z = TrackerRotation.z;

        // Used for percent error of X rotation axis. 
        num1 = TrackerRotation.x;
    }

    public void AnalysizeBendDownStep()
    {
        if (W_Start_Pos_Y > WaistTracker.transform.localPosition.y && (Upper_Margin_Calculator(W_Start_Rot_X) > WaistTracker.transform.localEulerAngles.x))
        {
            Set_Start_Pos(WaistTracker, 'y', 'w');
            PostureFeedback(true);
        }
        else
        {
            PostureFeedback(false);
        }

        // Used for percent error of X rotation axis. 
        num2 = WaistTracker.transform.localEulerAngles.x;
    }

    public void AnalysizeLiftUpStep()
    {
        reportObjects.SetActive(true);
        float backStraightResult = calculatePercentError(num1, num2);

        if (backStraightResult < 95) { reportCross.SetActive(true); }
        else { reportCheck.SetActive(true); }

        percentError.text = $"Kept Back Straight: {(Mathf.Round(backStraightResult * 100)) / 100.0}% accuracy";
        if (W_Start_Pos_Y < WaistTracker.transform.localPosition.y && (Upper_Margin_Calculator(W_Start_Rot_X) > WaistTracker.transform.localEulerAngles.x)) { PostureFeedback(true); }
        else { PostureFeedback(false); }
    }

    private void PostureFeedback(bool response)
    {
        var canvGroup = Check.GetComponent<CanvasGroup>();
        var canvGroup2 = Cross.GetComponent<CanvasGroup>();

        if (response)
        {
            Correct.Play();
            StartCoroutine(DoFade(canvGroup, 1, 0));
        }
        else if (!response)
        {
            Incorrect.Play();
            StartCoroutine(DoFade(canvGroup2, 1, 0));
        }
    }

    private IEnumerator AnalyzeMovementWait()
    {
        yield return new WaitForSeconds(15);
        SpriteUpdater();
        BendDownButton.onClick.Invoke(); // Checks if user has bent down.
        yield return new WaitForSeconds(15);
        LiftUpButton.onClick.Invoke(); // Checks if user has lifted cone. 
    }

    private IEnumerator DoFade(CanvasGroup canvGroup, float start, float end) // Displays correct/incorrect image to instructin board. 
    {
        float counter = 0f;
        while (counter < Duration)
        {
            counter += Time.deltaTime;
            canvGroup.alpha = Mathf.Lerp(start, end, (counter / Duration));

            yield return null;
        }
    }

    public float calculatePercentError(float num1, float num2)
    {
        var result = 100 - ((Mathf.Abs(num1 - num2) / 360) * 100);
        return result;
    }
}
