using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Globalization;

public class FloorLiftVerification : MonoBehaviour
{
    public Image Check, Cross, InstructionBoardImage;
    public float Duration = 1.0f;
    public GameObject WaistTracker;
    public AudioSource Correct, Incorrect;
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
        return (float)(Start_Position + (Start_Position * .05));
    }

    private float Lower_Margin_Calculator(float Start_Position)
    {
        return (float)(Start_Position - (Start_Position * .05));
    }

    public void SpriteUpdater()
    {
        InstructionBoardImage.sprite = LiftUp;
    }

    private void Set_Start_Pos(GameObject Tracker, char axis, char trackerName)
    {
        if (axis == 'x')
        {
            float _Position = Tracker.transform.position.x;
            string String_Position = _Position.ToString();
            if (trackerName == 'w') { W_Start_Pos_X = float.Parse(String_Position, CultureInfo.InvariantCulture.NumberFormat); }
        }
        else if (axis == 'y')
        {
            float _Position = Tracker.transform.position.y;
            string String_Position = _Position.ToString();
            if (trackerName == 'w') { W_Start_Pos_Y = float.Parse(String_Position, CultureInfo.InvariantCulture.NumberFormat); }
        }
        else if (axis == 'z')
        {
            float _Position = Tracker.transform.position.z;
            string String_Position = _Position.ToString();
            if (trackerName == 'w') { W_Start_Pos_Z = float.Parse(String_Position, CultureInfo.InvariantCulture.NumberFormat); }
        }
    }

    private void Set_Start_Rot(GameObject Tracker, char axis, char trackerName)
    {
        if (axis == 'x')
        {
            float Rotation = Tracker.transform.rotation.x;
            string String_Rotation = Rotation.ToString();
            if (trackerName == 'w') { W_Start_Rot_X = float.Parse(String_Rotation, CultureInfo.InvariantCulture.NumberFormat); }
        }
        else if (axis == 'y')
        {
            float Rotation = Tracker.transform.rotation.y;
            string String_Rotation = Rotation.ToString();
            if (trackerName == 'w') { W_Start_Rot_Y = float.Parse(String_Rotation, CultureInfo.InvariantCulture.NumberFormat); }
        }
        else if (axis == 'z')
        {
            float Rotation = Tracker.transform.rotation.z;
            string String_Rotation = Rotation.ToString();
            if (trackerName == 'w') { W_Start_Rot_Z = float.Parse(String_Rotation, CultureInfo.InvariantCulture.NumberFormat); }
        }
    }

    public void AnalysizeBendDownStep()
    {
        if ((Lower_Margin_Calculator(W_Start_Pos_Y) > WaistTracker.transform.position.y) && (0 < WaistTracker.transform.position.y))
        {
            Set_Start_Pos(WaistTracker, 'y', 'w');
            PostureFeedback(true);
        }
        else { PostureFeedback(false); }
    }

    public void AnalysizeLiftUpStep()
    {
        if ((Upper_Margin_Calculator(W_Start_Pos_Y) < WaistTracker.transform.position.y) && (2 > WaistTracker.transform.rotation.x) && (-2 < WaistTracker.transform.rotation.x)) { PostureFeedback(true); }
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
        yield return new WaitForSeconds(10);
        SpriteUpdater();
        BendDownButton.onClick.Invoke(); // Checks if user has bent down.
        yield return new WaitForSeconds(10);
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
}
