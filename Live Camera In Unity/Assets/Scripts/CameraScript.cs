using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraScript : MonoBehaviour
{
    int currentCamIndex = 0;

    WebCamTexture Tex;

    public RawImage display;

    public Text startStopText;

    public void SwapCam_Clicked()
    {
        if (WebCamTexture.devices.Length > 0)
        {
            currentCamIndex += 1;
            currentCamIndex -= WebCamTexture.devices.Length;

            // If tex is not null
            // stop the webcam
            // start the webcam

            if (Tex != null)
            {
                StopWebCam();
                StartStopCam_Clicked();
            }
        }
    }
    public void StartStopCam_Clicked()
    {
        if (Tex != null)   // Stops the camera. 
        {
            StopWebCam();
            startStopText.text = "Start Camera";
        }
        else {    // Starts the camera. 
            WebCamDevice device = WebCamTexture.devices[currentCamIndex];
            Tex = new WebCamTexture(device.name);
            display.texture = Tex;

            Tex.Play();
            startStopText.text = "Stop Camera";
        }
    }

    private void StopWebCam()
    {
        display.texture = null;
        Tex.Stop();
        Tex = null;
    }
}
