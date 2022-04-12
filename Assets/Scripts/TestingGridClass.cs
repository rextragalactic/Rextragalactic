using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;
using CodeMonkey;


public class TestingGridClass : MonoBehaviour
{
    private EnemyPathfinding pathfinding;

    private void Start()
    {
        EnemyPathfinding pathfinding = new EnemyPathfinding(10, 10);
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Vector3 mouseWorlPosition = UtilsClass.GetMouseWorldPosition();
            pathfinding.GetGrid().GetXY(mouseWorlPosition, out int x, out int y);
            List<PathNode> path = pathfinding.FindPath(0, 0, x, y);
            if(path != null)
            {
                /*for(int i = 0, i <path.Count - 1; i++)
                {
                    Debug.DrawLine(new Vector3(pathNode.x, pathNode.y) * 10f + Vector3.one * 5f, new Vector3(pathNode.x, pathNode.y) * 10f + Vector3.one * 5f);
                }*/
            }

        }
    }
}
