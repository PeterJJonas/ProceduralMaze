using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prims : GenerateMaze
{
    public override void GenerateMazeBlueprint()
    {
        int x = 2;
        int z = 2;

        mazeBlueprint[x, z] = 0;

        List<MapLocation> walls = new List<MapLocation>();
        walls.Add(new MapLocation(x + 1, z));
        walls.Add(new MapLocation(x - 1, z));
        walls.Add(new MapLocation(x, z + 1));
        walls.Add(new MapLocation(x, z - 1));

        int countLoops = 0; // Safety stop
        while (walls.Count > 0 && countLoops < 5000)
        {
            int randomWall = Random.Range(0, walls.Count);
            x = walls[randomWall].x;
            z = walls[randomWall].z;
            walls.RemoveAt(randomWall);
            if (CountSquareNeighbours(x, z) == 1)
            {
                mazeBlueprint[x, z] = 0;
                walls.Add(new MapLocation(x + 1, z));
                walls.Add(new MapLocation(x - 1, z));
                walls.Add(new MapLocation(x, z + 1));
                walls.Add(new MapLocation(x, z - 1));
            }

            countLoops++;
        }
    }
}
