using System.IO;
using UnityEngine;

public class QuestionReport : MonoBehaviour
{
    private string FileName = "";
    public string Scene;
    
    private void Start()
    {
        string time = System.DateTime.UtcNow.ToLocalTime().ToString("hh:mm:ss");
        string date = System.DateTime.UtcNow.ToLocalTime().ToString("dd MMMM, yyyy");
        FileName = Application.dataPath + "/Data/" + date + " " + Scene + ".csv";

        TextWriter tw = new StreamWriter(FileName, false);
        tw.WriteLine("Scene, Question, Right, Wrong");
        tw.Close();
    }

    public void WriteCSVWrong(string QuestionNumber)
    {
        TextWriter tw = new StreamWriter(FileName, true);
        tw.WriteLine(Scene + ", " + QuestionNumber + ", " + "  " + ", " + " X ");
        tw.Close();
    }

    public void WriteCSVRight(string QuestionNumber)
    {
        TextWriter tw = new StreamWriter(FileName, true);
        tw.WriteLine(Scene + ", " + QuestionNumber + ", " + " X " + ", " + "  ");
        tw.Close();
    }
}
