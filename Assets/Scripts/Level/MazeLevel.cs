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
    public GameObject player;
    public GameObject gameOverMenu;

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
        player = GameObject.Find("Holding the gun");
        gameOverMenu = GameObject.Find("GameOverMenu");
        gameOverMenu.SetActive(false);
        UnityEngine.Debug.Log(gameOverMenu);
        mazeGenerator = GetComponent<MazeGenerator>(); // Get component with type MazeGenerator attached to this object. 
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
        HUDController.Instance.updateAmmoG(ammo_gCount);
        HUDController.Instance.updateAmmoB(ammo_bCount);
        keysLeft = totalKeys;
        HUDController.Instance.updateKeyLabel(keysLeft);

        // Bake NavMesh
        navMesh.GetComponent<NavMeshSurface>().BuildNavMesh();

        UpdateNavMesh();
        //StartCoroutine(UpdateNavMesh());
    }

    // Continuously update navmesh in case of destroyed cubes
    // Not a permanent solution but works for a demo
    //public IEnumerator UpdateNavMesh()
    //{

    //    // Bake NavMesh
    //    navMesh.GetComponent<NavMeshSurface>().BuildNavMesh();

    //    UnityEngine.Debug.Log("baking navmesh");

    //    // Delay fade for some time
    //    yield return new WaitForSeconds(1);
    //}

    public void UpdateNavMesh()
    {

        // Bake NavMesh
        navMesh.GetComponent<NavMeshSurface>().BuildNavMesh();
        UnityEngine.Debug.Log("baking navmesh");
    }

    // --- Update methods.
    public void addToScore(int points) {
        score += points;
    }

    public void addToTime(int seconds) {
        if (timeLimit < 300) { // 5 minutes max
            timeLimit += seconds;
        }
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
        UnityEngine.Debug.Log("Gameover");
        HUDController.Instance.updateTime(0);
        timer.Stop();
        addToScore(timeRemaining * 1000);
        HUDController.Instance.updateScore(score);
        player.SetActive(false);
        GameObject.Find("MainUi").SetActive(false);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        gameOverMenu.SetActive(true);
    }

    public void GameClear() {
        HUDController.Instance.updateTime(0);
        timer.Stop();
        addToScore(timeRemaining * 3000);
        HUDController.Instance.updateScore(score);
        player.SetActive(false);
        GameObject.Find("MainUi").SetActive(false);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        gameOverMenu.SetActive(true);
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
            // TODO: call GameOver once. Disable Update? 
            GameOver();
        }
        
        // Update score.
        HUDController.Instance.updateScore(score);

        // Update ammo count.
        HUDController.Instance.updateAmmoR(ammo_rCount);
        HUDController.Instance.updateAmmoG(ammo_gCount);
        HUDController.Instance.updateAmmoB(ammo_bCount);

        // update key count
        HUDController.Instance.updateKeyLabel(keysLeft);
    }
}
