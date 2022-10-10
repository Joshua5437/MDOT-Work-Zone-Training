using Tobii.XR;
using System.IO;
using UnityEngine;

public class EyeDataExporter : MonoBehaviour
{
    private string FileName = "";

    private void Start()
    {
        string date = System.DateTime.UtcNow.ToLocalTime().ToString("dd MMMM, yyyy");
        FileName = Application.dataPath + "/Data/" + date + ".csv";

        TextWriter tw = new StreamWriter(FileName, false);
        tw.WriteLine("Object In Gaze, Time, X Position, Y Position, Z Position");
        tw.Close();
    }

    private void Update()
    {
        if(TobiiXR.FocusedObjects.Count > 0)
        {
            string time = System.DateTime.UtcNow.ToLocalTime().ToString("hh:mm:ss");
            GameObject focusedGameObject = TobiiXR.FocusedObjects[0].GameObject;
            WriteCSV(focusedGameObject, time);
        }
    }

    private void WriteCSV(GameObject focusedGameObject, string time)
    {
        TextWriter tw = new StreamWriter(FileName, true);
        tw.WriteLine(focusedGameObject.name + ", " + time + ", " + focusedGameObject.transform.position.x + ", " + focusedGameObject.transform.position.y + ", " + focusedGameObject.transform.position.z);
        tw.Close();
    }
}
