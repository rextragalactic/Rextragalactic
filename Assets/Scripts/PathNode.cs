using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathNode //Grid Object 
{
    // Constructor
    private Grid <PathNode> grid;
    public int x;
    public int y;

    // Values to calculate
    public int gCost;
    public int hCost;
    public int fCost;

    public bool isWalkable;

    public PathNode cameFromNode;

    public PathNode(Grid <PathNode> grid, int x, int y)
    {
        this.grid = grid;
        this.x = x;
        this.y = y;
        isWalkable = true;
    }

 

    public void CalculateFCost()
    {
        fCost = gCost + hCost;
    }

    public override string ToString()
    {
        return x + "," + y;
    }

    
}
