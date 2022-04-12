using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;


public class Enemy_AI : MonoBehaviour
{
    private EnemyPathfindingMovement pathfindinMovement;

    private Vector3 startingPos;
    private Vector3 roamPosition;


    private void Awake()
    {
        pathfindinMovement = GetComponent<EnemyPathfindingMovement>();
    }


    // Start is called before the first frame update
    void Start()
    {
        startingPos = transform.position;
        roamPosition = GetRoamingPosition();
    }

    // Update is called once per frame
    void Update()
    {
        pathfindinMovement.MoveTo(roamPosition);

        float reachedPositionDistance = 1f;
        if (Vector3.Distance(transform.position, roamPosition) < reachedPositionDistance)
        {
            // Reached Roam Position
            roamPosition = GetRoamingPosition(); // New roam position
        }
    }

    private Vector3 GetRoamingPosition()
    {
        return startingPos + UtilsClass.GetRandomDir() * Random.Range(10f, 70f) ;
    }
}
