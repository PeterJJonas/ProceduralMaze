using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeCrawler : GenerateMaze
{
    public override void GenerateMazeBlueprint()
    {
        bool isCrawlingDone = false;
        int widthStartPoint = Random.Range(1, mazeWidth);
        int depthStartPoint = 1;

        while (!isCrawlingDone)
        {
            mazeBlueprint[widthStartPoint, depthStartPoint] = 0;
            if (Random.Range(0, 100) < 50)
                widthStartPoint += Random.Range(-1, 2);
            else
                depthStartPoint += Random.Range(0, 2);
            isCrawlingDone |= (widthStartPoint < 1 || widthStartPoint >= mazeWidth - 1 || depthStartPoint < 1 || depthStartPoint >= mazeDepth - 1);
            //Same as:
            //if (x < 0 || x >= mazeWidth || z < 0 || z >= mazeDepth)
            //    isCrawlingIsDone = true;
            //else
            //    isCrawlingIsDone = false;
        }
    }
}
