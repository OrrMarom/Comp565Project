using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Diagnostics;
using System;
using TMPro;

// --- Controller for the maze level.

[RequireComponent(typeof(MazeGenerator))] 
public class MazeLevel : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timeLabel;
    [SerializeField] private TextMeshProUGUI scoreLabel;
    [SerializeField] private int rows;
    [SerializeField] private int cols;

    private int timeLimit = 90; // seconds

    private Stopwatch timer;
    private int timeRemaining;

    private int score = 0;
    private bool gameOver = false;
    private bool goalReached = false;

    private MazeGenerator mazeGenerator;
 
    void Start()
    {
        mazeGenerator = GetComponent<MazeGenerator>(); // Get component with type MazeGenerator attached to this object. 
        //timeLabel = GameObject.Find
        NewGame();
    }

    private void NewGame() 
    {
        // Default maze size. 
        if (rows == 0 || cols == 0) {
            rows = 15; 
            cols = 15;
        }

        mazeGenerator.CreateNewMaze(rows, cols);

        // --- Initialize values.
        // Time.
        timeRemaining = timeLimit;
        timeLabel.text = timeLimit.ToString();
        timer = new Stopwatch();
        timer.Start();

        // Score.
        score = 0;
        scoreLabel.text = "Score: " + score.ToString();

        // Display Rules UI.

    }

    public void setScore(int points) {
        score += points;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeRemaining > 0) {

        } else {
            timer.Stop();
        }
        

        // update timeLabel
        TimeSpan timeElapsed = timer.Elapsed;
        timeRemaining = (timeLimit - timeElapsed.Seconds);
        timeLabel.text = timeRemaining.ToString();

        // update scoreLabel
        scoreLabel.text = "Score: " + score.ToString();

        if (gameOver) {
            // GameOver UI.
            // "GameOver!"; "Score: "
        }

        if (goalReached) {
            // Calculate total score  
            score += (timeRemaining * 1000);

            // Cleared UI.
            // "Level Cleared!"; "Score: "
        }


        
    }
}
