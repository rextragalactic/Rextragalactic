using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyPath : MonoBehaviour
{
    private const float SPEED = 8f;

    private Enemy enemyMAin;
    public Transform[] wayPoints;
    private int currentPathIndex;
    private float waitTime;

    private Vector3 moveDir;
    private Vector3 lastMove;

    bool once;

    private void Awake()
    {
        enemyMAin = GetComponent<Enemy>();

    }



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position != wayPoints[currentPathIndex].position)
        {
            transform.position = Vector2.MoveTowards(transform.position, wayPoints[currentPathIndex].position, SPEED * Time.deltaTime);

        }
        else
        {
            if (once == false)
            {
                once = true;
                StartCoroutine(Wait());
            }

        }

    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(waitTime);
        if (currentPathIndex + 1 < wayPoints.Length)
        {
            currentPathIndex++;
        }
        else
        {
            currentPathIndex = 0;
        }
        once = false;

    }




}

