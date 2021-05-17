// Add System.IO to work with files!
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDataManager : MonoBehaviour
{
    // Create a field for the save file.
    //GameData gameData = new GameData();
    string saveFile;

    // Create a GameData field.
    private int score = 0;

    void Awake()
    {
        // Update the path once the persistent path exists.
        saveFile = Application.persistentDataPath + "/Comp565_Group4_Gamedata.json";
        Debug.Log(Application.persistentDataPath);
        score = MazeLevel.Instance.getScore();
    }

    public void readFile()
    {
        // Does the file exist?
        if (File.Exists(saveFile))
        {
            // Read the entire file and save its contents.
            string fileContents = File.ReadAllText(saveFile);

            // Deserialize the JSON data 
            //  into a pattern matching the GameData class.
            score = JsonUtility.FromJson<int>(fileContents);
        }
    }

    public void writeFile()
    {
        // Serialize the object into JSON and save string.
        string jsonString = JsonUtility.ToJson(score);

        // Write JSON to file.
        File.WriteAllText(saveFile, jsonString);
    }
}