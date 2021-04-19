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

    [SerializeField] private int timeLimit; // seconds

    private Stopwatch timer;
    private int timeRemaining;

    private int score = 0;
    private bool gameOver = false;
    private bool goalReached = false;

    private MazeGenerator mazeGenerator;
 
    void Start()
    {
        mazeGenerator = GetComponent<MazeGenerator>(); // Get component with type MazeGenerator attached to this object. 
        NewGame();
    }

    private void NewGame() 
    {
        // Default time limit.
        if (timeLimit == 0) {
            timeLimit = 60;
        }

        // Default maze size. 
        if (rows == 0 || cols == 0) {
            rows = 15; 
            cols = 15;
        }

        mazeGenerator.CreateNewMaze(rows, cols);

        // Initialize time.
        timeRemaining = timeLimit;
        timeLabel.text = timeLimit.ToString();
        timer = new Stopwatch();
        timer.Start();

        // Score.
        score = 0;
        scoreLabel.text = "Score: " + score.ToString();

        // Display Rules UI.
    }

    private void addToScore(int points) {
        score += points;
    }

    private void pickupKey() {
        addToScore(500);
    }

    private void pickupAmmo() {
        addToScore(50);
    }

    private void pickupTreasure() {
        addToScore(2000);
    }

    // Update is called once per frame
    void Update()
    {
        // Update timer.
        TimeSpan timeElapsed = timer.Elapsed;
        timeRemaining = (timeLimit - timeElapsed.Seconds);
        if (timeRemaining > 0) {
            timeLabel.text = timeRemaining.ToString(); // update timeLabel
        } else {
            timeLabel.text = "0";
            timer.Stop();
            gameOver = true;
        }
        
        // update scoreLabel
        scoreLabel.text = "Score: " + score.ToString();

        if (gameOver) {
            // GameOver UI.
            // "GameOver!"; "Score: "
        }

        if (goalReached) {
            // Calculate total score  
            addToScore(timeRemaining * 1000);

            // Cleared UI.
            // "Level Cleared!"; "Score: "
        }
    }
}
