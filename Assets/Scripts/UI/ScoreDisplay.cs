using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;

public class ScoreDisplay : MonoBehaviour
{

    private TextMeshProUGUI textMesh;
    private int score;

    // Start is called before the first frame update
    void Start()
    {
        textMesh=GetComponent<TextMeshProUGUI>();
        Debug.Log(textMesh);
        score = MazeLevel.Instance.getScore();
        textMesh.text= "Score: " + score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
