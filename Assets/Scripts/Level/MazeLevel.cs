using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using System.Diagnostics;
using System;

// --- Controller for the maze level.

[RequireComponent(typeof(MazeGenerator))] 
public class MazeLevel : MonoBehaviour
{
    // Singleton
    private static MazeLevel levelInstance;
    public static MazeLevel Instance { get { return levelInstance; } }

    // Level item variables.
    private int ammo_rCount = 0;
    private int ammo_gCount = 0;
    private int ammo_bCount = 0;
    private int keysLeft;
    private const string keyString = "Keys Left: ";
    [SerializeField] private int totalKeys = 3; // Total keys needed to collect treasure. 

    // Other level vars.
    [SerializeField] private int rows;
    [SerializeField] private int cols;

    [SerializeField] private int timeLimit; // seconds

    private Stopwatch timer;
    private int timeRemaining;

    private int score = 0;
    private bool gameOver = false;

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
        HUDController.Instance.updateTime(timeRemaining);
        timer = new Stopwatch();
        timer.Start();

        // Initialize score.
        score = 0;
        HUDController.Instance.updateScore(score); // Update HUD

        // Initialize items.
        HUDController.Instance.updateAmmoR(ammo_rCount);
        HUDController.Instance.updateAmmoR(ammo_gCount);
        HUDController.Instance.updateAmmoR(ammo_bCount);
        keysLeft = totalKeys;
        HUDController.Instance.updateKeyLabel(keysLeft);

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
    public int getScore() {
        return score;
    }

    public int getKeyCount() {
        return keysLeft;
    }

    public void GameOver() {
        HUDController.Instance.updateTime(0);
        timer.Stop();
        addToScore(timeRemaining * 2000);
        HUDController.Instance.updateScore(score);
        // pause game
        //Time.timeScale = 0; //unpause: Time.timeScale = 1;
        // activate Game Over UI.
        // play Game Over music
    }

    public void GameClear() {
        HUDController.Instance.updateTime(0);
        timer.Stop();
        addToScore(timeRemaining * 3000);
        HUDController.Instance.updateScore(score);
        // pause game
        // activate Game Over UI.
        // play Game Clear music
    }

    // Update is called once per frame
    void Update()
    {
        // Update timer.
        TimeSpan timeElapsed = timer.Elapsed;
        timeRemaining = (timeLimit - timeElapsed.Seconds);
        if (timeRemaining > 0) {
            HUDController.Instance.updateTime(timeRemaining); // update timeLabel
        } else {
            GameOver();
        }
        
        // Update score.
        HUDController.Instance.updateScore(score);

        // Update ammo count.
        HUDController.Instance.updateAmmoR(ammo_rCount);
        HUDController.Instance.updateAmmoR(ammo_gCount);
        HUDController.Instance.updateAmmoR(ammo_bCount);

        // update key count
        HUDController.Instance.updateKeyLabel(keysLeft);
    }
}
