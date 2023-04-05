using System.IO;
using UnityEngine;

public class CSVWriter : MonoBehaviour
{
    string FileName = "";

    [System.Serializable]
    public class Player
    {
        public string name;
        public int health;
        public int damage;
        public int defense;
    }

    [System.Serializable]
    public class PlayerList
    {
        public Player[] player;
    }

    public PlayerList myPlayerList = new PlayerList();
    // Start is called before the first frame update
    void Start()
    {
        FileName = Application.dataPath + "/test.csv";
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            WriteCSV();
        }
    }

    public void WriteCSV()
    {
        if(myPlayerList.player.Length > 0)
        {
            TextWriter tw = new StreamWriter(FileName, false);
            tw.WriteLine("Name, Health, Damge, Defense");
            tw.Close();

            tw = new StreamWriter(FileName, true);

            for(int i = 0; i < myPlayerList.player.Length; i++)
            {
                tw.WriteLine(myPlayerList.player[i].name + ", " + myPlayerList.player[i].health + ", " + myPlayerList.player[i].damage + ", " + myPlayerList.player[i].defense);
            }
            tw.Close();
        }
    }
}