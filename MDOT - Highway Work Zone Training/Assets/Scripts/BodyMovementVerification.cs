using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Globalization;

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
        if(!(CinderBlock.transform.position.y >= 0.97 && CinderBlock.transform.position.y <= 0.99) && Slide_Check) {
            PostureFeedback(false);
            Success = false;
        }
        if (!CinderBlockSnapZone.activeSelf) {
            Slide_Check = false;
            if(Success) {
                PostureFeedback(true);
                Success = false;
            }
        }
    }
    
    private float Upper_Margin_Calculator(float Start_Position) {
        return (float)(Start_Position + (Start_Position * .05));
    }

    private float Lower_Margin_Calculator(float Start_Position) {
        return (float)(Start_Position - (Start_Position * .05));
    }

    private void Set_Start_Pos(GameObject Tracker, char axis, char trackerName) {
        if (axis == 'x') {
            float _Position = Tracker.transform.position.x;
            string String_Position = _Position.ToString();
            if (trackerName == 'w') {W_Start_Pos_X = float.Parse(String_Position, CultureInfo.InvariantCulture.NumberFormat);}
            else if (trackerName == 'l') {L_Start_Pos_X = float.Parse(String_Position, CultureInfo.InvariantCulture.NumberFormat);}
            else if (trackerName == 'r') {R_Start_Pos_X = float.Parse(String_Position, CultureInfo.InvariantCulture.NumberFormat);}
        }
        else if (axis == 'y') {
            float _Position = Tracker.transform.position.y;
            string String_Position = _Position.ToString();
            if (trackerName == 'w') {W_Start_Pos_Y = float.Parse(String_Position, CultureInfo.InvariantCulture.NumberFormat);}
            else if (trackerName == 'l') {L_Start_Pos_Y = float.Parse(String_Position, CultureInfo.InvariantCulture.NumberFormat);}
            else if (trackerName == 'r') {R_Start_Pos_Y = float.Parse(String_Position, CultureInfo.InvariantCulture.NumberFormat);}
        }
        else if (axis == 'z') {
            float _Position = Tracker.transform.position.z;
            string String_Position = _Position.ToString();
            if(trackerName == 'w') {W_Start_Pos_Z = float.Parse(String_Position, CultureInfo.InvariantCulture.NumberFormat);}
            else if(trackerName == 'l') {L_Start_Pos_Z = float.Parse(String_Position, CultureInfo.InvariantCulture.NumberFormat);}
            else if(trackerName == 'r') {R_Start_Pos_Z = float.Parse(String_Position, CultureInfo.InvariantCulture.NumberFormat);}
        }
    }

    private void Set_Start_Rot(GameObject Tracker, char axis, char trackerName) {
        if (axis == 'x') {
            float Rotation = Tracker.transform.rotation.x;
            string String_Rotation = Rotation.ToString();
            if (trackerName == 'w') {W_Start_Rot_X = float.Parse(String_Rotation, CultureInfo.InvariantCulture.NumberFormat);}
            else if (trackerName == 'l') {L_Start_Rot_X = float.Parse(String_Rotation, CultureInfo.InvariantCulture.NumberFormat);}
            else if (trackerName == 'r') {R_Start_Rot_X = float.Parse(String_Rotation, CultureInfo.InvariantCulture.NumberFormat);}
        }
        else if (axis == 'y') {
            float Rotation = Tracker.transform.rotation.y;
            string String_Rotation = Rotation.ToString();
            if(trackerName == 'w') {W_Start_Rot_Y = float.Parse(String_Rotation, CultureInfo.InvariantCulture.NumberFormat);}
            else if(trackerName == 'l') {L_Start_Rot_Y = float.Parse(String_Rotation, CultureInfo.InvariantCulture.NumberFormat);}
            else if(trackerName == 'r') {R_Start_Rot_Y = float.Parse(String_Rotation, CultureInfo.InvariantCulture.NumberFormat);}
        }
        else if (axis == 'z') {
            float Rotation = Tracker.transform.rotation.z;
            string String_Rotation = Rotation.ToString();
            if(trackerName == 'w') {W_Start_Rot_Z = float.Parse(String_Rotation, CultureInfo.InvariantCulture.NumberFormat);}
            else if(trackerName == 'l') {L_Start_Rot_Z = float.Parse(String_Rotation, CultureInfo.InvariantCulture.NumberFormat);}
            else if(trackerName == 'r') {R_Start_Rot_Z = float.Parse(String_Rotation, CultureInfo.InvariantCulture.NumberFormat);}
        }
    }

    public void AnalysizeSlideStep() {
        Set_Start_Pos(WaistTracker, 'y', 'w'); Set_Start_Rot(WaistTracker, 'x', 'w');
        Slide_Check = true;
    }

    public void AnalysizeBendDownStep() {
        if((Lower_Margin_Calculator(W_Start_Pos_Y) > WaistTracker.transform.position.y) && (0 < WaistTracker.transform.position.y)) {
            Set_Start_Pos(WaistTracker, 'y', 'w');
            PostureFeedback(true);
        }
        else{PostureFeedback(false);}
    }

    public void AnalyzeLiftStep() {
        if((Upper_Margin_Calculator(W_Start_Pos_Y) < WaistTracker.transform.position.y) && (2 > WaistTracker.transform.rotation.x) && (-2 < WaistTracker.transform.rotation.x)) {PostureFeedback(true);}
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