using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using System.Diagnostics;
using System;
using TMPro;

// --- Controller for the maze level.

[RequireComponent(typeof(MazeGenerator))] 
public class MazeLevel : MonoBehaviour
{
    // Singleton
    private static MazeLevel levelInstance;
    public static MazeLevel Instance { get { return levelInstance; } }

    // Player and HUD variables
    [SerializeField] private TextMeshProUGUI timeLabel;
    [SerializeField] private TextMeshProUGUI scoreLabel;
    private TextMeshProUGUI health;
    [SerializeField] private TextMeshProUGUI ammoRLabel;
    [SerializeField] private TextMeshProUGUI ammoGLabel;
    [SerializeField] private TextMeshProUGUI ammoBLabel;
    [SerializeField] private TextMeshProUGUI keyLabel;

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

    public GameObject navMesh;

    private MazeGenerator mazeGenerator;
 
    // Only one instance of level allowed.
    private void Awake() 
    {
        if (levelInstance != null && levelInstance != this)
        {
            Destroy(this.gameObject);
        } else {
            levelInstance = this;
        }
    }

    void Start()
    {
        navMesh = GameObject.Find("NavMesh");
        mazeGenerator = GetComponent<MazeGenerator>(); // Get component with type MazeGenerator attached to this object. 
        NewGame();
    }

    private void NewGame() 
    {
        // Default time limit.
        if (timeLimit == 0) {
            timeLimit = 60;
        }
        // set time limit
        timeLimit = 60;

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
        ammoRLabel.text = ammo_rCount.ToString();
        ammoGLabel.text = ammo_gCount.ToString();
        ammoBLabel.text = ammo_bCount.ToString();
        keysLeft = totalKeys;
        keyLabel.text = keyString + keysLeft.ToString();


        // Display Rules UI.

        // Bake NavMesh
        navMesh.GetComponent<NavMeshSurface>().BuildNavMesh();

        StartCoroutine(UpdateNavMesh());
    }

    // Continuously update navmesh in case of destroyed cubes
    // Not a permanent solution but works for a demo
    public IEnumerator UpdateNavMesh()
    {

        // Bake NavMesh
        navMesh.GetComponent<NavMeshSurface>().BuildNavMesh();

        UnityEngine.Debug.Log("baking navmesh");

        // Delay fade for some time
        yield return new WaitForSeconds(1);
    }

    // --- Update methods.
    public void addToScore(int points) {
        score += points;
    }

    public void addAmmoR(int ammoNum) {
        ammo_rCount += ammoNum;
    }

    public void addAmmoG(int ammoNum) {
        ammo_gCount += ammoNum;
    }

    public void addAmmoB(int ammoNum) {
        ammo_bCount += ammoNum;
    }

    public void subtractKeyCount(int count) {
        keysLeft -= count;
    }


    // public void updateHealthLabel(int newHealth) {
    //     //HealthBar.updateHealth();
    // }

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
        
        // update score
        scoreLabel.text = "Score: " + score.ToString();

        // update ammo count
        ammoRLabel.text = ammo_rCount.ToString();
        ammoGLabel.text = ammo_gCount.ToString();
        ammoBLabel.text = ammo_bCount.ToString();

        // update key count
        keyLabel.text = keyString + keysLeft.ToString();

        // Game Over
        if (gameOver) {
            // GameOver UI.
            // "GameOver!"; "Score: "
        }

        // Game Clear
        if (goalReached) {
            // Calculate total score  
            addToScore(timeRemaining * 1000);

            // Cleared UI.
            // "Level Cleared!"; "Score: "
        }
    }
}
