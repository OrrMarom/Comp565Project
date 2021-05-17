using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using TMPro;

public class ScoreSubmit : MonoBehaviour
{
    private string ScoreName;
    private int score;
    private string saveFile;
    public string saveContents;

    // Start is called before the first frame update
    void Start()
    {
        score = MazeLevel.Instance.getScore();
        saveFile = Application.persistentDataPath + "/Comp565_Group4_FinalProject.json";
        Debug.Log(saveFile);
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void updateName(string input){
        ScoreName=input;
    }

    public void Submit(){
        string day = System.DateTime.Now.ToString("MM/dd/yyyy");
        saveContents = (day + "       Player: " + ScoreName + "       Score: " + score + ',');
        writeFile();
    }

    public string readFile()
    {
        // Does the file exist?
        if (File.Exists(saveFile))
        {
            // Read the entire file and save its contents.
            return File.ReadAllText(saveFile);
        }
        return "";
    }

    public void writeFile()
    {
        string oldData = readFile();
        saveContents+=oldData;
        Debug.Log(saveContents);
        File.WriteAllText(saveFile, saveContents);
    }
}
