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
        score = MazeLevel.Instance.getScore();
        Debug.Log(score);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
