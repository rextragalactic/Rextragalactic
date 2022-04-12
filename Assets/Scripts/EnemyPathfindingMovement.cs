using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathfindingMovement : MonoBehaviour
{
    private const float SPEED = 30f;

    private Enemy enemyMain;
    //public Transform[] pathVectorList;
    private List<Vector3> pathVectorList;
    private int currentPathIndex;
    private float pathfindingTimer;
    private Vector3 moveDirection;
    private Vector3 lastMoveDirection;

    private void Awake()
    {
        
        enemyMain = GetComponent<Enemy>();
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        pathfindingTimer -= Time.deltaTime;
        HandleMovement();
    }

    private void FixedUpdate()
    {
        enemyMain.EnemyRigidbody2D.velocity = moveDirection * SPEED;
        
    }

    private void HandleMovement()
    {
        PrintPathfindingPath();
        if(pathVectorList != null)
        {
            Vector3 targetPosition = pathVectorList[currentPathIndex];
        }
    }

    private void PrintPathfindingPath()
    {
        if(pathVectorList != null)
        {
            for (int i = 0; i < pathVectorList.Count - 1; i++)
            {
                Debug.DrawLine(pathVectorList[i], pathVectorList[i + 1]);
            }
        }
    }

    public void MoveTo(Vector3 targetPosition)
    {
        SetTargetPosition(targetPosition);
    }

    public void MoveToTimer(Vector3 targetPosition)
    {
        if(pathfindingTimer <= 0f)
        {
            SetTargetPosition(targetPosition);
        }
            
    }

    private void SetTargetPosition(Vector3 targetPosition)
    {
        currentPathIndex = 0;

        
    }
}
