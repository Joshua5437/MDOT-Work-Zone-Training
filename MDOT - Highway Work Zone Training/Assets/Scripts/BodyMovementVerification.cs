using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BodyMovementVerification : MonoBehaviour
{
    private bool Slide_Check = false, Success = true;
    public AudioSource Correct, Incorrect;
    public Image Check, Cross;
    public GameObject WaistTracker, LeftFootTracker, RightFootTracker, CinderBlock, CinderBlockSnapZone;
    private float W_Start_Pos_X = 0, W_Start_Pos_Y = 0, W_Start_Pos_Z = 0;
    private float L_Start_Pos_X = 0, L_Start_Pos_Y = 0, L_Start_Pos_Z = 0;
    private float R_Start_Pos_X = 0, R_Start_Pos_Y = 0, R_Start_Pos_Z = 0;
    private float W_Start_Rot_X = 0, W_Start_Rot_Y = 0, W_Start_Rot_Z = 0;
    private float L_Start_Rot_X = 0, L_Start_Rot_Y = 0, L_Start_Rot_Z = 0;
    private float R_Start_Rot_X = 0, R_Start_Rot_Y = 0, R_Start_Rot_Z = 0;

    void Update()
    {
        if(!(CinderBlock.transform.position.y >= 0.96 && CinderBlock.transform.position.y <= 1.00) && Slide_Check) {
            PostureFeedback(false);
            Slide_Check = false;
        }
        if (!CinderBlockSnapZone.activeSelf && Slide_Check) {
            PostureFeedback(true);
            Slide_Check = false;
        }
    }
    
    private float Upper_Margin_Calculator(float Start_Position) {
        return (float)(Start_Position * (1.20));
    }

    private float Lower_Margin_Calculator(float Start_Position)
    {
        return (float)(Start_Position * (0.80));
    }

    public void RemoveThisScript()
    {
        Destroy(this);
    }

    private void Set_Start_Pos(GameObject Tracker, char axis, char trackerName) {
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
    }

    public void AnalysizeSlideStep() {
        Set_Start_Pos(WaistTracker, 'y', 'w'); Set_Start_Rot(WaistTracker, 'x', 'w');
        Slide_Check = true;
    }

    public void AnalysizeBendDownStep() {
        if((W_Start_Pos_Y > WaistTracker.transform.localPosition.y) && (Upper_Margin_Calculator(W_Start_Rot_X)) > WaistTracker.transform.localEulerAngles.x) {
            Set_Start_Pos(WaistTracker, 'y', 'w');
            PostureFeedback(true);
        }
        else{PostureFeedback(false);}
    }

    public void AnalyzeLiftStep() {
        if((W_Start_Pos_Y < WaistTracker.transform.localPosition.y) && (Upper_Margin_Calculator(W_Start_Rot_X)) > WaistTracker.transform.localEulerAngles.x) {PostureFeedback(true);}
        else{PostureFeedback(false);}  
    }
    public float Duration = 1.0f;

    private void PostureFeedback(bool response) {
        var canvGroup = Check.GetComponent<CanvasGroup>();
        var canvGroup2 = Cross.GetComponent<CanvasGroup>();

        if (response) {
            Correct.Play();
            StartCoroutine(DoFade(canvGroup, 1, 0));
        }
        else if (!response) {
            Incorrect.Play();
            StartCoroutine(DoFade(canvGroup2, 1, 0));
        }
    }

    public IEnumerator DoFade(CanvasGroup canvGroup, float start, float end)
    {
        float counter = 0f;
        while(counter < Duration)
        {
            counter += Time.deltaTime;
            canvGroup.alpha = Mathf.Lerp(start, end, (counter / Duration));

            yield return null;
        }
    }
}