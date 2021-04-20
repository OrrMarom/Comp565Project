using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class VoxelData
{

    public static readonly int ChunkWidth = 10;
    public static readonly int ChunkHeight = 10;
    public static readonly int WorldSizeInChunks = 5;

    public static int WorldSizeInVoxels
    {
        get { return WorldSizeInChunks * ChunkWidth; }
    }

    public static readonly int ViewDistanceInChunks = 5;

    public static readonly int TextureAtlasSizeInBlocks = 4;

    public static float NormalizedBlockTextureSize
    {
        get { return 1f / (float)TextureAtlasSizeInBlocks; }
    }

    public static readonly Vector3[] voxelVerts = new Vector3[8] 
    {
        new Vector3(0.0f, 0.0f, 0.0f), // 0
        new Vector3(1.0f, 0.0f, 0.0f), // 1
        new Vector3(1.0f, 1.0f, 0.0f), // 2
        new Vector3(0.0f, 1.0f, 0.0f), // 3
        new Vector3(0.0f, 0.0f, 1.0f), // 4
        new Vector3(1.0f, 0.0f, 1.0f), // 5
        new Vector3(1.0f, 1.0f, 1.0f), // 6
        new Vector3(0.0f, 1.0f, 1.0f)  // 7
    };

    public static readonly Vector3[] faceChecks = new Vector3[6]
    {
        new Vector3(0.0f, 0.0f, -1.0f), // Back        
        new Vector3(0.0f, 0.0f, 1.0f), // Front
        new Vector3(0.0f, 1.0f, 0.0f), // Top
        new Vector3(0.0f, -1.0f, 0.0f), // Bottom
        new Vector3(-1.0f, 0.0f, 0.0f), // Left
        new Vector3(1.0f, 0.0f, 0.0f) // Right


    };

    public static readonly int[,] voxelTris = new int[6, 4]
    {
        // Only need 4 verts to make up triangle
        // True vert sequence to make each triangle shown below
        {0, 3, 1, 2}, // Front  {0, 3, 1, 1, 3, 2}
        {5, 6, 4, 7}, // Back   {5, 6, 4, 4, 6, 7}
        {3, 7, 2, 6}, // Top    {3, 7, 2, 2, 7, 6}
        {1, 5, 0, 4}, // Bottom {1, 5, 0, 0, 5, 4}
        {4, 7, 0, 3}, // Left   {4, 7, 0, 0, 7, 3}
        {1, 2, 5, 6}  // Right  {1, 2, 5, 5, 2, 6} 
    };

    public static readonly Vector2[] voxelUVs = new Vector2[4]
    {
        // Also only need 4 UVs, same as above
        new Vector2(0.0f, 0.0f),
        new Vector2(0.0f, 1.0f),
        new Vector2(1.0f, 0.0f),
        //new Vector2(1.0f, 0.0f),
        //new Vector2(0.0f, 1.0f),
        new Vector2(1.0f, 1.0f)
    };
}
