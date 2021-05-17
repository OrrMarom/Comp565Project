using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using TMPro;


public class ScoreDisplayMenu : MonoBehaviour
{

    private TextMeshProUGUI textMesh;
    private int score;
    private string saveFile;

    // Start is called before the first frame update
    void Start()
    {
        saveFile = Application.persistentDataPath + "/Comp565_Group4_FinalProject.json";
        textMesh=GetComponent<TextMeshProUGUI>();
        string Scores = readFile();
        Scores = Scores.Replace(",","\n");
        textMesh.text= Scores;
    }

    // Update is called once per frame
    void Update()
    {
        
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
}
