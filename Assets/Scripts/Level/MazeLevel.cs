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
    // Singleton
    //private static MazeLevel levelInstance;

    // Player and HUD variables
    [SerializeField] private TextMeshProUGUI timeLabel;
    [SerializeField] private TextMeshProUGUI scoreLabel;
    private TextMeshProUGUI health;
    [SerializeField] private TextMeshProUGUI ammo_r;
    [SerializeField] private TextMeshProUGUI ammo_g;
    [SerializeField] private TextMeshProUGUI ammo_b;
    [SerializeField] private TextMeshProUGUI keyCount;

    // Level item variables.
    private int ammo_rCount = 0;
    private int ammo_gCount = 0;
    private int ammo_bCount = 0;
    private int keysLeft;
    private const string keyString = "Keys Left: ";
    private int totalKeys = 5;

    // Other level vars.
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

        // Initialzie score.
        score = 0;
        scoreLabel.text = "Score: " + score.ToString();

        // Initialize items.
        ammo_r.text = ammo_rCount.ToString();
        ammo_g.text = ammo_gCount.ToString();
        ammo_b.text = ammo_bCount.ToString();
        keysLeft = totalKeys;
        keyCount.text = keyString + keysLeft.ToString();


        // Display Rules UI.
    }

    public void addToScore(int points) {
        score += points;
    }

    // private void pickupKey() {
    //     addToScore(500);
    // }

    // private void pickupAmmo() {
    //     addToScore(50);
    // }

    // private void pickupTreasure() {
    //     addToScore(2000);
    // }

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
