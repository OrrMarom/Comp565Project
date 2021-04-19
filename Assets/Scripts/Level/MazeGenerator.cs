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

    //[SerializeField] private int wallsDestroyed = 0;

    [SerializeField] private int playerTileIndex;
    [SerializeField] private int exitTileIndex;

    public List<GameObject> walls;
    public List<GameObject> floors;
    public List<GameObject> items;


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

        // --- Create maze floor.
        GameObject Base = new GameObject("Base"); // Parent gameobject for floor tiles.

        float tilePositionX = 0.0f;
        float tilePositionY = 0.0f;
        float tilePositionZ = 0.0f;
        float floorWidth = floorDimensions.x;
        float floorHeight = floorDimensions.y;
        float floorDepth = floorDimensions.z;
        initialTilePosition = new Vector3(tilePositionX, tilePositionY, tilePositionZ);

        // Generate Prefabs.
        for (int i = 0; i < rows; i++) {
            for (int j = 0; j < cols; j++) {
                Vector3 tilePosition = new Vector3(tilePositionX, tilePositionY, tilePositionZ);
                GameObject floor = Instantiate(floors[Random.Range(0, floors.Count)], tilePosition, Quaternion.identity, Base.transform); // spawn prefab
                //floor.tag = "Generated";
                if (maze[i, j] == 1) {
                    Vector3 wallPosition = new Vector3(tilePositionX, tilePositionY + floorHeight, tilePositionZ);
                    Instantiate(walls[Random.Range(0, walls.Count)], wallPosition, Quaternion.identity, Base.transform);
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
        GameObject[] objects = GameObject.FindGameObjectsWithTag("Generated");
        foreach (GameObject obj in objects) {
            Destroy(obj);
        }
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
