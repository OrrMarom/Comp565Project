using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// --- Create maze. 
public class MazeGenerator : MonoBehaviour
{
    // --- Variables
    public Vector3 floorDimensions;
    public Vector3 wallDimensions;
    public Vector3 initialTilePosition;
    [SerializeField] private Material floorMat;

    //[SerializeField] private int wallsDestroyed = 0;

    public List<GameObject> walls;
    public List<GameObject> floors;
    public List<GameObject> items;
    public List<GameObject> enemies;

    private Vector2Int treasureLocation;
    private Vector2Int playerLocation;
    public GameObject player;
    public GameObject treasure;
    [SerializeField] private int enemyCount;
    private int keyCount;
    
    
    public void Start() {
        // Initialize game objects
        floorDimensions = new Vector3(2.0f, 1.0f, 2.0f);
        wallDimensions = new Vector3(2.0f, 5.0f, 2.0f);
        walls = new List<GameObject>();
        floors = new List<GameObject>();
        items = new List<GameObject>();
    }

    // --- Methods 
    public void CreateNewMaze(int rows, int cols) {
        //DeleteOldMaze();

        rows = (rows % 2 == 0) ? rows + 1 : rows;
        cols = (cols % 2 == 0) ? cols + 1 : cols;
        // Initialize maze.
        int[,] maze = new int[rows, cols]; // z, x (rows, columns); 0 = no wall, 1 = wall. 

        // Generate maze.
        for (int i = 0; i < rows; i++) {
            for (int j = 0; j < cols; j++) {
                if ( i == 0 || i == rows - 1  || j == 0 || j == cols - 1 ) {
                    maze[i, j] = 1;
                } else if (i % 2 == 0 && j % 2 == 0) {
                    if ( Random.value > 0.1 ) {
                        maze[i, j] = 1;
                        var a = (Random.value < 0.5) ? 0 : (Random.value < 0.5 ? -1 : 1);
                        var b = (a != 0) ? 0 : Random.value < 0.5 ? -1 : 1;
                        maze[i + a, j + b] = 1;
                    }
                }
            }
        }

        // --- Place items and player.

        // Hashtable h = new Hashtable();
        // h.Add(playerLocation, player);

        // player
        for (int i = 1; i < rows - 1; i++) {
            for (int j = 1; j < cols - 1; j++) {
                if (maze[i, j] == 0) {
                    playerLocation = new Vector2Int(i, j);
                }
            }
        }
        // treasure
        for (int i = rows - 1; i > 0; i--) {
            for (int j = cols - 1; j > 0; j--) {
                if (maze[i, j] == 0) {
                    treasureLocation = new Vector2Int(i, j);
                }
            }
        }

        // --- Instantiate all objects
        GameObject Base = new GameObject("Base"); // Parent gameobject for floor tiles.

        // Give Base CubeRoot
        Base.AddComponent<CubeRoot>();

        float tilePositionX = 0.0f;
        float tilePositionY = 0.0f;
        float tilePositionZ = 0.0f;
        float floorWidth = floorDimensions.x;
        float floorHeight = floorDimensions.y;
        float floorDepth = floorDimensions.z;
        initialTilePosition = new Vector3(tilePositionX, tilePositionY, tilePositionZ);

        // Create single base floor. 
        // GameObject Floor = GameObject.CreatePrimitive(PrimitiveType.Cube);
        // Floor.transform.localScale = new Vector3( (float) cols * floorWidth, 1.0f, (float) rows * floorDepth);
        // Floor.transform.position = initialTilePosition;
        // if (floorMat) {
        //     Floor.GetComponent<Renderer>().material = floorMat;
        // }

        // Initialize enemies
        if (enemyCount == 0) {
            enemyCount = 5;
        }

        // Create maze.
        for (int i = 0; i < rows; i++) {
            for (int j = 0; j < cols; j++) {
                Vector3 tilePosition = new Vector3(tilePositionX, tilePositionY, tilePositionZ);
                GameObject floor = Instantiate(floors[Random.Range(0, floors.Count)], tilePosition, Quaternion.identity, Base.transform); // spawn prefab
                //floor.tag = "Generated";
                floor.tag = "Ground";
                if (maze[i, j] == 1) {
                    Vector3 wallPosition = new Vector3(tilePositionX, tilePositionY + floorHeight, tilePositionZ);
                    GameObject wall = Instantiate(walls[Random.Range(0, walls.Count)], wallPosition, Quaternion.identity, Base.transform);
                }

                // Instantiate entities and items.
                Vector3 spawnPosition = new Vector3(tilePositionX, tilePositionY + 1.0f, tilePositionZ);
                if (maze[i, j] == 0) {
                    if (i == playerLocation.x && j == playerLocation.y) {
                        //Instantiate(player, spawnPosition, Quaternion.identity);
                        player.transform.position = spawnPosition;
                    } else if (i == treasureLocation.x && j == treasureLocation.y) {
                        Instantiate(treasure, spawnPosition, Quaternion.identity);
                    } else {
                        if (Random.value > 0.6) {
                            Instantiate(items[Random.Range(0, items.Count)], spawnPosition, Quaternion.identity);
                        } else if (enemyCount > 0){
                            Instantiate(enemies[Random.Range(0, enemies.Count)], spawnPosition, Quaternion.identity);
                            enemyCount--;
                        }
                    }
                }

                tilePositionZ += floorDepth;
            }
            tilePositionZ = initialTilePosition.z; // reset z position.
            tilePositionX += floorWidth;
        }

        // --- Destroy random walls.
        // int randomWallIndex = Random.Range(0, cols * rows - 1);
        // for (int i = 0; i < wallsDestroyed; i++) {
        //     // TODO:
        //     while (randomWallIndex != playerTileIndex && randomWallIndex != exitTileIndex) {
        //         randomWallIndex = Random.Range(0, cols * rows - 1);
        //     }
        // }
    } // CreateNewMaze

    // Combine floortiles into one mesh to reduce number of draw calls.
    private void combineFloorMesh() {

    }

    private void DeleteOldMaze() {
        // GameObject[] floorTiles = GameObject.FindGameObjectsWithTag("Floor");
        // foreach (GameObject obj in floorTiles) {
        //     Destroy(obj);
        // }
        // GameObject[] wallTiles = GameObject.FindGameObjectsWithTag("Wall");
        // foreach (GameObject obj in wallTiles) {
        //     Destroy(obj);
        // }
        //Destroy(Maze);
    }

    void pickStartingPosition() {

    }

    void pickGoalPosition() {

    }

    void pickKeysPosition() {

    }

    // private int randomFloorTile() {
    //     return 0;
    // }

    // private int randomWall() {
    //     return 0;
    // }

    // private int randomItem() {
    //     return 0;
    // }
}
