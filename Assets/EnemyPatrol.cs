using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : StateMachineBehaviour
{
    public List<Vector3> wayPoints; // The check points where my enemy should move

    private Rigidbody2D rb;

    private Transform player;
    private Transform enemy;


    private int currentWayPoint;
    public float speed = 250;
    public float minDistance = 1;


    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        wayPoints = GetWayPoints(animator);
        rb = animator.gameObject.GetComponent<Rigidbody2D>();

        enemy = animator.transform;
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private List<Vector3> GetWayPoints(Animator animator)
    {
        return animator.gameObject.GetComponent<WayPointHolder>().wayPoints.ConvertAll(x => x.position);
    }



    //OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        var enemyPos = enemy.position;
        var target = wayPoints[currentWayPoint];
        var direction = (wayPoints[currentWayPoint] - animator.transform.position).normalized;
        //EnemyMovement.MoveEnemy(rb, target, target, speed);

        rb.velocity = direction * speed * Time.deltaTime;

        //Set the Rotation
        float rotationZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rb.SetRotation(rotationZ - 90);

        // Way Points Path
        if (Vector3.Distance(enemyPos, target) < minDistance)
        {
            currentWayPoint = (currentWayPoint + 1) % wayPoints.Count;
        }

        // Triangle points
        var right = enemy.right * 3;
        var forward = enemy.up * 8;
        var TrianglePointRight = enemyPos + forward + right;
        var TrianglePointLeft = enemyPos + forward - right;


        // Draw lines to see if its working
        Debug.DrawLine(enemyPos, TrianglePointLeft);
        Debug.DrawLine(enemyPos, TrianglePointRight);

        if (IsPointingInTriangle(enemyPos, TrianglePointLeft, TrianglePointRight, player.position))
        {
            //Debug.Log("Player Insode the Triangle");
            animator.SetBool("IsChasing", true);
        }

        // Enemy needs to detect the Player
        // This funktion checks if the point is inside the triangle 
        bool IsPointingInTriangle(Vector3 a, Vector3 b, Vector3 c, Vector3 p)
        {
            Vector3 d, e;
            float w1, w2;
            d = b - a;
            e = c - a;
            w1 = (e.x * (a.y - p.y) + e.y * (p.x - a.x)) / (d.x * e.y - d.y * e.x);
            w2 = (p.y - a.y - w1 * d.y) / e.y;
            return (w1 >= 0.0) && (w2 >= 0.0) && (w1 + w2 <= 1.0);
        }

    }


}