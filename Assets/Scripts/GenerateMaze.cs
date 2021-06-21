using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class MapLocation
{
    public int x;
    public int z;

    public MapLocation(int _x, int _z)
    {
        x = _x;
        z = _z;
    }
}

public class GenerateMaze : MonoBehaviour
{
    public int mazeDepth;
    public int mazeWidth;
    public byte[,] mazeBlueprint;
    public int scale;

    // Start is called before the first frame update
    void Start()
    {
        InitializeMap();
        GenerateMazeBlueprint();
        DrawMap();
    }

    void InitializeMap()
    {
        mazeBlueprint = new byte[mazeWidth, mazeDepth];
        for (int z = 0; z < mazeDepth; z++)
            for (int x = 0; x < mazeWidth; x++)
            {
                mazeBlueprint[x, z] = 1;
            }
    }

    public virtual void GenerateMazeBlueprint()
    {
        for (int z = 0; z < mazeDepth; z++)
            for (int x = 0; x < mazeWidth; x++)
            {
                if (Random.Range(0, 100) < 50)
                {
                    mazeBlueprint[x, z] = 0;
                }
            }
    }


    void DrawMap()
    {
        for (int z = 0; z < mazeDepth; z++)
            for (int x = 0; x < mazeWidth; x++)
            {
                if (mazeBlueprint[x, z] == 1)
                {
                    Vector3 wallPosition = new Vector3(x * scale, 0, z * scale);
                    GameObject mazeWall = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    mazeWall.transform.localScale = new Vector3(scale, scale, scale);
                    mazeWall.transform.position = wallPosition;
                }
            }
    }

    public int CountSquareNeighbours(int x, int z)
    {
        int count = 0;
        if (x <= 0 || x >= mazeWidth - 1 || z <= 0 || z >= mazeDepth - 1) return 5;
        if (mazeBlueprint[x - 1, z] == 0) count++;
        if (mazeBlueprint[x + 1, z] == 0) count++;
        if (mazeBlueprint[x, z - 1] == 0) count++;
        if (mazeBlueprint[x, z + 1] == 0) count++;
        return count;
    }

    public int CountDiagonalNeighbours(int x, int z)
    {
        int count = 0;
        if (x <= 0 || x >= mazeWidth - 1 || z <= 0 || z >= mazeDepth - 1) return 5;
        if (mazeBlueprint[x - 1, z - 1] == 0) count++;
        if (mazeBlueprint[x + 1, z + 1] == 0) count++;
        if (mazeBlueprint[x - 1, z + 1] == 0) count++;
        if (mazeBlueprint[x + 1, z - 1] == 0) count++;
        return count;
    }

    public int CountAllNeighbours(int x, int z)
    {
        return CountSquareNeighbours(x, z) + CountDiagonalNeighbours(x, z);
    }
}
