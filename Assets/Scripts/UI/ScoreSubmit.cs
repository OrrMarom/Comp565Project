using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using TMPro;
using UnityEngine.SceneManagement;

public class ScoreSubmit : MonoBehaviour
{
    private string ScoreName;
    private int score;
    private string saveFile;
    public string saveContents;

    // Start is called before the first frame update
    void Start()
    {
        saveFile = Application.persistentDataPath + "/Comp565_Group4_FinalProject.json";
    }

    // Update is called once per frame
    void Update()
    {
        score = MazeLevel.Instance.getScore();
    }

    public void updateName(string input){
        ScoreName=input;
    }

    public void Submit(){
        string day = System.DateTime.Now.ToString("MM/dd/yyyy");
        saveContents = (day + "       Player: " + ScoreName + "       Score: " + score + ',');
        writeFile();
        SceneManager.UnloadScene("MazeLevel");
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
